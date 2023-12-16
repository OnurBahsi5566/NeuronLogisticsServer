using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Features.Commands.UploadFilesCommands.CargoContainerFileCommands.UploadCommand
{
    public  class UploadCargoContainerFileCommandRequest : IRequest<UploadCargoContainerFileCommandResponse>
    {
        public string Id { get; set; }

        public IFormFileCollection? Files { get; set; }
    }
}
