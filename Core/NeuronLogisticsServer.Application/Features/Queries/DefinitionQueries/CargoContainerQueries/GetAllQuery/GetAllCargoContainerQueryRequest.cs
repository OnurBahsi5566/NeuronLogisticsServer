using MediatR;
using NeuronLogisticsServer.Application.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Queries.DefinitionQueries.CargoContainerQueries.GetAllQuery
{
    public class GetAllCargoContainerQueryRequest : IRequest<GetAllCargoContainerQueryResponse>
    {
        //public Pagination Pagination { get; set; }

        public int Page { get; set; } = 0;

        public int Size { get; set; } = 5;
    }
}
