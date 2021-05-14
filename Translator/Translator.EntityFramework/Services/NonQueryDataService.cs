using System.Collections.Generic;
using Translator.Domain.Models;
using Translator.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace Translator.EntityFramework.Services
{
    public class NonQueryDataService<T>  : IDbGenericService<T> where T : DomainObject
    {
        private readonly TranslatorDbContextFactory _contextFactory;

        
        public NonQueryDataService(TranslatorDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            await using var context = _contextFactory.CreateDbContext();
            
            var createdResult = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return createdResult.Entity;
        }
        
        public async Task<T> Get(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            
            var entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            await using var context = _contextFactory.CreateDbContext();
            
            var entities = await context.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> Update(int id, T entity)
        {
            await using var context = _contextFactory.CreateDbContext();
            
            entity.Id = id;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            
            var entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
