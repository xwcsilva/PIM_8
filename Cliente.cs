using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pim_8
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        // Lista de carrinhos associada a este cliente
        public List<Carrinho> Carrinhos { get; set; }

        public Endereco Endereco { get; set; }
    }
}