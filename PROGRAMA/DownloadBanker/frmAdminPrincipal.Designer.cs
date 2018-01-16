namespace DownloadBanker
{
    partial class frmAdminPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminPrincipal));
            this.pnlAdminPrincipal = new System.Windows.Forms.Panel();
            this.lblBackUp = new System.Windows.Forms.Label();
            this.lblAuditoria = new System.Windows.Forms.Label();
            this.lblGerarQRCode = new System.Windows.Forms.Label();
            this.lblSair = new System.Windows.Forms.Label();
            this.lblEditarPerfil = new System.Windows.Forms.Label();
            this.lblProdutos = new System.Windows.Forms.Label();
            this.lblClientes = new System.Windows.Forms.Label();
            this.lblFunc = new System.Windows.Forms.Label();
            this.pnlAdminPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAdminPrincipal
            // 
            this.pnlAdminPrincipal.BackgroundImage = global::DownloadBanker.Properties.Resources.TelaAdminPrincipal;
            this.pnlAdminPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlAdminPrincipal.Controls.Add(this.lblBackUp);
            this.pnlAdminPrincipal.Controls.Add(this.lblAuditoria);
            this.pnlAdminPrincipal.Controls.Add(this.lblGerarQRCode);
            this.pnlAdminPrincipal.Controls.Add(this.lblSair);
            this.pnlAdminPrincipal.Controls.Add(this.lblEditarPerfil);
            this.pnlAdminPrincipal.Controls.Add(this.lblProdutos);
            this.pnlAdminPrincipal.Controls.Add(this.lblClientes);
            this.pnlAdminPrincipal.Controls.Add(this.lblFunc);
            this.pnlAdminPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAdminPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlAdminPrincipal.MaximumSize = new System.Drawing.Size(484, 561);
            this.pnlAdminPrincipal.MinimumSize = new System.Drawing.Size(484, 561);
            this.pnlAdminPrincipal.Name = "pnlAdminPrincipal";
            this.pnlAdminPrincipal.Size = new System.Drawing.Size(484, 561);
            this.pnlAdminPrincipal.TabIndex = 0;
            // 
            // lblBackUp
            // 
            this.lblBackUp.AutoSize = true;
            this.lblBackUp.BackColor = System.Drawing.Color.Transparent;
            this.lblBackUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackUp.ForeColor = System.Drawing.Color.Black;
            this.lblBackUp.Location = new System.Drawing.Point(304, 533);
            this.lblBackUp.Name = "lblBackUp";
            this.lblBackUp.Size = new System.Drawing.Size(136, 15);
            this.lblBackUp.TabIndex = 7;
            this.lblBackUp.Text = "GERENCIAR BACKUPS";
            this.lblBackUp.Click += new System.EventHandler(this.lblBackUp_Click);
            // 
            // lblAuditoria
            // 
            this.lblAuditoria.BackColor = System.Drawing.Color.Transparent;
            this.lblAuditoria.Location = new System.Drawing.Point(304, 390);
            this.lblAuditoria.Name = "lblAuditoria";
            this.lblAuditoria.Size = new System.Drawing.Size(89, 85);
            this.lblAuditoria.TabIndex = 6;
            this.lblAuditoria.Click += new System.EventHandler(this.lblAuditoria_Click);
            // 
            // lblGerarQRCode
            // 
            this.lblGerarQRCode.BackColor = System.Drawing.Color.Transparent;
            this.lblGerarQRCode.Location = new System.Drawing.Point(88, 392);
            this.lblGerarQRCode.Name = "lblGerarQRCode";
            this.lblGerarQRCode.Size = new System.Drawing.Size(89, 85);
            this.lblGerarQRCode.TabIndex = 5;
            this.lblGerarQRCode.Click += new System.EventHandler(this.lblGerarQRCode_Click);
            // 
            // lblSair
            // 
            this.lblSair.BackColor = System.Drawing.Color.Transparent;
            this.lblSair.Location = new System.Drawing.Point(19, 524);
            this.lblSair.Name = "lblSair";
            this.lblSair.Size = new System.Drawing.Size(89, 24);
            this.lblSair.TabIndex = 4;
            this.lblSair.Click += new System.EventHandler(this.lblSair_Click);
            // 
            // lblEditarPerfil
            // 
            this.lblEditarPerfil.BackColor = System.Drawing.Color.Transparent;
            this.lblEditarPerfil.Location = new System.Drawing.Point(304, 282);
            this.lblEditarPerfil.Name = "lblEditarPerfil";
            this.lblEditarPerfil.Size = new System.Drawing.Size(89, 85);
            this.lblEditarPerfil.TabIndex = 3;
            this.lblEditarPerfil.Click += new System.EventHandler(this.lblEditarPerfil_Click);
            // 
            // lblProdutos
            // 
            this.lblProdutos.BackColor = System.Drawing.Color.Transparent;
            this.lblProdutos.Location = new System.Drawing.Point(98, 275);
            this.lblProdutos.Name = "lblProdutos";
            this.lblProdutos.Size = new System.Drawing.Size(79, 92);
            this.lblProdutos.TabIndex = 2;
            this.lblProdutos.Click += new System.EventHandler(this.lblProdutos_Click);
            // 
            // lblClientes
            // 
            this.lblClientes.BackColor = System.Drawing.Color.Transparent;
            this.lblClientes.Location = new System.Drawing.Point(304, 149);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(89, 94);
            this.lblClientes.TabIndex = 1;
            this.lblClientes.Click += new System.EventHandler(this.lblClientes_Click);
            // 
            // lblFunc
            // 
            this.lblFunc.BackColor = System.Drawing.Color.Transparent;
            this.lblFunc.Location = new System.Drawing.Point(87, 151);
            this.lblFunc.Name = "lblFunc";
            this.lblFunc.Size = new System.Drawing.Size(96, 94);
            this.lblFunc.TabIndex = 0;
            this.lblFunc.Click += new System.EventHandler(this.lblFunc_Click);
            // 
            // frmAdminPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.pnlAdminPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdminPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador - Menu Principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAdminPrincipal_FormClosed);
            this.pnlAdminPrincipal.ResumeLayout(false);
            this.pnlAdminPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAdminPrincipal;
        private System.Windows.Forms.Label lblSair;
        private System.Windows.Forms.Label lblEditarPerfil;
        private System.Windows.Forms.Label lblProdutos;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Label lblFunc;
        private System.Windows.Forms.Label lblAuditoria;
        private System.Windows.Forms.Label lblGerarQRCode;
        private System.Windows.Forms.Label lblBackUp;
    }
}