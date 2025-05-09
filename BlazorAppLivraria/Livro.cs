namespace BlazorAppLivraria
{
 


    public enum GeneroLivro
    {
        Ficcao = 1 ,
        Romance = 2,
        Misterio = 3,
        Fantasia = 4,
        Biografia = 5,
        Ciencia = 6,
        Historia = 7 ,
        Outro = 8
    }

    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int Genero { get; set; } // <- alterado de GeneroLivro para int
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
    }

}
