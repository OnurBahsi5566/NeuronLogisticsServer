using NeuronLogisticsServer.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Domain.Entities.Definitions
{
    public class Voyage : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Vessel> Vessels { get; set; }
    }
}
