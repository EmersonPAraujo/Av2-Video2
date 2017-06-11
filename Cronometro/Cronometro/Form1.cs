using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Cronometro
{
    public partial class Form1 : Form
    {
        Stopwatch cronometro = new Stopwatch();
        int vezParcial = 0;
        int regressivo;
        int m = 00, s=05, desc;
        //int numAtividade = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            /*Codigo Modificado*/
            //txtAtividade.Text= "";

            s = 3;
            m = 0; 
            tmrCronometro.Start();
            
            

            /*Codigo Original*/
            /*//zerar o cronometro
            cronometro.Reset();

            //iniciar o cronometro
            cronometro.Start();

            //zerar as variaveis
            tbParcial.Text = null;
            vezParcial = 0;

            //desativar botão iniciar e ativar os de parada
            btnParcial.Enabled = true;
            btnParar.Enabled = true;
            btnIniciar.Enabled = false;*/
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            //para o cronômetro
            cronometro.Stop();

            //desativar botões de paradas e ativar o de início
            btnParcial.Enabled = false;
            btnParar.Enabled = false;
            btnIniciar.Enabled = true;
            MessageBox.Show("Acabou a sua Ativade");

        }

        private void btnParcial_Click(object sender, EventArgs e)
        {
            vezParcial++;
            //numAtividade++;
            //jogar parcial no textbox e pular uma linha
            tbPomo.Text += vezParcial + "- " + lblTempo.Text + Environment.NewLine;
            //ir para a última linha do textbox
            tbPomo.SelectionStart = tbPomo.TextLength;
            tbPomo.ScrollToCaret();
        }

        private void tmrCronometro_Tick(object sender, EventArgs e)
        {                        

            s -= 1;
            if (s == -1)
            {
                m -= 1;
                s = 59;
            }
            else if (m == 0 && s == 0)
            {                
                tmrCronometro.Enabled = false;

                vezParcial++;
                tbPomo.Text += vezParcial + "- " + txtAtividade.Text + Environment.NewLine;
                 if (vezParcial < 4)
                {
                    MessageBox.Show("Acabou o seu pomodoris.\nFaça um pausa de 5 Minutos\nantes de começar outra atividade");
                }
                else if (vezParcial == 4)
                {
                    MessageBox.Show("Acabou o seu pomodoris.\nFaça um pausa de 30  Minutos\nantes de começar outra atividade");
                    vezParcial = 0;
                }
                //ir para a última linha do textbox
                tbPomo.SelectionStart = tbPomo.TextLength;
                tbPomo.ScrollToCaret();
            }
            lblTempo.Text = String.Format("{0:00}:{1:00}", m, s);

            //lblTempo.Text = String.Format("{0:00}:{1:00}:{2:00}", cronometro.Elapsed.Minutes, cronometro.Elapsed.Seconds, cronometro.Elapsed.Milliseconds / 10);

            //if (lblTempo.Text == "00:03:00")
            //{
            //    tmrCronometro.Enabled = false;
            //    MessageBox.Show("Acabou");
            //}

        }
    }
}