namespace sacis.view.sistema.gerenciamento.mensagem
{
    partial class gerenciaChave
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
            this.botaoOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chave = new System.Windows.Forms.OpenFileDialog();
            this.botaoSelecionar = new System.Windows.Forms.Button();
            this.chaveTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // botaoOk
            // 
            this.botaoOk.Location = new System.Drawing.Point(53, 126);
            this.botaoOk.Name = "botaoOk";
            this.botaoOk.Size = new System.Drawing.Size(75, 23);
            this.botaoOk.TabIndex = 0;
            this.botaoOk.Text = "Ok";
            this.botaoOk.UseVisualStyleBackColor = true;
            this.botaoOk.Click += new System.EventHandler(this.okButton);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selecione a chave privada desejada";
            // 
            // chave
            // 
            this.chave.FileName = "chave";
            // 
            // botaoSelecionar
            // 
            this.botaoSelecionar.Location = new System.Drawing.Point(134, 126);
            this.botaoSelecionar.Name = "botaoSelecionar";
            this.botaoSelecionar.Size = new System.Drawing.Size(103, 23);
            this.botaoSelecionar.TabIndex = 2;
            this.botaoSelecionar.Text = "Selecionar Chave";
            this.botaoSelecionar.UseVisualStyleBackColor = true;
            this.botaoSelecionar.Click += new System.EventHandler(this.selecionarButton);
            // 
            // chaveTextBox
            // 
            this.chaveTextBox.Location = new System.Drawing.Point(53, 76);
            this.chaveTextBox.Name = "chaveTextBox";
            this.chaveTextBox.Size = new System.Drawing.Size(184, 20);
            this.chaveTextBox.TabIndex = 3;
            // 
            // gerenciaChave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 171);
            this.Controls.Add(this.chaveTextBox);
            this.Controls.Add(this.botaoSelecionar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botaoOk);
            this.Name = "gerenciaChave";
            this.Text = "Seleção Chave Privada";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botaoOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog chave;
        private System.Windows.Forms.Button botaoSelecionar;
        private System.Windows.Forms.TextBox chaveTextBox;
    }
}