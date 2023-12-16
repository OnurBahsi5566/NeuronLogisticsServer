using NeuronLogisticsServer.Domain.Entities.Common;
using NeuronLogisticsServer.Domain.Entities.UploadFiles;

namespace NeuronLogisticsServer.Domain.Entities.Definitions
{
    public class CargoContainer : BaseEntity
    {
        public string Name { get; set; }

        public double Teu { get; set; }

        public Guid VesselId { get; set; }

        public Vessel Vessel { get; set; }
       
        public ICollection<CargoContainerFile> CargoContainerFiles { get; set; }
    }
}