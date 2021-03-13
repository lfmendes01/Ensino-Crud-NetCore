using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto.Retorno
{
    public class ServiceResult
    {

        public ServiceResult() 
        {
            Sucesso = false;
            Falhas = new List<string>();
        }
        public bool Sucesso { get; set; }

        public List<string> Falhas { get; set; }

        public object ResultadoSucesso { get; set; }

    }
}
