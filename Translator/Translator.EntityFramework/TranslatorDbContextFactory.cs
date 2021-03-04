using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Translator.EntityFramework
{
    public class TranslatorDbContextFactory : IDesignTimeDbContextFactory<TranslatorDbContext>
    {
        private readonly string _connectionString;


        public TranslatorDbContextFactory()
        {
            _connectionString = "server=(localdb)\\MSSQLLocalDB;Database=TranslatorDB;Trusted_Connection=True;";
        }

        public TranslatorDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TranslatorDbContext CreateDbContext(string[] args = null)
        {
            DbContextOptionsBuilder<TranslatorDbContext> options = new DbContextOptionsBuilder<TranslatorDbContext>();

            options.UseSqlServer(_connectionString);
            return new TranslatorDbContext(options.Options);
        }
    }
}
