using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto.Curso
{
    public class CursoPostDto
    {
        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public int NumeroAlunos { get; set; }

        public int IdCategoria { get; set; }

    }
}
