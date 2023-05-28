using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lojaN_1Application.API.Models
{
    [Table("pessoa")]
    public class Pessoa
    {
        [Key]
        [Required]
        [Column("cod_pessoa")]
        public int CodPessoa { get; set; }

        [Required]
        [Column("nome_pessoa")]
        public string NomePessoa { get; set; }

        [Required]
        [Column("cod_grupo")]
        public int CodGrupo { get; set; }

        public virtual GrupoPermissao GrupoPermissao { get; set; }
    }
}
