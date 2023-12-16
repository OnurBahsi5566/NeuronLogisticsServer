using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.IdentityModel.Tokens;
using NeuronLogisticsServer.Api.Configurations.ColumnWriters;
using NeuronLogisticsServer.Application;
using NeuronLogisticsServer.Application.Validators.Definitions;
using NeuronLogisticsServer.Infrastructure;
using NeuronLogisticsServer.Infrastructure.Filters;
using NeuronLogisticsServer.Infrastructure.Services.Storages.Azure;
using NeuronLogisticsServer.Infrastructure.Services.Storages.Local;
using NeuronLogisticsServer.Persistence;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();


//local dosya yapýsý kullanýyor ne istersek ona çevirebiliriz.
//builder.Services.AddStroage<LocalStorage>();
builder.Services.AddStroage<AzureStorage>();
// aþaðýdakindeki gibide method yaptýk kullanýlabilir.
//builder.Services.AddStroage(NeuronLogisticsServer.Infrastructure.Enums.StorageType.Local);

//api ye gelecek olan isteði kýsýtlama iþlemi.Sadece buradan istek alabilir demek.
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()
));

Logger log = new LoggerConfiguration()
                 .WriteTo.Console()
                 .WriteTo.File("neuron-logistics-logs/log.txt")
                 .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("PostgreSQL"),"logs",
                    needAutoCreateTable: true,
                    columnOptions: new Dictionary<string, ColumnWriterBase>
                    {
                        { "message", new RenderedMessageColumnWriter() },
                        { "message_template", new MessageTemplateColumnWriter() },
                        { "level", new LevelColumnWriter() },
                        { "time_stamp", new TimestampColumnWriter() },
                        { "exception", new ExceptionColumnWriter() },
                        { "log_event", new LogEventSerializedColumnWriter() },
                        { "user_name", new UserNameColumnWriter() },
                    })
                 .WriteTo.Seq(builder.Configuration["Seq:ServerURL"])
                 .Enrich.FromLogContext()
                 .MinimumLevel.Information()
                 .CreateLogger();

builder.Host.UseSerilog(log);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

//CreateCargoContainerValidator sadece bunu vermemeizin sebebi 1 tanesini bile versen diðerlerini
//vermene gerek yok artýk tüm validator larý algýlayacaktýr.
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateCargoContainerValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//jwt Authentication servisi
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Admin",options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        //oluþturulacak token ý hangi originler/siteler kullanacaksa doðrula örn:www.neuronlogistics.com
                        ValidateAudience = true,
                        //oluþturulacak token ý kimin daðýttýðýný doðrula örn: www.neuronlogisticsApi.com
                        ValidateIssuer = true,
                        //oluþturulacak token ýn süresini doðrula
                        ValidateLifetime = true,
                        //oluþturulack tokenýn bu uygulamaya ait olduðunu doðrula
                        ValidateIssuerSigningKey = true,

                        //bunlara deðer atamasý yapalým
                        ValidAudience = builder.Configuration["Token:Audience"],
                        ValidIssuer = builder.Configuration["Token:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
                        LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => 
                        expires != null ? expires > DateTime.UtcNow : false,

                        NameClaimType = ClaimTypes.Name // JWT üzerinde name claimine karþýlýk gelen deðeri
                        // "User.Identity.Name" propertisinden elde edebiliriz. 
                    };
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseSerilogRequestLogging(); //bunun altýndaki methodlarý loglar üstündekileri loglamaz.
app.UseHttpLogging();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication(); //þemayý kurduktan sonra ekledik.
app.UseAuthorization();

app.Use(async (context, next) =>
{
    var userName = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
    LogContext.PushProperty("user_name", userName);
    await next();
});

app.MapControllers();

app.Run();
