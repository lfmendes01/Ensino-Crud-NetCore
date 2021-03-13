using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dto.Curso;
using WebApi.Entities;

namespace WebApi.Repository.Interface
{
    public interface ICategoriaRepository
    {

        IQueryable<Categoria> GetAll();

        int Add(Categoria entity);
    }
}
