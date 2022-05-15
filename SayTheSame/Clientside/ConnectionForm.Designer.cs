namespace SayTheSame
{
    partial class ConnectionForm : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionForm));
            this.accept_button = new System.Windows.Forms.Button();
            this.ip_textbox = new System.Windows.Forms.TextBox();
            this.nickname_textbox = new System.Windows.Forms.TextBox();
            this.ip_label = new System.Windows.Forms.Label();
            this.nickname_label = new System.Windows.Forms.Label();
            this.header_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.server_linklabel = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // accept_button
            // 
            this.accept_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accept_button.Location = new System.Drawing.Point(40, 10);
            this.accept_button.Name = "accept_button";
            this.accept_button.Size = new System.Drawing.Size(298, 56);
            this.accept_button.TabIndex = 0;
            this.accept_button.Text = "Подключиться";
            this.accept_button.UseVisualStyleBackColor = true;
            this.accept_button.Click += new System.EventHandler(this.accept_button_Click);
            // 
            // ip_textbox
            // 
            this.ip_textbox.Location = new System.Drawing.Point(167, 72);
            this.ip_textbox.Name = "ip_textbox";
            this.ip_textbox.Size = new System.Drawing.Size(199, 31);
            this.ip_textbox.TabIndex = 1;
            this.ip_textbox.Text = "127.0.0.1";
            // 
            // nickname_textbox
            // 
            this.nickname_textbox.Location = new System.Drawing.Point(167, 142);
            this.nickname_textbox.Name = "nickname_textbox";
            this.nickname_textbox.Size = new System.Drawing.Size(199, 31);
            this.nickname_textbox.TabIndex = 2;
            // 
            // ip_label
            // 
            this.ip_label.AutoSize = true;
            this.ip_label.Location = new System.Drawing.Point(35, 72);
            this.ip_label.Name = "ip_label";
            this.ip_label.Size = new System.Drawing.Size(85, 25);
            this.ip_label.TabIndex = 3;
            this.ip_label.Text = "Server IP:";
            // 
            // nickname_label
            // 
            this.nickname_label.AutoSize = true;
            this.nickname_label.Location = new System.Drawing.Point(26, 142);
            this.nickname_label.Name = "nickname_label";
            this.nickname_label.Size = new System.Drawing.Size(94, 25);
            this.nickname_label.TabIndex = 4;
            this.nickname_label.Text = "Nickname:";
            // 
            // header_label
            // 
            this.header_label.Dock = System.Windows.Forms.DockStyle.Top;
            this.header_label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.header_label.Location = new System.Drawing.Point(0, 0);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(378, 61);
            this.header_label.TabIndex = 5;
            this.header_label.Text = "Подключение к игровому серверу";
            this.header_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.accept_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 353);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(40, 10, 40, 25);
            this.panel1.Size = new System.Drawing.Size(378, 91);
            this.panel1.TabIndex = 6;
            // 
            // server_linklabel
            // 
            this.server_linklabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.server_linklabel.Location = new System.Drawing.Point(0, 284);
            this.server_linklabel.Name = "server_linklabel";
            this.server_linklabel.Size = new System.Drawing.Size(378, 69);
            this.server_linklabel.TabIndex = 7;
            this.server_linklabel.TabStop = true;
            this.server_linklabel.Text = "Нажмите для запуска сервера сюда";
            this.server_linklabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.server_linklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.server_linklabel_LinkClicked);
            // 
            // ConnectionForm
            // 
            this.AcceptButton = this.accept_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 444);
            this.Controls.Add(this.server_linklabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.header_label);
            this.Controls.Add(this.nickname_label);
            this.Controls.Add(this.ip_label);
            this.Controls.Add(this.nickname_textbox);
            this.Controls.Add(this.ip_textbox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConnectionForm";
            this.Text = "Say the same";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button accept_button;
        private TextBox ip_textbox;
        private TextBox nickname_textbox;
        private Label ip_label;
        private Label nickname_label;
        private Label header_label;
        private Panel panel1;
        private LinkLabel server_linklabel;
    }
}