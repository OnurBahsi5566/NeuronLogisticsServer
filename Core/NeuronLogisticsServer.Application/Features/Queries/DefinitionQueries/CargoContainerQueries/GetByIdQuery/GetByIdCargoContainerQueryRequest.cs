using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Queries.DefinitionQueries.CargoContainerQueries.GetByIdQuery
{
    public class GetByIdCargoContainerQueryRequest : IRequest<GetByIdCargoContainerQueryResponse>
    {
        public string Id { get; set; }
    }
}
