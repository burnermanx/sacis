namespace sacis.view.sistema.gerenciamento.mensagem
{
    partial class gerenciaLogin
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
            this.label1_cliente = new System.Windows.Forms.Label();
            this.label2_cliente = new System.Windows.Forms.Label();
            this.button_cliente = new System.Windows.Forms.Button();
            this.textBox_nome = new System.Windows.Forms.TextBox();
            this.textBox_pass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1_cliente
            // 
            this.label1_cliente.Location = new System.Drawing.Point(36, 82);
            this.label1_cliente.Name = "label1_cliente";
            this.label1_cliente.Size = new System.Drawing.Size(45, 23);
            this.label1_cliente.TabIndex = 5;
            this.label1_cliente.Text = "Senha:";
            // 
            // label2_cliente
            // 
            this.label2_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2_cliente.Location = new System.Drawing.Point(40, 42);
            this.label2_cliente.Name = "label2_cliente";
            this.label2_cliente.Size = new System.Drawing.Size(46, 23);
            this.label2_cliente.TabIndex = 4;
            this.label2_cliente.Text = "Login:";
            // 
            // button_cliente
            // 
            this.button_cliente.Location = new System.Drawing.Point(87, 127);
            this.button_cliente.Name = "button_cliente";
            this.button_cliente.Size = new System.Drawing.Size(75, 23);
            this.button_cliente.TabIndex = 3;
            this.button_cliente.Text = "Ok";
            this.button_cliente.UseVisualStyleBackColor = true;
            this.button_cliente.Click += new System.EventHandler(this.click_cliente);
            // 
            // textBox_nome
            // 
            this.textBox_nome.Location = new System.Drawing.Point(89, 41);
            this.textBox_nome.Name = "textBox_nome";
            this.textBox_nome.Size = new System.Drawing.Size(100, 20);
            this.textBox_nome.TabIndex = 1;
            // 
            // textBox_pass
            // 
            this.textBox_pass.Location = new System.Drawing.Point(90, 77);
            this.textBox_pass.Name = "textBox_pass";
            this.textBox_pass.PasswordChar = '*';
            this.textBox_pass.Size = new System.Drawing.Size(100, 20);
            this.textBox_pass.TabIndex = 2;
            // 
            // gerenciaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 188);
            this.Controls.Add(this.textBox_pass);
            this.Controls.Add(this.textBox_nome);
            this.Controls.Add(this.button_cliente);
            this.Controls.Add(this.label2_cliente);
            this.Controls.Add(this.label1_cliente);
            this.KeyPreview = true;
            this.Name = "gerenciaLogin";
            this.Text = "Login Gerenciamento";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.click_cliente);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1_cliente;
        private System.Windows.Forms.Label label2_cliente;
        private System.Windows.Forms.Button button_cliente;
        private System.Windows.Forms.TextBox textBox_nome;
        private System.Windows.Forms.TextBox textBox_pass;
        
    }
}

