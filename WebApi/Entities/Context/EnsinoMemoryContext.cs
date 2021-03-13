using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities.Context
{
    public class EnsinoMemoryContext : DbContext
    {
        public EnsinoMemoryContext(DbContextOptions<EnsinoMemoryContext> options)
          : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .HasOne(s => s.Categoria)
                .WithMany(g => g.Curso)
                .HasForeignKey(s => s.IdCategoria);
        }

        public DbSet<Curso> Curso { get; set; }

        public DbSet<Categoria> Categoria { get; set; }
    }
}
