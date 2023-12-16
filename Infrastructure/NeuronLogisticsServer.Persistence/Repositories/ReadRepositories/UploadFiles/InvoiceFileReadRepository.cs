using NeuronLogisticsServer.Application.Repositories.ReadRepositories.UploadFiles;
using NeuronLogisticsServer.Domain.Entities.UploadFiles;
using NeuronLogisticsServer.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Persistence.Repositories.ReadRepositories.UploadFiles
{
    public class InvoiceFileReadRepository : ReadRepository<InvoiceFile>, IInvoiceFileReadRepository
    {
        public InvoiceFileReadRepository(NeuronLogisticsServerDbContext context) : base(context)
        {
        }
    }
}
