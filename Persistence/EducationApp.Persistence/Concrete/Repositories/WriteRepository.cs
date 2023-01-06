﻿using EducationApp.Domain.Entities.Common;
using EducationApp.Persistence.Context;
using EducationAPP.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Persistence.Concrete.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly EducationAppContext _context;

        public WriteRepository(EducationAppContext context)
        {
            _context = context;
        }
        public DbSet<T> Table =>  _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
          EntityEntry<T> entityEntry= await Table.AddAsync(entity);
            return entityEntry.State== EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> entity)
        {
            await Table.AddRangeAsync(entity);
            return true;
        }
        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> entity)
        {
            Table.RemoveRange(entity);
            return true;
        }
        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id)); //buldun
           return Remove(model);
        }
        public bool Update(T entity)
        {
          EntityEntry entityEntry=  Table.Update(entity);
           return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync()
                =>await _context.SaveChangesAsync();
    }
}