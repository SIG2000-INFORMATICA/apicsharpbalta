using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class OrderItem
    {
        [Key]
        public int idPedido { get; set; }    
        public int idProduto { get; set; }    
        public int qtd { get; set; }
        public decimal unitario { get; set; }
        public decimal total { get; set; }

    
        //public Order order { get; set; }
    }
}