namespace sacis.view.sistema.gerenciamento.mensagem
{
    partial class catalogoGeral
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
            this.catalogoDataGridView = new System.Windows.Forms.DataGridView();
            this.coluna_nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluna_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluna_adicionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.adicionaBotao = new System.Windows.Forms.Button();
            this.cancelarBotao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.catalogoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // catalogoDataGridView
            // 
            this.catalogoDataGridView.AllowUserToAddRows = false;
            this.catalogoDataGridView.AllowUserToDeleteRows = false;
            this.catalogoDataGridView.AllowUserToOrderColumns = true;
            this.catalogoDataGridView.AllowUserToResizeColumns = false;
            this.catalogoDataGridView.AllowUserToResizeRows = false;
            this.catalogoDataGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.catalogoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.catalogoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coluna_nome,
            this.coluna_email,
            this.coluna_adicionar});
            this.catalogoDataGridView.Location = new System.Drawing.Point(8, 10);
            this.catalogoDataGridView.Name = "catalogoDataGridView";
            this.catalogoDataGridView.RowHeadersVisible = false;
            this.catalogoDataGridView.RowHeadersWidth = 21;
            this.catalogoDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.catalogoDataGridView.Size = new System.Drawing.Size(424, 213);
            this.catalogoDataGridView.TabIndex = 10;
            this.catalogoDataGridView.Visible = false;
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
            // adicionaBotao
            // 
            this.adicionaBotao.Location = new System.Drawing.Point(130, 232);
            this.adicionaBotao.Name = "adicionaBotao";
            this.adicionaBotao.Size = new System.Drawing.Size(75, 23);
            this.adicionaBotao.TabIndex = 11;
            this.adicionaBotao.Text = "Adicionar";
            this.adicionaBotao.UseVisualStyleBackColor = true;
            this.adicionaBotao.Click += new System.EventHandler(this.adicionaBotaoClick);
            // 
            // cancelarBotao
            // 
            this.cancelarBotao.Location = new System.Drawing.Point(242, 232);
            this.cancelarBotao.Name = "cancelarBotao";
            this.cancelarBotao.Size = new System.Drawing.Size(75, 23);
            this.cancelarBotao.TabIndex = 12;
            this.cancelarBotao.Text = "Sair";
            this.cancelarBotao.UseVisualStyleBackColor = true;
            this.cancelarBotao.Click += new System.EventHandler(this.cancelaClick);
            // 
            // catalogoGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 264);
            this.Controls.Add(this.cancelarBotao);
            this.Controls.Add(this.adicionaBotao);
            this.Controls.Add(this.catalogoDataGridView);
            this.Name = "catalogoGeral";
            this.Text = "Catálogo Geral";
            ((System.ComponentModel.ISupportInitialize)(this.catalogoDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView catalogoDataGridView;
        private System.Windows.Forms.Button adicionaBotao;
        private System.Windows.Forms.Button cancelarBotao;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluna_nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluna_email;
        private System.Windows.Forms.DataGridViewCheckBoxColumn coluna_adicionar;

    }
}