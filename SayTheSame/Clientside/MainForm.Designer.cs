namespace SayTheSame
{
    partial class MainForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.status_strip = new System.Windows.Forms.StatusStrip();
            this.status_strip_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.main_tabcontrol = new System.Windows.Forms.TabControl();
            this.help_tabpage = new System.Windows.Forms.TabPage();
            this.help_textbox = new System.Windows.Forms.TextBox();
            this.globalchat_tabpage = new System.Windows.Forms.TabPage();
            this.global_textbox_in = new System.Windows.Forms.TextBox();
            this.global_textbox_out = new System.Windows.Forms.TextBox();
            this.roomchat_tabpage = new System.Windows.Forms.TabPage();
            this.room_textbox_out = new System.Windows.Forms.TextBox();
            this.room_textbox_in = new System.Windows.Forms.TextBox();
            this.title_label = new System.Windows.Forms.Label();
            this.refresh_button = new System.Windows.Forms.Button();
            this.main_panel = new System.Windows.Forms.Panel();
            this.leave_button = new System.Windows.Forms.Button();
            this.word_textbox = new System.Windows.Forms.TextBox();
            this.status_strip.SuspendLayout();
            this.main_tabcontrol.SuspendLayout();
            this.help_tabpage.SuspendLayout();
            this.globalchat_tabpage.SuspendLayout();
            this.roomchat_tabpage.SuspendLayout();
            this.SuspendLayout();
            // 
            // status_strip
            // 
            this.status_strip.AutoSize = false;
            this.status_strip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.status_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_strip_label});
            this.status_strip.Location = new System.Drawing.Point(0, 579);
            this.status_strip.Name = "status_strip";
            this.status_strip.Size = new System.Drawing.Size(1042, 50);
            this.status_strip.TabIndex = 1;
            this.status_strip.Text = "status_strip";
            // 
            // status_strip_label
            // 
            this.status_strip_label.BackColor = System.Drawing.SystemColors.Control;
            this.status_strip_label.Name = "status_strip_label";
            this.status_strip_label.Size = new System.Drawing.Size(0, 43);
            this.status_strip_label.Tag = "";
            this.status_strip_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // main_tabcontrol
            // 
            this.main_tabcontrol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.main_tabcontrol.Controls.Add(this.help_tabpage);
            this.main_tabcontrol.Controls.Add(this.globalchat_tabpage);
            this.main_tabcontrol.Controls.Add(this.roomchat_tabpage);
            this.main_tabcontrol.Location = new System.Drawing.Point(673, 12);
            this.main_tabcontrol.Name = "main_tabcontrol";
            this.main_tabcontrol.SelectedIndex = 0;
            this.main_tabcontrol.Size = new System.Drawing.Size(357, 564);
            this.main_tabcontrol.TabIndex = 2;
            // 
            // help_tabpage
            // 
            this.help_tabpage.Controls.Add(this.help_textbox);
            this.help_tabpage.Location = new System.Drawing.Point(4, 34);
            this.help_tabpage.Name = "help_tabpage";
            this.help_tabpage.Padding = new System.Windows.Forms.Padding(3);
            this.help_tabpage.Size = new System.Drawing.Size(349, 526);
            this.help_tabpage.TabIndex = 0;
            this.help_tabpage.Text = "О игре";
            this.help_tabpage.UseVisualStyleBackColor = true;
            // 
            // help_textbox
            // 
            this.help_textbox.AcceptsReturn = true;
            this.help_textbox.AcceptsTab = true;
            this.help_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.help_textbox.BackColor = System.Drawing.SystemColors.Window;
            this.help_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.help_textbox.Location = new System.Drawing.Point(6, 7);
            this.help_textbox.Multiline = true;
            this.help_textbox.Name = "help_textbox";
            this.help_textbox.ReadOnly = true;
            this.help_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.help_textbox.Size = new System.Drawing.Size(337, 513);
            this.help_textbox.TabIndex = 7;
            this.help_textbox.Text = resources.GetString("help_textbox.Text");
            // 
            // globalchat_tabpage
            // 
            this.globalchat_tabpage.BackColor = System.Drawing.SystemColors.Window;
            this.globalchat_tabpage.Controls.Add(this.global_textbox_in);
            this.globalchat_tabpage.Controls.Add(this.global_textbox_out);
            this.globalchat_tabpage.Location = new System.Drawing.Point(4, 34);
            this.globalchat_tabpage.Name = "globalchat_tabpage";
            this.globalchat_tabpage.Padding = new System.Windows.Forms.Padding(3);
            this.globalchat_tabpage.Size = new System.Drawing.Size(349, 526);
            this.globalchat_tabpage.TabIndex = 1;
            this.globalchat_tabpage.Text = "Общий чат";
            // 
            // global_textbox_in
            // 
            this.global_textbox_in.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.global_textbox_in.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.global_textbox_in.Location = new System.Drawing.Point(6, 491);
            this.global_textbox_in.Name = "global_textbox_in";
            this.global_textbox_in.Size = new System.Drawing.Size(337, 31);
            this.global_textbox_in.TabIndex = 7;
            // 
            // global_textbox_out
            // 
            this.global_textbox_out.AcceptsReturn = true;
            this.global_textbox_out.AcceptsTab = true;
            this.global_textbox_out.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.global_textbox_out.BackColor = System.Drawing.SystemColors.Window;
            this.global_textbox_out.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.global_textbox_out.Location = new System.Drawing.Point(6, 7);
            this.global_textbox_out.Multiline = true;
            this.global_textbox_out.Name = "global_textbox_out";
            this.global_textbox_out.ReadOnly = true;
            this.global_textbox_out.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.global_textbox_out.Size = new System.Drawing.Size(337, 478);
            this.global_textbox_out.TabIndex = 6;
            // 
            // roomchat_tabpage
            // 
            this.roomchat_tabpage.BackColor = System.Drawing.SystemColors.Window;
            this.roomchat_tabpage.Controls.Add(this.room_textbox_out);
            this.roomchat_tabpage.Controls.Add(this.room_textbox_in);
            this.roomchat_tabpage.Location = new System.Drawing.Point(4, 34);
            this.roomchat_tabpage.Name = "roomchat_tabpage";
            this.roomchat_tabpage.Padding = new System.Windows.Forms.Padding(3);
            this.roomchat_tabpage.Size = new System.Drawing.Size(349, 526);
            this.roomchat_tabpage.TabIndex = 2;
            this.roomchat_tabpage.Text = "Чат комнаты";
            // 
            // room_textbox_out
            // 
            this.room_textbox_out.AcceptsReturn = true;
            this.room_textbox_out.AcceptsTab = true;
            this.room_textbox_out.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.room_textbox_out.BackColor = System.Drawing.SystemColors.Window;
            this.room_textbox_out.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.room_textbox_out.Location = new System.Drawing.Point(6, 7);
            this.room_textbox_out.Multiline = true;
            this.room_textbox_out.Name = "room_textbox_out";
            this.room_textbox_out.ReadOnly = true;
            this.room_textbox_out.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.room_textbox_out.Size = new System.Drawing.Size(337, 478);
            this.room_textbox_out.TabIndex = 4;
            // 
            // room_textbox_in
            // 
            this.room_textbox_in.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.room_textbox_in.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.room_textbox_in.Location = new System.Drawing.Point(6, 491);
            this.room_textbox_in.Name = "room_textbox_in";
            this.room_textbox_in.Size = new System.Drawing.Size(337, 31);
            this.room_textbox_in.TabIndex = 3;
            // 
            // title_label
            // 
            this.title_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.title_label.BackColor = System.Drawing.SystemColors.Control;
            this.title_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.title_label.Location = new System.Drawing.Point(130, 9);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(537, 38);
            this.title_label.TabIndex = 3;
            this.title_label.Text = "Выберите игрока";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // refresh_button
            // 
            this.refresh_button.Location = new System.Drawing.Point(12, 9);
            this.refresh_button.Name = "refresh_button";
            this.refresh_button.Size = new System.Drawing.Size(112, 38);
            this.refresh_button.TabIndex = 0;
            this.refresh_button.Text = "Обновить";
            this.refresh_button.UseVisualStyleBackColor = true;
            // 
            // main_panel
            // 
            this.main_panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.main_panel.AutoScroll = true;
            this.main_panel.BackColor = System.Drawing.SystemColors.Window;
            this.main_panel.Location = new System.Drawing.Point(12, 53);
            this.main_panel.Margin = new System.Windows.Forms.Padding(0);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(655, 478);
            this.main_panel.TabIndex = 4;
            // 
            // leave_button
            // 
            this.leave_button.Location = new System.Drawing.Point(12, 9);
            this.leave_button.Name = "leave_button";
            this.leave_button.Size = new System.Drawing.Size(112, 38);
            this.leave_button.TabIndex = 5;
            this.leave_button.Text = "Выйти";
            this.leave_button.UseVisualStyleBackColor = true;
            this.leave_button.Visible = false;
            // 
            // word_textbox
            // 
            this.word_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.word_textbox.BackColor = System.Drawing.Color.White;
            this.word_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.word_textbox.Location = new System.Drawing.Point(12, 537);
            this.word_textbox.Name = "word_textbox";
            this.word_textbox.ReadOnly = true;
            this.word_textbox.Size = new System.Drawing.Size(655, 24);
            this.word_textbox.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1042, 629);
            this.Controls.Add(this.word_textbox);
            this.Controls.Add(this.leave_button);
            this.Controls.Add(this.main_panel);
            this.Controls.Add(this.refresh_button);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.main_tabcontrol);
            this.Controls.Add(this.status_strip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Say the same";
            this.status_strip.ResumeLayout(false);
            this.status_strip.PerformLayout();
            this.main_tabcontrol.ResumeLayout(false);
            this.help_tabpage.ResumeLayout(false);
            this.help_tabpage.PerformLayout();
            this.globalchat_tabpage.ResumeLayout(false);
            this.globalchat_tabpage.PerformLayout();
            this.roomchat_tabpage.ResumeLayout(false);
            this.roomchat_tabpage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private StatusStrip status_strip;
        private ToolStripStatusLabel status_strip_label;
        private TabControl main_tabcontrol;
        private TabPage help_tabpage;
        private TabPage globalchat_tabpage;
        private TabPage roomchat_tabpage;
        private Label title_label;
        private Button refresh_button;
        private Panel main_panel;
        private Button leave_button;
        private TextBox room_textbox_out;
        private TextBox room_textbox_in;
        private TextBox global_textbox_in;
        private TextBox global_textbox_out;
        private TextBox help_textbox;
        private TextBox word_textbox;
    }
}