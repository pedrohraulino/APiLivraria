using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services.Livro;
using MyWebApi.Models;
using MyWebApi.Dto.Livro;
using MyWebApi.Data;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _LivroInterface;

        public LivroController(ILivroInterface LivroInterface)
        {
            _LivroInterface = LivroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var Livros = await _LivroInterface.ListarLivros();
            if (Livros.Status)
            {
                return Ok(Livros);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Livros);
            }
        }

        [HttpGet("BuscarLivroPorId/{LivroId}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int LivroId)
        {
            var Livro = await _LivroInterface.BuscarLivroPorId(LivroId);
            if (Livro.Status)
            {
                return Ok(Livro);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Livro);
            }
        }

        [HttpGet("BuscarLivroPorIdAutor/{autorId}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorIdAutor(int autorId)
        {
            var Livro = await _LivroInterface.BuscarLivroPorIdAutor(autorId);
            if (Livro.Status)
            {
                return Ok(Livro);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Livro);
            }
        }

        [HttpPost("CadastrarLivro")]
        public async Task<ActionResult<List<ResponseModel<LivroModel>>>> CadastrarLivro(CriarLivroDTO criarLivroDTO)
        {
            var Livros = await _LivroInterface.CadastrarLivro(criarLivroDTO);
            if (Livros.Status)
            {
                return Ok(Livros);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Livros);
            }
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<List<ResponseModel<LivroModel>>>> CadastrarLivro(EditarLivroDto editarLivroDto)
        {
            var Livros = await _LivroInterface.EditarLivro(editarLivroDto);
            if (Livros.Status)
            {
                return Ok(Livros);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Livros);
            }
        }
        
        [HttpDelete("RemoverLivro")]
        public async Task<ActionResult<List<ResponseModel<LivroModel>>>> RemoverLivro(int LivroId)
        {
            var Livros = await _LivroInterface.RemoverLivro(LivroId);
            if (Livros.Status)
            {
                return Ok(Livros);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Livros);
            }
        }

    }
}

