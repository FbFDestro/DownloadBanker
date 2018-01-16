namespace DownloadBanker
{
    partial class frmTesteIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTesteIP));
            this.pnlTesteIP = new System.Windows.Forms.Panel();
            this.lblConectar = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtUsu = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.pnlTesteIP.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTesteIP
            // 
            this.pnlTesteIP.BackgroundImage = global::DownloadBanker.Properties.Resources.TelaTesteIP;
            this.pnlTesteIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTesteIP.Controls.Add(this.lblConectar);
            this.pnlTesteIP.Controls.Add(this.txtSenha);
            this.pnlTesteIP.Controls.Add(this.txtUsu);
            this.pnlTesteIP.Controls.Add(this.txtIP);
            this.pnlTesteIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTesteIP.Location = new System.Drawing.Point(0, 0);
            this.pnlTesteIP.MaximumSize = new System.Drawing.Size(391, 273);
            this.pnlTesteIP.MinimumSize = new System.Drawing.Size(391, 273);
            this.pnlTesteIP.Name = "pnlTesteIP";
            this.pnlTesteIP.Size = new System.Drawing.Size(391, 273);
            this.pnlTesteIP.TabIndex = 0;
            // 
            // lblConectar
            // 
            this.lblConectar.BackColor = System.Drawing.Color.Transparent;
            this.lblConectar.Location = new System.Drawing.Point(24, 229);
            this.lblConectar.Name = "lblConectar";
            this.lblConectar.Size = new System.Drawing.Size(157, 20);
            this.lblConectar.TabIndex = 21;
            this.lblConectar.Click += new System.EventHandler(this.lblConectar_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(119, 153);
            this.txtSenha.Margin = new System.Windows.Forms.Padding(5);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(164, 20);
            this.txtSenha.TabIndex = 16;
            // 
            // txtUsu
            // 
            this.txtUsu.Location = new System.Drawing.Point(134, 107);
            this.txtUsu.Margin = new System.Windows.Forms.Padding(5);
            this.txtUsu.Name = "txtUsu";
            this.txtUsu.Size = new System.Drawing.Size(164, 20);
            this.txtUsu.TabIndex = 15;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(69, 65);
            this.txtIP.Margin = new System.Windows.Forms.Padding(5);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(164, 20);
            this.txtIP.TabIndex = 14;
            // 
            // frmTesteIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 273);
            this.Controls.Add(this.pnlTesteIP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(407, 312);
            this.MinimumSize = new System.Drawing.Size(407, 312);
            this.Name = "frmTesteIP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DownloadBanker - Teste IP";
            this.pnlTesteIP.ResumeLayout(false);
            this.pnlTesteIP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTesteIP;
        private System.Windows.Forms.Label lblConectar;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtUsu;
        private System.Windows.Forms.TextBox txtIP;
    }
}