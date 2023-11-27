
using Pim_8;

class Program
    {
        static void Main()
        {
            // Substitua "sua_string_de_conexao" pela sua string de conexão real
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;";
            CarrinhoRepository carrinhoRepository = new CarrinhoRepository(connectionString);


            // Adicionar um novo carrinho
            Carrinho novoCarrinho = new Carrinho();
            Cliente cliente = new Cliente(); 
            StatusCarrinho statusCarrinho = new StatusCarrinho();
            
            cliente.Id = 1; cliente.CPF = 883044; cliente.Nome = "Teste";
            statusCarrinho.Descricao = "Novo"; statusCarrinho.Id = 1;

            novoCarrinho.Cliente = cliente;
            novoCarrinho.StatusCarrinho = statusCarrinho; 
            novoCarrinho.DataPedido = DateTime.Now;
            novoCarrinho.ValorTotal = 0.0m; // Substitua pelo valor real


            carrinhoRepository.Adicionar(novoCarrinho);

            // Obter todos os carrinhos
            List<Carrinho> carrinhos = carrinhoRepository.ObterTodos();
            Console.WriteLine("Lista de Carrinhos:");
            foreach (var carrinho in carrinhos)
            {
                Console.WriteLine($"ID: {carrinho.Id}, ID: {carrinho.Id}, Data Pedido: {carrinho.DataPedido}, Valor Total: {carrinho.ValorTotal}");
            }

            // Atualizar o carrinho (supondo que você já tenha um carrinho com ID 1 no banco de dados)
            Carrinho carrinhoAtualizado = carrinhoRepository.ObterPorId(1);
            if (carrinhoAtualizado != null)
            {
                carrinhoAtualizado.ValorTotal = 50.0m; // Atualize conforme necessário
                carrinhoRepository.Atualizar(carrinhoAtualizado);
            }

            // Excluir um carrinho (supondo que você já tenha um carrinho com ID 2 no banco de dados)
            Carrinho carrinhoParaExcluir = carrinhoRepository.ObterPorId(2);
            if (carrinhoParaExcluir != null)
            {
                carrinhoRepository.Excluir(carrinhoParaExcluir);
            }

            Console.ReadLine(); // Aguarde a entrada do usuário antes de fechar o console
        }
    }
