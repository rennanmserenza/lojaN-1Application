using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("clientes")]
    public class Cliente
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("endereco")]
        public string Endereco { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("senha")]
        public string Senha { get; set; }



    }
}
