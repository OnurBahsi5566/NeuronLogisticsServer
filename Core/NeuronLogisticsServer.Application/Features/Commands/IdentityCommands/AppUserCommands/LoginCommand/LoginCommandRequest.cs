using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Commands.IdentityCommands.AppUserCommands.LoginCommand
{
    public class LoginCommandRequest: IRequest<LoginCommandResponse>
    {
        public string UserNameOrEmail { get; set; }

        public string Password { get; set; }
    }
}