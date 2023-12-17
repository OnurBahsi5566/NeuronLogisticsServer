using MediatR;
using NeuronLogisticsServer.Application.Abstractions.Hubs;
using NeuronLogisticsServer.Application.Repositories.WriteRepositories.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Commands.DefinitionCommands.CargoContainerCommands.CreateCommand
{
    public class CreateCargoContainerCommandHandler : IRequestHandler<CreateCargoContainerCommandRequest, CreateCargoContainerCommandReponse>
    {
        readonly ICargoContainerWriteRepository _cargoContainerWriteRepository;
        readonly ICargoContainerHubService _cargoContainerHubService;

        public CreateCargoContainerCommandHandler(ICargoContainerWriteRepository cargoContainerWriteRepository, ICargoContainerHubService cargoContainerHubService)
        {
            _cargoContainerWriteRepository = cargoContainerWriteRepository;
            _cargoContainerHubService = cargoContainerHubService;
        }

        public async Task<CreateCargoContainerCommandReponse> Handle(CreateCargoContainerCommandRequest request, CancellationToken cancellationToken)
        {
            await _cargoContainerWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Teu = request.Teu,
                VesselId = Guid.Parse("4eb8f938-1760-4d64-9f6e-918d82d38ec3")
            });
            await _cargoContainerWriteRepository.SaveAsync();
            await _cargoContainerHubService.CargoContainerAddedMessageAsync($"{request.Name} added to containers");
            return new();
        }
    }
}