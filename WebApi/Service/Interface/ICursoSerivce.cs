using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dto.Curso;

namespace WebApi.Service.Interface
{
    public interface ICursoService
    {
        CursoGetDto Get(int id);

        IList<CursoGetDto> GetAll();

        int Add(CursoPostDto dto);

        bool Update(int id, CursoPostDto dto);
        bool Delete(int id);

    }

}
