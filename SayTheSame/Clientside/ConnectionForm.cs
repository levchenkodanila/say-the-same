using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace SayTheSame
{
    public partial class ConnectionForm : Form
    {
        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void accept_button_Click(object sender, EventArgs e)
        {
            string startText = this.Text;
            try
            {
                IPAddress address = IPAddress.Parse(ip_textbox.Text);
                Text = "Подключение...";
                Client.GetClient().Connect(address);
                Client.GetClient().BeginMessageLoop();
                Client.GetClient().CurrentForm = new MainForm(nickname_textbox.Text);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
            Text = startText;
        }

        private void server_linklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.Server = true;
            Close();
        }
    }
}
