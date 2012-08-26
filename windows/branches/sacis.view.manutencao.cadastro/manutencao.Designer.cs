namespace sacis.view.manutencao.cadastro
{
    partial class manutencao
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
            this.abasManutencao = new System.Windows.Forms.TabControl();
            this.abaCadastrar = new System.Windows.Forms.TabPage();
            this.abaAlterar = new System.Windows.Forms.TabPage();
            this.abaExcluir = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.abasManutencao.SuspendLayout();
            this.SuspendLayout();
            // 
            // abasManutencao
            // 
            this.abasManutencao.Controls.Add(this.abaCadastrar);
            this.abasManutencao.Controls.Add(this.abaAlterar);
            this.abasManutencao.Controls.Add(this.abaExcluir);
            this.abasManutencao.Location = new System.Drawing.Point(0, 1);
            this.abasManutencao.Name = "abasManutencao";
            this.abasManutencao.SelectedIndex = 0;
            this.abasManutencao.Size = new System.Drawing.Size(340, 227);
            this.abasManutencao.TabIndex = 0;
            // 
            // abaCadastrar
            // 
            this.abaCadastrar.Location = new System.Drawing.Point(4, 22);
            this.abaCadastrar.Name = "abaCadastrar";
            this.abaCadastrar.Padding = new System.Windows.Forms.Padding(3);
            this.abaCadastrar.Size = new System.Drawing.Size(424, 201);
            this.abaCadastrar.TabIndex = 0;
            this.abaCadastrar.Text = "Cadastrar";
            this.abaCadastrar.UseVisualStyleBackColor = true;
            // 
            // abaAlterar
            // 
            this.abaAlterar.Location = new System.Drawing.Point(4, 22);
            this.abaAlterar.Name = "abaAlterar";
            this.abaAlterar.Padding = new System.Windows.Forms.Padding(3);
            this.abaAlterar.Size = new System.Drawing.Size(332, 201);
            this.abaAlterar.TabIndex = 1;
            this.abaAlterar.Text = "Alterar";
            this.abaAlterar.UseVisualStyleBackColor = true;
            // 
            // abaExcluir
            // 
            this.abaExcluir.Location = new System.Drawing.Point(4, 22);
            this.abaExcluir.Name = "abaExcluir";
            this.abaExcluir.Padding = new System.Windows.Forms.Padding(3);
            this.abaExcluir.Size = new System.Drawing.Size(424, 201);
            this.abaExcluir.TabIndex = 2;
            this.abaExcluir.Text = "Excluir";
            this.abaExcluir.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(197, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Sair";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // manutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 262);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.abasManutencao);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "manutencao";
            this.Text = "S.A.C.I.S. - Sistema de Manutenção de Usuários";
            this.abasManutencao.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl abasManutencao;
        private System.Windows.Forms.TabPage abaCadastrar;
        private System.Windows.Forms.TabPage abaAlterar;
        private System.Windows.Forms.TabPage abaExcluir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}