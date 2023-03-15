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
                cmd.CommandText = @"INSERT INTO Usuario(Nome, NomeUsuario, Email,CPF, Ativo, Senha)
                                     VALUES (@Nome, @NomeUsuario, @Email, @CPF, @Ativo, @Senha)";
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu erro ao tentar inserir um usuario{ex.Message}");
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

        }
        public void Excluir(int _id)
        {

        }
    }
}
