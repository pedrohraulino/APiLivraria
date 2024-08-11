namespace MyWebApi.Data
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty; // Inicialização padrão
        public AutorModel Autor { get; set; } = new AutorModel(); // Inicialização padrão
    }
}
