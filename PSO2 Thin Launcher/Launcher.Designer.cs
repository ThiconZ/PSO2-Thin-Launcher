namespace PSO2_Thin_Launcher
{
    partial class Launcher
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.LaunchBtn = new System.Windows.Forms.Button();
            this.PathTextLabel = new System.Windows.Forms.Label();
            this.PathValueLabel = new System.Windows.Forms.Label();
            this.TrayContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExitLauncherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.PathDivider = new System.Windows.Forms.Label();
            this.TrayContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // LaunchBtn
            // 
            this.LaunchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LaunchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LaunchBtn.Location = new System.Drawing.Point(13, 265);
            this.LaunchBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LaunchBtn.Name = "LaunchBtn";
            this.LaunchBtn.Size = new System.Drawing.Size(704, 38);
            this.LaunchBtn.TabIndex = 0;
            this.LaunchBtn.Text = "LAUNCH";
            this.LaunchBtn.UseVisualStyleBackColor = true;
            this.LaunchBtn.Click += new System.EventHandler(this.LaunchBtn_Click);
            // 
            // PathTextLabel
            // 
            this.PathTextLabel.Location = new System.Drawing.Point(12, 9);
            this.PathTextLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PathTextLabel.Name = "PathTextLabel";
            this.PathTextLabel.Size = new System.Drawing.Size(150, 28);
            this.PathTextLabel.TabIndex = 1;
            this.PathTextLabel.Text = "PSO2 Install Path:";
            this.PathTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PathValueLabel
            // 
            this.PathValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathValueLabel.Location = new System.Drawing.Point(12, 37);
            this.PathValueLabel.Name = "PathValueLabel";
            this.PathValueLabel.Size = new System.Drawing.Size(706, 28);
            this.PathValueLabel.TabIndex = 2;
            this.PathValueLabel.Text = "<Path>";
            this.PathValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TrayContextMenuStrip
            // 
            this.TrayContextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TrayContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitLauncherToolStripMenuItem});
            this.TrayContextMenuStrip.Name = "TrayContextMenuStrip";
            this.TrayContextMenuStrip.Size = new System.Drawing.Size(146, 26);
            // 
            // ExitLauncherToolStripMenuItem
            // 
            this.ExitLauncherToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.ExitLauncherToolStripMenuItem.Name = "ExitLauncherToolStripMenuItem";
            this.ExitLauncherToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.ExitLauncherToolStripMenuItem.Text = "Exit Launcher";
            this.ExitLauncherToolStripMenuItem.Click += new System.EventHandler(this.ExitLauncherToolStripMenuItem_Click);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.Location = new System.Drawing.Point(12, 79);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(706, 172);
            this.DescriptionLabel.TabIndex = 4;
            this.DescriptionLabel.Text = resources.GetString("DescriptionLabel.Text");
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PathDivider
            // 
            this.PathDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathDivider.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PathDivider.Location = new System.Drawing.Point(12, 71);
            this.PathDivider.Name = "PathDivider";
            this.PathDivider.Size = new System.Drawing.Size(706, 2);
            this.PathDivider.TabIndex = 5;
            this.PathDivider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(730, 317);
            this.Controls.Add(this.PathDivider);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.PathValueLabel);
            this.Controls.Add(this.PathTextLabel);
            this.Controls.Add(this.LaunchBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PSO2 Thin Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Launcher_FormClosing);
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.TrayContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LaunchBtn;
        private System.Windows.Forms.Label PathTextLabel;
        private System.Windows.Forms.Label PathValueLabel;
        private System.Windows.Forms.ContextMenuStrip TrayContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ExitLauncherToolStripMenuItem;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label PathDivider;
    }
}

