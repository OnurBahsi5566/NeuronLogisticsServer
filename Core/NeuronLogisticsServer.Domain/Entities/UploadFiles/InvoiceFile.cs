using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Domain.Entities.UploadFiles
{
    public class InvoiceFile: UploadFile
    {
        public decimal TotalPrice { get; set; }
    }
}
