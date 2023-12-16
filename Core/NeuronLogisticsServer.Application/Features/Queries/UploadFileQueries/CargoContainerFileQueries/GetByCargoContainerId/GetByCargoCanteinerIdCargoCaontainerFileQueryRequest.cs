using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Queries.UploadFileQueries.CargoContainerFileQueries.GetByCargoContainerId
{
    public class GetByCargoCanteinerIdCargoCaontainerFileQueryRequest : IRequest<List<GetByCargoCanteinerIdCargoCaontainerFileQueryResponse>>
    {
        public string Id { get; set; }
    }
}