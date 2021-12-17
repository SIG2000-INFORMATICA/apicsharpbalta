using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Shop.Models
{
    public class OrderItemList
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]       
        public int idVendedor { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]    
        public int idPessoa { get; set; }

        public List<OrderItem> itens { get; set; }
        //public People pessoa { get; set; }

        public OrderItemList(int id, int idVendedor, int IdPessoa, List<OrderItem> itens)
        {
            this.id=id;
            this.idVendedor=idVendedor;
            this.idPessoa=idPessoa;
            this.itens=itens;
        }
    }
}