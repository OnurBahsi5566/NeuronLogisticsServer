using Microsoft.EntityFrameworkCore;
using NeuronLogisticsServer.Application.Repositories;
using NeuronLogisticsServer.Domain.Entities.Common;
using NeuronLogisticsServer.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeuronLogisticsServer.Persistence.Repositories
{
    //tracking oerasyonu açık olduğunda read okunan bir nesneyi 
    //metod çağırmadan update edebiliriz yani sonuna query ekliycektir.
    //fakat sadece okuma yapılan yerlerde tracking olmaması daha performanslı olacağından
    //yönetimini bu şekilde kontrol edebileceğiz.
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly NeuronLogisticsServerDbContext _context;

        public ReadRepository(NeuronLogisticsServerDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            
            return query;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            
            return await query.FirstOrDefaultAsync(method);
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {    
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id)); ;
        }
    }
}