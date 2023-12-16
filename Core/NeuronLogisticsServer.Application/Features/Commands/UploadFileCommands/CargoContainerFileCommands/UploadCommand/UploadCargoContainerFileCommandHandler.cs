using MediatR;
using NeuronLogisticsServer.Application.Abstractions.Storages;
using NeuronLogisticsServer.Application.Repositories.ReadRepositories.Definitions;
using NeuronLogisticsServer.Application.Repositories.WriteRepositories.Definitions;
using NeuronLogisticsServer.Application.Repositories.WriteRepositories.UploadFiles;
using NeuronLogisticsServer.Domain.Entities.Definitions;
using NeuronLogisticsServer.Domain.Entities.UploadFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Commands.UploadFilesCommands.CargoContainerFileCommands.UploadCommand
{
    public class UploadCargoContainerFileCommandHandler : IRequestHandler<UploadCargoContainerFileCommandRequest, UploadCargoContainerFileCommandResponse>
    {
        private readonly ICargoContainerReadRepository _cargoContainerReadRepository;
        private readonly ICargoContainerFileWriteRepository _cargoContainerFileWriteRepository;
        private readonly ICargoContainerWriteRepository _cargoContainerWriteRepository;
        private readonly IStorageService _storageService;

        public UploadCargoContainerFileCommandHandler(ICargoContainerReadRepository cargoContainerReadRepository, ICargoContainerFileWriteRepository cargoContainerFileWriteRepository, ICargoContainerWriteRepository cargoContainerWriteRepository, IStorageService storageService)
        {
            _cargoContainerReadRepository = cargoContainerReadRepository;
            _cargoContainerFileWriteRepository = cargoContainerFileWriteRepository;
            _cargoContainerWriteRepository = cargoContainerWriteRepository;
            _storageService = storageService;
        }

        public async Task<UploadCargoContainerFileCommandResponse> Handle(UploadCargoContainerFileCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("documents", request.Files);

            CargoContainer cargoContainer = await _cargoContainerReadRepository.GetByIdAsync(request.Id);

            await _cargoContainerFileWriteRepository.AddRangeAsync(result.Select(r => new CargoContainerFile()
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                CargoContainers = new List<CargoContainer>() { cargoContainer }
            }).ToList());
            await _cargoContainerWriteRepository.SaveAsync();
            return new();
        }
    }
}
