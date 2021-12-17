using System.ComponentModel.DataAnnotations;

namespace Shop.Models {
    public abstract class Pessoa {

        [Key]
        public int id { get; set; }
        
        [MaxLength(18, ErrorMessage = "Este campo deve conter entre 14 e 18 caracteres")]
        [MinLength(14, ErrorMessage = "Este campo deve conter entre 14 e 18 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string cgc { get; set; }

        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string nome { get; set; }

        public virtual Pedido pedido { get; set; }
    }
}