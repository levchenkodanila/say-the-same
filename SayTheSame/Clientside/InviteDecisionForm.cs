using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayTheSame
{
    public partial class InviteDecisionForm : Form
    {
        public InviteDecisionForm()
        {
            InitializeComponent();
        }

        public void SetInfo(string nickname)
        {
            nickname_label.Text = nickname;
        }

        public void SetAcceptEvent(EventHandler eh)
        {
            EventHandler accept = (object? o, EventArgs e) =>
            {
                eh.Invoke(o, e);
                this.Close();
            };
            accept_button.Click += accept;
        }

        public void SetRejectEvent(EventHandler eh)
        {
            EventHandler reject = (object? o, EventArgs e) =>
            {
                eh.Invoke(o, e);
                this.Close();
            };
            reject_button.Click += reject;
        }
    }

    public static class InviteMessageBox
    {
        public static EventHandler? AcceptClick;
        public static EventHandler? RejectClick;
        public static void Show(string invitor_nickname)
        {
            using (var form = new InviteDecisionForm())
            {
                form.SetInfo(invitor_nickname);
                if(AcceptClick != null && RejectClick != null)
                {
                    form.SetAcceptEvent(AcceptClick);
                    form.SetRejectEvent(RejectClick);
                } 
                form.ShowDialog();
            }
        }
    }
}
