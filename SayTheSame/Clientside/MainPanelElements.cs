using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayTheSame
{
    public class Row2Text : Panel
    {
        private Label left_label;
        private Label right_label;

        public Row2Text()
        {
            left_label = new Label();
            right_label = new Label();

            this.SuspendLayout();

            this.Dock = DockStyle.Top;

            left_label.BackColor = SystemColors.Control;
            left_label.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            left_label.TextAlign = ContentAlignment.MiddleCenter;
            left_label.AutoSize = false;

            right_label.BackColor = SystemColors.Control;
            right_label.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point);
            right_label.TextAlign = ContentAlignment.MiddleCenter;
            right_label.AutoSize = false;

            this.Controls.Add(left_label);
            this.Controls.Add(right_label);

            this.Resize += (object? o, EventArgs e) =>
            {
                if (this.Parent != null)
                {
                    int width = Parent.Size.Width;
                    int height = 40;
                    int margin = 1;

                    this.SuspendLayout();
                    this.Size = new Size(width, height);
                    left_label.Location = new Point(margin, margin);
                    right_label.Location = new Point(width / 2 + margin, margin);
                    left_label.Size = new Size(width / 2 - margin, height - margin);
                    right_label.Size = new Size(width / 2 - margin, height - margin);
                    this.ResumeLayout();
                }
            };

            this.ResumeLayout();
        }

        public void SetText(string left, string right)
        {
            left_label.Text = left;
            right_label.Text = right;
        }
    }

    public class Row1Text : Panel
    {
        private Label label;

        public Row1Text()
        {
            label = new Label();

            this.SuspendLayout();

            this.Dock = DockStyle.Top;

            label.BackColor = SystemColors.Control;
            label.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label.ForeColor = SystemColors.GrayText;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.AutoSize = false;

            this.Controls.Add(label);

            this.Resize += (object? o, EventArgs e) =>
            {
                if (this.Parent != null)
                {
                    int width = Parent.Size.Width;
                    int height = 40;
                    int margin = 1;

                    this.SuspendLayout();
                    this.Size = new Size(width, height);
                    label.Location = new Point(margin, margin);
                    label.Size = new Size(width - margin, height - margin);
                    this.ResumeLayout();
                }
            };

            this.ResumeLayout();
        }

        public void SetText(string text)
        {
            label.Text = text;
        }
    }

    public class RowInvite : Panel
    {
        private LinkLabel invite_label = new LinkLabel();
        private Label nickname_label = new Label();
        private Label status_label = new Label();

        public RowInvite(Action<string> Click)
        {
            invite_label = new LinkLabel();
            nickname_label = new Label();
            status_label = new Label();

            this.SuspendLayout();

            this.Dock = DockStyle.Top;

            invite_label.BackColor = SystemColors.Control;
            invite_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            invite_label.TextAlign = ContentAlignment.MiddleCenter;
            invite_label.AutoSize = false;

            nickname_label.BackColor = SystemColors.Control;
            nickname_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nickname_label.TextAlign = ContentAlignment.MiddleCenter;
            nickname_label.AutoSize = false;

            status_label.BackColor = SystemColors.Control;
            status_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            status_label.TextAlign = ContentAlignment.MiddleCenter;
            status_label.AutoSize = false;

            this.Controls.Add(invite_label);
            this.Controls.Add(nickname_label);
            this.Controls.Add(status_label);

            this.Resize += (object? o, EventArgs e) =>
            {
                if (this.Parent != null)
                {
                    int width = Parent.Size.Width;
                    int height = 40;
                    int margin = 1;

                    this.SuspendLayout();
                    this.Size = new Size(width, height);
                    invite_label.Location = new Point(margin, margin);
                    nickname_label.Location = new Point(width / 3 + margin, margin);
                    status_label.Location = new Point(2 * (width / 3) + margin, margin);
                    invite_label.Size = new Size(width / 3 - margin, height - margin);
                    nickname_label.Size = new Size(width / 3 - margin, height - margin);
                    status_label.Size = new Size(width / 3 - margin, height - margin);
                    this.ResumeLayout();
                }
            };

            invite_label.Click += (object? o, EventArgs e) =>
            {
                Click(nickname_label.Text);
            };

            this.ResumeLayout();
        }

        public void SetText(bool enabled, string linktext, string nickname, string status)
        {
            invite_label.Text = linktext;
            nickname_label.Text = nickname;
            status_label.Text = status;
            invite_label.Name = nickname;
            if (enabled) invite_label.Enabled = true;
            else invite_label.Enabled = false;
        }
    }
}
