using MyWebApi.Data;
using MyWebApi.Dto.Vinculo;

namespace MyWebApi.Dto.Livro
{
  public class EditarLivroDto
  {
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty; // Inicialização padrão
    public AutorVinculoDTO Autor { get; set; } = new AutorVinculoDTO(); // Inicialização padrão
  }
}
