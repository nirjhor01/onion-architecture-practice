using Microsoft.EntityFrameworkCore;
using RepositoryLayerClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerClassLibrary3
{
    public class BaseService<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public BaseService(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            T entity = await GetByIdAsync(id);
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }
    }
}

