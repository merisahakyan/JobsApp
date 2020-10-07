using JobsApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JobsApp.Core.Interfaces.Repositories;
using JobsApp.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace JobsApp.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        public AppDbContext Context { get; private set; }
        public RepositoryBase(AppDbContext context)
        {
            Context = context;
        }
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var entity = Context.Set<T>().FirstOrDefault(e => e.Id == id);
            Context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public async Task<T> GetSingleAsync(int id)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> GetSingleWithIncludeAsync<TProp>(int id, params Expression<Func<T, TProp>>[] exp)
        {
            var set = Context.Set<T>();
            IIncludableQueryable<T, TProp> resultSet = set.Include(exp[0]);
            for (int i = 1; i < exp.Length; i++)
            {
                set.Include(exp[i]);
            };

            return await resultSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
