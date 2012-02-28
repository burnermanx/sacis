namespace sacis.view.sistema.gerenciamento.mensagem
{
    partial class catalogoPessoal
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
            this.catalogoPessoal_dataGridView = new System.Windows.Forms.DataGridView();
            this.coluna_nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluna_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluna_adicionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.coluna_remover = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ok_Botao = new System.Windows.Forms.Button();
            this.sair_botao = new System.Windows.Forms.Button();
            this.remover_botao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.catalogoPessoal_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // catalogoPessoal_dataGridView
            // 
            this.catalogoPessoal_dataGridView.AllowUserToAddRows = false;
            this.catalogoPessoal_dataGridView.AllowUserToDeleteRows = false;
            this.catalogoPessoal_dataGridView.AllowUserToOrderColumns = true;
            this.catalogoPessoal_dataGridView.AllowUserToResizeColumns = false;
            this.catalogoPessoal_dataGridView.AllowUserToResizeRows = false;
            this.catalogoPessoal_dataGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.catalogoPessoal_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.catalogoPessoal_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coluna_nome,
            this.coluna_email,
            this.coluna_adicionar,
            this.coluna_remover});
            this.catalogoPessoal_dataGridView.Location = new System.Drawing.Point(8, 10);
            this.catalogoPessoal_dataGridView.Name = "catalogoPessoal_dataGridView";
            this.catalogoPessoal_dataGridView.RowHeadersVisible = false;
            this.catalogoPessoal_dataGridView.RowHeadersWidth = 21;
            this.catalogoPessoal_dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.catalogoPessoal_dataGridView.Size = new System.Drawing.Size(494, 213);
            this.catalogoPessoal_dataGridView.TabIndex = 10;
            this.catalogoPessoal_dataGridView.Visible = false;
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
            // coluna_remover
            // 
            this.coluna_remover.HeaderText = "Remover";
            this.coluna_remover.Name = "coluna_remover";
            this.coluna_remover.Width = 70;
            // 
            // ok_Botao
            // 
            this.ok_Botao.Location = new System.Drawing.Point(104, 232);
            this.ok_Botao.Name = "ok_Botao";
            this.ok_Botao.Size = new System.Drawing.Size(75, 23);
            this.ok_Botao.TabIndex = 11;
            this.ok_Botao.Text = "Ok";
            this.ok_Botao.UseVisualStyleBackColor = true;
            this.ok_Botao.Click += new System.EventHandler(this.okButton_Click);
            // 
            // sair_botao
            // 
            this.sair_botao.Location = new System.Drawing.Point(327, 231);
            this.sair_botao.Name = "sair_botao";
            this.sair_botao.Size = new System.Drawing.Size(75, 23);
            this.sair_botao.TabIndex = 12;
            this.sair_botao.Text = "Sair";
            this.sair_botao.UseVisualStyleBackColor = true;
            this.sair_botao.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // remover_botao
            // 
            this.remover_botao.Location = new System.Drawing.Point(215, 231);
            this.remover_botao.Name = "remover_botao";
            this.remover_botao.Size = new System.Drawing.Size(75, 23);
            this.remover_botao.TabIndex = 13;
            this.remover_botao.Text = "Remover";
            this.remover_botao.UseVisualStyleBackColor = true;
            this.remover_botao.Click += new System.EventHandler(this.remover_botao_Click);
            // 
            // catalogoPessoal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 264);
            this.Controls.Add(this.remover_botao);
            this.Controls.Add(this.sair_botao);
            this.Controls.Add(this.ok_Botao);
            this.Controls.Add(this.catalogoPessoal_dataGridView);
            this.Name = "catalogoPessoal";
            this.Text = "Catálogo Pessoal";
            ((System.ComponentModel.ISupportInitialize)(this.catalogoPessoal_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView catalogoPessoal_dataGridView;
        private System.Windows.Forms.Button ok_Botao;
        private System.Windows.Forms.Button sair_botao;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluna_nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluna_email;
        private System.Windows.Forms.DataGridViewCheckBoxColumn coluna_adicionar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn coluna_remover;
        private System.Windows.Forms.Button remover_botao;

    }
}