using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Commands.DefinitionCommands.CargoContainerCommands.CreateCommand
{
    public class CreateCargoContainerCommandRequest : IRequest<CreateCargoContainerCommandReponse>
    {
        public string Name { get; set; }

        public double Teu { get; set; }

    }
}
