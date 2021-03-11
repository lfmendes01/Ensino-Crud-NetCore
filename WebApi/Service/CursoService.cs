using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dto.Curso;
using WebApi.Entities;
using WebApi.Repository.Interface;
using WebApi.Service.Interface;

namespace WebApi.Service
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repository;


        public CursoService(
            ICursoRepository repository)
        {
            _repository = repository;
        }


        public CursoGetDto Get(int id)
        {
            var dto = _repository.Get(id);

            return dto;
        }

        public IList<CursoGetDto> GetAll()
        {
            return _repository.GetAll();
        }


        public int Add(CursoPostDto dto)
        {
            return _repository.Add(dto);
        }

        public bool Update(int id,CursoPostDto dto)
        {
           return _repository.Update(id,dto);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
