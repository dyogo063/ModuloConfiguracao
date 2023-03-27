using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
{
    public partial class FormBuscarGrupousuario : Form
    {
        public FormBuscarGrupousuario()
        {
            InitializeComponent();
        }
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            grupoUsuarioBindingSource.DataSource = new GrupoUsuarioBLL().BuscarTodos();
        }
        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            using(FormCadastraGrupoUsuario frm = new FormCadastraGrupoUsuario())
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(null,null);
        }

        private void buttonExcluirGrupo_Click(object sender, EventArgs e)
        {
            if(grupoUsuarioBindingSource.Count <= 0)
            {
                MessageBox.Show("Nao existe registro para ser excluida ");
                return;
            }
            if(MessageBox.Show("Deseja mesmo excluir esse registro?","atençao",MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            int id = ((GrupoUsuario)grupoUsuarioBindingSource.Current).Id;
            new GrupoUsuarioBLL().Excluir(id);
            grupoUsuarioBindingSource.RemoveCurrent();
            MessageBox.Show("registro excluido com sucesso");
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            int id = ((GrupoUsuario)grupoUsuarioBindingSource.Current).Id;
            using(FormCadastroUsuario frm = new FormCadastroUsuario(id))
            {
                frm.ShowDialog();
            }
        }

        private void buttonAdicionarPermissao_Click(object sender, EventArgs e)
        {
            using (FormCadastraGrupoUsuario frm = new FormCadastraGrupoUsuario())
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(null, null);
        }
    }
}
