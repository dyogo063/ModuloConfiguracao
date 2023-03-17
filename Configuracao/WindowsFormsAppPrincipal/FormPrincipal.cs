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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            Usuario usuario = new Usuario();
            usuario.Nome = "Guilherme";
            usuario.NomeUsuario = "chimbel";
            usuario.Ativo = true;
            usuario.CPF = "420.234.167-30";
            usuario.Senha = "vfjekf";
            usuario.Email = "Guilherme@dhsfnrj.com";
            new UsuarioBLL().Inserir(usuario);
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormBuscarUsuario frm = new FormBuscarUsuario())
            {
                frm.ShowDialog();
            }
        }
    }
}
