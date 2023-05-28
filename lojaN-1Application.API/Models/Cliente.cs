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

        public int CodPessoa { get; set; }

        public virtual Pessoa Pessoa { get; set; }



    }
}
