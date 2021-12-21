using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Shop.Models {
    public class PedidoItem {       
        [Key]
        public int id { get; set; }

        [Required]
        [Column("pedido_id")]
        public int pedidoId { get; set; }   

        [Required]
        [Column("produto_id")] 
        public int produtoId { get; set; }  

        [JsonIgnore]
        [ForeignKey("pedidoId")]
        public virtual Pedido pedido { get; set; }  

        [JsonIgnore]
        [ForeignKey("produtoId")]
        public virtual Produto produto { get; set; }
        public int qtd { get; set; }
        public decimal unitario { get; set; }
        public decimal total { get; set; }
    }
}