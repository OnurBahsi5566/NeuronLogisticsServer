using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Commands.IdentityCommands.AppUserCommands.RegisterCommand
{
    public class RegisterCommandResponse
    {
        public bool Succeeded { get; set; }

        public string Message { get; set; }
    }
}
