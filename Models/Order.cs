using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]       
        public int idVendedor { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]    
        public int idPessoa { get; set; }

        [Range(0, int.MinValue, ErrorMessage = "O valor não pode ser nullo")]
        public decimal total { get; set; }
        public People pessoa { get; set; }
    }
}