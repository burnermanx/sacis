namespace sacis.view.sistema.armazenamento
{
    partial class login
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
            this.armazena_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_login = new System.Windows.Forms.TextBox();
            this.textbox_senha = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // armazena_button
            // 
            this.armazena_button.Location = new System.Drawing.Point(83, 121);
            this.armazena_button.Name = "armazena_button";
            this.armazena_button.Size = new System.Drawing.Size(75, 23);
            this.armazena_button.TabIndex = 3;
            this.armazena_button.Text = "Ok";
            this.armazena_button.UseVisualStyleBackColor = true;
            this.armazena_button.Click += new System.EventHandler(this.armazena_button_Click);
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
            // textbox_login
            // 
            this.textbox_login.Location = new System.Drawing.Point(95, 39);
            this.textbox_login.Name = "textbox_login";
            this.textbox_login.Size = new System.Drawing.Size(100, 20);
            this.textbox_login.TabIndex = 1;
            // 
            // textbox_senha
            // 
            this.textbox_senha.Location = new System.Drawing.Point(96, 73);
            this.textbox_senha.Name = "textbox_senha";
            this.textbox_senha.PasswordChar = '*';
            this.textbox_senha.Size = new System.Drawing.Size(100, 20);
            this.textbox_senha.TabIndex = 2;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 184);
            this.Controls.Add(this.textbox_senha);
            this.Controls.Add(this.textbox_login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.armazena_button);
            this.KeyPreview = true;
            this.Name = "login";
            this.Text = "Login Armazenamento";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.armazena_button_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button armazena_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textbox_login;
        private System.Windows.Forms.TextBox textbox_senha;

    }
}

