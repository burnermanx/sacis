namespace sacis.view.sistema.armazenamento
{
    partial class chave
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
            this.chaveTextBox = new System.Windows.Forms.TextBox();
            this.botaoOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Digite uma frase senha de 32 caracteres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Senha :";
            // 
            // chaveTextBox
            // 
            this.chaveTextBox.Location = new System.Drawing.Point(87, 70);
            this.chaveTextBox.MaxLength = 32;
            this.chaveTextBox.Name = "chaveTextBox";
            this.chaveTextBox.PasswordChar = '*';
            this.chaveTextBox.Size = new System.Drawing.Size(162, 20);
            this.chaveTextBox.TabIndex = 1;
            // 
            // botaoOK
            // 
            this.botaoOK.Location = new System.Drawing.Point(103, 125);
            this.botaoOK.Name = "botaoOK";
            this.botaoOK.Size = new System.Drawing.Size(75, 23);
            this.botaoOK.TabIndex = 3;
            this.botaoOK.Text = "OK";
            this.botaoOK.UseVisualStyleBackColor = true;
            this.botaoOK.Click += new System.EventHandler(this.botaoOKClick);
            // 
            // chave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 178);
            this.Controls.Add(this.botaoOK);
            this.Controls.Add(this.chaveTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "chave";
            this.Text = "S.A.C.I.S. - Digite Frase Senha";
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.botaoOKClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox chaveTextBox;
        private System.Windows.Forms.Button botaoOK;
    }
}