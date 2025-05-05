

public enum GeneroLivro
{
    Ficcao,
    Romance,
    Misterio,
    Fantasia,
    Biografia,
    Ciencia,
    Historia,
    Outro
}

public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public GeneroLivro Genero { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
}
