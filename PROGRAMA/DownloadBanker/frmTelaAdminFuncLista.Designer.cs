namespace DownloadBanker
{
    partial class frmTelaAdminFuncLista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTelaAdminFuncLista));
            this.pnlAdminFunc = new System.Windows.Forms.Panel();
            this.lblEditar = new System.Windows.Forms.Label();
            this.lblDeletar = new System.Windows.Forms.Label();
            this.gvExibirFunc = new System.Windows.Forms.DataGridView();
            this.txtPesqFunc = new System.Windows.Forms.TextBox();
            this.lblVoltar = new System.Windows.Forms.Label();
            this.lblAdicionar = new System.Windows.Forms.Label();
            this.pnlAdminFunc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibirFunc)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAdminFunc
            // 
            this.pnlAdminFunc.BackgroundImage = global::DownloadBanker.Properties.Resources.TelaAdminFuncLista1;
            this.pnlAdminFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlAdminFunc.Controls.Add(this.lblEditar);
            this.pnlAdminFunc.Controls.Add(this.lblDeletar);
            this.pnlAdminFunc.Controls.Add(this.gvExibirFunc);
            this.pnlAdminFunc.Controls.Add(this.txtPesqFunc);
            this.pnlAdminFunc.Controls.Add(this.lblVoltar);
            this.pnlAdminFunc.Controls.Add(this.lblAdicionar);
            this.pnlAdminFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAdminFunc.Location = new System.Drawing.Point(0, 0);
            this.pnlAdminFunc.Name = "pnlAdminFunc";
            this.pnlAdminFunc.Size = new System.Drawing.Size(844, 561);
            this.pnlAdminFunc.TabIndex = 0;
            // 
            // lblEditar
            // 
            this.lblEditar.BackColor = System.Drawing.Color.Transparent;
            this.lblEditar.Location = new System.Drawing.Point(292, 444);
            this.lblEditar.Name = "lblEditar";
            this.lblEditar.Size = new System.Drawing.Size(88, 18);
            this.lblEditar.TabIndex = 10;
            this.lblEditar.Click += new System.EventHandler(this.lblEditar_Click);
            // 
            // lblDeletar
            // 
            this.lblDeletar.BackColor = System.Drawing.Color.Transparent;
            this.lblDeletar.Location = new System.Drawing.Point(192, 444);
            this.lblDeletar.Name = "lblDeletar";
            this.lblDeletar.Size = new System.Drawing.Size(94, 18);
            this.lblDeletar.TabIndex = 9;
            this.lblDeletar.Click += new System.EventHandler(this.lblDeletar_Click);
            // 
            // gvExibirFunc
            // 
            this.gvExibirFunc.AllowUserToAddRows = false;
            this.gvExibirFunc.AllowUserToDeleteRows = false;
            this.gvExibirFunc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExibirFunc.Location = new System.Drawing.Point(71, 175);
            this.gvExibirFunc.Name = "gvExibirFunc";
            this.gvExibirFunc.ReadOnly = true;
            this.gvExibirFunc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gvExibirFunc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvExibirFunc.Size = new System.Drawing.Size(700, 266);
            this.gvExibirFunc.TabIndex = 8;
            this.gvExibirFunc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvExibirFunc_CellClick);
            // 
            // txtPesqFunc
            // 
            this.txtPesqFunc.Location = new System.Drawing.Point(550, 151);
            this.txtPesqFunc.Name = "txtPesqFunc";
            this.txtPesqFunc.Size = new System.Drawing.Size(171, 20);
            this.txtPesqFunc.TabIndex = 4;
            this.txtPesqFunc.TextChanged += new System.EventHandler(this.txtPesqFunc_TextChanged);
            // 
            // lblVoltar
            // 
            this.lblVoltar.BackColor = System.Drawing.Color.Transparent;
            this.lblVoltar.Location = new System.Drawing.Point(622, 444);
            this.lblVoltar.Name = "lblVoltar";
            this.lblVoltar.Size = new System.Drawing.Size(86, 18);
            this.lblVoltar.TabIndex = 7;
            this.lblVoltar.Click += new System.EventHandler(this.lblVoltar_Click);
            // 
            // lblAdicionar
            // 
            this.lblAdicionar.BackColor = System.Drawing.Color.Transparent;
            this.lblAdicionar.Location = new System.Drawing.Point(71, 445);
            this.lblAdicionar.Name = "lblAdicionar";
            this.lblAdicionar.Size = new System.Drawing.Size(107, 18);
            this.lblAdicionar.TabIndex = 5;
            this.lblAdicionar.Click += new System.EventHandler(this.lblAdicionar_Click);
            // 
            // frmTelaAdminFuncLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 561);
            this.Controls.Add(this.pnlAdminFunc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(860, 600);
            this.MinimumSize = new System.Drawing.Size(860, 600);
            this.Name = "frmTelaAdminFuncLista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador - Funcionários";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTelaAdminFuncLista_FormClosed);
            this.Load += new System.EventHandler(this.frmTelaAdminFuncLista_Load);
            this.pnlAdminFunc.ResumeLayout(false);
            this.pnlAdminFunc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvExibirFunc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAdminFunc;
        private System.Windows.Forms.Label lblEditar;
        private System.Windows.Forms.Label lblDeletar;
        private System.Windows.Forms.DataGridView gvExibirFunc;
        private System.Windows.Forms.TextBox txtPesqFunc;
        private System.Windows.Forms.Label lblVoltar;
        private System.Windows.Forms.Label lblAdicionar;
    }
}