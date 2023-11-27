using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pim_8
{
    public class Carrinho
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }

        public System.Collections.Generic.List<ItemCarrinho> Itens { get; set; }

        public StatusCarrinho StatusCarrinho { get; set; }

        public Cliente Cliente { get; set; }
    }
}