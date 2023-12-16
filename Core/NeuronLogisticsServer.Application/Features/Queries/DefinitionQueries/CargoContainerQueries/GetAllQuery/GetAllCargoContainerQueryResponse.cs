using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Queries.DefinitionQueries.CargoContainerQueries.GetAllQuery
{
    public class GetAllCargoContainerQueryResponse
    {
        public int TotalCount { get; set; }

        public object CargoContainers { get; set; }
    }
}