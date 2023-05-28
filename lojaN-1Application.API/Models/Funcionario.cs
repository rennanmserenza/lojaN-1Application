using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lojaN_1Application.API.Models
{
    [Table("funcionario")]
    public class Funcionario
    {
        [Required]
        [Key]
        [Column("cod_funcionario")]
        public int CodFuncionario { get; set; }

        [Required]
        [Column("cod_pessoa")]
        public int CodPessoa { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
