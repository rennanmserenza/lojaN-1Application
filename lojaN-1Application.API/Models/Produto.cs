using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lojaN_1Application.API.Models
{
    [Table("produto")]
    public class Produto
    {
        [Column("cod_produto")]
        [Key]
        [Required]
        public int CodProduto { get; set; }

        [Column("nome_produto")]
        [Required]
        public string NomeProduto { get; set; }

        [Column("marca")]
        public string Marca { get; set; }

        [Column("tamanho")]
        public int Tamanho { get; set; }

        [Column("cor")]
        public string Cor { get; set; }

        [Column("preco")]
        public double Preco { get; set; }

        public virtual ItemPedido ItemPedido { get; set; }
    }
}
