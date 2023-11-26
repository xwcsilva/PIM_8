using System;
using System.Collections.Generic;
using System.Data.SqlClient;
public class VendedorRepository : IRepository<Vendedor>
{
    private string connectionString;

    public VendedorRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Adicionar(Vendedor vendedor)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO vendedor (endereco_id, nome_fantasia, razao_social, cnpj, email, senha, comissao) " +
                           "VALUES (@EnderecoId, @NomeFantasia, @RazaoSocial, @Cnpj, @Email, @Senha, @Comissao)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EnderecoId", vendedor.EnderecoId);
                command.Parameters.AddWithValue("@NomeFantasia", vendedor.NomeFantasia);
                command.Parameters.AddWithValue("@RazaoSocial", vendedor.RazaoSocial);
                command.Parameters.AddWithValue("@Cnpj", vendedor.CNPJ);
                command.Parameters.AddWithValue("@Email", vendedor.Email);
                command.Parameters.AddWithValue("@Senha", vendedor.Senha);
                command.Parameters.AddWithValue("@Comissao", vendedor.Comissao);

                command.ExecuteNonQuery();
            }
        }
    }

    public void Atualizar(Vendedor vendedor)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "UPDATE vendedor SET endereco_id = @EnderecoId, " +
                           "nome_fantasia = @NomeFantasia, razao_social = @RazaoSocial, " +
                           "cnpj = @Cnpj, email = @Email, senha = @Senha, comissao = @Comissao " +
                           "WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", vendedor.Id);
                command.Parameters.AddWithValue("@EnderecoId", vendedor.EnderecoId);
                command.Parameters.AddWithValue("@NomeFantasia", vendedor.NomeFantasia);
                command.Parameters.AddWithValue("@RazaoSocial", vendedor.RazaoSocial);
                command.Parameters.AddWithValue("@Cnpj", vendedor.CNPJ);
                command.Parameters.AddWithValue("@Email", vendedor.Email);
                command.Parameters.AddWithValue("@Senha", vendedor.Senha);
                command.Parameters.AddWithValue("@Comissao", vendedor.Comissao);

                command.ExecuteNonQuery();
            }
        }
    }

    public void Excluir(Vendedor vendedor)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "DELETE FROM vendedor WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", vendedor.Id);

                command.ExecuteNonQuery();
            }
        }
    }

    public Vendedor ObterPorId(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM vendedor WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Vendedor
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            EnderecoId = Convert.ToInt32(reader["endereco_id"]),
                            NomeFantasia = reader["nome_fantasia"].ToString(),
                            RazaoSocial = reader["razao_social"].ToString(),
                            CNPJ = reader["cnpj"].ToString(),
                            Email = reader["email"].ToString(),
                            Senha = reader["senha"].ToString(),
                            Comissao = Convert.ToDecimal(reader["comissao"])
                        };
                    }
                }
            }

            return null;
        }
    }

    public List<Vendedor> ObterTodos()
    {
        List<Vendedor> vendedores = new List<Vendedor>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM vendedor";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Vendedor vendedor = new Vendedor
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            EnderecoId = Convert.ToInt32(reader["endereco_id"]),
                            NomeFantasia = reader["nome_fantasia"].ToString(),
                            RazaoSocial = reader["razao_social"].ToString(),
                            CNPJ = reader["cnpj"].ToString(),
                            Email = reader["email"].ToString(),
                            Senha = reader["senha"].ToString(),
                            Comissao = Convert.ToDecimal(reader["comissao"])
                        };

                        vendedores.Add(vendedor);
                    }
                }
            }
        }

        return vendedores;
    }
}
