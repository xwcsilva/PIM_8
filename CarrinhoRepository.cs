using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class CarrinhoRepository : IRepository<Carrinho>
{
    private string connectionString;

    public CarrinhoRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Adicionar(Carrinho carrinho)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        string query = "INSERT INTO carrinho (cliente_id, status_carrinho_id, data_pedido, valor_total) " +
                       "VALUES (@ClienteId, @StatusCarrinhoId, @DataPedido, @ValorTotal)";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@ClienteId", carrinho.ClienteId);
            command.Parameters.AddWithValue("@StatusCarrinhoId", carrinho.StatusCarrinhoId);
            command.Parameters.AddWithValue("@DataPedido", carrinho.DataPedido);
            command.Parameters.AddWithValue("@ValorTotal", carrinho.ValorTotal);

            command.ExecuteNonQuery();
        }
    }

    public void Atualizar(Carrinho carrinho)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "UPDATE carrinho SET cliente_id = @ClienteId, " +
                           "status_carrinho_id = @StatusCarrinhoId, data_pedido = @DataPedido, " +
                           "valor_total = @ValorTotal " +
                           "WHERE Id = @Id";

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", carrinho.Id);
                command.Parameters.AddWithValue("@ClienteId", carrinho.ClienteId);
                command.Parameters.AddWithValue("@StatusCarrinhoId", carrinho.StatusCarrinhoId);
                command.Parameters.AddWithValue("@DataPedido", carrinho.DataPedido);
                command.Parameters.AddWithValue("@ValorTotal", carrinho.ValorTotal);

                command.ExecuteNonQuery();
            }
        }
    }

    public void Excluir(Carrinho carrinho)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "DELETE FROM carrinho WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", carrinho.Id);

                command.ExecuteNonQuery();
            }
        }
    }

    public Carrinho ObterPorId(int id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM carrinho WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Carrinho
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            ClienteId = Convert.ToInt32(reader["cliente_id"]),
                            StatusCarrinhoId = Convert.ToInt32(reader["status_carrinho_id"]),
                            DataPedido = Convert.ToDateTime(reader["data_pedido"]),
                            ValorTotal = Convert.ToDecimal(reader["valor_total"]),
                        };
                    }
                }
            }

            return null;
        }
    }

    public List<Carrinho> ObterTodos()
    {
        List<Carrinho> carrinhos = new List<Carrinho>();

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM carrinho";

            using (var command = new SqlCommand(query, connection))
            {
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Carrinho carrinho = new Carrinho
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        ClienteId = Convert.ToInt32(reader["cliente_id"]),
                        StatusCarrinhoId = Convert.ToInt32(reader["status_carrinho_id"]),
                        DataPedido = Convert.ToDateTime(reader["data_pedido"]),
                        ValorTotal = Convert.ToDecimal(reader["valor_total"]),
                    };

                    carrinhos.Add(carrinho);
                }
            }
        }

        return carrinhos;
    }
}
