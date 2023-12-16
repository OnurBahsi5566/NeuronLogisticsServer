using NeuronLogisticsServer.Application.Repositories.WriteRepositories.Definitions;
using NeuronLogisticsServer.Domain.Entities.Definitions;
using NeuronLogisticsServer.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Persistence.Repositories.WriteRepositories.Definitions
{
    public class CargoContainerWriteRepository : WriteRepository<CargoContainer>, ICargoContainerWriteRepository
    {
        public CargoContainerWriteRepository(NeuronLogisticsServerDbContext context) : base(context)
        {
        }
    }
}