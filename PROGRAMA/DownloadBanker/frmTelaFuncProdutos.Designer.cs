namespace DownloadBanker
{
    partial class frmTelaFuncProdutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTelaFuncProdutos));
            this.pnlFuncProd = new System.Windows.Forms.Panel();
            this.gvExibirProd = new System.Windows.Forms.DataGridView();
            this.txtPesqProd = new System.Windows.Forms.TextBox();
            this.lblVoltar = new System.Windows.Forms.Label();
            this.lblDeletar = new System.Windows.Forms.Label();
            this.pnlFuncProd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibirProd)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFuncProd
            // 
            this.pnlFuncProd.BackgroundImage = global::DownloadBanker.Properties.Resources.TelaFuncProdutosLista;
            this.pnlFuncProd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlFuncProd.Controls.Add(this.gvExibirProd);
            this.pnlFuncProd.Controls.Add(this.txtPesqProd);
            this.pnlFuncProd.Controls.Add(this.lblVoltar);
            this.pnlFuncProd.Controls.Add(this.lblDeletar);
            this.pnlFuncProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFuncProd.Location = new System.Drawing.Point(0, 0);
            this.pnlFuncProd.Name = "pnlFuncProd";
            this.pnlFuncProd.Size = new System.Drawing.Size(844, 561);
            this.pnlFuncProd.TabIndex = 0;
            // 
            // gvExibirProd
            // 
            this.gvExibirProd.AllowUserToAddRows = false;
            this.gvExibirProd.AllowUserToDeleteRows = false;
            this.gvExibirProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExibirProd.Location = new System.Drawing.Point(70, 173);
            this.gvExibirProd.Name = "gvExibirProd";
            this.gvExibirProd.ReadOnly = true;
            this.gvExibirProd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gvExibirProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvExibirProd.Size = new System.Drawing.Size(700, 266);
            this.gvExibirProd.TabIndex = 8;
            this.gvExibirProd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvExibirProd_CellClick);
            // 
            // txtPesqProd
            // 
            this.txtPesqProd.Location = new System.Drawing.Point(549, 149);
            this.txtPesqProd.Name = "txtPesqProd";
            this.txtPesqProd.Size = new System.Drawing.Size(171, 20);
            this.txtPesqProd.TabIndex = 4;
            this.txtPesqProd.TextChanged += new System.EventHandler(this.txtPesqProd_TextChanged);
            // 
            // lblVoltar
            // 
            this.lblVoltar.BackColor = System.Drawing.Color.Transparent;
            this.lblVoltar.Location = new System.Drawing.Point(621, 442);
            this.lblVoltar.Name = "lblVoltar";
            this.lblVoltar.Size = new System.Drawing.Size(86, 18);
            this.lblVoltar.TabIndex = 7;
            this.lblVoltar.Click += new System.EventHandler(this.lblVoltar_Click);
            // 
            // lblDeletar
            // 
            this.lblDeletar.BackColor = System.Drawing.Color.Transparent;
            this.lblDeletar.Location = new System.Drawing.Point(78, 443);
            this.lblDeletar.Name = "lblDeletar";
            this.lblDeletar.Size = new System.Drawing.Size(99, 18);
            this.lblDeletar.TabIndex = 5;
            this.lblDeletar.Click += new System.EventHandler(this.lblDeletar_Click);
            // 
            // frmTelaFuncProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 561);
            this.Controls.Add(this.pnlFuncProd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(860, 600);
            this.MinimumSize = new System.Drawing.Size(860, 600);
            this.Name = "frmTelaFuncProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Funcionário - Produtos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTelaFuncProdutos_FormClosed);
            this.Load += new System.EventHandler(this.frmTelaFuncProdutos_Load);
            this.pnlFuncProd.ResumeLayout(false);
            this.pnlFuncProd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibirProd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFuncProd;
        private System.Windows.Forms.DataGridView gvExibirProd;
        private System.Windows.Forms.TextBox txtPesqProd;
        private System.Windows.Forms.Label lblVoltar;
        private System.Windows.Forms.Label lblDeletar;
    }
}