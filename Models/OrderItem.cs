using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class OrderItem
    {
        [Key]
        public int idpedido { get; set; }    
        public int idproduto { get; set; }    
        public int qtd { get; set; }
        public decimal unitario { get; set; }
        public decimal total { get; set; }

    
        //public Order order { get; set; }
    }
}