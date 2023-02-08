using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Calculadora
{
    public partial class FrmLista : Form
    {

        int cont = 0;

        string email, senha, vazio;

        string[] SenhasArr;
        string[] EmailsArr;

        string caminhoE = @"C:\Users\Gabriel\Área de Trabalho\ \Email.txt"; 
        string caminhoS = @"C:\Users\Gabriel\Área de Trabalho\ \Senha.txt";


        private void FrmLista_Load(object sender, EventArgs e)
        {
            AtualizaListas();
        }

        public FrmLista()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            GuardaInfo();
            AtualizaListas();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (lsbSenhas.SelectedItem == null && lsbEmails.SelectedItem == null)
            {
                MessageBox.Show("Não há nada selecionado para apagar!");
            }
            else
            {

                if (lsbEmails.SelectedItem != null)
                {
                    string itemSelecionadoE = lsbEmails.SelectedItem.ToString();
                    List<string> EmailsList = new List<string>(EmailsArr);

                    for (int i = 0; i < EmailsArr.Length; i++)
                    {
                        if (EmailsArr[i] == itemSelecionadoE)
                        {
                            if (lsbEmails.SelectedItem != null)
                                lsbEmails.Items.Remove(lsbEmails.SelectedItem);

                            StreamWriter apagaE = new StreamWriter(caminhoE, false, Encoding.Default);

                            EmailsList.RemoveAt(i);

                            EmailsArr = EmailsList.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                            string txtReconstruido = String.Join(";", EmailsArr);
                            apagaE.WriteLine(txtReconstruido+";");

                            apagaE.Dispose();
                        }
                    }
                }


                if (lsbSenhas.SelectedItem != null)
                {

                    string itemSelecionadoS = lsbSenhas.SelectedItem.ToString();
                    List<string> SenhasList = new List<string>(SenhasArr);

                    for (int i = 0; i < SenhasArr.Length; i++)
                    {

                        if (SenhasArr[i] == itemSelecionadoS)
                        {
                            if (lsbSenhas.SelectedItem != null)
                                lsbSenhas.Items.Remove(lsbSenhas.SelectedItem);

                            StreamWriter apagaS = new StreamWriter(caminhoS, false, Encoding.Default);

                            SenhasList.RemoveAt(i);

                            SenhasArr = SenhasList.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                            string txtReconstruido = String.Join(";", SenhasArr);
                            apagaS.WriteLine(txtReconstruido+";");

                            apagaS.Dispose();
                        }

                    }
                }
            }
        }

        private void btnLimpaListas_Click(object sender, EventArgs e)
        {
            lsbEmails.Items.Clear();
            lsbSenhas.Items.Clear();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            string itemSelecionadoS = lsbSenhas.SelectedItem.ToString();
            string itemSelecionadoE = lsbEmails.SelectedItem.ToString();

            if (lsbSenhas.SelectedItem == null && lsbEmails.SelectedItem == null)
            {
                MessageBox.Show("Não há nada selecionado para copiar!");
            }
            else
            {

                if (lsbEmails.SelectedItem != null && lsbSenhas.SelectedItem != null)
                {
                    Clipboard.SetText($"{itemSelecionadoE}, {itemSelecionadoS}");
                }
                else
                {
                    if (lsbEmails.SelectedItem != null)
                    {
                        Clipboard.SetText(itemSelecionadoE);
                    }

                    if (lsbSenhas.SelectedItem != null)
                    {

                        Clipboard.SetText(itemSelecionadoS);
                    }
                } 
            }
        }

        private void GuardaInfo()
        {
            email = txtEmail.Text;
            senha = txtSenha.Text;

            StreamWriter addE = new StreamWriter(caminhoE, true, Encoding.UTF8);
            StreamWriter addS = new StreamWriter(caminhoS, true, Encoding.UTF8);

            if (txtEmail.Text == "" && txtSenha.Text == "")
            {
                MessageBox.Show("Não há nada para adicionar!");
            }
            else if (txtEmail.Text != "" && txtSenha.Text != "")
            {
                addE.Write($"{email};");
                addS.Write($"{senha};");

                MessageBox.Show("E-mail e Senha adicionados com successo!");
            }

            if (txtEmail.Text != "" && txtSenha.Text == "")
            {
                addE.Write($"{email};");
                MessageBox.Show("Email adicionado com sucesso!");
            }

            if (txtEmail.Text == "" && txtSenha.Text != "")
            {
                addS.Write($"{senha};");
                MessageBox.Show("Senha adicionada com sucesso!");
            }

            addE.Dispose();
            addS.Dispose();
        }

        private void AtualizaListas()
        {

            StreamReader readE = new StreamReader(caminhoE);
            StreamReader readS = new StreamReader(caminhoS);

            var contemTextoE = File.ReadAllText(caminhoE);
            if (contemTextoE.Length != 0)
            {
                EmailsArr = readE.ReadToEnd().Split(';');

                lsbEmails.Items.Clear();
                foreach (string Email in EmailsArr)
                {
                    lsbEmails.Items.Add(Email);
                }
            }

            var contemTextoS = File.ReadAllText(caminhoS);
            if (contemTextoS.Length != 0)
            {
                SenhasArr = readS.ReadToEnd().Split(';');

                lsbSenhas.Items.Clear();
                foreach (string Senha in SenhasArr)
                {
                    lsbSenhas.Items.Add(Senha);
                }
            }

            readE.Dispose();
            readS.Dispose();
        }
    }
}
