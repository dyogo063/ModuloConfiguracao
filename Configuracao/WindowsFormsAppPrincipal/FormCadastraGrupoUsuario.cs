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
    public partial class FormCadastraGrupoUsuario : Form
    {
        public int Id;
        public FormCadastraGrupoUsuario()
        {
            InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            
           GrupoUsuarioBLL grupoUsuarioBLL = new GrupoUsuarioBLL();
            grupoUsuarioBindingSource.EndEdit();
            if (Id == 0)
                grupoUsuarioBLL.Inserir((GrupoUsuario)grupoUsuarioBindingSource.Current);
            else
                grupoUsuarioBLL.Inserir((GrupoUsuario)grupoUsuarioBindingSource.Current);
            MessageBox.Show("Registro salvo com sucesso");
            Close();

            
            
     
           
           
        }

        private void FormCadastraGrupoUsuario_Load(object sender, EventArgs e)
        {
            if(Id == 0)
            {
                grupoUsuarioBindingSource.AddNew();
            }
            Constantes.IdUsuarioLogado = 3;
        }

        private void nomeGrupoLabel_Click(object sender, EventArgs e)
        {

        }

        private void nomeGrupoTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
