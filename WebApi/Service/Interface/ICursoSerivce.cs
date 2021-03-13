using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dto.Curso;
using WebApi.Dto.Retorno;

namespace WebApi.Service.Interface
{
    public interface ICursoService
    {
        CursoGetDto Get(int id);

        IList<CursoGetDto> GetAll();

        ServiceResult Add(CursoPostDto dto);

        bool Update(int id, CursoPostDto dto);
        bool Delete(int id);

    }

}
