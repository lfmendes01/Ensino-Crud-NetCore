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

        public DbSet<Curso> Curso { get; set; }

        public DbSet<Categoria> Categoria { get; set; }
    }
}
