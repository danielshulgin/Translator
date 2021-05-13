using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Translator.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Translator.EntityFramework.Configuration;
using RoleConfiguration = Translator.Domain.Configuration.RoleConfiguration;
using System.Linq;

namespace Translator.EntityFramework
{
    public class TranslatorDbContext : IdentityDbContext<User>
    {
        public DbSet<Word> Words { get; set; }
        
        public DbSet<Sentence> Sentences { get; set; }
        
        public DbSet<Collocation> Collocations { get; set; }

        public DbSet<LogMessage> LogMessages { get; set; }


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
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.Entity<Word>()
            .Property(e => e.Translations)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList<string>());
            modelBuilder.Entity<Word>()
            .Property(e => e.NounsTranslations)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList<string>());
            modelBuilder.Entity<Word>()
            .Property(e => e.AdjectivesTranslations)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList<string>());
            modelBuilder.Entity<Word>()
            .Property(e => e.VerbsTranslations)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList<string>());
            modelBuilder.Entity<Collocation>()
            .Property(e => e.Words)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList<string>());
        }
    }
}