using NeuronLogisticsServer.Application.Repositories.WriteRepositories.UploadFiles;
using NeuronLogisticsServer.Domain.Entities.UploadFiles;
using NeuronLogisticsServer.Persistence.Contexts;


namespace NeuronLogisticsServer.Persistence.Repositories.WriteRepositories.UploadFiles
{
    internal class CargoContainerFileWriteRepository : WriteRepository<CargoContainerFile>, ICargoContainerFileWriteRepository
    {
        public CargoContainerFileWriteRepository(NeuronLogisticsServerDbContext context) : base(context)
        {
        }
    }
}
