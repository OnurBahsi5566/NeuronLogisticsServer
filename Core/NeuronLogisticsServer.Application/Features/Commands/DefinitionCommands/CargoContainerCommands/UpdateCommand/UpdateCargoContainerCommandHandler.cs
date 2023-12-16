using MediatR;
using NeuronLogisticsServer.Application.Repositories.ReadRepositories.Definitions;
using NeuronLogisticsServer.Application.Repositories.WriteRepositories.Definitions;
using NeuronLogisticsServer.Domain.Entities.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Commands.DefinitionCommands.CargoContainerCommands.UpdateCommand
{
    public class UpdateCargoContainerCommandHandler : IRequestHandler<UpdateCargoContainerCommandRequest, UpdateCargoContainerCommandResponse>
    {
        private readonly ICargoContainerWriteRepository _cargoContainerWriteRepository;
        private readonly ICargoContainerReadRepository _cargoContainerReadRepository;

        public UpdateCargoContainerCommandHandler(ICargoContainerWriteRepository cargoContainerWriteRepository, ICargoContainerReadRepository cargoContainerReadRepository)
        {
            _cargoContainerWriteRepository = cargoContainerWriteRepository;
            _cargoContainerReadRepository = cargoContainerReadRepository;
        }

        public async Task<UpdateCargoContainerCommandResponse> Handle(UpdateCargoContainerCommandRequest request, CancellationToken cancellationToken)
        {
            CargoContainer cargoContainer = await _cargoContainerReadRepository.GetByIdAsync(request.Id);
            cargoContainer.Name = request.Name;
            cargoContainer.Teu = request.Teu;

            await _cargoContainerWriteRepository.SaveAsync();

            return new();
        }
    }
}