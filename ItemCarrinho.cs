using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pim_8
{
    public class ItemCarrinho
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
        
        public Produto Produto { get; set; }

        public Carrinho Carrinho { get; set; }
    }
}