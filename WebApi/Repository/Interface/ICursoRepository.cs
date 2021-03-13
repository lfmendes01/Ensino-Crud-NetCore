using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dto.Curso;
using WebApi.Entities;

namespace WebApi.Repository.Interface
{
    public interface ICursoRepository
    {

        IQueryable<Curso> GetAll();

        IQueryable<Curso> Get(int id);

        int Add(CursoPostDto dto);

        bool Delete(int id);

        bool Update(int id, CursoPostDto dto);
    }
}
