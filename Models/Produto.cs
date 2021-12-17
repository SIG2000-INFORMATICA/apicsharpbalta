using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models {
    public class Produto {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal preco { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria Inválida")]
        [Column("categoria_id")]
        public int categoriaId { get; set; }

        [ForeignKey("categoriaId")]
        public virtual Categoria categoria {get; set; }

        public int quantidade { get; set; }
    }
}