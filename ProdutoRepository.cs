using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class ProdutoRepository : IRepository<Produto>
{
    private string connectionString;

    public ProdutoRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Adicionar(Produto produto)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO produto (vendedor_id, categoria_id, descricao, preco, imagem, status) " +
                           "VALUES (@VendedorId, @CategoriaId, @Descricao, @Preco, @Imagem, @Status)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@VendedorId", produto.VendedorId);
                command.Parameters.AddWithValue("@CategoriaId", produto.CategoriaId);
                command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                command.Parameters.AddWithValue("@Preco", produto.Preco);
                command.Parameters.AddWithValue("@Imagem", produto.Imagem);
                command.Parameters.AddWithValue("@Status", produto.Status);

                command.ExecuteNonQuery();
            }
        }
    }

    public void Atualizar(Produto produto)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "UPDATE produto SET vendedor_id = @VendedorId, " +
                           "categoria_id = @CategoriaId, descricao = @Descricao, " +
                           "preco = @Preco, imagem = @Imagem, status = @Status " +
                           "WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", produto.Id);
                command.Parameters.AddWithValue("@VendedorId", produto.VendedorId);
                command.Parameters.AddWithValue("@CategoriaId", produto.CategoriaId);
                command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                command.Parameters.AddWithValue("@Preco", produto.Preco);
                command.Parameters.AddWithValue("@Imagem", produto.Imagem);
                command.Parameters.AddWithValue("@Status", produto.Status);

                command.ExecuteNonQuery();
            }
        }
    }

    public void Excluir(Produto produto)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "DELETE FROM produto WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", produto.Id);

                command.ExecuteNonQuery();
            }
        }
    }

    public Produto ObterPorId(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM produto WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Produto
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            VendedorId = Convert.ToInt32(reader["vendedor_id"]),
                            CategoriaId = Convert.ToInt32(reader["categoria_id"]),
                            Descricao = reader["descricao"].ToString(),
                            Preco = Convert.ToDecimal(reader["preco"]),
                            Imagem = reader["imagem"].ToString(),
                            Status = Convert.ToBoolean(reader["status"])
                        };
                    }
                }
            }

            return null;
        }
    }

    public List<Produto> ObterTodos()
    {
        List<Produto> produtos = new List<Produto>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM produto";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Produto produto = new Produto
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            VendedorId = Convert.ToInt32(reader["vendedor_id"]),
                            CategoriaId = Convert.ToInt32(reader["categoria_id"]),
                            Descricao = reader["descricao"].ToString(),
                            Preco = Convert.ToDecimal(reader["preco"]),
                            Imagem = reader["imagem"].ToString(),
                            Status = Convert.ToBoolean(reader["status"])
                        };

                        produtos.Add(produto);
                    }
                }
            }
        }

        return produtos;
    }
}
