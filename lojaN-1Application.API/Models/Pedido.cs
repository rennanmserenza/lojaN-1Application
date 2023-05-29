using Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lojaN_1Application.API.Models
{
    [Table("pedido")]
    public class Pedido
    {
        [Key]
        [Required]
        [Column("cod_pedido")]
        public int CodPedido { get; set; }
        
        [Required]
        [Column("data_pedido")]
        public DateTime DataPedido { get; set; }

        [Required]
        [Column("endereco_entrega")]
        public string EnderecoEntrega { get; set; }

        [Required]
        [Column("vl_total")]
        public double ValorTotal { get; set; }

        [Required]
        [Column("dt_status")]
        public DateTime DataStatus { get; set; }

        [Column("cod_status")]
        public int CodStatus { get; set; }
        [Column("cod_cliente")]
        public int CodCliente { get; set; }

        public virtual StatusPedido StatusPedido { get; set; }
        public virtual Entrega Entrega { get; set; }
        public virtual ItemPedido ItemPedido { get; set; }

        public virtual Cliente Cliente { get; set; }

    }
}
