namespace sacis.view.manutencao.cadastro
{
    partial class manutencaoLogin
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
            this.okManutencao = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginManutencaoTextBox = new System.Windows.Forms.TextBox();
            this.senhaManutencaoTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // okManutencao
            // 
            this.okManutencao.Location = new System.Drawing.Point(80, 146);
            this.okManutencao.Name = "okManutencao";
            this.okManutencao.Size = new System.Drawing.Size(75, 23);
            this.okManutencao.TabIndex = 3;
            this.okManutencao.Text = "Ok";
            this.okManutencao.UseVisualStyleBackColor = true;
            this.okManutencao.Click += new System.EventHandler(this.okManutencaoClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Login:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Senha:";
            // 
            // loginManutencaoTextBox
            // 
            this.loginManutencaoTextBox.Location = new System.Drawing.Point(87, 43);
            this.loginManutencaoTextBox.Name = "loginManutencaoTextBox";
            this.loginManutencaoTextBox.Size = new System.Drawing.Size(100, 20);
            this.loginManutencaoTextBox.TabIndex = 1;
            // 
            // senhaManutencaoTextBox
            // 
            this.senhaManutencaoTextBox.Location = new System.Drawing.Point(89, 87);
            this.senhaManutencaoTextBox.Name = "senhaManutencaoTextBox";
            this.senhaManutencaoTextBox.PasswordChar = '*';
            this.senhaManutencaoTextBox.Size = new System.Drawing.Size(100, 20);
            this.senhaManutencaoTextBox.TabIndex = 2;
            // 
            // manutencaoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 193);
            this.Controls.Add(this.senhaManutencaoTextBox);
            this.Controls.Add(this.loginManutencaoTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okManutencao);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "manutencaoLogin";
            this.Text = "Sistema Manutenção - Login";
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.okManutencaoClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okManutencao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox loginManutencaoTextBox;
        private System.Windows.Forms.TextBox senhaManutencaoTextBox;
    }
}