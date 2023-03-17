using DAL;
using Models;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class UsuarioBLL
    {

        public void Inserir(Usuario _usuario)
        {
           
    
            
        }
        private void Alterar(Usuario _usuario)
        {
            ValidarDados(_usuario);

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Alterar(_usuario);
            
        }
        private void ValidarDados(Usuario _usuario)
        {
            if (_usuario.Senha.Length <= 3)
             throw new Exception("A senha deve ter mais de 3 caracteres");
            if (_usuario.Nome.Length <= 2)
                throw new Exception("O nome deve ter mais de 2 caracteres");

            }
        public void Excluir(int _id)
        {
            new UsuarioDAL().Excluir(_id);

        }
        public List<Usuario> BuscarTodos()
        {
            return new UsuarioDAL().BuscarTodos();
        }
        public Usuario BuscarPorId(int _id)
        {
            return new UsuarioDAL().BuscarPorId(_id);   
        }
        public Usuario BuscarPorCpf(string _cpf)
        {
            return new UsuarioDAL().BuscarPorCpf(_cpf);
        }
        public List<Usuario> BuscarPorNome( string _nome)
        {
            return new UsuarioDAL().BuscarPorNome(_nome);
        }
        public Usuario BuscarPorNomeUsuario(string _nomeUsuario)
        {
            return new UsuarioDAL().BuscarPorNomeusuario(_nomeUsuario);
        }
          

    }
}
