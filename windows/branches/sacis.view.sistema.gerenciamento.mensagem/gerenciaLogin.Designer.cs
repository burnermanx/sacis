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
            this.buttonCliente = new System.Windows.Forms.Button();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
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
            // buttonCliente
            // 
            this.buttonCliente.Location = new System.Drawing.Point(87, 127);
            this.buttonCliente.Name = "buttonCliente";
            this.buttonCliente.Size = new System.Drawing.Size(75, 23);
            this.buttonCliente.TabIndex = 3;
            this.buttonCliente.Text = "Ok";
            this.buttonCliente.UseVisualStyleBackColor = true;
            this.buttonCliente.Click += new System.EventHandler(this.clickCliente);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(89, 41);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(100, 20);
            this.textBoxNome.TabIndex = 1;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(90, 77);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(100, 20);
            this.textBoxPass.TabIndex = 2;
            // 
            // gerenciaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 188);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.buttonCliente);
            this.Controls.Add(this.label2_cliente);
            this.Controls.Add(this.label1_cliente);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "gerenciaLogin";
            this.Text = "Sistema Gerenciamento - Login";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clickCliente);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1_cliente;
        private System.Windows.Forms.Label label2_cliente;
        private System.Windows.Forms.Button buttonCliente;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxPass;
        
    }
}

