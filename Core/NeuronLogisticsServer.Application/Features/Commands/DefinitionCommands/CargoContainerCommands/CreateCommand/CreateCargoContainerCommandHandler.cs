using MediatR;
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
        private readonly ICargoContainerWriteRepository _cargoContainerWriteRepository;

        public CreateCargoContainerCommandHandler(ICargoContainerWriteRepository cargoContainerWriteRepository)
        {
            _cargoContainerWriteRepository = cargoContainerWriteRepository;
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

            return new();
        }
    }
}