using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NeuronLogisticsServer.Application.Abstractions.Services;
using NeuronLogisticsServer.Application.Repositories.ReadRepositories.Definitions;
using NeuronLogisticsServer.Application.Repositories.ReadRepositories.UploadFiles;
using NeuronLogisticsServer.Application.Repositories.WriteRepositories.Definitions;
using NeuronLogisticsServer.Application.Repositories.WriteRepositories.UploadFiles;
using NeuronLogisticsServer.Domain.Entities.Identity;
using NeuronLogisticsServer.Persistence.Contexts;
using NeuronLogisticsServer.Persistence.Repositories.ReadRepositories.Definitions;
using NeuronLogisticsServer.Persistence.Repositories.ReadRepositories.UploadFiles;
using NeuronLogisticsServer.Persistence.Repositories.WriteRepositories.Definitions;
using NeuronLogisticsServer.Persistence.Repositories.WriteRepositories.UploadFiles;
using NeuronLogisticsServer.Persistence.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Persistence
{
    //program.cs te ayağa kaldırılacak servis collectionları bu çatıda toplar.
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<NeuronLogisticsServerDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<NeuronLogisticsServerDbContext>();

            #region Definitions
            services.AddScoped<ICargoContainerReadRepository,CargoContainerReadRepository>();
            services.AddScoped<ICargoContainerWriteRepository, CargoContainerWriteRepository>();
            services.AddScoped<IVesselReadRepository, VesselReadRepository>();
            services.AddScoped<IVesselWriteRepository, VesselWriteRepository>();
            services.AddScoped<IVoyageReadRepository, VoyageReadRepository>();
            services.AddScoped<IVoyageWriteRepository, VoyageWriteRepository>();
            #endregion

            #region UploadFiles
            services.AddScoped<IUploadFileReadRepository, UploadFileReadRepository>();
            services.AddScoped<IUploadFileWriteRepository, UploadFileWriteRepository>();
            services.AddScoped<ICargoContainerFileReadRepository, CargoContainerFileReadRepository>();
            services.AddScoped<ICargoContainerFileWriteRepository, CargoContainerFileWriteRepository>();
            services.AddScoped<IOperationFileReadRepository, OperationFileReadRepository>();
            services.AddScoped<IOperationFileWriteRepository, OperationFileWriteRepository>();
            services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
            #endregion

            #region Users
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAuthService, AuthService>();
            #endregion
        }
    }
}