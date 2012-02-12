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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gerenciaLogin));
            this.label1_cliente = new System.Windows.Forms.Label();
            this.label2_cliente = new System.Windows.Forms.Label();
            this.button_cliente = new System.Windows.Forms.Button();
            this.textBox_nome = new System.Windows.Forms.TextBox();
            this.textBox_pass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1_cliente
            // 
            resources.ApplyResources(this.label1_cliente, "label1_cliente");
            this.label1_cliente.Name = "label1_cliente";
            // 
            // label2_cliente
            // 
            resources.ApplyResources(this.label2_cliente, "label2_cliente");
            this.label2_cliente.Name = "label2_cliente";
            // 
            // button_cliente
            // 
            resources.ApplyResources(this.button_cliente, "button_cliente");
            this.button_cliente.Name = "button_cliente";
            this.button_cliente.UseVisualStyleBackColor = true;
            this.button_cliente.Click += new System.EventHandler(this.click_cliente);
            // 
            // textBox_nome
            // 
            resources.ApplyResources(this.textBox_nome, "textBox_nome");
            this.textBox_nome.Name = "textBox_nome";
            // 
            // textBox_pass
            // 
            resources.ApplyResources(this.textBox_pass, "textBox_pass");
            this.textBox_pass.Name = "textBox_pass";
            // 
            // cliente_login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_pass);
            this.Controls.Add(this.textBox_nome);
            this.Controls.Add(this.button_cliente);
            this.Controls.Add(this.label2_cliente);
            this.Controls.Add(this.label1_cliente);
            this.KeyPreview = true;
            this.Name = "cliente_login";
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

