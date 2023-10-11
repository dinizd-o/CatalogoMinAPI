using CatalogoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoApi.Context
{
    public class AppDbContext : DbContext
    {

        //instancia de DBContextOptions carrega as informaçoes
        //de configuracoes necessarias pro contexto, como a string de conexão e o provedor
        //do banco de dados. o base(options) é pra passar isso pra classe base
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //categoria
            mb.Entity<Categoria>().HasKey(c => c.CategoriaId);

            mb.Entity<Categoria>().Property(c => c.Nome)
                                  .HasMaxLength(100)
                                  .IsRequired();

            mb.Entity<Categoria>().Property(c => c.Descricao)
                                  .HasMaxLength(150)
                                   .IsRequired();

            //produto
            mb.Entity<Produto>().HasKey(c => c.ProdutoId);

            mb.Entity<Produto>().Property(c => c.Nome)
                                .HasMaxLength(100)
                                .IsRequired();

            mb.Entity<Produto>().Property(c => c.Descricao)
                                .HasMaxLength(100);

            mb.Entity<Produto>().Property(c => c.Imagem)
                                .HasMaxLength(100);

            mb.Entity<Produto>().Property(c => c.Preco)
                                .HasPrecision(14, 2);

            //relacionamento 

            mb.Entity<Produto>()
                .HasOne<Categoria>(c => c.Categoria)
                 .WithMany(p => p.Produtos)
                    .HasForeignKey(c =>  c.CategoriaId);
                                
        }
    }
}
