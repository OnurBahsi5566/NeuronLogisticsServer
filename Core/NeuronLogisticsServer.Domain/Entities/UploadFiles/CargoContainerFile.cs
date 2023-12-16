using NeuronLogisticsServer.Domain.Entities.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Domain.Entities.UploadFiles
{
    public class CargoContainerFile : UploadFile
    {
        public ICollection<CargoContainer> CargoContainers { get; set; }
    }
}
