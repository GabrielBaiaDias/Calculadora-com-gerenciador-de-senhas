using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculadora
{
    public partial class FrmCalculadora : Form
    {
        bool abreFechaH = false;
        bool abreFechaT = false;

        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            btnLimpaMemoria.Location = new Point(btnLimpaMemoria.Location.X, (painelMemoria.Height / 2) - (btnLimpaMemoria.Height / 2) );
        }

        static double ResolveExpressao(String expressao)
        {
            DataTable table = new DataTable();
            return Convert.ToDouble(table.Compute(expressao, String.Empty));
        }

        private void VerificaLimiteText()
        {
            if (txtContas.Text.Length >= 11)
            {
                txtContas.Font = new Font("Arial", txtContas.Font.Size - 5, FontStyle.Bold);
                //txtContas.Text = txtContas.Text.Remove(txtContas.MaxLength, txtContas.TextLength - txtContas.MaxLength);
                if (txtContas.Font.Size == 15)
                    txtContas.Font = new Font("Arial", txtContas.Font.Size + 5, FontStyle.Bold);
                else if (txtContas.Font.Size == 30)
                    txtContas.Font = new Font("Arial", txtContas.Font.Size - 5, FontStyle.Bold);

            }

            if (txtContas.Text.Length <= 10)
            {
                txtContas.Font = new Font("Arial", 25, FontStyle.Bold);
            }

            if (txtContas.Text.Length > 13)
            {
                txtContas.Text = txtContas.Text.Remove(txtContas.MaxLength, txtContas.TextLength - txtContas.MaxLength);
            }
        }
        private void txtContas_TextChanged_1(object sender, EventArgs e)
        {
            txtContas.Text = Regex.Replace(txtContas.Text, "[^0-9-,.+=×÷/]", "");
            VerificaLimiteText();
            if (txtContas.Text.Length >= 12)
            {
                //txtContas.Text = txtContas.Text.Remove(txtContas.MaxLength, txtContas.TextLength - txtContas.MaxLength);
            }

            int totalVirgulas = txtContas.Text.Split(',').Length - 1;
            if (totalVirgulas >= 2)
            {
                VerificaBotao("Deleta");
            }
        }

        private void VerificaBotao(string idBotao)
        {
            VerificaLimiteText();
            //maiorDe13:
            //if (txtContas.Text.Length >= 13)
            //{
            //    txtContas.Text = txtContas.Text.Remove(txtContas.MaxLength, txtContas.TextLength - txtContas.MaxLength);
            //}
            //else
            //{
                switch (idBotao)
                {
                    case "1":

                        if (txtContas.Text.Length == 13)
                            return;
                        else
                        {
                            //if (txtContas.Text == "0")
                            //    txtContas.Text = "1";
                            //else
                                txtContas.Text += 1;
                        }
                        break;
                    case "2":

                        if (txtContas.Text.Length == 13)
                            return;
                        else
                        {
                        //if (txtContas.Text == "0")
                        //    txtContas.Text = "3";
                        //else
                            txtContas.Text += 2;
                        }
                        break;
                    case "3":

                        if (txtContas.Text.Length == 13)
                            return;
                        else
                        {
                            //if (txtContas.Text == "0")
                            //    txtContas.Text = "3";
                            //else
                                txtContas.Text += 3;
                        }
                        break;
                    case "4":

                        if (txtContas.Text.Length == 13)
                            return;
                        else
                        {
                            //if (txtContas.Text == "0")
                            //    txtContas.Text = "4";
                            //else
                                txtContas.Text += 4;
                        }
                        break;
                    case "5":

                        if (txtContas.Text.Length == 13)
                            return;
                        else
                        {
                            //if (txtContas.Text == "0")
                            //    txtContas.Text = "5";
                            //else
                                txtContas.Text += 5;
                        }
                        break;
                    case "6":

                        if (txtContas.Text.Length == 13)
                            return;
                        else
                        {
                            //if (txtContas.Text == "0")
                            //    txtContas.Text = "6";
                            //else
                                txtContas.Text += 6;
                        }
                        break;
                    case "7":

                        if (txtContas.Text.Length == 13)
                            return;
                        else
                        {
                            //if (txtContas.Text == "0")
                            //    txtContas.Text = "7";
                            //else
                                txtContas.Text += 7;
                        }
                        break;
                    case "8":

                        if (txtContas.Text.Length == 13)
                            return;
                        else
                        {
                            //if (txtContas.Text == "0")
                            //    txtContas.Text = "8";
                            //else
                                txtContas.Text += 8;
                        }
                        break;
                    case "9":

                        if (txtContas.Text.Length == 13)
                            return;
                        else
                        {
                            txtContas.Text = txtContas.Text;
                            //if (txtContas.Text == "0")
                            //    txtContas.Text = "9";
                            //else
                                txtContas.Text += 9;
                        }
                        break;
                    case "0":
                        if (txtContas.Text == "0")
                            return;
                        else
                            txtContas.Text += 0;
                        break;
                    case "LimpaConta":

                        txtContas.Text = "";
                        preVisuConta.Text = txtContas.Text;
                        txtContas.Font = new Font("Arial", 25, FontStyle.Bold);
                    break;
                    case "CancelaNumero":

                        txtContas.Text = "";
                        break;
                    case"Deleta":

                        if (txtContas.Text == "")
                            return;
                        else
                            txtContas.Text = txtContas.Text.Remove(txtContas.TextLength - 1, 1);

                    break;
                    case "Virgula":
                        if (txtContas.Text.Length == 13)
                            return;
                        else
                        {
                            if (txtContas.Text == "" || txtContas.Text.Contains(","))
                                return;
                            else
                                txtContas.Text += ",";
                        }
                        break;
                    case "TrocaSinal":
                        double valor = double.Parse(txtContas.Text);

                        if (valor < 0)
                        {
                            valor = Math.Abs(valor);
                        }
                        else if (valor > 0)
                        {
                            valor = -valor;
                        }
                        txtContas.Text = valor.ToString();
                        break;
                    case "Somar":
                        if (txtContas.Text == "")
                            return;
                        else
                            txtContas.Text = $"{txtContas.Text}+";
                        preVisuConta.Text = txtContas.Text;
                        txtContas.Text = "";
                        break;
                    case "Subtrair":
                        if (txtContas.Text == "")
                            return;
                        else
                            txtContas.Text = $"{txtContas.Text}-";
                        preVisuConta.Text = txtContas.Text;
                        txtContas.Text = "";

                        break;
                    case "Multiplicar":
                        if (txtContas.Text == "")
                            return;
                        else
                            txtContas.Text = $"{txtContas.Text}×";
                        preVisuConta.Text = txtContas.Text;
                        txtContas.Text = "";
                        break;
                    case "Dividir":
                        if (txtContas.Text == "")
                            return;
                        else
                            txtContas.Text = $"{txtContas.Text}÷";
                        preVisuConta.Text = txtContas.Text;
                        txtContas.Text = "";
                        break;
                    case "Resultado":
                        VoltaResultado();
                        NadaSUS(preVisuConta);
                    if (lsbMemoriaConta.Items.Count == 19)
                    {
                        lsbMemoriaConta.Width = lsbMemoriaConta.Width + 30;
                    }
                        lsbMemoriaConta.Items.Add($"{preVisuConta.Text} = {txtContas.Text}");
                        lsbMemoriaConta.Items.Add("");
                    break;

                    default:
                        break;
                }
            //}

        }

        private void btn01_Click(object sender, EventArgs e)
        {
            VerificaBotao("1");
        }

        private void btn02_Click(object sender, EventArgs e)
        {
            VerificaBotao("2");
        }

        private void btn03_Click(object sender, EventArgs e)
        {
            VerificaBotao("3");
        }

        private void btn04_Click(object sender, EventArgs e)
        {
            VerificaBotao("4");
        }

        private void btn05_Click(object sender, EventArgs e)
        {
            VerificaBotao("5");
        }

        private void btn06_Click(object sender, EventArgs e)
        {
            VerificaBotao("6");
        }

        private void btn07_Click(object sender, EventArgs e)
        {
            VerificaBotao("7");
        }

        private void btn08_Click(object sender, EventArgs e)
        {
            VerificaBotao("8");
        }

        private void btn09_Click(object sender, EventArgs e)
        {
            VerificaBotao("9");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerificaBotao("0");
        }

        private void btnLimpaConta_Click_1(object sender, EventArgs e)
        {
            VerificaBotao("LimpaConta");
        }

        private void btnCancelaNum_Click(object sender, EventArgs e)
        {
            VerificaBotao("CancelaNumero");
        }

        private void btnDeleta_Click(object sender, EventArgs e)
        {
            VerificaBotao("Deleta");
        }

        private void btnSomar_Click(object sender, EventArgs e)
        {
            VerificaBotao("Somar");
        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            VerificaBotao("Subtrair");
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            VerificaBotao("Multiplicar");
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            VerificaBotao("Dividir");
        }

        private void btnTrocaSinal_Click(object sender, EventArgs e)
        {
            VerificaBotao("TrocaSinal");
        }

        private void VoltaResultado()
        {
            double expressaoResolvida;
            preVisuConta.Text += txtContas.Text;
            expressaoResolvida = ResolveConta(preVisuConta.Text);
            VerificaLimiteText();
            txtContas.Text = expressaoResolvida.ToString();

        }

        private double ResolveConta(string expressao)
        {
            expressao = expressao.Replace("×", "*").Replace("÷", "/").Replace(",", ".");
            double expressaoResolvida = ResolveExpressao(expressao);
            return expressaoResolvida;
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            VerificaBotao("Resultado");
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            VerificaBotao("Virgula");
        }

        private void btnUmDivididoX_Click(object sender, EventArgs e)
        {
            if (txtContas.Text == "0" || txtContas.Text == "")
                return;
            else 
            {
                double x = double.Parse(txtContas.Text);
                txtContas.Text = $"1 ÷ {txtContas.Text}";
                preVisuConta.Text = "";
                VoltaResultado();
                preVisuConta.Text = $"1/({x})";

                lsbMemoriaConta.Items.Add($"{preVisuConta.Text} = {txtContas.Text}");
                lsbMemoriaConta.Items.Add("");
            }


        }

        private void btnXAoQuadrado_Click(object sender, EventArgs e)
        {
            if (txtContas.Text == "0" || txtContas.Text == "")
                return;
            else
            {
                double sqr = double.Parse(txtContas.Text);
                txtContas.Text = $"{txtContas.Text} × {txtContas.Text}";
                preVisuConta.Text = "";
                preVisuConta.Text += txtContas.Text;
                txtContas.Text = ResolveConta(preVisuConta.Text).ToString();
                preVisuConta.Text = $"sqr({sqr})";

                lsbMemoriaConta.Items.Add($"{preVisuConta.Text} = {txtContas.Text}");
                lsbMemoriaConta.Items.Add("");
            }

        }

        private void btnRaizQuadrada_Click(object sender, EventArgs e)
        {
            if (txtContas.Text == "0" || txtContas.Text == "")
                return;
            else
            {
                preVisuConta.Text = "";
                string numeroRaiz = txtContas.Text;
                txtContas.Text = Math.Sqrt(double.Parse(txtContas.Text)).ToString();
                preVisuConta.Text = $"√({numeroRaiz})";

                lsbMemoriaConta.Items.Add($"{preVisuConta.Text} = {txtContas.Text}");
                lsbMemoriaConta.Items.Add("");
            }
            
        }

        private void btnPorcentagem_Click(object sender, EventArgs e)
        {
            string porcentagem;

            if (txtContas.Text == "0" || txtContas.Text == "")
                return;
            else
            {
                porcentagem = txtContas.Text;
                txtContas.Text = $"{txtContas.Text} ÷ 100";
            }

            preVisuConta.Text += ResolveConta(txtContas.Text);
            txtContas.Text = ResolveConta(preVisuConta.Text).ToString();

            lsbMemoriaConta.Items.Add($"{preVisuConta.Text} ({porcentagem}%) = {txtContas.Text}");
            lsbMemoriaConta.Items.Add("");

        }

        private void NadaSUS(Label preVisu)
        {
            string num1, num2;
            string Minuto = DateTime.Now.Minute.ToString();
            string Dia = DateTime.Now.Day.ToString();

            string numeros = Regex.Replace(preVisu.ToString(), @"[^\d]", "");

            if (numeros.Length == 4)
            {
                num1 = numeros.Substring(0, 2);
                num2 = numeros.Substring(2, 2);

                if (int.Parse(num1.Substring(0, 1)) == 0)
                {
                    num1 = num1.Remove(0, 1);
                }

                if (int.Parse(num2.Substring(0, 1)) == 0)
                {
                    num2 = num2.Remove(0, 1);
                }

                if (Minuto == num1 && Dia == num2)
                {
                    FrmLogin login = new FrmLogin();
                    this.Hide();
                    login.ShowDialog();
                }
            }
        }

        private void btnMemoria_Click(object sender, EventArgs e)
        {
            if (abreFechaH == false)
            {
                abreFechaH = true;
                this.Width = this.Width + 200;
            }
            else
            {
                abreFechaH = false;
                this.Width = this.Width - 200;
            }
        }
        private void btnTema_Click_1(object sender, EventArgs e)
        {
            if (abreFechaT == false)
            {
                abreFechaT = true;
                pnTemas.Visible = true;
            }
            else
            {
                abreFechaT = false;
                pnTemas.Visible = false;
            }
        }

        private void btnLimpaMemoria_Click(object sender, EventArgs e)
        {
            lsbMemoriaConta.Items.Clear();
        }

        private void btnAplicarTema_Click(object sender, EventArgs e)
        {
            
            //for (int rb = 1; rb < 8; rb++)
            //{

            //}

            if (rb1.Checked)
            {
                Color VermelhoEscuro = Color.FromArgb(176, 9, 16);
                Color VermelhoClaro = Color.FromArgb(255, 51, 59);
                Color VermelhoBack = Color.FromArgb(255, 115, 121);
                Color VermelhoResult = Color.FromArgb(89, 1, 5);
                Color VermelhoMemoria = Color.FromArgb(252, 141, 141);

                Color VermelhoFore1 = Color.White;
                Color VermelhoFore2 = Color.White;

                MudaCores(VermelhoEscuro, VermelhoClaro, VermelhoBack, VermelhoResult, VermelhoFore1, VermelhoFore2, VermelhoMemoria);
            }
            else if (rb2.Checked)
            {
                Color LaranjaEscuro = Color.FromArgb(163, 79, 0);
                Color LaranjaClaro = Color.FromArgb(255, 156, 64);
                Color LaranjaBack = Color.FromArgb(255, 173, 97);
                Color LaranjaResult = Color.FromArgb(166, 80, 0);
                Color LaranjaMemoria = Color.FromArgb(255, 199, 120);

                Color LaranjaFore1 = Color.White;
                Color LaranjaFore2 = Color.White;

                MudaCores(LaranjaEscuro, LaranjaClaro, LaranjaBack, LaranjaResult, LaranjaFore1, LaranjaFore2, LaranjaMemoria);
            }
            else if (rb3.Checked)
            {
                Color AmareloEscuro = Color.FromArgb(166, 166, 0);
                Color AmareloClaro = Color.FromArgb(255, 255, 105);
                Color AmareloBack = Color.FromArgb(255, 255, 158);
                Color AmareloResult = Color.FromArgb(135, 135, 0);
                Color AmareloMemoria = Color.FromArgb(255, 255, 181);

                Color AmareloFore1 = Color.FromArgb(189, 189, 2);
                Color AmareloFore2 = Color.FromArgb(255, 255, 48);

                MudaCores(AmareloEscuro, AmareloClaro, AmareloBack, AmareloResult, AmareloFore1, AmareloFore2, AmareloMemoria);

                lsbMemoriaConta.ForeColor = AmareloFore1;
            }
            else if (rb4.Checked)
            {
                Color VerdeEscuro = Color.FromArgb(12, 140, 0);
                Color VerdeClaro = Color.FromArgb(60, 204, 47);
                Color VerdeBack = Color.FromArgb(154, 255, 145);
                Color VerdeResult = Color.FromArgb(8, 94, 0);
                Color VerdeMemoria = Color.FromArgb(179, 255, 182);

                Color VerdeFore1 = Color.White;
                Color VerdeFore2 = Color.White;

                MudaCores(VerdeEscuro, VerdeClaro, VerdeBack, VerdeResult, VerdeFore1, VerdeFore2, VerdeMemoria);
            }
            else if (rb5.Checked)
            {
                Color AzulEscuro = Color.FromArgb(0, 0, 133);
                Color AzulClaro = Color.FromArgb(76, 76, 217);
                Color AzulBack = Color.FromArgb(135, 135, 255);
                Color AzulResult = Color.FromArgb(0, 0, 89);
                Color AzulMemoria = Color.FromArgb(143, 169, 255);

                Color AzulFore1 = Color.White;
                Color AzulFore2 = Color.White;

                MudaCores(AzulEscuro, AzulClaro, AzulBack, AzulResult, AzulFore1, AzulFore2, AzulMemoria);
            }
            else if (rb6.Checked)
            {
                Color BrancoEscuro = Color.FromArgb(120, 120, 120);
                Color BrancoClaro = Color.FromArgb(153, 153, 153);
                Color BrancoBack = Color.White;
                Color BrancoResult = Color.FromArgb(84, 84, 84);
                Color BrancoMemoria = Color.FromArgb(212, 212, 212);

                Color BrancoFore1 = Color.FromArgb(240, 240, 240);
                Color BrancoFore2 = Color.FromArgb(245, 245, 245);

                MudaCores(BrancoEscuro, BrancoClaro, BrancoBack, BrancoResult, BrancoFore1, BrancoFore2, BrancoMemoria);
            }

        }

        private void MudaCores(Color Escuro, Color Claro, Color Back, Color Result, Color Fore1, Color Fore2, Color Memoria)
        {
            txtContas.BackColor = Color.FromArgb(122, 0, 5);

            btn01.BackColor = Claro;
            btn02.BackColor = Claro;
            btn03.BackColor = Claro;
            btn04.BackColor = Claro;
            btn05.BackColor = Claro;
            btn06.BackColor = Claro;
            btn07.BackColor = Claro;
            btn08.BackColor = Claro;
            btn09.BackColor = Claro;
            btn00.BackColor = Claro;

            lsbMemoriaConta.BackColor = Memoria;
            preVisuConta.ForeColor = Color.White;
            preVisuConta.BackColor = Escuro;
            btnLimpaConta.BackColor = Escuro;
            btnCancelaNum.BackColor = Escuro;
            btnDeleta.BackColor = Escuro;
            btnPorcentagem.BackColor = Escuro;
            btnRaizQuadrada.BackColor = Escuro;
            btnTrocaSinal.BackColor = Escuro;
            btnUmDivididoX.BackColor = Escuro;
            btnVirgula.BackColor = Escuro;
            btnXAoQuadrado.BackColor = Escuro;

            btnDeleta.BackColor = Escuro;
            btnDividir.BackColor = Escuro;
            btnMultiplicar.BackColor = Escuro;
            btnSomar.BackColor = Escuro;
            btnSubtrair.BackColor = Escuro;

            txtContas.BackColor = Escuro;

            btnResultado.BackColor = Result;
            btnResultado.ForeColor = Color.White;

            //================================

            btn00.ForeColor = Fore1;
            btn01.ForeColor = Fore1;
            btn02.ForeColor = Fore1;
            btn03.ForeColor = Fore1;
            btn04.ForeColor = Fore1;
            btn05.ForeColor = Fore1;
            btn06.ForeColor = Fore1;
            btn07.ForeColor = Fore1;
            btn08.ForeColor = Fore1;
            btn09.ForeColor = Fore1;

            btnLimpaConta.ForeColor    = Fore2;
            btnCancelaNum.ForeColor    = Fore2;
            btnDeleta.ForeColor        = Fore2;
            btnPorcentagem.ForeColor   = Fore2;
            btnRaizQuadrada.ForeColor  = Fore2;
            btnTrocaSinal.ForeColor    = Fore2;
            btnUmDivididoX.ForeColor   = Fore2;
            btnVirgula.ForeColor       = Fore2;
            btnXAoQuadrado.ForeColor   = Fore2;

            btnLimpaMemoria.BackColor = Escuro;
            btnTema.ForeColor = Escuro;
            btnMemoria.ForeColor = Escuro;

            rb1.ForeColor = Escuro;
            rb2.ForeColor = Escuro;
            rb3.ForeColor = Escuro;
            rb4.ForeColor = Escuro;
            rb5.ForeColor = Escuro;
            rb6.ForeColor = Escuro;


            btnDeleta.ForeColor      = Fore2;
            btnDividir.ForeColor     = Fore2;
            btnMultiplicar.ForeColor = Fore2;
            btnSomar.ForeColor       = Fore2;
            btnSubtrair.ForeColor    = Fore2;

            lsbMemoriaConta.ForeColor = Color.White;

            painelMemoria.BackColor = Back;
            this.BackColor = Back;
        }

        private void btnTemaPadrao_Click(object sender, EventArgs e)
        {
            Color PadraoEscuro = Color.FromArgb(64, 64, 64);
            Color PadraoClaro = Color.FromArgb(78, 78, 78);
            Color PadraoBack = Color.DimGray;
            Color PadraoResult = Color.Goldenrod;

            Color PadraoFore1 = Color.White;
            Color PadraoFore2 = Color.White;

            MudaCores(PadraoEscuro, PadraoClaro, PadraoBack, PadraoResult, PadraoFore1, PadraoFore2, Color.Gray);

            btnResultado.ForeColor = Color.FromArgb(64, 64, 64);

            preVisuConta.ForeColor = Color.FromArgb(78,78,78);
            btnTema.ForeColor = Color.White;
            btnMemoria.ForeColor = Color.White;

        }
    }
}
