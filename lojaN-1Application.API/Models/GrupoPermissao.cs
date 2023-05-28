using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lojaN_1Application.API.Models
{
    [Table("grupo_permissao")]
    public class GrupoPermissao
    {
        [Required]
        [Key]
        [Column("cod_grupo")]
        public int CodGrupo { get; set; }

        [Required]
        [Column("desc_permissao")]
        public string DescPermissao { get; set; }
    }
}
