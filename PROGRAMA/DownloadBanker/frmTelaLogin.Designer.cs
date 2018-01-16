namespace DownloadBanker
{
    partial class frmTelaLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTelaLogin));
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.lnkSenhaEsqueci = new System.Windows.Forms.LinkLabel();
            this.pctTipo = new System.Windows.Forms.PictureBox();
            this.pctSenha = new System.Windows.Forms.PictureBox();
            this.pctUsuario = new System.Windows.Forms.PictureBox();
            this.lblEntrar = new System.Windows.Forms.Label();
            this.grpTipo = new System.Windows.Forms.GroupBox();
            this.rdAdm = new System.Windows.Forms.RadioButton();
            this.rdFunc = new System.Windows.Forms.RadioButton();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSenha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctUsuario)).BeginInit();
            this.grpTipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(68, 262);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(212, 20);
            this.txtLogin.TabIndex = 4;
            this.txtLogin.TextChanged += new System.EventHandler(this.txtLogin_TextChanged);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(68, 334);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(212, 20);
            this.txtSenha.TabIndex = 5;
            this.txtSenha.TextChanged += new System.EventHandler(this.txtSenha_TextChanged);
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackgroundImage = global::DownloadBanker.Properties.Resources.TelaLogin;
            this.pnlLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlLogin.Controls.Add(this.lnkSenhaEsqueci);
            this.pnlLogin.Controls.Add(this.pctTipo);
            this.pnlLogin.Controls.Add(this.pctSenha);
            this.pnlLogin.Controls.Add(this.pctUsuario);
            this.pnlLogin.Controls.Add(this.lblEntrar);
            this.pnlLogin.Controls.Add(this.grpTipo);
            this.pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogin.ForeColor = System.Drawing.Color.Red;
            this.pnlLogin.Location = new System.Drawing.Point(0, 0);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(468, 522);
            this.pnlLogin.TabIndex = 8;
            this.pnlLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLogin_Paint);
            // 
            // lnkSenhaEsqueci
            // 
            this.lnkSenhaEsqueci.AutoSize = true;
            this.lnkSenhaEsqueci.BackColor = System.Drawing.Color.Transparent;
            this.lnkSenhaEsqueci.ForeColor = System.Drawing.Color.Red;
            this.lnkSenhaEsqueci.LinkColor = System.Drawing.Color.Red;
            this.lnkSenhaEsqueci.Location = new System.Drawing.Point(70, 371);
            this.lnkSenhaEsqueci.Name = "lnkSenhaEsqueci";
            this.lnkSenhaEsqueci.Size = new System.Drawing.Size(102, 13);
            this.lnkSenhaEsqueci.TabIndex = 7;
            this.lnkSenhaEsqueci.TabStop = true;
            this.lnkSenhaEsqueci.Text = "Esqueceu a senha?";
            this.lnkSenhaEsqueci.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSenhaEsqueci_LinkClicked);
            // 
            // pctTipo
            // 
            this.pctTipo.BackColor = System.Drawing.Color.Transparent;
            this.pctTipo.Image = global::DownloadBanker.Properties.Resources._1473469531_alert_triangle_red;
            this.pctTipo.Location = new System.Drawing.Point(365, 180);
            this.pctTipo.Name = "pctTipo";
            this.pctTipo.Size = new System.Drawing.Size(24, 24);
            this.pctTipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctTipo.TabIndex = 6;
            this.pctTipo.TabStop = false;
            this.pctTipo.Visible = false;
            // 
            // pctSenha
            // 
            this.pctSenha.BackColor = System.Drawing.Color.Transparent;
            this.pctSenha.Image = global::DownloadBanker.Properties.Resources._1473469531_alert_triangle_red;
            this.pctSenha.Location = new System.Drawing.Point(286, 331);
            this.pctSenha.Name = "pctSenha";
            this.pctSenha.Size = new System.Drawing.Size(24, 24);
            this.pctSenha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctSenha.TabIndex = 2;
            this.pctSenha.TabStop = false;
            this.pctSenha.Visible = false;
            // 
            // pctUsuario
            // 
            this.pctUsuario.BackColor = System.Drawing.Color.Transparent;
            this.pctUsuario.Image = global::DownloadBanker.Properties.Resources._1473469531_alert_triangle_red;
            this.pctUsuario.Location = new System.Drawing.Point(286, 260);
            this.pctUsuario.Name = "pctUsuario";
            this.pctUsuario.Size = new System.Drawing.Size(24, 24);
            this.pctUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctUsuario.TabIndex = 1;
            this.pctUsuario.TabStop = false;
            this.pctUsuario.Visible = false;
            // 
            // lblEntrar
            // 
            this.lblEntrar.BackColor = System.Drawing.Color.Transparent;
            this.lblEntrar.Location = new System.Drawing.Point(26, 447);
            this.lblEntrar.Name = "lblEntrar";
            this.lblEntrar.Size = new System.Drawing.Size(115, 30);
            this.lblEntrar.TabIndex = 0;
            this.lblEntrar.Click += new System.EventHandler(this.lblEntrar_Click);
            // 
            // grpTipo
            // 
            this.grpTipo.BackColor = System.Drawing.Color.Transparent;
            this.grpTipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grpTipo.Controls.Add(this.rdAdm);
            this.grpTipo.Controls.Add(this.rdFunc);
            this.grpTipo.Location = new System.Drawing.Point(59, 178);
            this.grpTipo.Name = "grpTipo";
            this.grpTipo.Size = new System.Drawing.Size(300, 25);
            this.grpTipo.TabIndex = 5;
            this.grpTipo.TabStop = false;
            // 
            // rdAdm
            // 
            this.rdAdm.AutoSize = true;
            this.rdAdm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAdm.Location = new System.Drawing.Point(11, 10);
            this.rdAdm.Name = "rdAdm";
            this.rdAdm.Size = new System.Drawing.Size(14, 13);
            this.rdAdm.TabIndex = 3;
            this.rdAdm.TabStop = true;
            this.rdAdm.UseVisualStyleBackColor = true;
            this.rdAdm.CheckedChanged += new System.EventHandler(this.rdAdm_CheckedChanged);
            // 
            // rdFunc
            // 
            this.rdFunc.AutoSize = true;
            this.rdFunc.BackColor = System.Drawing.Color.Transparent;
            this.rdFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdFunc.Location = new System.Drawing.Point(182, 10);
            this.rdFunc.Name = "rdFunc";
            this.rdFunc.Size = new System.Drawing.Size(14, 13);
            this.rdFunc.TabIndex = 4;
            this.rdFunc.TabStop = true;
            this.rdFunc.UseVisualStyleBackColor = false;
            this.rdFunc.CheckedChanged += new System.EventHandler(this.rdFunc_CheckedChanged);
            // 
            // frmTelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(468, 522);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.pnlLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(484, 561);
            this.MinimumSize = new System.Drawing.Size(484, 561);
            this.Name = "frmTelaLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTelaLogin_FormClosed);
            this.Load += new System.EventHandler(this.frmTelaLogin_Load);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSenha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctUsuario)).EndInit();
            this.grpTipo.ResumeLayout(false);
            this.grpTipo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblEntrar;
        private System.Windows.Forms.PictureBox pctSenha;
        private System.Windows.Forms.PictureBox pctUsuario;
        private System.Windows.Forms.RadioButton rdFunc;
        private System.Windows.Forms.RadioButton rdAdm;
        private System.Windows.Forms.PictureBox pctTipo;
        private System.Windows.Forms.GroupBox grpTipo;
        private System.Windows.Forms.LinkLabel lnkSenhaEsqueci;
    }
}