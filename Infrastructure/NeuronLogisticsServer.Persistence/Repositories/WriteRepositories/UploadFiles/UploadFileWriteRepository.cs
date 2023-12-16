using NeuronLogisticsServer.Application.Repositories.WriteRepositories.UploadFiles;
using NeuronLogisticsServer.Domain.Entities.UploadFiles;
using NeuronLogisticsServer.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Persistence.Repositories.WriteRepositories.UploadFiles
{
    public class UploadFileWriteRepository : WriteRepository<UploadFile>, IUploadFileWriteRepository
    {
        public UploadFileWriteRepository(NeuronLogisticsServerDbContext context) : base(context)
        {
        }
    }
}
