using EducationApp.Domain.Entities.Common;
using EducationApp.Persistence.Context;
using EducationAPP.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Persistence.Concrete.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly EducationAppContext _context;

        public ReadRepository(EducationAppContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll() => Table;

        public async Task<T> GetByIdAsync(string id)
          => await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
      => await Table.FirstOrDefaultAsync(predicate);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
          => Table.Where(predicate);
    }
}
