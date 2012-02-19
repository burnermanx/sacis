namespace sacis.view.sistema.gerenciamento.mensagem
{
    partial class novaMensagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(novaMensagem));
            this.para_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.novo_anarq = new System.Windows.Forms.Label();
            this.novo_para = new System.Windows.Forms.TextBox();
            this.novo_assunto = new System.Windows.Forms.TextBox();
            this.novo_cripto = new System.Windows.Forms.CheckBox();
            this.novo_assina = new System.Windows.Forms.CheckBox();
            this.novo_enviar = new System.Windows.Forms.Button();
            this.novo_descartar = new System.Windows.Forms.Button();
            this.novo_texto = new System.Windows.Forms.TextBox();
            this.nome_anexos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // para_label
            // 
            this.para_label.AutoSize = true;
            this.para_label.Image = ((System.Drawing.Image)(resources.GetObject("para_label.Image")));
            this.para_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.para_label.Location = new System.Drawing.Point(7, 14);
            this.para_label.MinimumSize = new System.Drawing.Size(2, 20);
            this.para_label.Name = "para_label";
            this.para_label.Size = new System.Drawing.Size(61, 20);
            this.para_label.TabIndex = 0;
            this.para_label.Text = "      Para:";
            this.para_label.MouseLeave += new System.EventHandler(this.para_out);
            this.para_label.MouseHover += new System.EventHandler(this.para_over);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 42);
            this.label2.MinimumSize = new System.Drawing.Size(0, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Assunto:";
            // 
            // novo_anarq
            // 
            this.novo_anarq.AutoSize = true;
            this.novo_anarq.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.novo_anarq.Image = ((System.Drawing.Image)(resources.GetObject("novo_anarq.Image")));
            this.novo_anarq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.novo_anarq.Location = new System.Drawing.Point(6, 68);
            this.novo_anarq.MinimumSize = new System.Drawing.Size(2, 20);
            this.novo_anarq.Name = "novo_anarq";
            this.novo_anarq.Size = new System.Drawing.Size(62, 20);
            this.novo_anarq.TabIndex = 3;
            this.novo_anarq.Text = "   Anexar:";
            this.novo_anarq.MouseLeave += new System.EventHandler(this.anexar_out);
            this.novo_anarq.Click += new System.EventHandler(this.anexar_Click);
            this.novo_anarq.MouseHover += new System.EventHandler(this.anexar_over);
            // 
            // novo_para
            // 
            this.novo_para.AllowDrop = true;
            this.novo_para.Location = new System.Drawing.Point(74, 14);
            this.novo_para.MaximumSize = new System.Drawing.Size(401, 4);
            this.novo_para.MinimumSize = new System.Drawing.Size(4, 20);
            this.novo_para.Name = "novo_para";
            this.novo_para.Size = new System.Drawing.Size(401, 20);
            this.novo_para.TabIndex = 1;
            // 
            // novo_assunto
            // 
            this.novo_assunto.Location = new System.Drawing.Point(74, 40);
            this.novo_assunto.MaximumSize = new System.Drawing.Size(401, 4);
            this.novo_assunto.MinimumSize = new System.Drawing.Size(4, 20);
            this.novo_assunto.Multiline = true;
            this.novo_assunto.Name = "novo_assunto";
            this.novo_assunto.Size = new System.Drawing.Size(401, 20);
            this.novo_assunto.TabIndex = 2;
            // 
            // novo_cripto
            // 
            this.novo_cripto.AutoSize = true;
            this.novo_cripto.Location = new System.Drawing.Point(103, 104);
            this.novo_cripto.Name = "novo_cripto";
            this.novo_cripto.Size = new System.Drawing.Size(156, 17);
            this.novo_cripto.TabIndex = 4;
            this.novo_cripto.Text = "Criptografar Mensagem";
            this.novo_cripto.UseVisualStyleBackColor = true;
            // 
            // novo_assina
            // 
            this.novo_assina.AutoSize = true;
            this.novo_assina.Location = new System.Drawing.Point(270, 105);
            this.novo_assina.Name = "novo_assina";
            this.novo_assina.Size = new System.Drawing.Size(131, 17);
            this.novo_assina.TabIndex = 5;
            this.novo_assina.Text = "Assinar Mensagem";
            this.novo_assina.UseVisualStyleBackColor = true;
            // 
            // novo_enviar
            // 
            this.novo_enviar.Location = new System.Drawing.Point(161, 308);
            this.novo_enviar.Name = "novo_enviar";
            this.novo_enviar.Size = new System.Drawing.Size(75, 23);
            this.novo_enviar.TabIndex = 7;
            this.novo_enviar.Text = "&Enviar";
            this.novo_enviar.UseVisualStyleBackColor = true;
            this.novo_enviar.Click += new System.EventHandler(this.novo_enviar_Click);
            // 
            // novo_descartar
            // 
            this.novo_descartar.Location = new System.Drawing.Point(247, 308);
            this.novo_descartar.Name = "novo_descartar";
            this.novo_descartar.Size = new System.Drawing.Size(75, 23);
            this.novo_descartar.TabIndex = 8;
            this.novo_descartar.Text = "&Descartar";
            this.novo_descartar.UseVisualStyleBackColor = true;
            this.novo_descartar.Click += new System.EventHandler(this.fechar_Click);
            // 
            // novo_texto
            // 
            this.novo_texto.Location = new System.Drawing.Point(14, 133);
            this.novo_texto.Multiline = true;
            this.novo_texto.Name = "novo_texto";
            this.novo_texto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.novo_texto.Size = new System.Drawing.Size(461, 168);
            this.novo_texto.TabIndex = 6;
            // 
            // nome_anexos
            // 
            this.nome_anexos.Location = new System.Drawing.Point(78, 71);
            this.nome_anexos.Name = "nome_anexos";
            this.nome_anexos.ReadOnly = true;
            this.nome_anexos.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.nome_anexos.Size = new System.Drawing.Size(396, 20);
            this.nome_anexos.TabIndex = 9;
            // 
            // novaMensagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 343);
            this.Controls.Add(this.nome_anexos);
            this.Controls.Add(this.novo_descartar);
            this.Controls.Add(this.novo_enviar);
            this.Controls.Add(this.novo_assina);
            this.Controls.Add(this.novo_cripto);
            this.Controls.Add(this.novo_assunto);
            this.Controls.Add(this.novo_para);
            this.Controls.Add(this.novo_texto);
            this.Controls.Add(this.novo_anarq);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.para_label);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBox = false;
            this.Name = "novaMensagem";
            this.Text = "Nova Mensagem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label para_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label novo_anarq;
        private System.Windows.Forms.TextBox novo_para;
        private System.Windows.Forms.TextBox novo_assunto;
        private System.Windows.Forms.CheckBox novo_cripto;
        private System.Windows.Forms.CheckBox novo_assina;
        private System.Windows.Forms.Button novo_enviar;
        private System.Windows.Forms.Button novo_descartar;
        private System.Windows.Forms.TextBox novo_texto;
        private System.Windows.Forms.TextBox nome_anexos;

    }
}