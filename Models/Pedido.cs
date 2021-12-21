using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Shop.Models {
    public class Pedido {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]   
        [Column("cliente_id")]
        public int clienteId { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")] 
        [Column("vendedor_id")] 
        public int vendedorId { get; set; }

        [JsonIgnore]
        [ForeignKey("clienteId")]
        public virtual Cliente cliente { get; set; }

        [JsonIgnore]
        [ForeignKey("vendedorId")]
        public virtual Vendedor vendedor { get; set; }

        [Column("pedido_item")] 
        public virtual List<PedidoItem> pedidoItems { get; set; }

        public decimal total { get; set; }
    }
}