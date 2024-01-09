using Calculadora;
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

namespace Calculadora
{
    public partial class FrmLista : Form
    {

        bool encryptou = false;

        string email, senha;

        string[] SenhasArr;
        string[] EmailsArr;

        string caminhoE = @"..."; 
        string caminhoS = @"...";

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

            txtEmail.Text = string.Empty;
            txtSenha.Text = string.Empty;
        }

        private void AtualizaEncrypt(string txtEncryptadoE, string txtEncryptadoS)
        {
            StreamWriter writeE = new StreamWriter(caminhoE, false, Encoding.UTF8);
            StreamWriter writeS = new StreamWriter(caminhoS, false, Encoding.UTF8);

            writeE.Write(txtEncryptadoE);
            writeS.Write(txtEncryptadoS);

            //MessageBox.Show(txtEncryptado);

            writeE.Dispose();
            writeS.Dispose();
        }

        private void Encryptar()
        {

            if (encryptou == false)
            {

                string textoCompletoE = string.Empty;
                string textoCompletoS = string.Empty;

                int Cifrado, Usuario;

                StreamReader readE = new StreamReader(caminhoE);
                StreamReader readS = new StreamReader(caminhoS);

                string totalLenghtE = readE.ReadToEnd();
                string totalLenghtS = readS.ReadToEnd();

                for (int i = 0; i < totalLenghtE.Length; i++)
                {

                    Usuario = (int)totalLenghtE[i];

                    Cifrado = Usuario + 10;

                    textoCompletoE += Char.ConvertFromUtf32(Cifrado);

                }

                for (int i = 0; i < totalLenghtS.Length; i++)
                {

                    Usuario = (int)totalLenghtS[i];

                    Cifrado = Usuario + 10;

                    textoCompletoS += Char.ConvertFromUtf32(Cifrado);

                }

                encryptou = true;

                readE.Dispose();
                readS.Dispose();

                AtualizaEncrypt(textoCompletoE, textoCompletoS);

            }


        }

        private void Decryptar()
        {

                StreamReader readE = new StreamReader(caminhoE);
                StreamReader readS = new StreamReader(caminhoS);

                string textoCompletoE = string.Empty;
                string textoCompletoS = string.Empty;

                int Cifrado, Usuario;

                string totalLenghtE = readE.ReadToEnd();
                string totalLenghtS = readS.ReadToEnd();

                for (int i = 0; i < totalLenghtE.Length; i++)
                {

                    Usuario = (int)totalLenghtE[i];

                    Cifrado = Usuario - 10;

                    textoCompletoE += Char.ConvertFromUtf32(Cifrado);

                }

                for (int i = 0; i < totalLenghtS.Length; i++)
                {

                    Usuario = (int)totalLenghtS[i];

                    Cifrado = Usuario - 10;

                    textoCompletoS += Char.ConvertFromUtf32(Cifrado);

                }

                encryptou = false;

                readE.Dispose();
                readS.Dispose();

                AtualizaEncrypt(textoCompletoE, textoCompletoS);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Decryptar();
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
                            apagaE.Write(txtReconstruido+";");

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
                            apagaS.Write(txtReconstruido+";");

                            apagaS.Dispose();
                        }

                    }
                }
            }
            Encryptar();
        }

        private void btnLimpaListas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente apagar todos os itens destas listas?", "Apagar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                LimpaTudo();
            }
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
            Decryptar();
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

            Encryptar();
        }

        public void AtualizaListas()
        {
            Decryptar();

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

            Encryptar();
        }
        public void LimpaTudo()
        {
            lsbEmails.Items.Clear();
            lsbSenhas.Items.Clear();

            StreamWriter substituirE = new StreamWriter(caminhoE, false, Encoding.Default);
            StreamWriter substituirS = new StreamWriter(caminhoS, false, Encoding.Default);

            substituirE.Dispose();
            substituirS.Dispose();
            AtualizaListas();
        }
    }
}
