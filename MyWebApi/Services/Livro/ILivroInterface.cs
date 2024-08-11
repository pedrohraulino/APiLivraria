using MyWebApi.Models;
using MyWebApi.Data;
using MyWebApi.Dto.Livro;

namespace MyWebApi.Services.Livro
{
  public interface ILivroInterface
  {
    Task<ResponseModel<List<LivroModel>>> ListarLivros();
    Task<ResponseModel<LivroModel>> BuscarLivroPorId(int livroId);
    Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int autorId);
    Task<ResponseModel<List<LivroModel>>> CadastrarLivro(CriarLivroDTO criarLivroDTO);
    Task<ResponseModel<List<LivroModel>>> EditarLivro(EditarLivroDto editarLivroDto);
    Task<ResponseModel<List<LivroModel>>> RemoverLivro(int livroId);
  }
}
