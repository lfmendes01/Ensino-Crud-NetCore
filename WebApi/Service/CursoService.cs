using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Dto.Curso;
using WebApi.Dto.Retorno;
using WebApi.Repository.Interface;
using WebApi.Service.Interface;

namespace WebApi.Service
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repository;
        private readonly ICategoriaRepository _repositoryCategoria;


        public CursoService(
            ICursoRepository repository, ICategoriaRepository repositoryCategoria)
        {
            _repository = repository;
            _repositoryCategoria = repositoryCategoria;
        }


        public CursoGetDto Get(int id)
        {
            var query = _repository.Get(id);

            var dto = query.Select( c=>  new CursoGetDto()
            {
                Id = c.IdCurso,
                DataInicio = c.DataInicio,
                DataTermino = c.DataTermino,
                Descricao = c.Descricao,
                NumeroAlunos = c.NumeroAlunos
            }).FirstOrDefault();

            return dto;
        }

        public IList<CursoGetDto> GetAll()
        {

            var query = _repository.GetAll();

            var lista = query.Select(a => new CursoGetDto()
            {
                Id = a.IdCurso,
                DataInicio = a.DataInicio,
                DataTermino = a.DataTermino,
                Descricao = a.Descricao,
                NumeroAlunos = a.NumeroAlunos
            }).ToList();

            return lista;
        }


        public ServiceResult Add(CursoPostDto dto)
        {
            var result = ValidarCurso(dto);
            var id = _repository.Add(dto);
            result.ResultadoSucesso = id;

            return result;
        }

        public bool Update(int id,CursoPostDto dto)
        {
           return _repository.Update(id,dto);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
        private ServiceResult ValidarCurso(CursoPostDto dto)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrWhiteSpace(dto.Descricao) || DateTime.MinValue >= dto.DataInicio
                || DateTime.MinValue >= dto.DataTermino) {

                result.Falhas.Add("Campos informados incorretamente.");
                return result;  
             }

            if (dto.DataInicio.Date < DateTime.Now.Date)
            {
                result.Falhas.Add("Data Inicio menor que a atual.");
                return result;
            }

            if (dto.DataInicio.Date > dto.DataTermino.Date)
            {
                result.Falhas.Add("Data Inicio maior que a termino.");
                return result;
            }

            var query = GetAll();

            if (query.Any(c => dto.DataInicio > c.DataInicio && dto.DataTermino < c.DataTermino))
            {
                result.Falhas.Add("Existe(m) curso(s) planejado(s) dentro do periodo informado.");
                return result;
            }

            var queryCategoria = _repositoryCategoria.GetAll();
            if (queryCategoria.Any(c => c.IdCategoria == dto.IdCategoria))
            {
                result.Falhas.Add("Categoria do curso não cadastrada.");
                return result;
            }

            result.Sucesso = true;
            return result;

        }
    }
}
