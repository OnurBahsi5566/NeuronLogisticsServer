using MediatR;
using NeuronLogisticsServer.Application.Features.Queries.DefinitionQueries.CargoContainerQueries.GetAllQuery;
using NeuronLogisticsServer.Application.Repositories.ReadRepositories.Definitions;
using NeuronLogisticsServer.Domain.Entities.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Queries.DefinitionQueries.CargoContainerQueries.GetByIdQuery
{
    public class GetByIdCargoContainerQueryHandler : IRequestHandler<GetByIdCargoContainerQueryRequest, GetByIdCargoContainerQueryResponse>
    {
        private readonly ICargoContainerReadRepository _cargoContainerReadRepository;

        public GetByIdCargoContainerQueryHandler(ICargoContainerReadRepository cargoContainerReadRepository)
        {
            _cargoContainerReadRepository = cargoContainerReadRepository;
        }

        public async Task<GetByIdCargoContainerQueryResponse> Handle(GetByIdCargoContainerQueryRequest request, CancellationToken cancellationToken)
        {
            CargoContainer cargoContainer = await _cargoContainerReadRepository.GetByIdAsync(request.Id, false);

            return new GetByIdCargoContainerQueryResponse
            {
                Name = cargoContainer.Name,
                Teu = cargoContainer.Teu,
                VesselId = cargoContainer.VesselId
            };
        }
    }
}
