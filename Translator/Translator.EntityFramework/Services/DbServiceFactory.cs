using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Translator.Domain.Models;

namespace Translator.EntityFramework.Services
{
    public class DbServiceFactory
    {
        private readonly TranslatorDbContextFactory _dbContextFactory;

        
        public DbServiceFactory(TranslatorDbContextFactory translatorDbContextFactory)
        {
            _dbContextFactory = translatorDbContextFactory;
        }
        
        public IDbGenericService<T> Create<T>() where T : DomainObject
        {
            return new NonQueryDataService<T>(_dbContextFactory);
        }
    }
}