using Microsoft.AspNetCore.Http;

namespace NeuronLogisticsServer.Application.Abstractions.Storages
{
    //bulut tabanlı sistemlerde path adları containerName diye tutulduğundan pathOrCantainerName dedik.
    public interface IStorage
    {
        Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);

        Task DeleteAsync(string pathOrContainerName, string fileName);

        List<string> GetFiles(string pathOrContainerName);

        bool HasFile(string pathOrContainerName, string fileName);
    }
}
