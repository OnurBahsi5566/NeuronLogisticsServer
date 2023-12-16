using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NeuronLogisticsServer.Application.Repositories.ReadRepositories.Definitions;
using NeuronLogisticsServer.Domain.Entities.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Queries.UploadFileQueries.CargoContainerFileQueries.GetByCargoContainerId
{
    public class GetByCargoCanteinerIdCargoCaontainerFileQueryHandler : IRequestHandler<GetByCargoCanteinerIdCargoCaontainerFileQueryRequest, List<GetByCargoCanteinerIdCargoCaontainerFileQueryResponse>>
    {
        private readonly ICargoContainerReadRepository _cargoContainerReadRepository;
        private readonly IConfiguration _configuration;

        public GetByCargoCanteinerIdCargoCaontainerFileQueryHandler(ICargoContainerReadRepository cargoContainerReadRepository, IConfiguration configuration)
        {
            _cargoContainerReadRepository = cargoContainerReadRepository;
            _configuration = configuration;
        }

        public async Task<List<GetByCargoCanteinerIdCargoCaontainerFileQueryResponse>> Handle(GetByCargoCanteinerIdCargoCaontainerFileQueryRequest request, CancellationToken cancellationToken)
        {
            CargoContainer? cargoContainer = await _cargoContainerReadRepository.Table.Include(c => c.CargoContainerFiles)
                                                            .FirstOrDefaultAsync(c => c.Id == Guid.Parse(request.Id));

            return cargoContainer?.CargoContainerFiles.Select(c => new GetByCargoCanteinerIdCargoCaontainerFileQueryResponse
            {
                Path = $"{_configuration["BaseStorageUrl"]}{c.Path}",
                FileName = c.FileName,
                Id = c.Id
            }).ToList();
        }
    }
}