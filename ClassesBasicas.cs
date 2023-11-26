using System;

public class Endereco
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public string Cep { get; set; }
}

public class Vendedor
{
    public int Id { get; set; }
    public int EnderecoId { get; set; }
    public string NomeFantasia { get; set; }
    public string RazaoSocial { get; set; }
    public string CNPJ { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public decimal Comissao { get; set; }

    // Adicionando a propriedade de navegação para o Endereco
    public Endereco Endereco { get; set; }

  
}

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
}
public class Produto
{
    public int Id { get; set; }
    public int VendedorId { get; set; }
    public int CategoriaId { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public string Imagem { get; set; }
    public bool Status { get; set; }

    // Adicionando propriedades de navegação para o Vendedor e Categoria
    public Vendedor Vendedor { get; set; }
    public Categoria Categoria { get; set; }
}


public class Carrinho
{
    public int Id { get; set; }
    public int ClienteId { get; set; }  // Referência ao cliente a quem pertence o carrinho
    public int StatusCarrinhoId { get; set; }
    public DateTime DataPedido { get; set; }
    public decimal ValorTotal { get; set; }

    // Adicionando propriedade de navegação para o Cliente
    public Cliente Cliente { get; set; }

    // Adicionando propriedade de navegação para o StatusCarrinho
    public StatusCarrinho StatusCarrinho { get; set; }

    // Lista de itens associada a este carrinho
    public List<ItemCarrinho> ItensCarrinho { get; set; }
}

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public long CPF { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }

    // Lista de carrinhos associada a este cliente
    public List<Carrinho> Carrinhos { get; set; }
}
public class StatusCarrinho
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
}


public class ItemCarrinho
{
    public int Id { get; set; }
    public int CarrinhoId { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal Total { get; set; }
}

