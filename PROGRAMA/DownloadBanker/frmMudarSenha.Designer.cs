namespace DownloadBanker
{
    partial class frmMudarSenha
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSalvar = new System.Windows.Forms.Label();
            this.lblForca = new System.Windows.Forms.Label();
            this.progressForca = new System.Windows.Forms.ProgressBar();
            this.txtConfirma = new System.Windows.Forms.TextBox();
            this.txtNovaSenha = new System.Windows.Forms.TextBox();
            this.txtSenhaAtual = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::DownloadBanker.Properties.Resources.TelaMudarSenha;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblSalvar);
            this.panel1.Controls.Add(this.lblForca);
            this.panel1.Controls.Add(this.progressForca);
            this.panel1.Controls.Add(this.txtConfirma);
            this.panel1.Controls.Add(this.txtNovaSenha);
            this.panel1.Controls.Add(this.txtSenhaAtual);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 298);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(13, 263);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 32);
            this.pictureBox1.TabIndex = 84;
            this.pictureBox1.TabStop = false;
            // 
            // lblSalvar
            // 
            this.lblSalvar.BackColor = System.Drawing.Color.Transparent;
            this.lblSalvar.Location = new System.Drawing.Point(111, 262);
            this.lblSalvar.Name = "lblSalvar";
            this.lblSalvar.Size = new System.Drawing.Size(84, 27);
            this.lblSalvar.TabIndex = 83;
            this.lblSalvar.Click += new System.EventHandler(this.lblSalvar_Click);
            // 
            // lblForca
            // 
            this.lblForca.AutoSize = true;
            this.lblForca.Location = new System.Drawing.Point(195, 181);
            this.lblForca.Name = "lblForca";
            this.lblForca.Size = new System.Drawing.Size(0, 13);
            this.lblForca.TabIndex = 82;
            // 
            // progressForca
            // 
            this.progressForca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressForca.BackColor = System.Drawing.SystemColors.Control;
            this.progressForca.Location = new System.Drawing.Point(194, 200);
            this.progressForca.Name = "progressForca";
            this.progressForca.Size = new System.Drawing.Size(154, 5);
            this.progressForca.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressForca.TabIndex = 81;
            // 
            // txtConfirma
            // 
            this.txtConfirma.Location = new System.Drawing.Point(37, 236);
            this.txtConfirma.Name = "txtConfirma";
            this.txtConfirma.PasswordChar = '*';
            this.txtConfirma.Size = new System.Drawing.Size(151, 20);
            this.txtConfirma.TabIndex = 2;
            // 
            // txtNovaSenha
            // 
            this.txtNovaSenha.Location = new System.Drawing.Point(37, 185);
            this.txtNovaSenha.Name = "txtNovaSenha";
            this.txtNovaSenha.PasswordChar = '*';
            this.txtNovaSenha.Size = new System.Drawing.Size(151, 20);
            this.txtNovaSenha.TabIndex = 1;
            this.txtNovaSenha.TextChanged += new System.EventHandler(this.txtNovaSenha_TextChanged);
            this.txtNovaSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNovaSenha_KeyPress);
            // 
            // txtSenhaAtual
            // 
            this.txtSenhaAtual.Location = new System.Drawing.Point(37, 122);
            this.txtSenhaAtual.Name = "txtSenhaAtual";
            this.txtSenhaAtual.PasswordChar = '*';
            this.txtSenhaAtual.Size = new System.Drawing.Size(151, 20);
            this.txtSenhaAtual.TabIndex = 0;
            // 
            // frmMudarSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 298);
            this.Controls.Add(this.panel1);
            this.Name = "frmMudarSenha";
            this.Text = "Mudar senha";
            this.Load += new System.EventHandler(this.frmMudarSenha_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressForca;
        private System.Windows.Forms.TextBox txtConfirma;
        private System.Windows.Forms.TextBox txtNovaSenha;
        private System.Windows.Forms.TextBox txtSenhaAtual;
        private System.Windows.Forms.Label lblForca;
        private System.Windows.Forms.Label lblSalvar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}