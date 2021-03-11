using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Dto.Curso;
using WebApi.Dto.Error;
using WebApi.Service.Interface;

namespace WebApi.Controllers
{
    [Route("api/curso")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class CursoController: ControllerBase
    {
        private readonly ICursoService _service;

        public CursoController(ICursoService service)
        {
            _service = service;
        }
        /// <summary>
        /// Busca todos os cursos cadastrados
        /// </summary>
        /// <returns>Lista dos cursos</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CursoGetDto>), StatusCodes.Status200OK)]
        public  IEnumerable<CursoGetDto> List()
        {
            return _service.GetAll();
        }
        /// <summary>
        /// Busca
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CursoGetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResult), StatusCodes.Status404NotFound)]
        public ActionResult<CursoGetDto> Get(int id)
        {
            var model = _service.Get(id);
            if (model == null)
            {
                return NotFound(new ApiErrorResult(StatusCodes.Status404NotFound, "Não encontrado", $"Curso {id} não encontrado"));
            }
            return model;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CursoPostDto), StatusCodes.Status201Created)]
        public ActionResult<CursoPostDto> Add([FromBody] CursoPostDto curso)
        {
            var id = _service.Add(curso);
            return CreatedAtAction(nameof(Get), new { id }, curso);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CursoDeleteResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResult), StatusCodes.Status404NotFound)]
        public ActionResult<CursoDeleteResult> Delete(int id)
        {
            var success = _service.Delete(id);
            var result = new CursoDeleteResult { Id = id };

            if (!success)
            {
                return NotFound(new ApiErrorResult(StatusCodes.Status404NotFound, "Não encontrado", $"Curso {id} não encontrado"));
            }
            return result;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CursoPostDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResult), StatusCodes.Status404NotFound)]
        public ActionResult<CursoDeleteResult> Update(int id, [FromBody] CursoPostDto curso)
        {
            var success = _service.Update(id,curso);
            var result = new CursoDeleteResult { Id = id };

            if (!success)
            {
                return NotFound(new ApiErrorResult(StatusCodes.Status404NotFound, "Não encontrado", $"Curso {id} não encontrado"));
            }
            return result;
        }
    }
}
