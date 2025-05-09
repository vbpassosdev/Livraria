using Microsoft.EntityFrameworkCore;

namespace API_Livraria
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }  // Exemplo de tabela
    }
}
