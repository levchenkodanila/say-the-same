using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace SayTheSame
{
    public partial class MainForm : Form
    {
        private Message last_request = new Message(MessageType.ServerReject, "");
        private List<string> invited_list = new List<string>();

        private string opponent_nickname = "";
        private string[] last_players_list = { "" };
        private string username;

        private bool is_in_game = false;

        public MainForm(string username)
        {
            this.username = username;

            InitializeComponent();
            InitShowTimer();

            Resize += form_Resize;
            Load += form_Load;

            refresh_button.Click += refresh_button_Click;
            leave_button.Click += leave_button_Click;
            status_strip_label.Click += status_strip_label_Click;
            global_textbox_in.KeyDown += globalchat_textbox_in_KeyDown;
            room_textbox_in.KeyDown += roomchat_textbox_in_KeyDown;
            word_textbox.KeyDown += word_textbox_KeyDown;

            InviteMessageBox.AcceptClick += decision_Accept;
            InviteMessageBox.RejectClick += decision_Reject;

            OnResize(new EventArgs());
        }

        public void OnMessageReceived(Message message)
        {
            if (message.Type == MessageType.ServerAccept)
            {
                ShowInfo(last_request.Type.ToString() + " принято");
                if (last_request.Type == MessageType.ClientCreateInvite)
                {
                    invited_list.Add(last_request.Payload);
                    RefreshPlayerList();
                }
                if (last_request.Type == MessageType.ClientGameWord)
                {
                    word_textbox.ReadOnly = false;
                    word_textbox.Text = "";
                    word_textbox.BackColor = Color.Honeydew;
                }
                if (last_request.Type == MessageType.ClientRoomLeave)
                {
                    title_label.Text = "Выберите игрока";

                    foreach (Row1Text r in text1_rows) main_panel.Controls.Remove(r);
                    foreach (Row2Text r in text2_rows) main_panel.Controls.Remove(r);
                    text1_rows.Clear();
                    text2_rows.Clear();

                    refresh_button.Show();
                    leave_button.Hide();
                    word_textbox.ReadOnly = true;
                    word_textbox.BackColor = Color.White;
                    RefreshPlayerList();
                }
            }

            if (message.Type == MessageType.ServerReject)
            {
                ShowInfo(last_request.Type.ToString() + " отклонено");
            }

            if (message.Type == MessageType.ServerPlayerList)
            {
                last_players_list = message.Payload.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (!is_in_game) RefreshPlayerList();
                Text = $"Say the same.   " +
                       $"Server IP: {Client.GetClient().GetServerIP()} " +
                       $" - {last_players_list.Length} {(last_players_list.Length == 1 ? "player" : "players")} -   " +
                       $"User: {username}";
            }

            if (message.Type == MessageType.ServerGlobalChat)
            {
                global_textbox_out.AppendText(message.Payload + Environment.NewLine);
            }

            if (message.Type == MessageType.ServerRoomChat)
            {
                room_textbox_out.AppendText(message.Payload + Environment.NewLine);
            }

            if (message.Type == MessageType.ServerInviteCreated)
            {
                opponent_nickname = message.Payload;
                InviteMessageBox.Show(opponent_nickname);
            }

            if (message.Type == MessageType.ServerInviteRemoved)
            {
                string nickname = message.Payload;
                if (invited_list.Remove(nickname)) ShowInfo($"{nickname} отменил приглашение");
                if (!is_in_game) RefreshPlayerList();
            }

            if (message.Type == MessageType.ServerRoomEngagement)
            {
                opponent_nickname = message.Payload;
                invited_list.Clear();

                is_in_game = true;
                title_label.Text = $"Скажи тоже самое слово с игроком: {opponent_nickname}";

                refresh_button.Hide();
                leave_button.Show();

                foreach (RowInvite ri in invite_rows) ri.Hide();

                word_textbox.ReadOnly = false;
                word_textbox.BackColor = Color.White;
                word_textbox.Text = "";

                Row1Text row = new Row1Text();
                row.SetText("Введите начальные слова");
                text1_rows.Add(row);
                main_panel.Controls.Add(row);

                ShowInfo("Вы вошли в комнату");
            }

            if (message.Type == MessageType.ServerRoomCanceled)
            {
                is_in_game = false;
                title_label.Text = "Выберите игрока";

                refresh_button.Show();
                leave_button.Hide();

                main_panel.SuspendLayout();
                foreach (Row1Text r in text1_rows) main_panel.Controls.Remove(r);
                foreach (Row2Text r in text2_rows) main_panel.Controls.Remove(r);
                text1_rows.Clear();
                text2_rows.Clear();
                main_panel.ResumeLayout();

                RefreshPlayerList();

                word_textbox.Text = "";
                word_textbox.BackColor = Color.White;
                word_textbox.ReadOnly = true;
            }

            if (message.Type == MessageType.ServerGameReminder)
            {
                if(is_in_game) ShowInfo($"{opponent_nickname} разыграл слово");
            }

            if (message.Type == MessageType.ServerGameWordsOut)
            {
                string[] words = message.Payload.Split(' ');

                Row2Text row = new Row2Text();
                row.SetText(words[0].ToUpper(), words[1].ToUpper());
                text2_rows.Add(row);
                main_panel.Controls.Add(row);

                word_textbox.Text = "";
                word_textbox.BackColor = Color.White;
                word_textbox.ReadOnly = false;
            }

            if (message.Type == MessageType.ServerGameFinished)
            {
                Row1Text row1 = new Row1Text();
                row1.SetText("Игра окончена");
                text1_rows.Add(row1);
                main_panel.Controls.Add(row1);

                Row1Text row2 = new Row1Text();
                row2.SetText("Вы можете разыграть новую партию");
                text1_rows.Add(row2);
                main_panel.Controls.Add(row2);
            }
        }

        #region EventHandlers

        public void form_Resize(object? sender, EventArgs e)
        {
            int form_width = this.Width;
            int form_height = this.Height;

            int main_panel_width = 2 * form_width / 3 - 12;
            int main_panel_height = form_height - 159;

            int title_label_widht = main_panel_width - 118;
            int title_label_height = 38;

            main_panel.Location = new Point(12, 53);
            title_label.Location = new Point(130, 9);
            word_textbox.Location = new Point(12, main_panel_height + 23);

            main_panel.Size = new Size(main_panel_width, main_panel_height - 39);
            title_label.Size = new Size(title_label_widht, title_label_height);
            word_textbox.Size = new Size(main_panel_width, 31);

            main_tabcontrol.Location = new Point(2 * form_width / 3 + 6, 9);
            main_tabcontrol.Size = new Size(form_width / 3 - 36, main_panel_height + title_label_height);
        }

        private void form_Load(object? sender, EventArgs e)
        {
            Message nickrequest = new Message(MessageType.ClientNickname, username);
            Client.GetClient().PerformRequest(nickrequest);
            last_request = nickrequest;
        }

        private void refresh_button_Click(object? sender, EventArgs e)
        {
            Message request = new Message(MessageType.ClientPlayerList, "");
            Client.GetClient().PerformRequest(request);
        }

        private void leave_button_Click(object? sender, EventArgs e)
        {
            Message request = new Message(MessageType.ClientRoomLeave, "");
            Client.GetClient().PerformRequest(request);
            last_request = request;
        }

        private void status_strip_label_Click(object? sender, EventArgs e)
        {
            if (show_messages.Count > 0)
            {
                show_messages.RemoveFirst();
                StringBuilder sb = new StringBuilder();
                foreach (string msg in show_messages) sb.Append($"{msg}   ");
                status_strip_label.Text = sb.ToString();
            }
        }

        private void decision_Accept(object? sender, EventArgs e)
        {
            Message accept = new Message(MessageType.ClientInviteAccept, opponent_nickname);
            Client.GetClient().PerformRequest(accept);
            last_request = accept;
        }

        private void decision_Reject(object? sender, EventArgs e)
        {
            Message reject = new Message(MessageType.ClientInviteReject, opponent_nickname);
            Client.GetClient().PerformRequest(reject);
            last_request = reject;
        }

        private void globalchat_textbox_in_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Message chat = new Message(MessageType.ClientGlobalChat, global_textbox_in.Text);
                Client.GetClient().PerformRequest(chat);
                last_request = chat;
                global_textbox_in.Text = "";
            }
        }

        private void roomchat_textbox_in_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Message chat = new Message(MessageType.ClientRoomChat, room_textbox_in.Text);
                Client.GetClient().PerformRequest(chat);
                last_request = chat;
                room_textbox_in.Text = "";
            }
        }

        private void invite_label_Click(string nickname)
        {
            Message request = new Message(MessageType.ClientCreateInvite, nickname);
            Client.GetClient().PerformRequest(request);
            last_request = request;
        }

        private void word_textbox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !word_textbox.ReadOnly)
            {
                Message request = new Message(MessageType.ClientGameWord, word_textbox.Text.ToLower());
                Client.GetClient().PerformRequest(request);
                last_request = request;
            }
        }

    #endregion

        #region ShowInfo

        Timer show_timer = new Timer();
        LinkedList<string> show_messages = new LinkedList<string>();
        private void ShowInfo(string info)
        {
            show_messages.AddLast($"*{info}*");
            StringBuilder sb = new StringBuilder();
            foreach (string msg in show_messages) sb.Append($"{msg}   ");
            status_strip_label.Text = sb.ToString();
        }
        private void InitShowTimer()
        {
            show_timer.Interval = 4000;
            show_timer.Start();
            show_timer.Tick += (object? o, EventArgs e) =>
            {
                if (show_messages.Count >= 2)
                {
                    show_messages.RemoveFirst();
                    StringBuilder sb = new StringBuilder();
                    foreach (string msg in show_messages) sb.Append($"{msg}   ");
                    status_strip_label.Text = sb.ToString();
                }
            };
        }

        #endregion

        List<Row1Text> text1_rows = new List<Row1Text>();
        List<Row2Text> text2_rows = new List<Row2Text>();
        List<RowInvite> invite_rows = new List<RowInvite>();
        private void RefreshPlayerList()
        {
            main_panel.SuspendLayout();
            foreach (RowInvite ri in invite_rows) main_panel.Controls.Remove(ri);
            invite_rows.Clear();
            for (int i = 0; i < last_players_list.Length; i++)
            {
                RowInvite row = new RowInvite(invite_label_Click);
                invite_rows.Add(row);
                main_panel.Controls.Add(row);

                char prefix = last_players_list[i][0];
                string nickname_clear = last_players_list[i].Remove(0, 1);

                if (invited_list.Contains(nickname_clear))
                {
                    if (prefix == '!') invite_rows[i].SetText(false, "Приглашён", nickname_clear, "В игре");
                    if (prefix == '?') invite_rows[i].SetText(false, "Приглашён", nickname_clear, "Свободен");
                    if (prefix == '^') invite_rows[i].SetText(false, "Ошибка", nickname_clear, "Это вы");
                }
                else
                {
                    if (prefix == '!') invite_rows[i].SetText(false, "Занят", nickname_clear, "В игре");
                    if (prefix == '?') invite_rows[i].SetText(true, "Пригласить", nickname_clear, "Свободен");
                    if (prefix == '^') 
                    {
                        invite_rows[i].SetText(false, "", nickname_clear, "Это вы");
                        username = nickname_clear;
                    }
                }
            }

            foreach (RowInvite row in invite_rows) row.Show();

            main_panel.ResumeLayout();
        }

    }
}
