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
            this.textBoxpNome = new System.Windows.Forms.TextBox();
            this.textBoxpPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxpLogin = new System.Windows.Forms.TextBox();
            this.textBoxpChave = new System.Windows.Forms.TextBox();
            this.button_chave = new System.Windows.Forms.Button();
            this.anexar = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxpPermissao = new System.Windows.Forms.ComboBox();
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
            this.button_privado.Location = new System.Drawing.Point(88, 191);
            this.button_privado.Name = "button_privado";
            this.button_privado.Size = new System.Drawing.Size(75, 23);
            this.button_privado.TabIndex = 7;
            this.button_privado.Text = "Ok";
            this.button_privado.UseVisualStyleBackColor = true;
            this.button_privado.Click += new System.EventHandler(this.clickPrivado);
            // 
            // textBoxpNome
            // 
            this.textBoxpNome.Location = new System.Drawing.Point(88, 21);
            this.textBoxpNome.Name = "textBoxpNome";
            this.textBoxpNome.Size = new System.Drawing.Size(100, 20);
            this.textBoxpNome.TabIndex = 1;
            // 
            // textBoxpPass
            // 
            this.textBoxpPass.Location = new System.Drawing.Point(88, 75);
            this.textBoxpPass.Name = "textBoxpPass";
            this.textBoxpPass.PasswordChar = '*';
            this.textBoxpPass.Size = new System.Drawing.Size(100, 20);
            this.textBoxpPass.TabIndex = 3;
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
            // textBoxpLogin
            // 
            this.textBoxpLogin.Location = new System.Drawing.Point(88, 47);
            this.textBoxpLogin.Name = "textBoxpLogin";
            this.textBoxpLogin.Size = new System.Drawing.Size(100, 20);
            this.textBoxpLogin.TabIndex = 2;
            // 
            // textBoxpChave
            // 
            this.textBoxpChave.Location = new System.Drawing.Point(88, 139);
            this.textBoxpChave.Name = "textBoxpChave";
            this.textBoxpChave.Size = new System.Drawing.Size(100, 20);
            this.textBoxpChave.TabIndex = 6;
            // 
            // button_chave
            // 
            this.button_chave.Location = new System.Drawing.Point(12, 136);
            this.button_chave.Name = "button_chave";
            this.button_chave.Size = new System.Drawing.Size(66, 23);
            this.button_chave.TabIndex = 5;
            this.button_chave.Text = "Certificado";
            this.button_chave.UseVisualStyleBackColor = true;
            this.button_chave.Click += new System.EventHandler(this.buttonChaveClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Permissão :";
            // 
            // comboBoxpPermissao
            // 
            this.comboBoxpPermissao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxpPermissao.FormattingEnabled = true;
            this.comboBoxpPermissao.Items.AddRange(new object[] {
            "Administrador",
            "Usuario"});
            this.comboBoxpPermissao.Location = new System.Drawing.Point(88, 107);
            this.comboBoxpPermissao.Name = "comboBoxpPermissao";
            this.comboBoxpPermissao.Size = new System.Drawing.Size(100, 21);
            this.comboBoxpPermissao.TabIndex = 13;
            // 
            // cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 226);
            this.Controls.Add(this.comboBoxpPermissao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_chave);
            this.Controls.Add(this.textBoxpChave);
            this.Controls.Add(this.textBoxpLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxpPass);
            this.Controls.Add(this.textBoxpNome);
            this.Controls.Add(this.button_privado);
            this.Controls.Add(this.label2_privado);
            this.Controls.Add(this.label1_privado);
            this.KeyPreview = true;
            this.Name = "cadastro";
            this.Text = "Sistema de Cadastro";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clickPrivado);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1_privado;
        private System.Windows.Forms.Label label2_privado;
        private System.Windows.Forms.Button button_privado;
        private System.Windows.Forms.TextBox textBoxpNome;
        private System.Windows.Forms.TextBox textBoxpPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxpLogin;
        private System.Windows.Forms.TextBox textBoxpChave;
        private System.Windows.Forms.Button button_chave;
        private System.Windows.Forms.OpenFileDialog anexar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxpPermissao;

    }
}

