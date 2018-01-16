namespace DownloadBanker
{
    partial class frmBuscaCEP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaCEP));
            this.chkZonaRural = new System.Windows.Forms.CheckBox();
            this.cmbRuas = new System.Windows.Forms.ComboBox();
            this.mskCep = new System.Windows.Forms.MaskedTextBox();
            this.cmbBairro = new System.Windows.Forms.ComboBox();
            this.cmbCidades = new System.Windows.Forms.ComboBox();
            this.cmbTipoLogradouro = new System.Windows.Forms.ComboBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.cmbUF = new System.Windows.Forms.ComboBox();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.pnlBuscarCEP = new System.Windows.Forms.Panel();
            this.lblConfirmar = new System.Windows.Forms.Label();
            this.lblVoltar = new System.Windows.Forms.Label();
            this.pnlBuscarCEP.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkZonaRural
            // 
            this.chkZonaRural.AutoSize = true;
            this.chkZonaRural.BackColor = System.Drawing.Color.Transparent;
            this.chkZonaRural.Location = new System.Drawing.Point(594, 202);
            this.chkZonaRural.Name = "chkZonaRural";
            this.chkZonaRural.Size = new System.Drawing.Size(15, 14);
            this.chkZonaRural.TabIndex = 54;
            this.chkZonaRural.UseVisualStyleBackColor = false;
            // 
            // cmbRuas
            // 
            this.cmbRuas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbRuas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRuas.FormattingEnabled = true;
            this.cmbRuas.Location = new System.Drawing.Point(372, 164);
            this.cmbRuas.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRuas.Name = "cmbRuas";
            this.cmbRuas.Size = new System.Drawing.Size(334, 21);
            this.cmbRuas.TabIndex = 4;
            // 
            // mskCep
            // 
            this.mskCep.Location = new System.Drawing.Point(129, 228);
            this.mskCep.Margin = new System.Windows.Forms.Padding(2);
            this.mskCep.Mask = "00,000-000";
            this.mskCep.Name = "mskCep";
            this.mskCep.Size = new System.Drawing.Size(117, 20);
            this.mskCep.TabIndex = 1;
            // 
            // cmbBairro
            // 
            this.cmbBairro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBairro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBairro.FormattingEnabled = true;
            this.cmbBairro.Location = new System.Drawing.Point(155, 133);
            this.cmbBairro.Margin = new System.Windows.Forms.Padding(2);
            this.cmbBairro.Name = "cmbBairro";
            this.cmbBairro.Size = new System.Drawing.Size(430, 21);
            this.cmbBairro.TabIndex = 2;
            // 
            // cmbCidades
            // 
            this.cmbCidades.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCidades.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCidades.FormattingEnabled = true;
            this.cmbCidades.Location = new System.Drawing.Point(394, 98);
            this.cmbCidades.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCidades.Name = "cmbCidades";
            this.cmbCidades.Size = new System.Drawing.Size(312, 21);
            this.cmbCidades.TabIndex = 1;
            // 
            // cmbTipoLogradouro
            // 
            this.cmbTipoLogradouro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTipoLogradouro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoLogradouro.FormattingEnabled = true;
            this.cmbTipoLogradouro.Location = new System.Drawing.Point(144, 164);
            this.cmbTipoLogradouro.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipoLogradouro.Name = "cmbTipoLogradouro";
            this.cmbTipoLogradouro.Size = new System.Drawing.Size(102, 21);
            this.cmbTipoLogradouro.TabIndex = 3;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(165, 196);
            this.txtNum.Margin = new System.Windows.Forms.Padding(2);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(81, 20);
            this.txtNum.TabIndex = 5;
            // 
            // cmbUF
            // 
            this.cmbUF.FormattingEnabled = true;
            this.cmbUF.Items.AddRange(new object[] {
            "AC",
            "AL",
            "AP",
            "AM",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MT",
            "MS",
            "MG",
            "PA",
            "PB",
            "PR",
            "PE",
            "PI",
            "RJ",
            "RN",
            "RS",
            "RO",
            "RR",
            "SC",
            "SP",
            "SE",
            "TO"});
            this.cmbUF.Location = new System.Drawing.Point(165, 98);
            this.cmbUF.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUF.Name = "cmbUF";
            this.cmbUF.Size = new System.Drawing.Size(106, 21);
            this.cmbUF.TabIndex = 0;
            // 
            // txtComplemento
            // 
            this.txtComplemento.Location = new System.Drawing.Point(463, 196);
            this.txtComplemento.Margin = new System.Windows.Forms.Padding(2);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(122, 20);
            this.txtComplemento.TabIndex = 6;
            // 
            // pnlBuscarCEP
            // 
            this.pnlBuscarCEP.BackgroundImage = global::DownloadBanker.Properties.Resources.TelaBuscaCEP;
            this.pnlBuscarCEP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBuscarCEP.Controls.Add(this.lblVoltar);
            this.pnlBuscarCEP.Controls.Add(this.lblConfirmar);
            this.pnlBuscarCEP.Controls.Add(this.mskCep);
            this.pnlBuscarCEP.Controls.Add(this.chkZonaRural);
            this.pnlBuscarCEP.Controls.Add(this.cmbUF);
            this.pnlBuscarCEP.Controls.Add(this.cmbCidades);
            this.pnlBuscarCEP.Controls.Add(this.cmbBairro);
            this.pnlBuscarCEP.Controls.Add(this.cmbTipoLogradouro);
            this.pnlBuscarCEP.Controls.Add(this.cmbRuas);
            this.pnlBuscarCEP.Controls.Add(this.txtComplemento);
            this.pnlBuscarCEP.Controls.Add(this.txtNum);
            this.pnlBuscarCEP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBuscarCEP.Location = new System.Drawing.Point(0, 0);
            this.pnlBuscarCEP.Name = "pnlBuscarCEP";
            this.pnlBuscarCEP.Size = new System.Drawing.Size(809, 280);
            this.pnlBuscarCEP.TabIndex = 58;
            // 
            // lblConfirmar
            // 
            this.lblConfirmar.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmar.Enabled = false;
            this.lblConfirmar.Location = new System.Drawing.Point(260, 249);
            this.lblConfirmar.Name = "lblConfirmar";
            this.lblConfirmar.Size = new System.Drawing.Size(131, 23);
            this.lblConfirmar.TabIndex = 55;
            this.lblConfirmar.Click += new System.EventHandler(this.lblConfirmar_Click);
            // 
            // lblVoltar
            // 
            this.lblVoltar.BackColor = System.Drawing.Color.Transparent;
            this.lblVoltar.Location = new System.Drawing.Point(408, 248);
            this.lblVoltar.Name = "lblVoltar";
            this.lblVoltar.Size = new System.Drawing.Size(106, 23);
            this.lblVoltar.TabIndex = 56;
            this.lblVoltar.Click += new System.EventHandler(this.lblVoltar_Click);
            // 
            // frmBuscaCEP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 280);
            this.Controls.Add(this.pnlBuscarCEP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBuscaCEP";
            this.Text = "DownloadBanker - Buscar CEP";
            this.pnlBuscarCEP.ResumeLayout(false);
            this.pnlBuscarCEP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox chkZonaRural;
        private System.Windows.Forms.ComboBox cmbRuas;
        private System.Windows.Forms.ComboBox cmbBairro;
        private System.Windows.Forms.ComboBox cmbCidades;
        private System.Windows.Forms.ComboBox cmbTipoLogradouro;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.ComboBox cmbUF;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.MaskedTextBox mskCep;
        private System.Windows.Forms.Panel pnlBuscarCEP;
        private System.Windows.Forms.Label lblVoltar;
        private System.Windows.Forms.Label lblConfirmar;
    }
}