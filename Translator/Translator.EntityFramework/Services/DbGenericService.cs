using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Translator.Domain.Models;

namespace Translator.EntityFramework.Services
{
    public class DbGenericService<T> where T: DomainObject
    {
        private readonly TranslatorDbContextFactory _contextFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;
        private readonly Func<DbSet<T>> _entitiesProvider;

        public DbGenericService(TranslatorDbContextFactory contextFactory, Func<DbSet<T>> entitiesProvider)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<T>(contextFactory);
            _entitiesProvider = entitiesProvider;
        }

        public async Task<T> Create(T entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<T> Get(int id)
        {
            using (TranslatorDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await _entitiesProvider()
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (TranslatorDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await _entitiesProvider()
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}