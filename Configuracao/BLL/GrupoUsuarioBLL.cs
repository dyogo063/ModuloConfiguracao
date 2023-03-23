using DAL;
using Models;
using System.Collections.Generic;

namespace BLL
{
    public class GrupoUsuarioBLL
    {
        public void Inserir(GrupoUsuario _grupousuario)
        {
            ValidarDados(_grupousuario);
            GrupoUsuarioDAL usuarioDAL = new GrupoUsuarioDAL();
            usuarioDAL.Inserir(_grupousuario);
        }
        public void Excluir(int id)
        {
            new GrupoUsuarioDAL().Excluir(id);
        }
        public List<GrupoUsuario> BuscarTodos()
        {
            return new GrupoUsuarioDAL().BuscarTodos();
        }
        public List<GrupoUsuario> BuscarPorNomeGrupo(string _nomegrupo)
        {
            return new GrupoUsuarioDAL().BuscarPorNomeGrupo(_nomegrupo);
        }
        public GrupoUsuario BuscarPorId(int _id)
        {
            return new GrupoUsuarioDAL().BuscarPorId(_id);
        }
        public void Alterar(GrupoUsuario _grupousuario)
        {
            ValidarDados(_grupousuario);

            new GrupoUsuarioDAL().Alterar(_grupousuario);
        }
        private void ValidarDados(GrupoUsuario _grupousuario)
        {
            if (_grupousuario.NomeGrupo.Length <= 3)
                throw new System.Exception("O nome do grupo deve ter mais de 3 caracteres");
        }
    }

}

