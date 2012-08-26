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
            this.paraLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.novoAnarq = new System.Windows.Forms.Label();
            this.novoPara = new System.Windows.Forms.TextBox();
            this.novoAssunto = new System.Windows.Forms.TextBox();
            this.novoCripto = new System.Windows.Forms.CheckBox();
            this.novoAssina = new System.Windows.Forms.CheckBox();
            this.novoEnviar = new System.Windows.Forms.Button();
            this.novoDescartar = new System.Windows.Forms.Button();
            this.novoTexto = new System.Windows.Forms.TextBox();
            this.nomeAnexos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // paraLabel
            // 
            this.paraLabel.AutoSize = true;
            this.paraLabel.Image = ((System.Drawing.Image)(resources.GetObject("paraLabel.Image")));
            this.paraLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paraLabel.Location = new System.Drawing.Point(7, 14);
            this.paraLabel.MinimumSize = new System.Drawing.Size(2, 20);
            this.paraLabel.Name = "paraLabel";
            this.paraLabel.Size = new System.Drawing.Size(61, 20);
            this.paraLabel.TabIndex = 0;
            this.paraLabel.Text = "      Para:";
            this.paraLabel.MouseLeave += new System.EventHandler(this.paraOut);
            this.paraLabel.Click += new System.EventHandler(this.paraLabelClick);
            this.paraLabel.MouseHover += new System.EventHandler(this.paraOver);
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
            // novoAnarq
            // 
            this.novoAnarq.AutoSize = true;
            this.novoAnarq.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.novoAnarq.Image = ((System.Drawing.Image)(resources.GetObject("novoAnarq.Image")));
            this.novoAnarq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.novoAnarq.Location = new System.Drawing.Point(6, 68);
            this.novoAnarq.MinimumSize = new System.Drawing.Size(2, 20);
            this.novoAnarq.Name = "novoAnarq";
            this.novoAnarq.Size = new System.Drawing.Size(62, 20);
            this.novoAnarq.TabIndex = 3;
            this.novoAnarq.Text = "   Anexar:";
            this.novoAnarq.MouseLeave += new System.EventHandler(this.anexarOut);
            this.novoAnarq.Click += new System.EventHandler(this.anexarClick);
            this.novoAnarq.MouseHover += new System.EventHandler(this.anexarOver);
            // 
            // novoPara
            // 
            this.novoPara.AllowDrop = true;
            this.novoPara.Location = new System.Drawing.Point(74, 14);
            this.novoPara.MaximumSize = new System.Drawing.Size(401, 4);
            this.novoPara.MinimumSize = new System.Drawing.Size(4, 20);
            this.novoPara.Name = "novoPara";
            this.novoPara.Size = new System.Drawing.Size(401, 20);
            this.novoPara.TabIndex = 1;
            // 
            // novoAssunto
            // 
            this.novoAssunto.Location = new System.Drawing.Point(74, 40);
            this.novoAssunto.MaximumSize = new System.Drawing.Size(401, 4);
            this.novoAssunto.MinimumSize = new System.Drawing.Size(4, 20);
            this.novoAssunto.Multiline = true;
            this.novoAssunto.Name = "novoAssunto";
            this.novoAssunto.Size = new System.Drawing.Size(401, 20);
            this.novoAssunto.TabIndex = 2;
            // 
            // novoCripto
            // 
            this.novoCripto.AutoSize = true;
            this.novoCripto.Location = new System.Drawing.Point(103, 104);
            this.novoCripto.Name = "novoCripto";
            this.novoCripto.Size = new System.Drawing.Size(156, 17);
            this.novoCripto.TabIndex = 4;
            this.novoCripto.Text = "Criptografar Mensagem";
            this.novoCripto.UseVisualStyleBackColor = true;
            // 
            // novoAssina
            // 
            this.novoAssina.AutoSize = true;
            this.novoAssina.Location = new System.Drawing.Point(270, 105);
            this.novoAssina.Name = "novoAssina";
            this.novoAssina.Size = new System.Drawing.Size(131, 17);
            this.novoAssina.TabIndex = 5;
            this.novoAssina.Text = "Assinar Mensagem";
            this.novoAssina.UseVisualStyleBackColor = true;
            // 
            // novoEnviar
            // 
            this.novoEnviar.Location = new System.Drawing.Point(161, 308);
            this.novoEnviar.Name = "novoEnviar";
            this.novoEnviar.Size = new System.Drawing.Size(75, 23);
            this.novoEnviar.TabIndex = 7;
            this.novoEnviar.Text = "&Enviar";
            this.novoEnviar.UseVisualStyleBackColor = true;
            this.novoEnviar.Click += new System.EventHandler(this.novoEnviarClick);
            // 
            // novoDescartar
            // 
            this.novoDescartar.Location = new System.Drawing.Point(247, 308);
            this.novoDescartar.Name = "novoDescartar";
            this.novoDescartar.Size = new System.Drawing.Size(75, 23);
            this.novoDescartar.TabIndex = 8;
            this.novoDescartar.Text = "&Descartar";
            this.novoDescartar.UseVisualStyleBackColor = true;
            this.novoDescartar.Click += new System.EventHandler(this.fecharClick);
            // 
            // novoTexto
            // 
            this.novoTexto.Location = new System.Drawing.Point(14, 133);
            this.novoTexto.Multiline = true;
            this.novoTexto.Name = "novoTexto";
            this.novoTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.novoTexto.Size = new System.Drawing.Size(461, 168);
            this.novoTexto.TabIndex = 6;
            // 
            // nomeAnexos
            // 
            this.nomeAnexos.Location = new System.Drawing.Point(78, 71);
            this.nomeAnexos.Name = "nomeAnexos";
            this.nomeAnexos.ReadOnly = true;
            this.nomeAnexos.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.nomeAnexos.Size = new System.Drawing.Size(396, 20);
            this.nomeAnexos.TabIndex = 9;
            // 
            // novaMensagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 343);
            this.Controls.Add(this.nomeAnexos);
            this.Controls.Add(this.novoDescartar);
            this.Controls.Add(this.novoEnviar);
            this.Controls.Add(this.novoAssina);
            this.Controls.Add(this.novoCripto);
            this.Controls.Add(this.novoAssunto);
            this.Controls.Add(this.novoPara);
            this.Controls.Add(this.novoTexto);
            this.Controls.Add(this.novoAnarq);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.paraLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeBox = false;
            this.Name = "novaMensagem";
            this.Text = "Nova Mensagem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label paraLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label novoAnarq;
        private System.Windows.Forms.TextBox novoPara;
        private System.Windows.Forms.TextBox novoAssunto;
        private System.Windows.Forms.CheckBox novoCripto;
        private System.Windows.Forms.CheckBox novoAssina;
        private System.Windows.Forms.Button novoEnviar;
        private System.Windows.Forms.Button novoDescartar;
        private System.Windows.Forms.TextBox novoTexto;
        private System.Windows.Forms.TextBox nomeAnexos;

    }
}