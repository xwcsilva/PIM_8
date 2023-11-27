using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pim_8
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public decimal Comissao { get; set; }

        public List<Pim_8.Produto> Produtos { get; set; }

        public Pim_8.Endereco Endereco { get; set; }
    }
}