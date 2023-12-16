using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Queries.UploadFileQueries.CargoContainerFileQueries.GetByCargoContainerId
{
    public class GetByCargoCanteinerIdCargoCaontainerFileQueryResponse
    {
        public string FileName { get; set; }

        public string Path { get; set; }

        public Guid Id { get; set; }
    }
}