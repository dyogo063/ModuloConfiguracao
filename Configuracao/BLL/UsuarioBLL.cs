using DAL;
using Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace BLL
{
    public class UsuarioBLL
    {

        public void Inserir(Usuario _usuario, string _confirmacaoDeSenha)
        {
           ValidarPermissao(2);
           ValidarDados(_usuario,  _confirmacaoDeSenha);

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Inserir(_usuario);  
        }
        public void Alterar(Usuario _usuario, string _confirmacaoDeSenha)
        {
            ValidarPermissao(3);
            ValidarDados(_usuario, _confirmacaoDeSenha);

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Alterar(_usuario);
            
        }
        private void ValidarDados(Usuario _usuario, string _confirmacaoDeSenha)
        {
            if (_usuario.Senha != _confirmacaoDeSenha)
            {
                throw new Exception("A senha de confirmacao deve ser igual a senha");
            }
            if (_usuario.Senha.Length <= 3)
             throw new Exception("A senha deve ter mais de 3 caracteres");
            if (_usuario.Nome.Length <= 2)
                throw new Exception("O nome deve ter mais de 2 caracteres");

            }
        public void Excluir(int _id)
        {
            ValidarPermissao(4);

            new UsuarioDAL().Excluir(_id);

        }
        public List<Usuario> BuscarTodos()
        {
            ValidarPermissao(1);
            return new UsuarioDAL().BuscarTodos();
        }
        public Usuario BuscarPorId(int _id)
        {
            ValidarPermissao(1);
            return new UsuarioDAL().BuscarPorId(_id);   
        }
        public Usuario BuscarPorCpf(string _cpf)
        {
            ValidarPermissao(1);
            return new UsuarioDAL().BuscarPorCpf(_cpf);
        }
        public List<Usuario> BuscarPorNome( string _nome)
        {
            ValidarPermissao(1);
            return new UsuarioDAL().BuscarPorNome(_nome);
        }
        public Usuario BuscarPorNomeUsuario(string _nomeUsuario)
        {
            ValidarPermissao(1);
            return new UsuarioDAL().BuscarPorNomeusuario(_nomeUsuario);
        }
          
        public void ValidarPermissao(int _IdPermissao)
        {
          if( !new UsuarioDAL().ValidarPermissao(Constantes.IdUsuarioLogado,_IdPermissao))
            throw new Exception("Você nao possui permissao para realizar esta ação. Procure o administrador do sistema");
        }

        public void AdicionarGrupoUsuario(int _idUsuario, int _idGrupoUsuario)
        {
            if(!new UsuarioDAL().UsuarioPertenceAoGrupo(_idUsuario, _idGrupoUsuario))
            new UsuarioDAL().AdicionarGrupoUsuario(_idUsuario, _idGrupoUsuario);
        }

        public void Autenticar(string _nomeUsuario, string _senha)
        {
            Usuario usuario = new UsuarioDAL().BuscarPorNomeusuario(_nomeUsuario);
            if (_senha == usuario.Senha && usuario.Ativo)
            
                Constantes.IdUsuarioLogado = usuario.Id;
                else
                    throw new Exception("usuario ou senha inválido");
            
        }
    }
}
