using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.Abstractions.Hubs
{
    public interface ICargoContainerHubService
    {
        Task CargoContainerAddedMessageAsync(string message);
    }
}
