using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pim_8
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
        public string Status { get; set; }

        public List<Pim_8.Vendedor> Vendedores { get; set; }

        public Pim_8.Categoria Categoria { get; set; }

        public List<Pim_8.ItemCarrinho> Itens { get; set; }
    }
}