﻿namespace sacis.view.sistema.gerenciamento.mensagem
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
            this.catalogoPessoalDataGridView = new System.Windows.Forms.DataGridView();
            this.sairBotao = new System.Windows.Forms.Button();
            this.removerBotao = new System.Windows.Forms.Button();
            this.coluna_nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluna_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluna_remover = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.coluna_remover});
            this.catalogoPessoalDataGridView.Location = new System.Drawing.Point(8, 10);
            this.catalogoPessoalDataGridView.Name = "catalogoPessoalDataGridView";
            this.catalogoPessoalDataGridView.RowHeadersVisible = false;
            this.catalogoPessoalDataGridView.RowHeadersWidth = 21;
            this.catalogoPessoalDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.catalogoPessoalDataGridView.Size = new System.Drawing.Size(423, 213);
            this.catalogoPessoalDataGridView.TabIndex = 10;
            this.catalogoPessoalDataGridView.Visible = false;
            // 
            // sairBotao
            // 
            this.sairBotao.Location = new System.Drawing.Point(232, 231);
            this.sairBotao.Name = "sairBotao";
            this.sairBotao.Size = new System.Drawing.Size(75, 23);
            this.sairBotao.TabIndex = 12;
            this.sairBotao.Text = "Sair";
            this.sairBotao.UseVisualStyleBackColor = true;
            this.sairBotao.Click += new System.EventHandler(this.cancelarButtonClick);
            // 
            // removerBotao
            // 
            this.removerBotao.Location = new System.Drawing.Point(98, 231);
            this.removerBotao.Name = "removerBotao";
            this.removerBotao.Size = new System.Drawing.Size(75, 23);
            this.removerBotao.TabIndex = 13;
            this.removerBotao.Text = "Remover";
            this.removerBotao.UseVisualStyleBackColor = true;
            this.removerBotao.Click += new System.EventHandler(this.removerBotaoClick);
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
            // coluna_remover
            // 
            this.coluna_remover.HeaderText = "Remover";
            this.coluna_remover.Name = "coluna_remover";
            this.coluna_remover.Width = 70;
            // 
            // catalogoPessoal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 264);
            this.Controls.Add(this.removerBotao);
            this.Controls.Add(this.sairBotao);
            this.Controls.Add(this.catalogoPessoalDataGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "catalogoPessoal";
            this.Text = "Catálogo Pessoal";
            ((System.ComponentModel.ISupportInitialize)(this.catalogoPessoalDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView catalogoPessoalDataGridView;
        private System.Windows.Forms.Button sairBotao;
        private System.Windows.Forms.Button removerBotao;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluna_nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluna_email;
        private System.Windows.Forms.DataGridViewCheckBoxColumn coluna_remover;

    }
}