using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lojaN_1Application.API.Models
{
    [Table("status_pedido")]
    public class StatusPedido
    {
        [Required]
        [Key]
        [Column("cod_status")]
        public int CodStatus { get; set; }

        [Required]
        [Column("desc_status")]
        public string DescStatus { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
