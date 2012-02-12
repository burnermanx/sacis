namespace sacis.view.manutencao.cadastro
{
    partial class cadastro
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
            this.label1_privado = new System.Windows.Forms.Label();
            this.label2_privado = new System.Windows.Forms.Label();
            this.button_privado = new System.Windows.Forms.Button();
            this.textBoxp_nome = new System.Windows.Forms.TextBox();
            this.textBoxp_pass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxp_login = new System.Windows.Forms.TextBox();
            this.textBoxp_chave = new System.Windows.Forms.TextBox();
            this.button_chave = new System.Windows.Forms.Button();
            this.anexar = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1_privado
            // 
            this.label1_privado.Location = new System.Drawing.Point(40, 53);
            this.label1_privado.Name = "label1_privado";
            this.label1_privado.Size = new System.Drawing.Size(100, 23);
            this.label1_privado.TabIndex = 10;
            this.label1_privado.Text = "Login :";
            // 
            // label2_privado
            // 
            this.label2_privado.Location = new System.Drawing.Point(36, 81);
            this.label2_privado.Name = "label2_privado";
            this.label2_privado.Size = new System.Drawing.Size(100, 23);
            this.label2_privado.TabIndex = 9;
            this.label2_privado.Text = "Senha :";
            // 
            // button_privado
            // 
            this.button_privado.Location = new System.Drawing.Point(85, 153);
            this.button_privado.Name = "button_privado";
            this.button_privado.Size = new System.Drawing.Size(75, 23);
            this.button_privado.TabIndex = 7;
            this.button_privado.Text = "Ok";
            this.button_privado.UseVisualStyleBackColor = true;
            this.button_privado.Click += new System.EventHandler(this.click_privado);
            // 
            // textBoxp_nome
            // 
            this.textBoxp_nome.Location = new System.Drawing.Point(88, 21);
            this.textBoxp_nome.Name = "textBoxp_nome";
            this.textBoxp_nome.Size = new System.Drawing.Size(100, 20);
            this.textBoxp_nome.TabIndex = 1;
            // 
            // textBoxp_pass
            // 
            this.textBoxp_pass.Location = new System.Drawing.Point(88, 75);
            this.textBoxp_pass.Name = "textBoxp_pass";
            this.textBoxp_pass.PasswordChar = '*';
            this.textBoxp_pass.Size = new System.Drawing.Size(100, 20);
            this.textBoxp_pass.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nome :";
            // 
            // textBoxp_login
            // 
            this.textBoxp_login.Location = new System.Drawing.Point(88, 47);
            this.textBoxp_login.Name = "textBoxp_login";
            this.textBoxp_login.Size = new System.Drawing.Size(100, 20);
            this.textBoxp_login.TabIndex = 2;
            // 
            // textBoxp_chave
            // 
            this.textBoxp_chave.Location = new System.Drawing.Point(88, 109);
            this.textBoxp_chave.Name = "textBoxp_chave";
            this.textBoxp_chave.Size = new System.Drawing.Size(100, 20);
            this.textBoxp_chave.TabIndex = 6;
            // 
            // button_chave
            // 
            this.button_chave.Location = new System.Drawing.Point(24, 107);
            this.button_chave.Name = "button_chave";
            this.button_chave.Size = new System.Drawing.Size(56, 23);
            this.button_chave.TabIndex = 5;
            this.button_chave.Text = "Chave";
            this.button_chave.UseVisualStyleBackColor = true;
            this.button_chave.Click += new System.EventHandler(this.button_chave_Click);
            // 
            // cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 196);
            this.Controls.Add(this.button_chave);
            this.Controls.Add(this.textBoxp_chave);
            this.Controls.Add(this.textBoxp_login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxp_pass);
            this.Controls.Add(this.textBoxp_nome);
            this.Controls.Add(this.button_privado);
            this.Controls.Add(this.label2_privado);
            this.Controls.Add(this.label1_privado);
            this.KeyPreview = true;
            this.Name = "cadastro";
            this.Text = "Sistema de Cadastro";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.click_privado);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1_privado;
        private System.Windows.Forms.Label label2_privado;
        private System.Windows.Forms.Button button_privado;
        private System.Windows.Forms.TextBox textBoxp_nome;
        private System.Windows.Forms.TextBox textBoxp_pass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxp_login;
        private System.Windows.Forms.TextBox textBoxp_chave;
        private System.Windows.Forms.Button button_chave;
        private System.Windows.Forms.OpenFileDialog anexar;

    }
}

