using Microsoft.EntityFrameworkCore;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Dto.Curso;
using WebApi.Dto.Retorno;
using WebApi.Entities;
using WebApi.Repository;
using WebApi.Repository.Interface;
using WebApi.Service;
using WebApi.Service.Interface;
using Xunit;

namespace XUnitTest
{
    public class CursoUnitTest
    {
        private const int ID_INVALIDO = 2;
        private const int ID_VALIDO = 1;

        private ICursoService mock;
        private ICategoriaRepository mockCategoria;

        public CursoUnitTest()
        {
            mock = Substitute.For<ICursoService>();
            mockCategoria = Substitute.For<ICategoriaRepository>();

            #region Mock para buscar todas as categorias

            //cria o mock para testar a logica do retorno das categorias
            List<Categoria> lista = new List<Categoria>();
            lista.Add(new Categoria() { Descricao = "Comportamental" });
            lista.Add(new Categoria() { Descricao = "Programação" });
            lista.Add(new Categoria() { Descricao = "Qualidade" });
            lista.Add(new Categoria() { Descricao = "Processos" });

            var query = lista.AsQueryable();

            mockCategoria.GetAll().Returns(query);

            #endregion

            #region Mock para buscar todas as categorias

            //cria o mock para testar a logica da busca

            CursoGetDto dtoGet = new CursoGetDto()
            {
                DataInicio = DateTime.Now.AddDays(3),
                DataTermino = DateTime.Now.AddMonths(1),
                Descricao = "Descrição de teste",
                Id = 1,
                NumeroAlunos = 0,
                IdCategoria = 1,
                Categoria = "Comportamental"
            };

            mock.Get(ID_VALIDO).Returns(dtoGet);

            #endregion  

        }


        [Fact]
        public void BuscaTodasCategorias()
        {
            var list = mockCategoria.GetAll();

            Assert.NotNull(list);
        }

        [Fact]
        public void BuscaComIdInvalido()
        {
            var dto = mock.Get(ID_INVALIDO);

            Assert.Null(dto);
        }

        [Fact]
        public void BuscaComIdValido()
        {          
            var dto = mock.Get(ID_VALIDO);

            Assert.NotNull(dto);
        }


        [Fact]
        public void CadastroSucesso()
        {
            CursoPostDto dto = new CursoPostDto()
            {
                DataInicio = new DateTime(2020, 10, 20),
                DataTermino = new DateTime(2020, 10, 20),
                Descricao = "Curso de teste",
                NumeroAlunos = 0
            };
            ServiceResult serviceResult = new ServiceResult()
            {
                Falhas = new List<string>(),
                ResultadoSucesso = 1,
                Sucesso = true
            };

            mock.Add(dto).Returns(serviceResult);
            Assert.True(mock.Add(dto).Sucesso);
        }

    }
}
