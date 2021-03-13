using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Entities.Context;

namespace WebApi.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EnsinoMemoryContext(
                serviceProvider.GetRequiredService<DbContextOptions<EnsinoMemoryContext>>()))
            {
                // Look for any board games.
                if (context.Categoria.Any())
                {
                    return;   // Data was already seeded
                }



                List<Categoria> lista = new List<Categoria>();
                lista.Add(new Categoria() { Descricao = "Comportamental", Codigo = 1 });
                lista.Add(new Categoria() { Descricao = "Programação", Codigo = 2 });
                lista.Add(new Categoria() { Descricao = "Qualidade", Codigo = 3 });
                lista.Add(new Categoria() { Descricao = "Processos",  Codigo = 4 });

                context.Categoria.AddRange(lista);
                   

                context.SaveChanges();
            }
        }
    }
}

