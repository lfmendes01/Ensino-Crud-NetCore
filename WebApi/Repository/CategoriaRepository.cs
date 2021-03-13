using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dto.Curso;
using WebApi.Entities;
using WebApi.Entities.Context;
using WebApi.Repository.Interface;

namespace WebApi.Repository
{
    public class CategoriaRepository:ICategoriaRepository
    {
        EnsinoMemoryContext db;
        public CategoriaRepository(EnsinoMemoryContext _db)
        {
            db = _db;
        }

        public IQueryable<Categoria> GetAll()
        {
            if (db != null)
            {
                var query = db.Categoria.OrderBy(entity => entity.IdCategoria).AsQueryable();

                return query;
            }
            return null;
        }


        public int Add(Categoria entity)
        {

            var entityEntry = db.Add(entity);
            db.SaveChanges();
            return entityEntry.Entity.IdCategoria;
        }
    }
}
