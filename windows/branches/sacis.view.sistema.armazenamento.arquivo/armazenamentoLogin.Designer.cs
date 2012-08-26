namespace sacis.view.sistema.armazenamento
{
    partial class armazenamentoLogin
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
            this.armazenaButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textboxLogin = new System.Windows.Forms.TextBox();
            this.textboxSenha = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // armazenaButton
            // 
            this.armazenaButton.Location = new System.Drawing.Point(83, 121);
            this.armazenaButton.Name = "armazenaButton";
            this.armazenaButton.Size = new System.Drawing.Size(75, 23);
            this.armazenaButton.TabIndex = 2;
            this.armazenaButton.Text = "Ok";
            this.armazenaButton.UseVisualStyleBackColor = true;
            this.armazenaButton.Click += new System.EventHandler(this.armazenaButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Login:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Senha:";
            // 
            // textboxLogin
            // 
            this.textboxLogin.Location = new System.Drawing.Point(95, 39);
            this.textboxLogin.Name = "textboxLogin";
            this.textboxLogin.Size = new System.Drawing.Size(100, 20);
            this.textboxLogin.TabIndex = 0;
            // 
            // textboxSenha
            // 
            this.textboxSenha.Location = new System.Drawing.Point(96, 73);
            this.textboxSenha.Name = "textboxSenha";
            this.textboxSenha.PasswordChar = '*';
            this.textboxSenha.Size = new System.Drawing.Size(100, 20);
            this.textboxSenha.TabIndex = 1;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 184);
            this.Controls.Add(this.textboxSenha);
            this.Controls.Add(this.textboxLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.armazenaButton);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.Text = "Sistema Armazenamento - Login";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.armazenaButtonClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button armazenaButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textboxLogin;
        private System.Windows.Forms.TextBox textboxSenha;

    }
}

