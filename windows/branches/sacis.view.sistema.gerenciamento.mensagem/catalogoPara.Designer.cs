namespace sacis.view.sistema.gerenciamento.mensagem
{
    partial class catalogoPara
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
            this.catalogoPessoalDataGridView = new System.Windows.Forms.DataGridView();
            this.okBotao = new System.Windows.Forms.Button();
            this.sairBotao = new System.Windows.Forms.Button();
            this.coluna_nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluna_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluna_adicionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.catalogoPessoalDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // catalogoPessoalDataGridView
            // 
            this.catalogoPessoalDataGridView.AllowUserToAddRows = false;
            this.catalogoPessoalDataGridView.AllowUserToDeleteRows = false;
            this.catalogoPessoalDataGridView.AllowUserToOrderColumns = true;
            this.catalogoPessoalDataGridView.AllowUserToResizeColumns = false;
            this.catalogoPessoalDataGridView.AllowUserToResizeRows = false;
            this.catalogoPessoalDataGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.catalogoPessoalDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.catalogoPessoalDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coluna_nome,
            this.coluna_email,
            this.coluna_adicionar});
            this.catalogoPessoalDataGridView.Location = new System.Drawing.Point(8, 10);
            this.catalogoPessoalDataGridView.Name = "catalogoPessoalDataGridView";
            this.catalogoPessoalDataGridView.RowHeadersVisible = false;
            this.catalogoPessoalDataGridView.RowHeadersWidth = 21;
            this.catalogoPessoalDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.catalogoPessoalDataGridView.Size = new System.Drawing.Size(424, 213);
            this.catalogoPessoalDataGridView.TabIndex = 10;
            this.catalogoPessoalDataGridView.Visible = false;
            // 
            // okBotao
            // 
            this.okBotao.Location = new System.Drawing.Point(104, 232);
            this.okBotao.Name = "okBotao";
            this.okBotao.Size = new System.Drawing.Size(75, 23);
            this.okBotao.TabIndex = 11;
            this.okBotao.Text = "Ok";
            this.okBotao.UseVisualStyleBackColor = true;
            this.okBotao.Click += new System.EventHandler(this.okButtonClick);
            // 
            // sairBotao
            // 
            this.sairBotao.Location = new System.Drawing.Point(230, 232);
            this.sairBotao.Name = "sairBotao";
            this.sairBotao.Size = new System.Drawing.Size(75, 23);
            this.sairBotao.TabIndex = 12;
            this.sairBotao.Text = "Sair";
            this.sairBotao.UseVisualStyleBackColor = true;
            this.sairBotao.Click += new System.EventHandler(this.cancelarButtonClick);
            // 
            // coluna_nome
            // 
            this.coluna_nome.HeaderText = "Nome";
            this.coluna_nome.Name = "coluna_nome";
            this.coluna_nome.Width = 150;
            // 
            // coluna_email
            // 
            this.coluna_email.HeaderText = "E-mail";
            this.coluna_email.Name = "coluna_email";
            this.coluna_email.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.coluna_email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.coluna_email.Width = 200;
            // 
            // coluna_adicionar
            // 
            this.coluna_adicionar.HeaderText = "Adicionar";
            this.coluna_adicionar.Name = "coluna_adicionar";
            this.coluna_adicionar.Width = 70;
            // 
            // catalogoPara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 264);
            this.Controls.Add(this.sairBotao);
            this.Controls.Add(this.okBotao);
            this.Controls.Add(this.catalogoPessoalDataGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "catalogoPara";
            this.Text = "Catálogo Pessoal";
            ((System.ComponentModel.ISupportInitialize)(this.catalogoPessoalDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView catalogoPessoalDataGridView;
        private System.Windows.Forms.Button okBotao;
        private System.Windows.Forms.Button sairBotao;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluna_nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluna_email;
        private System.Windows.Forms.DataGridViewCheckBoxColumn coluna_adicionar;

    }
}