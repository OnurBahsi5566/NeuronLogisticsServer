using NeuronLogisticsServer.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Commands.IdentityCommands.AppUserCommands.GoogleLoginCommand
{
    public class GoogleLoginCommandResponse
    {
        public Token Token { get; set; }
    }
}