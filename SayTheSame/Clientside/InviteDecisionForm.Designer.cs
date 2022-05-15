namespace SayTheSame
{
    partial class InviteDecisionForm : Form
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
            this.accept_button = new System.Windows.Forms.Button();
            this.reject_button = new System.Windows.Forms.Button();
            this.info_label = new System.Windows.Forms.Label();
            this.nickname_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accept_button
            // 
            this.accept_button.Location = new System.Drawing.Point(32, 128);
            this.accept_button.Name = "accept_button";
            this.accept_button.Size = new System.Drawing.Size(127, 39);
            this.accept_button.TabIndex = 0;
            this.accept_button.Text = "Принять";
            this.accept_button.UseVisualStyleBackColor = true;
            // 
            // reject_button
            // 
            this.reject_button.Location = new System.Drawing.Point(212, 128);
            this.reject_button.Name = "reject_button";
            this.reject_button.Size = new System.Drawing.Size(127, 39);
            this.reject_button.TabIndex = 1;
            this.reject_button.Text = "Отклонить";
            this.reject_button.UseVisualStyleBackColor = true;
            // 
            // info_label
            // 
            this.info_label.Dock = System.Windows.Forms.DockStyle.Top;
            this.info_label.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.info_label.Location = new System.Drawing.Point(0, 0);
            this.info_label.Name = "info_label";
            this.info_label.Size = new System.Drawing.Size(378, 46);
            this.info_label.TabIndex = 2;
            this.info_label.Text = "С вами хочет сыграть:";
            this.info_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nickname_label
            // 
            this.nickname_label.Dock = System.Windows.Forms.DockStyle.Top;
            this.nickname_label.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nickname_label.Location = new System.Drawing.Point(0, 46);
            this.nickname_label.Name = "nickname_label";
            this.nickname_label.Size = new System.Drawing.Size(378, 39);
            this.nickname_label.TabIndex = 3;
            this.nickname_label.Text = "undefined";
            this.nickname_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InviteDecisionForm
            // 
            this.AcceptButton = this.accept_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.reject_button;
            this.ClientSize = new System.Drawing.Size(378, 194);
            this.ControlBox = false;
            this.Controls.Add(this.nickname_label);
            this.Controls.Add(this.info_label);
            this.Controls.Add(this.reject_button);
            this.Controls.Add(this.accept_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InviteDecisionForm";
            this.Text = "Приглашение";
            this.ResumeLayout(false);

        }

        #endregion

        private Button accept_button;
        private Button reject_button;
        private Label info_label;
        private Label nickname_label;
    }
}