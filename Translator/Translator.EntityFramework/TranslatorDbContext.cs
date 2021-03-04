using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Translator.Domain.Models;

namespace Translator.EntityFramework
{
    public class TranslatorDbContext : DbContext
    {
        public DbSet<Word> Words { get; set; }


        public TranslatorDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}