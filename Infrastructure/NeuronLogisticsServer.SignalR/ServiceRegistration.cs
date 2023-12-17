using Microsoft.Extensions.DependencyInjection;
using NeuronLogisticsServer.Application.Abstractions.Hubs;
using NeuronLogisticsServer.SignalR.HubServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRService(this IServiceCollection collection)
        {
            collection.AddTransient<ICargoContainerHubService, CargoContainerHubService>();
            collection.AddSignalR();
        }
    }
}