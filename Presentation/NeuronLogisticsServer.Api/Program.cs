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


//local dosya yap�s� kullan�yor ne istersek ona �evirebiliriz.
//builder.Services.AddStroage<LocalStorage>();
builder.Services.AddStroage<AzureStorage>();
// a�a��dakindeki gibide method yapt�k kullan�labilir.
//builder.Services.AddStroage(NeuronLogisticsServer.Infrastructure.Enums.StorageType.Local);

//api ye gelecek olan iste�i k�s�tlama i�lemi.Sadece buradan istek alabilir demek.
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

//CreateCargoContainerValidator sadece bunu vermemeizin sebebi 1 tanesini bile versen di�erlerini
//vermene gerek yok art�k t�m validator lar� alg�layacakt�r.
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
                        //olu�turulacak token � hangi originler/siteler kullanacaksa do�rula �rn:www.neuronlogistics.com
                        ValidateAudience = true,
                        //olu�turulacak token � kimin da��tt���n� do�rula �rn: www.neuronlogisticsApi.com
                        ValidateIssuer = true,
                        //olu�turulacak token �n s�resini do�rula
                        ValidateLifetime = true,
                        //olu�turulack token�n bu uygulamaya ait oldu�unu do�rula
                        ValidateIssuerSigningKey = true,

                        //bunlara de�er atamas� yapal�m
                        ValidAudience = builder.Configuration["Token:Audience"],
                        ValidIssuer = builder.Configuration["Token:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
                        LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => 
                        expires != null ? expires > DateTime.UtcNow : false,

                        NameClaimType = ClaimTypes.Name // JWT �zerinde name claimine kar��l�k gelen de�eri
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

app.UseSerilogRequestLogging(); //bunun alt�ndaki methodlar� loglar �st�ndekileri loglamaz.
app.UseHttpLogging();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication(); //�emay� kurduktan sonra ekledik.
app.UseAuthorization();

app.Use(async (context, next) =>
{
    var userName = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
    LogContext.PushProperty("user_name", userName);
    await next();
});

app.MapControllers();

app.Run();
