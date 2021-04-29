using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Translator.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Translator.EntityFramework.Configuration;
using RoleConfiguration = Translator.Domain.Configuration.RoleConfiguration;

namespace Translator.EntityFramework
{
    public class TranslatorDbContext : IdentityDbContext<User>
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}