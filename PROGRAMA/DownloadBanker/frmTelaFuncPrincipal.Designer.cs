namespace DownloadBanker
{
    partial class frmTelaFuncPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTelaFuncPrincipal));
            this.pnlFuncPrincipal = new System.Windows.Forms.Panel();
            this.lblAuditoria = new System.Windows.Forms.Label();
            this.lblGerarQRCode = new System.Windows.Forms.Label();
            this.lblSair = new System.Windows.Forms.Label();
            this.lblEditarPerfil = new System.Windows.Forms.Label();
            this.lblProdutos = new System.Windows.Forms.Label();
            this.lblClientes = new System.Windows.Forms.Label();
            this.lblBackUp = new System.Windows.Forms.Label();
            this.pnlFuncPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFuncPrincipal
            // 
            this.pnlFuncPrincipal.BackgroundImage = global::DownloadBanker.Properties.Resources.TelaFuncPrincipal1;
            this.pnlFuncPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFuncPrincipal.Controls.Add(this.lblBackUp);
            this.pnlFuncPrincipal.Controls.Add(this.lblAuditoria);
            this.pnlFuncPrincipal.Controls.Add(this.lblGerarQRCode);
            this.pnlFuncPrincipal.Controls.Add(this.lblSair);
            this.pnlFuncPrincipal.Controls.Add(this.lblEditarPerfil);
            this.pnlFuncPrincipal.Controls.Add(this.lblProdutos);
            this.pnlFuncPrincipal.Controls.Add(this.lblClientes);
            this.pnlFuncPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFuncPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlFuncPrincipal.Name = "pnlFuncPrincipal";
            this.pnlFuncPrincipal.Size = new System.Drawing.Size(484, 561);
            this.pnlFuncPrincipal.TabIndex = 0;
            // 
            // lblAuditoria
            // 
            this.lblAuditoria.BackColor = System.Drawing.Color.Transparent;
            this.lblAuditoria.Location = new System.Drawing.Point(307, 375);
            this.lblAuditoria.Name = "lblAuditoria";
            this.lblAuditoria.Size = new System.Drawing.Size(90, 89);
            this.lblAuditoria.TabIndex = 5;
            this.lblAuditoria.Click += new System.EventHandler(this.lblAuditoria_Click);
            // 
            // lblGerarQRCode
            // 
            this.lblGerarQRCode.BackColor = System.Drawing.Color.Transparent;
            this.lblGerarQRCode.Location = new System.Drawing.Point(94, 370);
            this.lblGerarQRCode.Name = "lblGerarQRCode";
            this.lblGerarQRCode.Size = new System.Drawing.Size(90, 89);
            this.lblGerarQRCode.TabIndex = 4;
            this.lblGerarQRCode.Click += new System.EventHandler(this.lblGerarQRCode_Click);
            // 
            // lblSair
            // 
            this.lblSair.BackColor = System.Drawing.Color.Transparent;
            this.lblSair.Location = new System.Drawing.Point(22, 507);
            this.lblSair.Name = "lblSair";
            this.lblSair.Size = new System.Drawing.Size(104, 31);
            this.lblSair.TabIndex = 3;
            this.lblSair.Click += new System.EventHandler(this.lblSair_Click);
            // 
            // lblEditarPerfil
            // 
            this.lblEditarPerfil.BackColor = System.Drawing.Color.Transparent;
            this.lblEditarPerfil.Location = new System.Drawing.Point(305, 268);
            this.lblEditarPerfil.Name = "lblEditarPerfil";
            this.lblEditarPerfil.Size = new System.Drawing.Size(92, 84);
            this.lblEditarPerfil.TabIndex = 2;
            this.lblEditarPerfil.Click += new System.EventHandler(this.lblEditarPerfil_Click);
            // 
            // lblProdutos
            // 
            this.lblProdutos.BackColor = System.Drawing.Color.Transparent;
            this.lblProdutos.Location = new System.Drawing.Point(106, 257);
            this.lblProdutos.Name = "lblProdutos";
            this.lblProdutos.Size = new System.Drawing.Size(67, 95);
            this.lblProdutos.TabIndex = 1;
            this.lblProdutos.Click += new System.EventHandler(this.lblProdutos_Click);
            // 
            // lblClientes
            // 
            this.lblClientes.BackColor = System.Drawing.Color.Transparent;
            this.lblClientes.Location = new System.Drawing.Point(201, 154);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(90, 89);
            this.lblClientes.TabIndex = 0;
            this.lblClientes.Click += new System.EventHandler(this.lblClientes_Click);
            // 
            // lblBackUp
            // 
            this.lblBackUp.AutoSize = true;
            this.lblBackUp.BackColor = System.Drawing.Color.Transparent;
            this.lblBackUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackUp.ForeColor = System.Drawing.Color.Black;
            this.lblBackUp.Location = new System.Drawing.Point(336, 523);
            this.lblBackUp.Name = "lblBackUp";
            this.lblBackUp.Size = new System.Drawing.Size(136, 15);
            this.lblBackUp.TabIndex = 8;
            this.lblBackUp.Text = "GERENCIAR BACKUPS";
            this.lblBackUp.Click += new System.EventHandler(this.lblBackUp_Click_1);
            // 
            // frmTelaFuncPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.pnlFuncPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 600);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "frmTelaFuncPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Funcionário - Menu Principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTelaFuncPrincipal_FormClosed);
            this.pnlFuncPrincipal.ResumeLayout(false);
            this.pnlFuncPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFuncPrincipal;
        private System.Windows.Forms.Label lblSair;
        private System.Windows.Forms.Label lblEditarPerfil;
        private System.Windows.Forms.Label lblProdutos;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Label lblAuditoria;
        private System.Windows.Forms.Label lblGerarQRCode;
        private System.Windows.Forms.Label lblBackUp;
    }
}