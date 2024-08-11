using MyWebApi.Data;

namespace MyWebApi.Dto.Vinculo
{
  public class AutorVinculoDTO
  {
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
  }
}
