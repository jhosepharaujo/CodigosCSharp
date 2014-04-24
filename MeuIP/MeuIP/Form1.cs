using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeuIP
{
    public partial class Form1 : Form
    {
        private const string IP_LABEL = "Meu IP: ";
        private const string HOSTNAME_LABEL = "Computador: ";
        private string Ip;
        private string Hostname;
        private bool flag = true;
        public Form1(string[] args = null)
        {
            InitializeComponent();
        }

        private void AtualizarIpEHostNome()
        {
            Grabber g = new Grabber();
            Ip = g.Ip;
            Hostname = g.Hostname;
            
            HostName.Text = HOSTNAME_LABEL + Hostname;
            meuIP.Text = IP_LABEL + g.Ip;

            notifyIcon.Text = string.Format("{0}", Ip);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizarIpEHostNome();

            // muda a posição do formulário para o canto inferior direito
            this.Location = new System.Drawing.Point
                (Screen.PrimaryScreen.Bounds.Width - this.Width,
                (Screen.PrimaryScreen.Bounds.Bottom - this.Height) - 50);

            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetStatusVisible();
        }

        private void minimizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            flag = true;
        }

        private void notifyIcon1_BalloonTipShown(object sender, EventArgs e)
        {
            AtualizarIpEHostNome();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (flag)
                {
                    SetStatusVisible();
                    flag = false;
                }
                else
                {
                    this.Hide();
                    flag = true;
                }
            }
        }

        private void SetStatusVisible()
        {
            AtualizarIpEHostNome();
            notifyIcon.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.TopMost = true; // deixa o form sempre visível
            this.Show();
        }
    }
}
