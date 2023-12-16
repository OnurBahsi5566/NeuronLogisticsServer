
namespace NeuronLogisticsServer.Application.Abstractions.Storages
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get; }
    }
}
