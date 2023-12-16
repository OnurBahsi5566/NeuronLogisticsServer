using MediatR;
using NeuronLogisticsServer.Application.Repositories.WriteRepositories.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Commands.DefinitionCommands.CargoContainerCommands.RemoveCommand
{
    public class RemoveCargoContainerCommandHandler : IRequestHandler<RemoveCargoContainerCommandRequest, RemoveCargoContainerCommandResponse>
    {
        private readonly ICargoContainerWriteRepository _cargoContainerWriteRepository;

        public RemoveCargoContainerCommandHandler(ICargoContainerWriteRepository cargoContainerWriteRepository)
        {
            _cargoContainerWriteRepository = cargoContainerWriteRepository;
        }

        public async Task<RemoveCargoContainerCommandResponse> Handle(RemoveCargoContainerCommandRequest request, CancellationToken cancellationToken)
        {
            await _cargoContainerWriteRepository.RemoveAsync(request.Id);
            await _cargoContainerWriteRepository.SaveAsync();

            return new();
        }
    }
}
