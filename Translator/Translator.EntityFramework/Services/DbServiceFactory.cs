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
        
        public DbGenericService<T> Create<T>(Func<DbSet<T>> dbSetProvider) where T : DomainObject
        {
            return new DbGenericService<T>(_dbContextFactory, dbSetProvider);
        }
    }
}