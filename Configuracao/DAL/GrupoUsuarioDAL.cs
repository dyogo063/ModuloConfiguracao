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
                cmd.CommandText = @"INSERT INTO GrupoUsuario(Id, NomeGrupo) Values(@Id, @NomeGrupo)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _Grupousuario.Id);
                cmd.Parameters.AddWithValue("@NomeGrupo", _Grupousuario.NomeGrupo);
              

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
            throw new NotImplementedException();
        }
        public List<GrupoUsuario> BuscarPorNomeGrupo(string _nomeGrupo)
        {
            throw new NotImplementedException();
        }
        public List<GrupoUsuario> BuscarPorId(int _id)
        {
            throw new NotImplementedException();
        }
        public void Alterar(GrupoUsuario _grupoUsuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"UPDATE INTO GrupoUsuario(Id, NomeGrupo) Values(@Id, @NomeGrupo)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _grupoUsuario.Id);
                cmd.Parameters.AddWithValue("@NomeUsuario", _grupoUsuario.NomeGrupo);
          

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
                cmd.CommandText = "DELETE FROM GrupoUsuario WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _id);


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
    }
}
