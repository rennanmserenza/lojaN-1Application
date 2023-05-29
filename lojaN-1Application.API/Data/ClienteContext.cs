using Models;
using Microsoft.EntityFrameworkCore;
using lojaN_1Application.API.Models;

namespace Data
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemPedido>().HasKey(u => new
            {
                u.CodProduto,
                u.CodPedido
            });

            //Foreign keys
            //Tabela Funcionario
            modelBuilder.Entity<Pessoa>()
                .HasOne(pessoa => pessoa.Funcionario)
                .WithOne(func => func.Pessoa)
                .HasForeignKey<Funcionario>(pessoa => pessoa.CodPessoa)
                .OnDelete(DeleteBehavior.Restrict);

            //Tabela CLiente
            modelBuilder.Entity<Pessoa>()
                .HasOne(pessoa => pessoa.Cliente)
                .WithOne(cliente => cliente.Pessoa)
                .HasForeignKey<Cliente>(pessoa => pessoa.CodPessoa)
                .OnDelete(DeleteBehavior.Restrict);

            //Tabela Pessoa
            modelBuilder.Entity<GrupoPermissao>()
                .HasOne(perm => perm.Pessoa)
                .WithOne(pessoa => pessoa.GrupoPermissao)
                .HasForeignKey<Pessoa>(pessoa => pessoa.CodGrupo)
                .OnDelete(DeleteBehavior.SetNull);

            //Tabela Pedido
            modelBuilder.Entity<StatusPedido>()
                .HasOne(status => status.Pedido) 
                .WithOne(pedido => pedido.StatusPedido)
                .HasForeignKey<Pedido>(pedido => pedido.CodPedido)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Cliente>()
                .HasOne(cliente => cliente.Pedido)
                .WithOne(pedido => pedido.Cliente)
                .HasForeignKey<Pedido>(pedido => pedido.CodCliente)
                .OnDelete(DeleteBehavior.NoAction);

            //Tabela Item Pedido
            modelBuilder.Entity<Pedido>()
                .HasOne(item => item.ItemPedido)
                .WithOne(pedido => pedido.Pedido)
                .HasForeignKey<ItemPedido>(pedido => pedido.CodPedido)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Produto>()
                .HasOne(produto => produto.ItemPedido)
                .WithOne(item => item.Produto)
                .HasForeignKey<ItemPedido>(item => item.CodProduto)
                .OnDelete(DeleteBehavior.Restrict);

            //Tabela Entrega
            modelBuilder.Entity<StatusEntrega>()
                .HasOne(status => status.Entrega)
                .WithOne(entrega => entrega.StatusEntrega)
                .HasForeignKey<Entrega>(entrega => entrega.CodStatus)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Pedido>()
                .HasOne(pedido => pedido.Entrega)
                .WithOne(entrega => entrega.Pedido)
                .HasForeignKey<Entrega>(entrega => entrega.CodPedido)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<StatusEntrega> StatusEmpresas { get; set; }
        public DbSet<StatusPedido> StatusPedidos { get; set; }
        public DbSet<GrupoPermissao> GrupoPermissoes { get; set; }
        public DbSet<ItemPedido> ItemPedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
    }
}
