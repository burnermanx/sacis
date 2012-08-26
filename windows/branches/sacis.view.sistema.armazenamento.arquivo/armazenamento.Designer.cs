namespace sacis.view.sistema.armazenamento
{
    partial class armazenamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(armazenamento));
            this.tabArmazena = new System.Windows.Forms.TabControl();
            this.tabCripto = new System.Windows.Forms.TabPage();
            this.criptoDataGridView = new System.Windows.Forms.DataGridView();
            this.colunaArquivoCripto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaRemoverCripto = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabDescripto = new System.Windows.Forms.TabPage();
            this.descriptoDataGridView = new System.Windows.Forms.DataGridView();
            this.colunaArquivoDescripto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaRemoverDescripto = new System.Windows.Forms.DataGridViewImageColumn();
            this.botaoOk = new System.Windows.Forms.Button();
            this.botaoCancelar = new System.Windows.Forms.Button();
            this.botaoSelecionar = new System.Windows.Forms.Button();
            this.anexar = new System.Windows.Forms.OpenFileDialog();
            this.selecionaPastaDestino = new System.Windows.Forms.FolderBrowserDialog();
            this.tabArmazena.SuspendLayout();
            this.tabCripto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.criptoDataGridView)).BeginInit();
            this.tabDescripto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.descriptoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabArmazena
            // 
            this.tabArmazena.Controls.Add(this.tabCripto);
            this.tabArmazena.Controls.Add(this.tabDescripto);
            this.tabArmazena.Location = new System.Drawing.Point(1, 4);
            this.tabArmazena.Name = "tabArmazena";
            this.tabArmazena.SelectedIndex = 0;
            this.tabArmazena.Size = new System.Drawing.Size(405, 224);
            this.tabArmazena.TabIndex = 0;
            // 
            // tabCripto
            // 
            this.tabCripto.Controls.Add(this.criptoDataGridView);
            this.tabCripto.Location = new System.Drawing.Point(4, 22);
            this.tabCripto.Name = "tabCripto";
            this.tabCripto.Padding = new System.Windows.Forms.Padding(3);
            this.tabCripto.Size = new System.Drawing.Size(397, 198);
            this.tabCripto.TabIndex = 0;
            this.tabCripto.Text = "Criptografar";
            this.tabCripto.UseVisualStyleBackColor = true;
            // 
            // criptoDataGridView
            // 
            this.criptoDataGridView.AllowUserToAddRows = false;
            this.criptoDataGridView.AllowUserToDeleteRows = false;
            this.criptoDataGridView.AllowUserToResizeColumns = false;
            this.criptoDataGridView.AllowUserToResizeRows = false;
            this.criptoDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.criptoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.criptoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaArquivoCripto,
            this.colunaRemoverCripto});
            this.criptoDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.criptoDataGridView.Location = new System.Drawing.Point(0, 0);
            this.criptoDataGridView.Name = "criptoDataGridView";
            this.criptoDataGridView.ReadOnly = true;
            this.criptoDataGridView.RowHeadersVisible = false;
            this.criptoDataGridView.Size = new System.Drawing.Size(397, 198);
            this.criptoDataGridView.TabIndex = 0;
            this.criptoDataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.removerArquivoLista);
            // 
            // colunaArquivoCripto
            // 
            this.colunaArquivoCripto.HeaderText = "Arquivo";
            this.colunaArquivoCripto.Name = "colunaArquivoCripto";
            this.colunaArquivoCripto.ReadOnly = true;
            this.colunaArquivoCripto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colunaArquivoCripto.Width = 345;
            // 
            // colunaRemoverCripto
            // 
            this.colunaRemoverCripto.FillWeight = 50F;
            this.colunaRemoverCripto.HeaderText = "";
            this.colunaRemoverCripto.Image = ((System.Drawing.Image)(resources.GetObject("colunaRemoverCripto.Image")));
            this.colunaRemoverCripto.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colunaRemoverCripto.Name = "colunaRemoverCripto";
            this.colunaRemoverCripto.ReadOnly = true;
            this.colunaRemoverCripto.ToolTipText = "Excluir Arquivo da Lista";
            this.colunaRemoverCripto.Width = 30;
            // 
            // tabDescripto
            // 
            this.tabDescripto.Controls.Add(this.descriptoDataGridView);
            this.tabDescripto.Location = new System.Drawing.Point(4, 22);
            this.tabDescripto.Name = "tabDescripto";
            this.tabDescripto.Padding = new System.Windows.Forms.Padding(3);
            this.tabDescripto.Size = new System.Drawing.Size(397, 198);
            this.tabDescripto.TabIndex = 1;
            this.tabDescripto.Text = "Descriptografar";
            this.tabDescripto.UseVisualStyleBackColor = true;
            // 
            // descriptoDataGridView
            // 
            this.descriptoDataGridView.AllowUserToAddRows = false;
            this.descriptoDataGridView.AllowUserToDeleteRows = false;
            this.descriptoDataGridView.AllowUserToResizeColumns = false;
            this.descriptoDataGridView.AllowUserToResizeRows = false;
            this.descriptoDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.descriptoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.descriptoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaArquivoDescripto,
            this.colunaRemoverDescripto});
            this.descriptoDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.descriptoDataGridView.Location = new System.Drawing.Point(0, 0);
            this.descriptoDataGridView.Name = "descriptoDataGridView";
            this.descriptoDataGridView.ReadOnly = true;
            this.descriptoDataGridView.RowHeadersVisible = false;
            this.descriptoDataGridView.Size = new System.Drawing.Size(397, 198);
            this.descriptoDataGridView.TabIndex = 1;
            this.descriptoDataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.removerArquivoLista);
            // 
            // colunaArquivoDescripto
            // 
            this.colunaArquivoDescripto.HeaderText = "Arquivo";
            this.colunaArquivoDescripto.Name = "colunaArquivoDescripto";
            this.colunaArquivoDescripto.ReadOnly = true;
            this.colunaArquivoDescripto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colunaArquivoDescripto.Width = 345;
            // 
            // colunaRemoverDescripto
            // 
            this.colunaRemoverDescripto.FillWeight = 50F;
            this.colunaRemoverDescripto.HeaderText = "";
            this.colunaRemoverDescripto.Image = ((System.Drawing.Image)(resources.GetObject("colunaRemoverDescripto.Image")));
            this.colunaRemoverDescripto.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colunaRemoverDescripto.Name = "colunaRemoverDescripto";
            this.colunaRemoverDescripto.ReadOnly = true;
            this.colunaRemoverDescripto.ToolTipText = "Excluir Arquivo da Lista";
            this.colunaRemoverDescripto.Width = 30;
            // 
            // botaoOk
            // 
            this.botaoOk.Location = new System.Drawing.Point(67, 234);
            this.botaoOk.Name = "botaoOk";
            this.botaoOk.Size = new System.Drawing.Size(75, 23);
            this.botaoOk.TabIndex = 1;
            this.botaoOk.Text = "OK";
            this.botaoOk.UseVisualStyleBackColor = true;
            this.botaoOk.Click += new System.EventHandler(this.okButtonClick);
            // 
            // botaoCancelar
            // 
            this.botaoCancelar.Location = new System.Drawing.Point(167, 235);
            this.botaoCancelar.Name = "botaoCancelar";
            this.botaoCancelar.Size = new System.Drawing.Size(75, 23);
            this.botaoCancelar.TabIndex = 2;
            this.botaoCancelar.Text = "Cancelar";
            this.botaoCancelar.UseVisualStyleBackColor = true;
            this.botaoCancelar.Click += new System.EventHandler(this.cancelarButtonClick);
            // 
            // botaoSelecionar
            // 
            this.botaoSelecionar.Location = new System.Drawing.Point(266, 235);
            this.botaoSelecionar.Name = "botaoSelecionar";
            this.botaoSelecionar.Size = new System.Drawing.Size(75, 23);
            this.botaoSelecionar.TabIndex = 3;
            this.botaoSelecionar.Text = "Selecionar";
            this.botaoSelecionar.UseVisualStyleBackColor = true;
            this.botaoSelecionar.Click += new System.EventHandler(this.selecionarButtonClick);
            // 
            // anexar
            // 
            this.anexar.FileName = "anexar";
            this.anexar.Multiselect = true;
            // 
            // armazenamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 267);
            this.Controls.Add(this.botaoSelecionar);
            this.Controls.Add(this.botaoCancelar);
            this.Controls.Add(this.botaoOk);
            this.Controls.Add(this.tabArmazena);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "armazenamento";
            this.Text = "S.A.C.I.S. - Sistema de Armazenamento de Arquivos";
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cancelarButtonClick);
            this.tabArmazena.ResumeLayout(false);
            this.tabCripto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.criptoDataGridView)).EndInit();
            this.tabDescripto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.descriptoDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabArmazena;
        private System.Windows.Forms.TabPage tabCripto;
        private System.Windows.Forms.TabPage tabDescripto;
        private System.Windows.Forms.Button botaoOk;
        private System.Windows.Forms.Button botaoCancelar;
        private System.Windows.Forms.Button botaoSelecionar;
        private System.Windows.Forms.DataGridView criptoDataGridView;
        private System.Windows.Forms.DataGridView descriptoDataGridView;
        private System.Windows.Forms.OpenFileDialog anexar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaArquivoCripto;
        private System.Windows.Forms.DataGridViewImageColumn colunaRemoverCripto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaArquivoDescripto;
        private System.Windows.Forms.DataGridViewImageColumn colunaRemoverDescripto;
        private System.Windows.Forms.FolderBrowserDialog selecionaPastaDestino;
    }
}