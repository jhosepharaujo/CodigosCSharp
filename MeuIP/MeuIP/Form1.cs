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
        private string _IP = "sem IP ";
        private string _hostName = "Nome Computador:";
        private bool flag = true;
        public Form1(string[] args = null)
        {
            InitializeComponent();
        }

        private void AtualizarIpEHostNome()
        {
            HostName.Text = _hostName = "Nome Computador: " + Environment.MachineName;
            meuIP.Text = _IP = "Meu IP: " + Dns.GetHostAddresses(Environment.MachineName).FirstOrDefault(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
            notifyIcon.Text = string.Format("{0}", _IP);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizarIpEHostNome();

            // muda a posição do formulário para o canto inferior direito
            this.Location = new System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - this.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Bottom - this.Height - 50);
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
        }

        private void notifyIcon1_BalloonTipShown(object sender, EventArgs e)
        {
            AtualizarIpEHostNome();
            notifyIcon.Text = string.Format("{0}", _IP);
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
