using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pim_8
{
    public class Carrinho
    {
        private List<Produto> contem;
        private Cliente cliente;
        private StatusCarrinho status;

        public int id
        {
            get => default;
            set
            {
            }
        }

        public DateTime dataPedido
        {
            get => default;
            set
            {
            }
        }

        public decimal valoTotal
        {
            get => default;
            set
            {
            }
        }

        public List<Produto> produto
        {
            get => default;
            set
            {
            }
        }
    }
}