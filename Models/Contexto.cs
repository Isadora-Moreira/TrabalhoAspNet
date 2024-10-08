using Microsoft.EntityFrameworkCore;

namespace TrabalhoASPNet.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options) { }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
    }
}