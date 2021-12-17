using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class People
    {
        [Key]
        public int id { get; set; }
        
        [MaxLength(18, ErrorMessage = "Este campo deve conter entre 14 e 18 caracteres")]
        [MinLength(14, ErrorMessage = "Este campo deve conter entre 14 e 18 caracteres")]     
        public string cgc { get; set; }
        public string nome { get; set; }
        public int tipo { get; set; }
    }
}