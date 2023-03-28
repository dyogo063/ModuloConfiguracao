using BLL;
using Models;
using System;
using System.Windows.Forms;

namespace WindowsFormsAppPrincipal
{
    public partial class FormCadastroUsuario : Form
    {
        public int Id;
        public FormCadastroUsuario(int _id = 0)
        {
            InitializeComponent();
            Id = _id;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            try
            {

            UsuarioBLL usuarioBLL = new UsuarioBLL();
            usuarioBindingSource.EndEdit();

            if(Id == 0)
            
                usuarioBLL.Inserir((Usuario)usuarioBindingSource.Current, textBoxConfirmarSenha.Text);
                else
                    usuarioBLL.Alterar((Usuario)usuarioBindingSource.Current, textBoxConfirmarSenha.Text);
                MessageBox.Show("registro salvo com sucesso");
                      Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormCadastroUsuario_Load(object sender, EventArgs e)
        {
            if (Id == 0) 
            usuarioBindingSource.AddNew();
            else
                usuarioBindingSource.DataSource = new UsuarioBLL().BuscarPorId(Id);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
