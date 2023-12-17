using Microsoft.AspNetCore.SignalR;
using NeuronLogisticsServer.Application.Abstractions.Hubs;
using NeuronLogisticsServer.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.SignalR.HubServices
{
    public class CargoContainerHubService : ICargoContainerHubService
    {
        readonly IHubContext<CargoContainerHub> _hubContext;

        public CargoContainerHubService(IHubContext<CargoContainerHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task CargoContainerAddedMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.CargoContainerAddedMessage, message);
        }
    }
}
