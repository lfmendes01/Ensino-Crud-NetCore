using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Dto.Curso;
using WebApi.Dto.Error;
using WebApi.Dto.Retorno;
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
        /// Busca o curso conforme o id informado
        /// </summary>
        /// <param name="id">id do curso</param>
        /// <returns>objeto contendo os dados do curso</returns>
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
        /// <summary>
        /// Cadastro de novo curso
        /// </summary>
        /// <param name="curso">Dados do curso</param>
        /// <returns>dados do cadastro e com o id gerado</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CursoPostDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status400BadRequest)]
        public ActionResult<CursoPostDto> Add([FromBody] CursoPostDto curso)
        {
            var result = _service.Add(curso);

            if (result.Sucesso)
            {
                return CreatedAtAction(nameof(Add), new { result.ResultadoSucesso }, curso);
            }
            else
            {
                return BadRequest(result);
            }
        }

        /// <summary>
        /// Exclui um curso já cadastrado
        /// </summary>
        /// <param name="id">id do curso cadastrado</param>
        /// <returns>caso tela deletado com sucesso retorna o id da deleção</returns>
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

        /// <summary>
        /// Atualização do curso
        /// </summary>
        /// <param name="id">id do curso a ser atualizado</param>
        /// <param name="curso">dados do curso</param>
        /// <returns>true caso a atualização tenha sido feita com sucesso</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CursoPostDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResult), StatusCodes.Status404NotFound)]
        public ActionResult<bool> Update(int id, [FromBody] CursoPostDto curso)
        {
            var success = _service.Update(id,curso);

            if (!success)
            {
                return NotFound(new ApiErrorResult(StatusCodes.Status404NotFound, "Não encontrado", $"Curso {id} não encontrado"));
            }
            return success;
        }
    }
}
