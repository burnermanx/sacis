namespace sacis.view.sistema.gerenciamento.mensagem
{
    partial class novaMensagemAnexar
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
            this.anexosDataGridView = new System.Windows.Forms.DataGridView();
            this.coluna_arquivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluna_remover = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.coluna_criptografar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.anexar = new System.Windows.Forms.OpenFileDialog();
            this.okBotao = new System.Windows.Forms.Button();
            this.cancelarBotao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.anexosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // anexosDataGridView
            // 
            this.anexosDataGridView.AllowUserToAddRows = false;
            this.anexosDataGridView.AllowUserToDeleteRows = false;
            this.anexosDataGridView.AllowUserToOrderColumns = true;
            this.anexosDataGridView.AllowUserToResizeColumns = false;
            this.anexosDataGridView.AllowUserToResizeRows = false;
            this.anexosDataGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.anexosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.anexosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coluna_arquivo,
            this.coluna_remover,
            this.coluna_criptografar});
            this.anexosDataGridView.Location = new System.Drawing.Point(8, 10);
            this.anexosDataGridView.Name = "anexosDataGridView";
            this.anexosDataGridView.RowHeadersVisible = false;
            this.anexosDataGridView.RowHeadersWidth = 21;
            this.anexosDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.anexosDataGridView.Size = new System.Drawing.Size(424, 213);
            this.anexosDataGridView.TabIndex = 10;
            this.anexosDataGridView.Visible = false;
            // 
            // coluna_arquivo
            // 
            this.coluna_arquivo.HeaderText = "Arquivo";
            this.coluna_arquivo.Name = "coluna_arquivo";
            this.coluna_arquivo.Width = 264;
            // 
            // coluna_remover
            // 
            this.coluna_remover.HeaderText = "Remover";
            this.coluna_remover.Name = "coluna_remover";
            this.coluna_remover.Width = 70;
            // 
            // coluna_criptografar
            // 
            this.coluna_criptografar.HeaderText = "Criptografar";
            this.coluna_criptografar.Name = "coluna_criptografar";
            this.coluna_criptografar.Width = 70;
            // 
            // anexar
            // 
            this.anexar.Multiselect = true;
            this.anexar.Title = "Selecionar Arquivos";
            // 
            // okBotao
            // 
            this.okBotao.Location = new System.Drawing.Point(130, 232);
            this.okBotao.Name = "okBotao";
            this.okBotao.Size = new System.Drawing.Size(75, 23);
            this.okBotao.TabIndex = 11;
            this.okBotao.Text = "Ok";
            this.okBotao.UseVisualStyleBackColor = true;
            this.okBotao.Click += new System.EventHandler(this.okButtonClick);
            // 
            // cancelarBotao
            // 
            this.cancelarBotao.Location = new System.Drawing.Point(242, 232);
            this.cancelarBotao.Name = "cancelarBotao";
            this.cancelarBotao.Size = new System.Drawing.Size(75, 23);
            this.cancelarBotao.TabIndex = 12;
            this.cancelarBotao.Text = "Cancelar";
            this.cancelarBotao.UseVisualStyleBackColor = true;
            this.cancelarBotao.Click += new System.EventHandler(this.cancelarButtonClick);
            // 
            // novaMensagemAnexar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 264);
            this.Controls.Add(this.cancelarBotao);
            this.Controls.Add(this.okBotao);
            this.Controls.Add(this.anexosDataGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "novaMensagemAnexar";
            this.Text = "Anexos";
            ((System.ComponentModel.ISupportInitialize)(this.anexosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView anexosDataGridView;
        private System.Windows.Forms.OpenFileDialog anexar;
        private System.Windows.Forms.Button okBotao;
        private System.Windows.Forms.Button cancelarBotao;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluna_arquivo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn coluna_remover;
        private System.Windows.Forms.DataGridViewCheckBoxColumn coluna_criptografar;

    }
}