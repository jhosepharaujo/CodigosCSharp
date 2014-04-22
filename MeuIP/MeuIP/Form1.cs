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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HostName.Text = "Nome Computador: " + Environment.MachineName;

            meuIP.Text = "Meu IP: " + Dns.GetHostAddresses(Environment.MachineName).FirstOrDefault(x => !x.IsIPv6SiteLocal && !x.IsIPv6LinkLocal && !x.IsIPv6Multicast && !x.IsIPv6Teredo);

            // muda a posição do formulário para o canto inferior direito
            this.Location = new System.Drawing.Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - this.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Bottom - this.Height - 50);

            this.WindowState = FormWindowState.Minimized;
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Visible = false;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                //notifyIcon1.ShowBalloonTip(500, "Meu IP", "", ToolTipIcon.Info);
                this.Hide();
            }
        }

        private void minimizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
