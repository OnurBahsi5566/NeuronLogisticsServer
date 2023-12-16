using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Application.ViewModels.Definitions
{
    public class VM_Update_CargoContainer
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public double Teu { get; set; }
    }
}
