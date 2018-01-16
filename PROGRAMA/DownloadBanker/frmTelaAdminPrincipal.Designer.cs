namespace DownloadBanker
{
    partial class frmTelaAdminPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTelaAdminPrincipal));
            this.pnlAdminPrincipal = new System.Windows.Forms.Panel();
            this.lblFuncionario = new System.Windows.Forms.Label();
            this.lblClientes = new System.Windows.Forms.Label();
            this.lblProdutos = new System.Windows.Forms.Label();
            this.lblEditarPerfil = new System.Windows.Forms.Label();
            this.lblSair = new System.Windows.Forms.Label();
            this.pnlAdminPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAdminPrincipal
            // 
            this.pnlAdminPrincipal.BackgroundImage = global::DownloadBanker.Properties.Resources.TelaAdminPrincipal;
            this.pnlAdminPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlAdminPrincipal.Controls.Add(this.lblSair);
            this.pnlAdminPrincipal.Controls.Add(this.lblEditarPerfil);
            this.pnlAdminPrincipal.Controls.Add(this.lblProdutos);
            this.pnlAdminPrincipal.Controls.Add(this.lblClientes);
            this.pnlAdminPrincipal.Controls.Add(this.lblFuncionario);
            this.pnlAdminPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAdminPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlAdminPrincipal.Name = "pnlAdminPrincipal";
            this.pnlAdminPrincipal.Size = new System.Drawing.Size(468, 522);
            this.pnlAdminPrincipal.TabIndex = 0;
            // 
            // lblFuncionario
            // 
            this.lblFuncionario.BackColor = System.Drawing.Color.Transparent;
            this.lblFuncionario.Location = new System.Drawing.Point(100, 161);
            this.lblFuncionario.Name = "lblFuncionario";
            this.lblFuncionario.Size = new System.Drawing.Size(227, 31);
            this.lblFuncionario.TabIndex = 0;
            // 
            // lblClientes
            // 
            this.lblClientes.BackColor = System.Drawing.Color.Transparent;
            this.lblClientes.Location = new System.Drawing.Point(100, 224);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(170, 31);
            this.lblClientes.TabIndex = 1;
            // 
            // lblProdutos
            // 
            this.lblProdutos.BackColor = System.Drawing.Color.Transparent;
            this.lblProdutos.Location = new System.Drawing.Point(100, 299);
            this.lblProdutos.Name = "lblProdutos";
            this.lblProdutos.Size = new System.Drawing.Size(188, 31);
            this.lblProdutos.TabIndex = 2;
            // 
            // lblEditarPerfil
            // 
            this.lblEditarPerfil.BackColor = System.Drawing.Color.Transparent;
            this.lblEditarPerfil.Location = new System.Drawing.Point(100, 370);
            this.lblEditarPerfil.Name = "lblEditarPerfil";
            this.lblEditarPerfil.Size = new System.Drawing.Size(227, 31);
            this.lblEditarPerfil.TabIndex = 3;
            // 
            // lblSair
            // 
            this.lblSair.BackColor = System.Drawing.Color.Transparent;
            this.lblSair.Location = new System.Drawing.Point(43, 457);
            this.lblSair.Name = "lblSair";
            this.lblSair.Size = new System.Drawing.Size(87, 31);
            this.lblSair.TabIndex = 4;
            // 
            // frmTelaAdminPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(468, 522);
            this.Controls.Add(this.pnlAdminPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(484, 561);
            this.MinimumSize = new System.Drawing.Size(484, 561);
            this.Name = "frmTelaAdminPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador - Menu Principal";
            this.pnlAdminPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAdminPrincipal;
        private System.Windows.Forms.Label lblSair;
        private System.Windows.Forms.Label lblEditarPerfil;
        private System.Windows.Forms.Label lblProdutos;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Label lblFuncionario;
    }
}