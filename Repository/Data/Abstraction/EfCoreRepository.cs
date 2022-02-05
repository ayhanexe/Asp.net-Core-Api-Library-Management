using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data.EFCore
{
    public class EfCoreRepository<TEntity, TEntityDto, TContext> : IRepository<TEntity>
    where TEntity : class, IEntity
    where TContext : DbContext
    {
        private readonly TContext _context;

        public EfCoreRepository(TContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

    }
}
