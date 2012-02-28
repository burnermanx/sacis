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
            this.catalogo_DataGridView = new System.Windows.Forms.DataGridView();
            this.coluna_nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluna_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluna_adicionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.adiciona_botao = new System.Windows.Forms.Button();
            this.cancelar_Botao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.catalogo_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // catalogo_DataGridView
            // 
            this.catalogo_DataGridView.AllowUserToAddRows = false;
            this.catalogo_DataGridView.AllowUserToDeleteRows = false;
            this.catalogo_DataGridView.AllowUserToOrderColumns = true;
            this.catalogo_DataGridView.AllowUserToResizeColumns = false;
            this.catalogo_DataGridView.AllowUserToResizeRows = false;
            this.catalogo_DataGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.catalogo_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.catalogo_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coluna_nome,
            this.coluna_email,
            this.coluna_adicionar});
            this.catalogo_DataGridView.Location = new System.Drawing.Point(8, 10);
            this.catalogo_DataGridView.Name = "catalogo_DataGridView";
            this.catalogo_DataGridView.RowHeadersVisible = false;
            this.catalogo_DataGridView.RowHeadersWidth = 21;
            this.catalogo_DataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.catalogo_DataGridView.Size = new System.Drawing.Size(424, 213);
            this.catalogo_DataGridView.TabIndex = 10;
            this.catalogo_DataGridView.Visible = false;
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
            // adiciona_botao
            // 
            this.adiciona_botao.Location = new System.Drawing.Point(130, 232);
            this.adiciona_botao.Name = "adiciona_botao";
            this.adiciona_botao.Size = new System.Drawing.Size(75, 23);
            this.adiciona_botao.TabIndex = 11;
            this.adiciona_botao.Text = "Adicionar";
            this.adiciona_botao.UseVisualStyleBackColor = true;
            this.adiciona_botao.Click += new System.EventHandler(this.adicionaBotao_Click);
            // 
            // cancelar_Botao
            // 
            this.cancelar_Botao.Location = new System.Drawing.Point(242, 232);
            this.cancelar_Botao.Name = "cancelar_Botao";
            this.cancelar_Botao.Size = new System.Drawing.Size(75, 23);
            this.cancelar_Botao.TabIndex = 12;
            this.cancelar_Botao.Text = "Sair";
            this.cancelar_Botao.UseVisualStyleBackColor = true;
            this.cancelar_Botao.Click += new System.EventHandler(this.cancela_Click);
            // 
            // catalogoGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 264);
            this.Controls.Add(this.cancelar_Botao);
            this.Controls.Add(this.adiciona_botao);
            this.Controls.Add(this.catalogo_DataGridView);
            this.Name = "catalogoGeral";
            this.Text = "Catálogo Geral";
            ((System.ComponentModel.ISupportInitialize)(this.catalogo_DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView catalogo_DataGridView;
        private System.Windows.Forms.Button adiciona_botao;
        private System.Windows.Forms.Button cancelar_Botao;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluna_nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluna_email;
        private System.Windows.Forms.DataGridViewCheckBoxColumn coluna_adicionar;

    }
}