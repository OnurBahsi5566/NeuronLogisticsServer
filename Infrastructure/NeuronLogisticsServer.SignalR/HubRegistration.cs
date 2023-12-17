using Microsoft.AspNetCore.Builder;
using NeuronLogisticsServer.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.SignalR
{
    //program.cs te sürekli her hubu yazmamak için burada tanımladık.(ServiceRegistration mantığında)
    public static class HubRegistration
    {
        public static void MapHubs(this WebApplication webApplication) 
        {
            webApplication.MapHub<CargoContainerHub>("/cargo-containers-hub"); //son verilen endpoint
        }
    }
}
