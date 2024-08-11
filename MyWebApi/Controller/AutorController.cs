using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services.Autor;
using MyWebApi.Models;
using MyWebApi.Dto.Autor;
using MyWebApi.Data;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface;

        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            if (autores.Status)
            {
                return Ok(autores);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, autores);
            }
        }

        [HttpGet("BuscarAutorPorId/{autorId}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int autorId)
        {
            var autor = await _autorInterface.BuscarAutorPorId(autorId);
            if (autor.Status)
            {
                return Ok(autor);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, autor);
            }
        }

        [HttpGet("BuscarAutorPorIdLivro/{livroId}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int livroId)
        {
            var autor = await _autorInterface.BuscarAutorPorIdLivro(livroId);
            if (autor.Status)
            {
                return Ok(autor);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, autor);
            }
        }

        [HttpPost("CadastrarAutor")]
        public async Task<ActionResult<List<ResponseModel<AutorModel>>>> CadastrarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var autores = await _autorInterface.CadastrarAutor(autorCriacaoDto);
            if (autores.Status)
            {
                return Ok(autores);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, autores);
            }
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<List<ResponseModel<AutorModel>>>> CadastrarAutor(EditarAutorDto editarAutorDto)
        {
            var autores = await _autorInterface.EditarAutor(editarAutorDto);
            if (autores.Status)
            {
                return Ok(autores);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, autores);
            }
        }
        
        [HttpDelete("RemoverAutor")]
        public async Task<ActionResult<List<ResponseModel<AutorModel>>>> RemoverAutor(int autorId)
        {
            var autores = await _autorInterface.RemoverAutor(autorId);
            if (autores.Status)
            {
                return Ok(autores);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, autores);
            }
        }

    }
}

