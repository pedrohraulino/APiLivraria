using MyWebApi.Models;
using MyWebApi.Data;
using MyWebApi.Dto.Autor;

namespace MyWebApi.Services.Autor
{
  public interface IAutorInterface
  {
    Task<ResponseModel<List<AutorModel>>> ListarAutores();
    Task<ResponseModel<AutorModel>> BuscarAutorPorId(int autorId);
    Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int livroId);
    Task<ResponseModel<List<AutorModel>>> CadastrarAutor(AutorCriacaoDto autorCriacaoDto);
    Task<ResponseModel<List<AutorModel>>> EditarAutor(EditarAutorDto editarAutorDto);
    Task<ResponseModel<List<AutorModel>>> RemoverAutor(int autorId);
  }
}
