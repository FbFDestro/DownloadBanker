namespace DownloadBanker
{
    partial class frmEsqueceuSenha
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
            this.pnlSenhaEsquec = new System.Windows.Forms.Panel();
            this.lblEnviar = new System.Windows.Forms.Label();
            this.lblVoltar = new System.Windows.Forms.Label();
            this.mskCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.pnlSenhaEsquec.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSenhaEsquec
            // 
            this.pnlSenhaEsquec.BackgroundImage = global::DownloadBanker.Properties.Resources.TelaEsqueciSenha;
            this.pnlSenhaEsquec.Controls.Add(this.lblEnviar);
            this.pnlSenhaEsquec.Controls.Add(this.lblVoltar);
            this.pnlSenhaEsquec.Controls.Add(this.mskCPF);
            this.pnlSenhaEsquec.Controls.Add(this.txtEmail);
            this.pnlSenhaEsquec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSenhaEsquec.Location = new System.Drawing.Point(0, 0);
            this.pnlSenhaEsquec.Name = "pnlSenhaEsquec";
            this.pnlSenhaEsquec.Size = new System.Drawing.Size(432, 299);
            this.pnlSenhaEsquec.TabIndex = 0;
            // 
            // lblEnviar
            // 
            this.lblEnviar.BackColor = System.Drawing.Color.Transparent;
            this.lblEnviar.Location = new System.Drawing.Point(137, 250);
            this.lblEnviar.Name = "lblEnviar";
            this.lblEnviar.Size = new System.Drawing.Size(84, 21);
            this.lblEnviar.TabIndex = 4;
            this.lblEnviar.Click += new System.EventHandler(this.lblEnviar_Click);
            // 
            // lblVoltar
            // 
            this.lblVoltar.BackColor = System.Drawing.Color.Transparent;
            this.lblVoltar.Location = new System.Drawing.Point(22, 250);
            this.lblVoltar.Name = "lblVoltar";
            this.lblVoltar.Size = new System.Drawing.Size(91, 21);
            this.lblVoltar.TabIndex = 3;
            this.lblVoltar.Click += new System.EventHandler(this.lblVoltar_Click);
            // 
            // mskCPF
            // 
            this.mskCPF.Location = new System.Drawing.Point(123, 114);
            this.mskCPF.Mask = "000.000.000-00";
            this.mskCPF.Name = "mskCPF";
            this.mskCPF.Size = new System.Drawing.Size(90, 20);
            this.mskCPF.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(123, 181);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(178, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // frmEsqueceuSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 299);
            this.Controls.Add(this.pnlSenhaEsquec);
            this.Name = "frmEsqueceuSenha";
            this.Text = "frmEsqueceuSenha";
            this.pnlSenhaEsquec.ResumeLayout(false);
            this.pnlSenhaEsquec.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSenhaEsquec;
        private System.Windows.Forms.MaskedTextBox mskCPF;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEnviar;
        private System.Windows.Forms.Label lblVoltar;
    }
}