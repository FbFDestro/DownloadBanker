namespace DownloadBanker
{
    partial class frmTelaPergRespSecreta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTelaPergRespSecreta));
            this.pnlPergRespSecreta = new System.Windows.Forms.Panel();
            this.pctRespSecreta = new System.Windows.Forms.PictureBox();
            this.lblConfir = new System.Windows.Forms.Label();
            this.cmbPergunta = new System.Windows.Forms.ComboBox();
            this.txtResp = new System.Windows.Forms.TextBox();
            this.pnlPergRespSecreta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctRespSecreta)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPergRespSecreta
            // 
            this.pnlPergRespSecreta.BackgroundImage = global::DownloadBanker.Properties.Resources.TelaPergRespSecreta;
            this.pnlPergRespSecreta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlPergRespSecreta.Controls.Add(this.pctRespSecreta);
            this.pnlPergRespSecreta.Controls.Add(this.lblConfir);
            this.pnlPergRespSecreta.Controls.Add(this.cmbPergunta);
            this.pnlPergRespSecreta.Controls.Add(this.txtResp);
            this.pnlPergRespSecreta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPergRespSecreta.Location = new System.Drawing.Point(0, 0);
            this.pnlPergRespSecreta.Name = "pnlPergRespSecreta";
            this.pnlPergRespSecreta.Size = new System.Drawing.Size(391, 273);
            this.pnlPergRespSecreta.TabIndex = 0;
            // 
            // pctRespSecreta
            // 
            this.pctRespSecreta.BackColor = System.Drawing.Color.Transparent;
            this.pctRespSecreta.Image = global::DownloadBanker.Properties.Resources._1473469531_alert_triangle_red;
            this.pctRespSecreta.Location = new System.Drawing.Point(250, 188);
            this.pctRespSecreta.Name = "pctRespSecreta";
            this.pctRespSecreta.Size = new System.Drawing.Size(24, 24);
            this.pctRespSecreta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctRespSecreta.TabIndex = 27;
            this.pctRespSecreta.TabStop = false;
            this.pctRespSecreta.Visible = false;
            // 
            // lblConfir
            // 
            this.lblConfir.BackColor = System.Drawing.Color.Transparent;
            this.lblConfir.Location = new System.Drawing.Point(40, 232);
            this.lblConfir.Name = "lblConfir";
            this.lblConfir.Size = new System.Drawing.Size(114, 23);
            this.lblConfir.TabIndex = 2;
            this.lblConfir.Click += new System.EventHandler(this.lblConfir_Click);
            // 
            // cmbPergunta
            // 
            this.cmbPergunta.FormattingEnabled = true;
            this.cmbPergunta.Items.AddRange(new object[] {
            "Nome do melhor amigo de infância?",
            "Qual é a sua comida favorita?",
            "Qual é o nome do meio de sua avó?",
            "Em que cidade você nasceu?",
            "Qual era o nome do seu primeiro animal de estimação?"});
            this.cmbPergunta.Location = new System.Drawing.Point(31, 124);
            this.cmbPergunta.Name = "cmbPergunta";
            this.cmbPergunta.Size = new System.Drawing.Size(214, 21);
            this.cmbPergunta.TabIndex = 1;
            // 
            // txtResp
            // 
            this.txtResp.Location = new System.Drawing.Point(31, 191);
            this.txtResp.Name = "txtResp";
            this.txtResp.Size = new System.Drawing.Size(214, 20);
            this.txtResp.TabIndex = 0;
            // 
            // frmTelaPergRespSecreta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 273);
            this.Controls.Add(this.pnlPergRespSecreta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(407, 312);
            this.MinimumSize = new System.Drawing.Size(407, 312);
            this.Name = "frmTelaPergRespSecreta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DownloadBanker - Pergunta Secreta";
            this.Load += new System.EventHandler(this.frmTelaPergRespSecreta_Load);
            this.pnlPergRespSecreta.ResumeLayout(false);
            this.pnlPergRespSecreta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctRespSecreta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPergRespSecreta;
        private System.Windows.Forms.Label lblConfir;
        private System.Windows.Forms.ComboBox cmbPergunta;
        private System.Windows.Forms.TextBox txtResp;
        private System.Windows.Forms.PictureBox pctRespSecreta;
    }
}