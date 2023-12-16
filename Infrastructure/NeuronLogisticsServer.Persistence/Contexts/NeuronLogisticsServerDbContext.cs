using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NeuronLogisticsServer.Domain.Entities.Common;
using NeuronLogisticsServer.Domain.Entities.Definitions;
using NeuronLogisticsServer.Domain.Entities.Identity;
using NeuronLogisticsServer.Domain.Entities.UploadFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Persistence.Contexts
{
    public class NeuronLogisticsServerDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public NeuronLogisticsServerDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CargoContainer> CargoContainers { get; set; }

        public DbSet<Vessel> Vessels { get; set; }

        public DbSet<Voyage> Voyages { get; set; }

        public DbSet<UploadFile> UploadFiles { get; set; }

        public DbSet<InvoiceFile> InvoiceFiles { get; set; }

        public DbSet<OperationFile> OperationFiles { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            #region Tüm entitylerde ortak değişiklikler
            //ChangeTracker entitiy üzerinde yapılan değişiklikleri yakalar.


            var datas = ChangeTracker.Entries<BaseEntity>(); //tip base entitiy olarak giren tüm modelleri yakala

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            #endregion

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}