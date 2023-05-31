using lojaN_1Application.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [Required]
        [Column("cod_cliente")]
        public int CodCliente { get; set; }

        [Column("nome_cliente")]
        [Required]
        public string Nome { get; set; }

        [Column("endereco")]
        public string Endereco { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [NotMapped]
        public string ConfirmaSenha { get; set; }

        [Column("senha_hash")]
        public string SenhaHash { get; set; }

        [Column("cod_pessoa")]
        public int CodPessoa { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual Pedido Pedido { get; set; }
        
    }
}
