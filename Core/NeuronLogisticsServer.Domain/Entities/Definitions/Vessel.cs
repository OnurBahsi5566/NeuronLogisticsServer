using NeuronLogisticsServer.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Domain.Entities.Definitions
{
    public class Vessel : BaseEntity
    {
        public string Name { get; set; }

        public string YearOfConstruction { get; set; }
        
        public string Imo { get; set; }

        public string FlagName { get; set; }

        public ICollection<Voyage> Voyages { get; set; }

        public ICollection<CargoContainer> CargoContainers { get; set; }
    }
}