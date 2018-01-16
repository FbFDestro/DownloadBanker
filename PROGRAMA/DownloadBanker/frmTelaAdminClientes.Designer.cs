namespace DownloadBanker
{
    partial class frmTelaAdminClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTelaAdminClientes));
            this.pnlAdminClientes = new System.Windows.Forms.Panel();
            this.gvExibirClientes = new System.Windows.Forms.DataGridView();
            this.lblVoltar = new System.Windows.Forms.Label();
            this.lblDeletar = new System.Windows.Forms.Label();
            this.txtPesqCli = new System.Windows.Forms.TextBox();
            this.pnlAdminClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibirClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAdminClientes
            // 
            this.pnlAdminClientes.BackgroundImage = global::DownloadBanker.Properties.Resources.TelaAdminClientesLista;
            this.pnlAdminClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlAdminClientes.Controls.Add(this.gvExibirClientes);
            this.pnlAdminClientes.Controls.Add(this.lblVoltar);
            this.pnlAdminClientes.Controls.Add(this.lblDeletar);
            this.pnlAdminClientes.Controls.Add(this.txtPesqCli);
            this.pnlAdminClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAdminClientes.Location = new System.Drawing.Point(0, 0);
            this.pnlAdminClientes.Name = "pnlAdminClientes";
            this.pnlAdminClientes.Size = new System.Drawing.Size(844, 561);
            this.pnlAdminClientes.TabIndex = 0;
            // 
            // gvExibirClientes
            // 
            this.gvExibirClientes.AllowUserToAddRows = false;
            this.gvExibirClientes.AllowUserToDeleteRows = false;
            this.gvExibirClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExibirClientes.Location = new System.Drawing.Point(72, 174);
            this.gvExibirClientes.Name = "gvExibirClientes";
            this.gvExibirClientes.ReadOnly = true;
            this.gvExibirClientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gvExibirClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvExibirClientes.Size = new System.Drawing.Size(700, 266);
            this.gvExibirClientes.TabIndex = 3;
            this.gvExibirClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvExibirClientes_CellClick);
            // 
            // lblVoltar
            // 
            this.lblVoltar.BackColor = System.Drawing.Color.Transparent;
            this.lblVoltar.Location = new System.Drawing.Point(623, 443);
            this.lblVoltar.Name = "lblVoltar";
            this.lblVoltar.Size = new System.Drawing.Size(86, 18);
            this.lblVoltar.TabIndex = 2;
            this.lblVoltar.Click += new System.EventHandler(this.lblVoltar_Click);
            // 
            // lblDeletar
            // 
            this.lblDeletar.BackColor = System.Drawing.Color.Transparent;
            this.lblDeletar.Location = new System.Drawing.Point(80, 444);
            this.lblDeletar.Name = "lblDeletar";
            this.lblDeletar.Size = new System.Drawing.Size(99, 18);
            this.lblDeletar.TabIndex = 1;
            this.lblDeletar.Click += new System.EventHandler(this.lblDeletar_Click);
            // 
            // txtPesqCli
            // 
            this.txtPesqCli.Location = new System.Drawing.Point(551, 150);
            this.txtPesqCli.Name = "txtPesqCli";
            this.txtPesqCli.Size = new System.Drawing.Size(171, 20);
            this.txtPesqCli.TabIndex = 0;
            this.txtPesqCli.TextChanged += new System.EventHandler(this.txtPesqCli_TextChanged);
            // 
            // frmTelaAdminClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 561);
            this.Controls.Add(this.pnlAdminClientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(860, 600);
            this.MinimumSize = new System.Drawing.Size(860, 600);
            this.Name = "frmTelaAdminClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador - Clientes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTelaAdminClientes_FormClosed);
            this.Load += new System.EventHandler(this.frmTelaAdminClientes_Load);
            this.pnlAdminClientes.ResumeLayout(false);
            this.pnlAdminClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibirClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAdminClientes;
        private System.Windows.Forms.DataGridView gvExibirClientes;
        private System.Windows.Forms.Label lblVoltar;
        private System.Windows.Forms.Label lblDeletar;
        private System.Windows.Forms.TextBox txtPesqCli;
    }
}