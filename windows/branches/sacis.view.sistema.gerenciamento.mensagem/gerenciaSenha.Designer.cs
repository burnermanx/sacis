namespace sacis.view.sistema.gerenciamento.mensagem
{
    partial class gerenciaSenha
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.novaSenhaTextBox = new System.Windows.Forms.TextBox();
            this.confirmaSenhaTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nova Senha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Confirma Senha:";
            // 
            // novaSenhaTextBox
            // 
            this.novaSenhaTextBox.Location = new System.Drawing.Point(121, 33);
            this.novaSenhaTextBox.Name = "novaSenhaTextBox";
            this.novaSenhaTextBox.PasswordChar = '*';
            this.novaSenhaTextBox.Size = new System.Drawing.Size(100, 20);
            this.novaSenhaTextBox.TabIndex = 0;
            // 
            // confirmaSenhaTextBox
            // 
            this.confirmaSenhaTextBox.Location = new System.Drawing.Point(121, 72);
            this.confirmaSenhaTextBox.Name = "confirmaSenhaTextBox";
            this.confirmaSenhaTextBox.PasswordChar = '*';
            this.confirmaSenhaTextBox.Size = new System.Drawing.Size(100, 20);
            this.confirmaSenhaTextBox.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(104, 127);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButtonClick);
            // 
            // gerenciaSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 175);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.confirmaSenhaTextBox);
            this.Controls.Add(this.novaSenhaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "gerenciaSenha";
            this.Text = "S.A.C.I.S. - Alterar Senha";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.okButtonClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox novaSenhaTextBox;
        private System.Windows.Forms.TextBox confirmaSenhaTextBox;
        private System.Windows.Forms.Button okButton;
    }
}