using DAL;
using Models;
using System.Collections.Generic;
using System;

namespace BLL
{
    public class PermissaoBLL
    {
        public void Inserir(Permissao _permissao)
        {


            PermissaoDAL permissaoDAL = new PermissaoDAL();
            permissaoDAL.Inserir(_permissao);

        }
        private void Alterar(Permissao _usuario)
        {
            ValidarDados2(_usuario);

            PermissaoDAL permissaoDAL = new PermissaoDAL();
            permissaoDAL.Alterar(_usuario);

        }
        private void ValidarDados2(Permissao _permissao)
        {
            if (_permissao.Descricao.Length <= 10)
                throw new Exception("A descricao deve ter mais de 10 caracteres");

        }
        public void Excluir(int _id)
        {
            new PermissaoDAL().Excluir(_id);

        }
        public Permissao BuscarPorId(int _id)
        {
            return new PermissaoDAL().BuscarPorId(_id);
        }
        public List<Permissao> BuscarPorDescricao(string _descricao)
        {
            return new PermissaoDAL().BuscarPorDescricao(_descricao);
        }

    }
}
