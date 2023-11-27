using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Pim_8
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
  

    public class CarrinhoRepository : IRepository<Carrinho>
    {
        private readonly string connectionString;

        public CarrinhoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Adicionar(Carrinho entidade)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Carrinho (id, cliente_id, status_carrinho_id, data_pedido, valor_total) VALUES (SELECT SCOPE_IDENTITY(), @ClienteId, @StatusCarrinhoId, @DataPedido, @ValorTotal);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClienteId", entidade.Cliente.Id);
                    command.Parameters.AddWithValue("@StatusCarrinhoId", entidade.StatusCarrinho.Id);
                    command.Parameters.AddWithValue("@DataPedido", entidade.DataPedido);
                    command.Parameters.AddWithValue("@ValorTotal", entidade.ValorTotal);
                }
            }
        }

        public void Atualizar(Carrinho entidade)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Carrinho SET cliente_id = @ClienteId, status_carrinho_id = @StatusCarrinhoId, data_pedido = @DataPedido, valor_total = @ValorTotal WHERE Id = @CarrinhoId;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClienteId", entidade.Cliente.Id);
                    command.Parameters.AddWithValue("@StatusCarrinhoId", entidade.StatusCarrinho.Id);
                    command.Parameters.AddWithValue("@DataPedido", entidade.DataPedido);
                    command.Parameters.AddWithValue("@ValorTotal", entidade.ValorTotal);
                    command.Parameters.AddWithValue("@CarrinhoId", entidade.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Excluir(Carrinho entidade)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Carrinho WHERE Id = @CarrinhoId;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarrinhoId", entidade.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Carrinho ObterPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Carrinho WHERE Id = @CarrinhoId;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarrinhoId", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapToCarrinho(reader);
                        }
                    }
                }

                return null;
            }
        }

        public List<Carrinho> ObterTodos()
        {
            List<Carrinho> carrinhos = new List<Carrinho>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Carrinho;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Carrinho carrinho = MapToCarrinho(reader);
                            carrinhos.Add(carrinho);
                        }
                    }
                }
            }

            return carrinhos;
        }

        private Carrinho MapToCarrinho(SqlDataReader reader)
        {
            return new Carrinho
            {
                Id = (int)reader["Id"],
                //ClienteRepository. = ClienteRepository. (int)reader["ClienteId"],
                //StatusCarrinhoId = (int)reader["StatusCarrinhoId"],
                DataPedido = (DateTime)(reader["DataPedido"] == DBNull.Value ? null : (DateTime?)reader["DataPedido"]),
                ValorTotal = (decimal)(reader["ValorTotal"] != DBNull.Value ? (decimal?)reader["ValorTotal"] : null)
                // Mapeie outras propriedades conforme necessário
            };
        }
    }

}