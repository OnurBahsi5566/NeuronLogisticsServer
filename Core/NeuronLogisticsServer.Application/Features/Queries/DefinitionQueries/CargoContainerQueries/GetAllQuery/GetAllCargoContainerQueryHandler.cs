using MediatR;
using NeuronLogisticsServer.Application.Repositories.ReadRepositories.Definitions;
using NeuronLogisticsServer.Application.RequestParameters;
using NeuronLogisticsServer.Domain.Entities.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Queries.DefinitionQueries.CargoContainerQueries.GetAllQuery
{
    public class GetAllCargoContainerQueryHandler : IRequestHandler<GetAllCargoContainerQueryRequest, GetAllCargoContainerQueryResponse>
    {
        private readonly ICargoContainerReadRepository _cargoContainerReadRepository;

        public GetAllCargoContainerQueryHandler(ICargoContainerReadRepository cargoContainerReadRepository)
        {
            _cargoContainerReadRepository = cargoContainerReadRepository;
        }

        public Task<GetAllCargoContainerQueryResponse> Handle(GetAllCargoContainerQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _cargoContainerReadRepository.GetAll(false).Count();
            var cargoContainers = _cargoContainerReadRepository.GetAll(false)
                                             .Skip(request.Page * request.Size)
                                             .Take(request.Size).ToList();

            return Task.FromResult(new GetAllCargoContainerQueryResponse
            {
                TotalCount = totalCount,
                CargoContainers = cargoContainers,
            });
        }
    }
}