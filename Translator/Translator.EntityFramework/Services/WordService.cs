using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Translator.Domain.Models;
using Translator.Domain.Services;

namespace Translator.EntityFramework.Services
{
    public class WordService : IDataService<Word>
    {
        private readonly TranslatorDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Word> _nonQueryDataService;

        public WordService(TranslatorDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Word>(contextFactory);
        }

        public async Task<Word> Create(Word entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Word> Get(int id)
        {
            using (TranslatorDbContext context = _contextFactory.CreateDbContext())
            {
                Word entity = await context.Words
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Word>> GetAll()
        {
            using (TranslatorDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Word> entities = await context.Words
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<Word> Update(int id, Word entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
