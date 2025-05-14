namespace BlazorAppLivraria
{
 


    public enum GeneroLivro
    {
        Ficcao = 0 ,
        Romance = 1,
        Misterio = 2,
        Fantasia = 3,
        Biografia = 4,
        Ciencia = 5,
        Historia = 6 ,
        Outro = 7
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
