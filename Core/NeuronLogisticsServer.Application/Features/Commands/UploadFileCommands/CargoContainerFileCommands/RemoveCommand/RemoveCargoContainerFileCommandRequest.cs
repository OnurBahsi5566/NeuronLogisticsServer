using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Commands.UploadFileCommands.CargoContainerFileCommands.RemoveCommand
{
    public class RemoveCargoContainerFileCommandRequest: IRequest<RemoveCargoContainerFileCommandResponse>
    {
        public string CargoContainerId { get; set; }

        public string? CargoContainerFileId { get; set; }
    }
}
