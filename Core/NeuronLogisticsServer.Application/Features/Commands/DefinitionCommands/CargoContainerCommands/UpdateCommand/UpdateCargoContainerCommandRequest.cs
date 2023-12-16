using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Commands.DefinitionCommands.CargoContainerCommands.UpdateCommand
{
    public class UpdateCargoContainerCommandRequest : IRequest<UpdateCargoContainerCommandResponse>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double Teu { get; set; }
    }
}
