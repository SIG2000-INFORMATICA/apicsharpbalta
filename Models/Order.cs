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
        public decimal total { get; set; }
        //public People pessoa { get; set; }
    }
}