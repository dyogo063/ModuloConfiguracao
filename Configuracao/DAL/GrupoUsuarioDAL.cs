using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class GrupoUsuarioDAL
    {
        public void Inserir(GrupoUsuario _Grupousuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO GrupoUsuario( NomeGrupo) Values(@NomeGrupo)";
                cmd.CommandType = System.Data.CommandType.Text;
      
                cmd.Parameters.AddWithValue("@NomeGrupo", _Grupousuario.NomeGrupo);
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
              

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
        public List<GrupoUsuario> BuscarTodos()
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            List<GrupoUsuario> GrupoUsuarios = new List<GrupoUsuario>();
            GrupoUsuario GrupoUsuario;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id, NomeGrupo FROM GrupoUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        GrupoUsuario = new GrupoUsuario();
                        GrupoUsuario.Id = Convert.ToInt32(rd["Id"]);
                        GrupoUsuario.NomeGrupo = rd["NomeGrupo"].ToString();
  
                        GrupoUsuarios.Add(GrupoUsuario);
                    }
                }
                return GrupoUsuarios;
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
        public List<GrupoUsuario> BuscarPorNomeGrupo(string _nomeGrupo)
        {
            List<GrupoUsuario> Grupousuarios = new List<GrupoUsuario>();
            GrupoUsuario Grupousuario = new GrupoUsuario();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Id, NomeGrupo
                                  FROM GrupoUsuario WHERE NomeGrupo LIKE @NomeGrupo";

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@NomeGrupo", "%" + _nomeGrupo + "%");

                cn.Open();
                

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Grupousuario = new GrupoUsuario();
                        Grupousuario.Id = Convert.ToInt32(rd["Id"]);
                        Grupousuario.NomeGrupo = rd["NomeGrupo"].ToString();
                    }


                }
                return Grupousuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar alterar o usuario no banco de dados. ", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public GrupoUsuario BuscarPorId(int _id)
        {
            
            GrupoUsuario Grupousuario = new GrupoUsuario();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id, NomeGrupo  WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        Grupousuario = new GrupoUsuario();
                        Grupousuario.Id = Convert.ToInt32(rd["Id"]);
                        Grupousuario.NomeGrupo = rd["Nome"].ToString();
                      

                    }
                }
                return Grupousuario;
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
        public void Alterar(GrupoUsuario _grupoUsuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"UPDATE GrupoUsuario SET NomeGrupo = @NomeGrupo WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@NomeGrupo", _grupoUsuario.NomeGrupo);
                cmd.Connection = cn;   
                cn.Open();
                cmd.ExecuteNonQuery();
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
                cmd.CommandText = @"DELETE FROM GrupoUsuario WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _id);
                cmd.Connection=cn;
                cn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao deletar no banco de dados", ex);
            }
            finally
            {
                cn.Close();
            }

        }
        public List<GrupoUsuario> BuscarPorIdUsuario(int _idUsuario)
        {
            List<GrupoUsuario> Grupousuarios = new List<GrupoUsuario>();
            GrupoUsuario Grupousuario = new GrupoUsuario();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT GrupoUsuario.Id, GrupoUsuario.NomeGrupo FROM GrupoUsuario INNER JOIN UsuarioGrupoUsuario ON GrupoUsuario.Id = UsuarioGrupoUsuario.IdGrupoUsuario WHERE UsuarioGrupoUsuario.IdUsuario = @IdUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@IdUsuario", _idUsuario);

                cn.Open();
                
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Grupousuario = new GrupoUsuario();
                        Grupousuario.Id = Convert.ToInt32(rd["Id"]);
                        Grupousuario.NomeGrupo = rd["NomeGrupo"].ToString();
                        Grupousuarios.Add(Grupousuario);

                    }
                }
                return Grupousuarios;
            }

            catch (Exception ex)
            {
                throw new Exception($"ocorreu um erro ao buscar por id de usuário", ex);
            }
            finally
            {
                cn.Close();
            }
        }

    }
}
