using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lojaN_1Application.API.Models
{
    [Table("item_pedido")]
    public class ItemPedido
    {
        [Key]
        [Required]
        [Column("cod_pedido")]
        public int CodPedido { get; set; }

        [Key]
        [Required]
        [Column("cod_produto")]
        public int CodProduto { get; set; }

        [Required]
        [Column("qtd_produto")]
        public int QtdProduto { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
