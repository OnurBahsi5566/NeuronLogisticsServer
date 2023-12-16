using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Commands.DefinitionCommands.CargoContainerCommands.RemoveCommand
{
    public class RemoveCargoContainerCommandRequest : IRequest<RemoveCargoContainerCommandResponse>
    {
        public string Id { get; set; }
    }
}