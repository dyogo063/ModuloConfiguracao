using Models;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;

namespace DAL
{
    public class PermissaoDAL
    {
        public void Inserir(Permissao _permissao)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Permissao(Id, Descricao) Values(@Id, @Descricao)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _permissao.Id);
                cmd.Parameters.AddWithValue("@Descricao", _permissao.Descricao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao inserir no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Permissao> BuscarTodos()
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            List<Permissao> Permissoes = new List<Permissao>();
            Permissao Permissao;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id, Descricao  WHERE (@Id, @Descricao)";
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Permissao = new Permissao();
                        Permissao.Id = Convert.ToInt32(rd["Id"]);
                        Permissao.Descricao = rd["NomeGrupo"].ToString();

                        Permissoes.Add(Permissao);
                    }
                }
                return Permissoes;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar todos os usuarios no banco de dados. ", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Permissao> BuscarPorDescricao(string _descricao)
        {
            List<Permissao> permissoes = new List<Permissao>();
            Permissao permissao = new Permissao();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Id, Descricao FROM Permissao WHERE Descricao LIKE @Descricao";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Dsecricao" ,"%" + _descricao + "%");
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        permissao = new Permissao();
                        permissao.Id = Convert.ToInt32(rd["Id"]);
                        permissao.Descricao = rd["Descricao"].ToString();


                    }


                }
                return permissoes;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar o usuario no banco de dados. ", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public Permissao BuscarPorId(int _id)
        {
            List<Permissao> Permissoes = new List<Permissao>();
            Permissao Permissao = new Permissao();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id, Descricao  WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        Permissao = new Permissao();
                        Permissao.Id = Convert.ToInt32(rd["Id"]);
                        Permissao.Descricao = rd["Descricao"].ToString();
                        Permissoes.Add(Permissao);

                    }
                }
                return Permissao;
            }

            catch (Exception ex)
            {
                throw new Exception($"ocorreu um erro ao buscar por id", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Alterar(Permissao _permissao)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"UPDATE Permissao SET Descricao = @Descricao WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Descricao", _permissao.Descricao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao alterar no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }

        }
        public void Excluir(int _id)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "DELETE FROM Permissao WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _id);


            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao exluir no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}  



