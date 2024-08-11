namespace MyWebApi.Dto.Autor
{
  public class EditarAutorDto
  {
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
  }
}
