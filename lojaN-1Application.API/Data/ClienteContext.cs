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
