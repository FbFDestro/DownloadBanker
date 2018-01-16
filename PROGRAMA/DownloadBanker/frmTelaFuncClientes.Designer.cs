namespace DownloadBanker
{
    partial class frmTelaFuncClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTelaFuncClientes));
            this.pnlFuncClientes = new System.Windows.Forms.Panel();
            this.gvExibirClientes = new System.Windows.Forms.DataGridView();
            this.lblVoltar = new System.Windows.Forms.Label();
            this.lblDeletar = new System.Windows.Forms.Label();
            this.txtPesqCli = new System.Windows.Forms.TextBox();
            this.pnlFuncClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibirClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFuncClientes
            // 
            this.pnlFuncClientes.BackgroundImage = global::DownloadBanker.Properties.Resources.TelaFuncClientesLista;
            this.pnlFuncClientes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFuncClientes.Controls.Add(this.gvExibirClientes);
            this.pnlFuncClientes.Controls.Add(this.lblVoltar);
            this.pnlFuncClientes.Controls.Add(this.lblDeletar);
            this.pnlFuncClientes.Controls.Add(this.txtPesqCli);
            this.pnlFuncClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFuncClientes.Location = new System.Drawing.Point(0, 0);
            this.pnlFuncClientes.Name = "pnlFuncClientes";
            this.pnlFuncClientes.Size = new System.Drawing.Size(844, 561);
            this.pnlFuncClientes.TabIndex = 0;
            // 
            // gvExibirClientes
            // 
            this.gvExibirClientes.AllowUserToAddRows = false;
            this.gvExibirClientes.AllowUserToDeleteRows = false;
            this.gvExibirClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExibirClientes.Location = new System.Drawing.Point(71, 174);
            this.gvExibirClientes.MultiSelect = false;
            this.gvExibirClientes.Name = "gvExibirClientes";
            this.gvExibirClientes.ReadOnly = true;
            this.gvExibirClientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gvExibirClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvExibirClientes.Size = new System.Drawing.Size(700, 266);
            this.gvExibirClientes.TabIndex = 8;
            this.gvExibirClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvExibirClientes_CellClick);
            // 
            // lblVoltar
            // 
            this.lblVoltar.BackColor = System.Drawing.Color.Transparent;
            this.lblVoltar.Location = new System.Drawing.Point(622, 443);
            this.lblVoltar.Name = "lblVoltar";
            this.lblVoltar.Size = new System.Drawing.Size(86, 18);
            this.lblVoltar.TabIndex = 7;
            this.lblVoltar.Click += new System.EventHandler(this.lblVoltar_Click);
            // 
            // lblDeletar
            // 
            this.lblDeletar.BackColor = System.Drawing.Color.Transparent;
            this.lblDeletar.Location = new System.Drawing.Point(79, 444);
            this.lblDeletar.Name = "lblDeletar";
            this.lblDeletar.Size = new System.Drawing.Size(99, 18);
            this.lblDeletar.TabIndex = 5;
            this.lblDeletar.Click += new System.EventHandler(this.lblDeletar_Click);
            // 
            // txtPesqCli
            // 
            this.txtPesqCli.Location = new System.Drawing.Point(550, 150);
            this.txtPesqCli.Name = "txtPesqCli";
            this.txtPesqCli.Size = new System.Drawing.Size(171, 20);
            this.txtPesqCli.TabIndex = 4;
            this.txtPesqCli.TextChanged += new System.EventHandler(this.txtPesqCli_TextChanged);
            // 
            // frmTelaFuncClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 561);
            this.Controls.Add(this.pnlFuncClientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(860, 600);
            this.MinimumSize = new System.Drawing.Size(860, 600);
            this.Name = "frmTelaFuncClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Funcionário - Clientes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTelaFuncClientes_FormClosed);
            this.Load += new System.EventHandler(this.frmTelaFuncClientes_Load);
            this.pnlFuncClientes.ResumeLayout(false);
            this.pnlFuncClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibirClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFuncClientes;
        private System.Windows.Forms.DataGridView gvExibirClientes;
        private System.Windows.Forms.Label lblVoltar;
        private System.Windows.Forms.Label lblDeletar;
        private System.Windows.Forms.TextBox txtPesqCli;
    }
}