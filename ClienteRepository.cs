using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class ClienteRepository : IRepository<Cliente>
{
    private string connectionString;

    public ClienteRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Adicionar(Cliente cliente)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO cliente (nome, cpf, email, senha) " +
                           "VALUES (@Nome, @CPF, @Email, @Senha)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nome", cliente.Nome);
                command.Parameters.AddWithValue("@CPF", cliente.CPF);
                command.Parameters.AddWithValue("@Email", cliente.Email);
                command.Parameters.AddWithValue("@Senha", cliente.Senha);

                command.ExecuteNonQuery();
            }
        }
    }

    public void Atualizar(Cliente cliente)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "UPDATE cliente SET nome = @Nome, cpf = @CPF, " +
                           "email = @Email, senha = @Senha " +
                           "WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", cliente.Id);
                command.Parameters.AddWithValue("@Nome", cliente.Nome);
                command.Parameters.AddWithValue("@CPF", cliente.CPF);
                command.Parameters.AddWithValue("@Email", cliente.Email);
                command.Parameters.AddWithValue("@Senha", cliente.Senha);

                command.ExecuteNonQuery();
            }
        }
    }

    public void Excluir(Cliente cliente)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "DELETE FROM cliente WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", cliente.Id);

                command.ExecuteNonQuery();
            }
        }
    }

    public Cliente ObterPorId(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM cliente WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Cliente
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nome = reader["nome"].ToString(),
                            CPF = Convert.ToInt64(reader["cpf"]),
                            Email = reader["email"].ToString(),
                            Senha = reader["senha"].ToString(),
                        };
                    }
                }
            }

            return null;
        }
    }

    public List<Cliente> ObterTodos()
    {
        List<Cliente> clientes = new List<Cliente>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM cliente";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nome = reader["nome"].ToString(),
                            CPF = Convert.ToInt64(reader["cpf"]),
                            Email = reader["email"].ToString(),
                            Senha = reader["senha"].ToString(),
                        };

                        clientes.Add(cliente);
                    }
                }
            }
        }

        return clientes;
    }
}
