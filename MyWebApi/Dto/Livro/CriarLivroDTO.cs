using MyWebApi.Data;
using MyWebApi.Dto.Vinculo;

namespace MyWebApi.Dto.Livro
{
    public class CriarLivroDTO
    {
        public string Titulo { get; set; } = string.Empty;
        public AutorVinculoDTO Autor { get; set; } = new AutorVinculoDTO();
    }
}
