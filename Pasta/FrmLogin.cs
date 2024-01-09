using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class FrmLogin : Form
    { 
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtEmail.Text;
            string senha = txtSenha.Text;

            if (usuario == "usuario" && senha == "Senha")
            {
                FrmLista lista = new FrmLista();
                this.Hide();
                lista.ShowDialog();
            }
        }
    }
}
