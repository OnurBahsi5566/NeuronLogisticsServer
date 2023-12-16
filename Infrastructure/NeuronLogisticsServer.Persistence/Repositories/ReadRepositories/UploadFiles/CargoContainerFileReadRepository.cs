using NeuronLogisticsServer.Application.Repositories.ReadRepositories.UploadFiles;
using NeuronLogisticsServer.Domain.Entities.UploadFiles;
using NeuronLogisticsServer.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Persistence.Repositories.ReadRepositories.UploadFiles
{
    internal class CargoContainerFileReadRepository : ReadRepository<CargoContainerFile>, ICargoContainerFileReadRepository
    {
        public CargoContainerFileReadRepository(NeuronLogisticsServerDbContext context) : base(context)
        {
        }
    }
}
