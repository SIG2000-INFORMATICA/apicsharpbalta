using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("clienteId")]
        public virtual Cliente cliente { get; set; }

        [ForeignKey("vendedorId")]
        public virtual Vendedor vendedor { get; set; }

        [Column("pedido_item")] 
        public virtual List<PedidoItem> pedidoItems { get; set; }

        public decimal total { get; set; }
    }
}