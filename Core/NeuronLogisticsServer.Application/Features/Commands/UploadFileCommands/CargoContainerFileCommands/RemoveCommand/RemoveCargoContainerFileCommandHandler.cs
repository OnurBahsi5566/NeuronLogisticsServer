using MediatR;
using Microsoft.EntityFrameworkCore;
using NeuronLogisticsServer.Application.Repositories.ReadRepositories.Definitions;
using NeuronLogisticsServer.Application.Repositories.WriteRepositories.Definitions;
using NeuronLogisticsServer.Domain.Entities.Definitions;
using NeuronLogisticsServer.Domain.Entities.UploadFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Commands.UploadFileCommands.CargoContainerFileCommands.RemoveCommand
{
    public class RemoveCargoContainerFileCommandHandler : IRequestHandler<RemoveCargoContainerFileCommandRequest, RemoveCargoContainerFileCommandResponse>
    {
        ICargoContainerReadRepository _cargoContainerReadRepository;
        ICargoContainerWriteRepository _cargoContainerWriteRepository;

        public RemoveCargoContainerFileCommandHandler(ICargoContainerReadRepository cargoContainerReadRepository, ICargoContainerWriteRepository cargoContainerWriteRepository)
        {
            _cargoContainerReadRepository = cargoContainerReadRepository;
            _cargoContainerWriteRepository = cargoContainerWriteRepository;
        }


        public async Task<RemoveCargoContainerFileCommandResponse> Handle(RemoveCargoContainerFileCommandRequest request, CancellationToken cancellationToken)
        {

            CargoContainer? cargoContainer = await _cargoContainerReadRepository.Table.Include(c => c.CargoContainerFiles)
                                                            .FirstOrDefaultAsync(c => c.Id ==
                                                            Guid.Parse(request.CargoContainerId));

            CargoContainerFile? cargoContainerFile = cargoContainer?.CargoContainerFiles
                                                            .FirstOrDefault(c => c.Id == Guid.Parse(request.CargoContainerFileId));

            if (cargoContainerFile != null)
                cargoContainer?.CargoContainerFiles.Remove(cargoContainerFile);
            
            await _cargoContainerWriteRepository.SaveAsync();

            return new();
        }
    }
}
