using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NeuronLogisticsServer.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Persistence
{
    //powershell den migration oluşturmak için yapılan sınıf
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<NeuronLogisticsServerDbContext>
    {
        public NeuronLogisticsServerDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<NeuronLogisticsServerDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}