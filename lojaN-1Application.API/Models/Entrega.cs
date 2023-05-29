using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace lojaN_1Application.API.Models
{
    [Table("entrega")]
    public class Entrega
    {
        [Key]
        [Required]
        [Column("cod_entrega")]
        public int CodEntrega { get; set; }

        [Required]
        [Column("cod_pedido")]
        public int CodPedido { get; set; }

        [Required]
        [Column("cod_status")]
        public int CodStatus { get; set; }

        [Required]
        [Column("dt_previsao")]
        public DateTime DataPrevisao { get; set; }

        [Required]
        [Column("dt_status")]
        public DateTime DataStatus { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual StatusEntrega StatusEntrega { get; set; }
    }
}
