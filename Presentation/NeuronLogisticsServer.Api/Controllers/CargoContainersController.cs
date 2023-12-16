using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeuronLogisticsServer.Application.Features.Commands.DefinitionCommands.CargoContainerCommands.CreateCommand;
using NeuronLogisticsServer.Application.Features.Commands.DefinitionCommands.CargoContainerCommands.RemoveCommand;
using NeuronLogisticsServer.Application.Features.Commands.DefinitionCommands.CargoContainerCommands.UpdateCommand;
using NeuronLogisticsServer.Application.Features.Commands.UploadFileCommands.CargoContainerFileCommands.RemoveCommand;
using NeuronLogisticsServer.Application.Features.Commands.UploadFilesCommands.CargoContainerFileCommands.UploadCommand;
using NeuronLogisticsServer.Application.Features.Queries.DefinitionQueries.CargoContainerQueries.GetAllQuery;
using NeuronLogisticsServer.Application.Features.Queries.DefinitionQueries.CargoContainerQueries.GetByIdQuery;
using NeuronLogisticsServer.Application.Features.Queries.UploadFileQueries.CargoContainerFileQueries.GetByCargoContainerId;
using System.Net;

namespace NeuronLogisticsServer.Api.Controllers
{
    [Route("api/cargoContainers")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class CargoContainersController : ControllerBase
    {
        readonly IMediator _mediator;
        public CargoContainersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCargoContainerQueryRequest getAllCargoContainerQueryRequest)
        {
            GetAllCargoContainerQueryResponse response = await _mediator.Send(getAllCargoContainerQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCargoContainerQueryRequest getByIdCargoContainerQueryRequest)
        {
            GetByIdCargoContainerQueryResponse response = await _mediator.Send(getByIdCargoContainerQueryRequest);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCargoContainerCommandRequest createCargoContainerCommandRequest)
        {
            CreateCargoContainerCommandReponse response = await _mediator.Send(createCargoContainerCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCargoContainerCommandRequest updateCargoContainerCommandRequest)
        {
            UpdateCargoContainerCommandResponse response = await _mediator.Send(updateCargoContainerCommandRequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveCargoContainerCommandRequest removeCargoContainerCommandRequest)
        {
            RemoveCargoContainerCommandResponse response = await _mediator.Send(removeCargoContainerCommandRequest);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadCargoContainerFileCommandRequest  uploadCargoContainerFileCommandRequest)
        {
            uploadCargoContainerFileCommandRequest.Files = Request.Form.Files;
            UploadCargoContainerFileCommandResponse response = await _mediator.Send(uploadCargoContainerFileCommandRequest);
            return Ok();
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetFiles([FromRoute] GetByCargoCanteinerIdCargoCaontainerFileQueryRequest getByCargoCanteinerIdCargoCaontainerFileQueryRequest)
        {
            List<GetByCargoCanteinerIdCargoCaontainerFileQueryResponse> response = await _mediator.Send(getByCargoCanteinerIdCargoCaontainerFileQueryRequest);

            return Ok(response);
        }

        [HttpDelete("[action]/{cargoContainerId}")]
        public async Task<IActionResult> DeleteDocument([FromRoute] RemoveCargoContainerFileCommandRequest removeCargoContainerFileCommandRequest, [FromQuery] string cargoContainerFileId)
        {
            removeCargoContainerFileCommandRequest.CargoContainerFileId = cargoContainerFileId;
            RemoveCargoContainerFileCommandResponse response = await _mediator.Send(removeCargoContainerFileCommandRequest);
            return Ok();
        }
    }
}