namespace Pim_8
{
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
}