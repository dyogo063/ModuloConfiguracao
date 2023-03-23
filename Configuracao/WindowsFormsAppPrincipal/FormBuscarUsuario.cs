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
    public partial class FormBuscarUsuario : Form
    {
        public FormBuscarUsuario()
        {
            InitializeComponent();
        }



        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
            usuarioBindingSource.DataSource = new UsuarioBLL().BuscarTodos();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonExcluirusuario_Click(object sender, EventArgs e)
            
        {
            if(usuarioBindingSource.Count <= 0)
            {
                MessageBox.Show("Nao existe registro para ser escluido");
                return;
            }
            if (MessageBox.Show("deseja realmente excluir?", "Atençao", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            int id = ((Usuario)usuarioBindingSource.Current).Id;
            new UsuarioBLL().Excluir(id);
            usuarioBindingSource.RemoveCurrent();
        }

        private void buttonAdicionarUsuario_Click(object sender, EventArgs e)
        {
           using (FormCadastroUsuario frm = new FormCadastroUsuario())
            {
                frm.ShowDialog();
            }
           buttonBuscar_Click(null, null); 
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            int id = ((Usuario)usuarioBindingSource.Current).Id;

            using(FormCadastroUsuario frm = new FormCadastroUsuario(id))
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(null , null);
        }

        private void buttonAdicionarGrupoUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormConsultaGrupoUsuario frm = new FormConsultaGrupoUsuario())
                {
                    frm.ShowDialog();

                    if(frm.Id != 0)
                    {
                        int idUsuario = ((Usuario)usuarioBindingSource.Current).Id;
                        new UsuarioBLL().AdicionarGrupoUsuario(idUsuario, frm.Id);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExcluirGrupo_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
