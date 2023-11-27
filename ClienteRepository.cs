using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Pim_8
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly string connectionString;

        public ClienteRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Adicionar(Cliente entidade)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Cliente (Nome, Cpf, Email, Senha) VALUES (@Nome, @Cpf, @Email, @Senha); SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", entidade.Nome);
                    command.Parameters.AddWithValue("@Cpf", entidade.CPF);
                    command.Parameters.AddWithValue("@Email", entidade.Email);
                    command.Parameters.AddWithValue("@Senha", entidade.Senha);

                    entidade.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public void Atualizar(Cliente entidade)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Cliente SET Nome = @Nome, Cpf = @Cpf, Email = @Email, Senha = @Senha WHERE Id = @ClienteId;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nome", entidade.Nome);
                    command.Parameters.AddWithValue("@Cpf", entidade.CPF);
                    command.Parameters.AddWithValue("@Email", entidade.Email);
                    command.Parameters.AddWithValue("@Senha", entidade.Senha);
                    command.Parameters.AddWithValue("@ClienteId", entidade.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Excluir(Cliente entidade)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Cliente WHERE Id = @ClienteId;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClienteId", entidade.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Cliente ObterPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Cliente WHERE Id = @ClienteId;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClienteId", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapToCliente(reader);
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

                string query = "SELECT * FROM Cliente;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = MapToCliente(reader);
                            clientes.Add(cliente);
                        }
                    }
                }
            }

            return clientes;
        }

        private Cliente MapToCliente(SqlDataReader reader)
        {
            return new Cliente
            {
                Id = (int)reader["Id"],
                Nome = reader["Nome"].ToString(),
                CPF = (long)(reader["Cpf"] != DBNull.Value ? (long?)reader["Cpf"] : null),
                Email = reader["Email"].ToString(),
                Senha = reader["Senha"].ToString()
                // Mapeie outras propriedades conforme necessário
            };
        }
    }
}