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
            this.anexos_dataGridView = new System.Windows.Forms.DataGridView();
            this.anexar = new System.Windows.Forms.OpenFileDialog();
            this.ok_botao = new System.Windows.Forms.Button();
            this.cancelar_botao = new System.Windows.Forms.Button();
            this.coluna_arquivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coluna_remover = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.coluna_criptografar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.anexos_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // anexos_dataGridView
            // 
            this.anexos_dataGridView.AllowUserToAddRows = false;
            this.anexos_dataGridView.AllowUserToDeleteRows = false;
            this.anexos_dataGridView.AllowUserToOrderColumns = true;
            this.anexos_dataGridView.AllowUserToResizeColumns = false;
            this.anexos_dataGridView.AllowUserToResizeRows = false;
            this.anexos_dataGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.anexos_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.anexos_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coluna_arquivo,
            this.coluna_remover,
            this.coluna_criptografar});
            this.anexos_dataGridView.Location = new System.Drawing.Point(8, 10);
            this.anexos_dataGridView.Name = "anexos_dataGridView";
            this.anexos_dataGridView.RowHeadersVisible = false;
            this.anexos_dataGridView.RowHeadersWidth = 21;
            this.anexos_dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.anexos_dataGridView.Size = new System.Drawing.Size(424, 213);
            this.anexos_dataGridView.TabIndex = 10;
            this.anexos_dataGridView.Visible = false;
            // 
            // anexar
            // 
            this.anexar.Multiselect = true;
            this.anexar.Title = "Selecionar Arquivos";
            // 
            // ok_botao
            // 
            this.ok_botao.Location = new System.Drawing.Point(130, 232);
            this.ok_botao.Name = "ok_botao";
            this.ok_botao.Size = new System.Drawing.Size(75, 23);
            this.ok_botao.TabIndex = 11;
            this.ok_botao.Text = "Ok";
            this.ok_botao.UseVisualStyleBackColor = true;
            this.ok_botao.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelar_botao
            // 
            this.cancelar_botao.Location = new System.Drawing.Point(242, 232);
            this.cancelar_botao.Name = "cancelar_botao";
            this.cancelar_botao.Size = new System.Drawing.Size(75, 23);
            this.cancelar_botao.TabIndex = 12;
            this.cancelar_botao.Text = "Cancelar";
            this.cancelar_botao.UseVisualStyleBackColor = true;
            this.cancelar_botao.Click += new System.EventHandler(this.cancelarButton_Click);
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
            // novaMensagemAnexar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 264);
            this.Controls.Add(this.cancelar_botao);
            this.Controls.Add(this.ok_botao);
            this.Controls.Add(this.anexos_dataGridView);
            this.Name = "novaMensagemAnexar";
            this.Text = "Anexos";
            ((System.ComponentModel.ISupportInitialize)(this.anexos_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView anexos_dataGridView;
        private System.Windows.Forms.OpenFileDialog anexar;
        private System.Windows.Forms.Button ok_botao;
        private System.Windows.Forms.Button cancelar_botao;
        private System.Windows.Forms.DataGridViewTextBoxColumn coluna_arquivo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn coluna_remover;
        private System.Windows.Forms.DataGridViewCheckBoxColumn coluna_criptografar;

    }
}