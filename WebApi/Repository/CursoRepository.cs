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
    public class CursoRepository:ICursoRepository
    {
        EnsinoMemoryContext db;
        public CursoRepository(EnsinoMemoryContext _db)
        {
            db = _db;
        }
        public CursoGetDto Get(int id)
        {
            if (db != null)
            {
                var query = db.Curso.Find(id);
                if (query != null)
                {
                    var dto = new CursoGetDto()
                    {
                        Id = query.IdCurso,
                        DataInicio = query.DataInicio,
                        DataTermino = query.DataTermino,
                        Descricao = query.Descricao,
                        NumeroAlunos = query.NumeroAlunos
                    };
                    return dto;
                }
                
            }
            return null;
        }

        public List<CursoGetDto> GetAll()
        {
            if (db != null)
            {
                var query = db.Curso.OrderBy(entity => entity.IdCurso).ToList();

                var dto = query.Select(a => new CursoGetDto()
                {
                    Id = a.IdCurso,
                    DataInicio = a.DataInicio,
                    DataTermino = a.DataTermino,
                    Descricao = a.Descricao,
                    NumeroAlunos = a.NumeroAlunos
                }).ToList();

                return dto;
            }
            return null;
        }


        public int Add(CursoPostDto dto)
        {

            Curso entity = new Curso()
            {
                DataInicio = dto.DataInicio,
                DataTermino = dto.DataTermino,
                NumeroAlunos = dto.NumeroAlunos,
                Descricao = dto.Descricao
            };

            var entityEntry = db.Add(entity);
            db.SaveChanges();
            return entityEntry.Entity.IdCurso;
        }

        public bool Delete(int id)
        {
            var entity = db.Curso.Find(id);
            if (entity == null)
            {
                return false;
            }

            try
            {
                db.Remove(entity);
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }


        public bool Update(int id,CursoPostDto dto)
        {
            var entity = db.Curso.Find(id);
            if (entity == null)
            {
                return false;
            }

            try
            {

                entity.DataInicio = dto.DataInicio;
                entity.DataTermino = dto.DataTermino;
                entity.NumeroAlunos = dto.NumeroAlunos;
                entity.Descricao = dto.Descricao;

                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }
    }
}
