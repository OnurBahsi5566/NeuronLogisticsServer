using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Queries.DefinitionQueries.CargoContainerQueries.GetByIdQuery
{
    public class GetByIdCargoContainerQueryResponse
    {
        public string Name { get; set; }

        public double Teu { get; set; }

        public Guid VesselId { get; set; }
    }
}
