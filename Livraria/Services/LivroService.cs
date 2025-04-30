   using global::LivrariaApi.Models;
    using System.Xml.Linq;
    using LivrariaApi.Models;

    namespace LivrariaApi.Services;

    public class LivroService
    {
        private readonly List<Livro> _livros = new();
        private int _proximoId = 1;

        public List<Livro> ObterTodos() => _livros;

        public Livro? ObterPorId(int id) => _livros.FirstOrDefault(l => l.Id == id);

        public Livro Criar(Livro livro)
        {
            livro.Id = _proximoId++;
            _livros.Add(livro);
            return livro;
        }

        public bool Atualizar(int id, Livro livroAtualizado)
        {
            var livro = ObterPorId(id);
            if (livro == null) return false;

            livro.Titulo = livroAtualizado.Titulo;
            livro.Autor = livroAtualizado.Autor;
            livro.Genero = livroAtualizado.Genero;
            livro.Preco = livroAtualizado.Preco;
            livro.QuantidadeEstoque = livroAtualizado.QuantidadeEstoque;
            return true;
        }

        public bool Remover(int id)
        {
            var livro = ObterPorId(id);
            if (livro == null) return false;
            _livros.Remove(livro);
            return true;
        }
    }


