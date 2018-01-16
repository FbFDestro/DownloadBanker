namespace DownloadBanker
{
    partial class frmAdminFuncCadastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminFuncCadastro));
            this.pnlAdminCadastroFunc = new System.Windows.Forms.Panel();
            this.txtSalario = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.pnlAdminCadastroFunc.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAdminCadastroFunc
            // 
            this.pnlAdminCadastroFunc.BackgroundImage = global::DownloadBanker.Properties.Resources.TelaAdminFuncCadastro;
            this.pnlAdminCadastroFunc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlAdminCadastroFunc.Controls.Add(this.txtData);
            this.pnlAdminCadastroFunc.Controls.Add(this.txtCelular);
            this.pnlAdminCadastroFunc.Controls.Add(this.txtSalario);
            this.pnlAdminCadastroFunc.Controls.Add(this.txtBairro);
            this.pnlAdminCadastroFunc.Controls.Add(this.txtCEP);
            this.pnlAdminCadastroFunc.Controls.Add(this.txtCPF);
            this.pnlAdminCadastroFunc.Controls.Add(this.txtEmail);
            this.pnlAdminCadastroFunc.Controls.Add(this.txtNome);
            this.pnlAdminCadastroFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAdminCadastroFunc.Location = new System.Drawing.Point(0, 0);
            this.pnlAdminCadastroFunc.Name = "pnlAdminCadastroFunc";
            this.pnlAdminCadastroFunc.Size = new System.Drawing.Size(828, 522);
            this.pnlAdminCadastroFunc.TabIndex = 1;
            // 
            // txtSalario
            // 
            this.txtSalario.Location = new System.Drawing.Point(157, 397);
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.Size = new System.Drawing.Size(138, 20);
            this.txtSalario.TabIndex = 5;
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(148, 358);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(147, 20);
            this.txtBairro.TabIndex = 4;
            // 
            // txtCEP
            // 
            this.txtCEP.Location = new System.Drawing.Point(116, 317);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(165, 20);
            this.txtCEP.TabIndex = 3;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(116, 235);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(251, 20);
            this.txtCPF.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(141, 192);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(226, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(242, 150);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(219, 20);
            this.txtNome.TabIndex = 0;
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(582, 156);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(161, 20);
            this.txtCelular.TabIndex = 6;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(613, 194);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(130, 20);
            this.txtData.TabIndex = 7;
            // 
            // frmAdminFuncCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 522);
            this.Controls.Add(this.pnlAdminCadastroFunc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(844, 561);
            this.MinimumSize = new System.Drawing.Size(844, 561);
            this.Name = "frmAdminFuncCadastro";
            this.Text = "Administrador - Cadastro de funcionários";
            this.pnlAdminCadastroFunc.ResumeLayout(false);
            this.pnlAdminCadastroFunc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAdminCadastroFunc;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.TextBox txtSalario;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNome;
    }
}