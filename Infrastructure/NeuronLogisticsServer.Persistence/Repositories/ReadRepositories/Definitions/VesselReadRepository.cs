using NeuronLogisticsServer.Application.Repositories.ReadRepositories.Definitions;
using NeuronLogisticsServer.Domain.Entities.Definitions;
using NeuronLogisticsServer.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Persistence.Repositories.ReadRepositories.Definitions
{
    public class VesselReadRepository : ReadRepository<Vessel>, IVesselReadRepository
    {
        public VesselReadRepository(NeuronLogisticsServerDbContext context) : base(context)
        {
        }
    }
}
