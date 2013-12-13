namespace sacis.view.sistema.gerenciamento.mensagem
{
    partial class abrirMensagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(abrirMensagem));
            this.abreAnexos = new System.Windows.Forms.TextBox();
            this.abreEncaminhar = new System.Windows.Forms.Button();
            this.abreResponder = new System.Windows.Forms.Button();
            this.abreAssunto = new System.Windows.Forms.TextBox();
            this.abreDe = new System.Windows.Forms.TextBox();
            this.abreTexto = new System.Windows.Forms.TextBox();
            this.abreAnex = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.abreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // abreAnexos
            // 
            this.abreAnexos.Location = new System.Drawing.Point(78, 71);
            this.abreAnexos.Name = "abreAnexos";
            this.abreAnexos.ReadOnly = true;
            this.abreAnexos.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.abreAnexos.Size = new System.Drawing.Size(396, 20);
            this.abreAnexos.TabIndex = 9;
            this.abreAnexos.UseWaitCursor = true;
            this.abreAnexos.DoubleClick += new System.EventHandler(this.abreAnexos_DoubleClick);
            // 
            // abreEncaminhar
            // 
            this.abreEncaminhar.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.abreEncaminhar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abreEncaminhar.Location = new System.Drawing.Point(251, 294);
            this.abreEncaminhar.Name = "abreEncaminhar";
            this.abreEncaminhar.Size = new System.Drawing.Size(86, 23);
            this.abreEncaminhar.TabIndex = 8;
            this.abreEncaminhar.Text = "&Encaminhar";
            this.abreEncaminhar.UseVisualStyleBackColor = true;
            this.abreEncaminhar.UseWaitCursor = true;
            this.abreEncaminhar.Click += new System.EventHandler(this.abreEncaminhar_Click);
            // 
            // abreResponder
            // 
            this.abreResponder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abreResponder.Location = new System.Drawing.Point(153, 294);
            this.abreResponder.Name = "abreResponder";
            this.abreResponder.Size = new System.Drawing.Size(87, 23);
            this.abreResponder.TabIndex = 7;
            this.abreResponder.Text = "&Responder";
            this.abreResponder.UseVisualStyleBackColor = true;
            this.abreResponder.UseWaitCursor = true;
            this.abreResponder.Click += new System.EventHandler(this.abreResponder_Click);
            // 
            // abreAssunto
            // 
            this.abreAssunto.Location = new System.Drawing.Point(74, 40);
            this.abreAssunto.MaximumSize = new System.Drawing.Size(401, 4);
            this.abreAssunto.MinimumSize = new System.Drawing.Size(4, 20);
            this.abreAssunto.Name = "abreAssunto";
            this.abreAssunto.ReadOnly = true;
            this.abreAssunto.Size = new System.Drawing.Size(401, 20);
            this.abreAssunto.TabIndex = 2;
            this.abreAssunto.UseWaitCursor = true;
            // 
            // abreDe
            // 
            this.abreDe.AllowDrop = true;
            this.abreDe.Location = new System.Drawing.Point(74, 14);
            this.abreDe.MaximumSize = new System.Drawing.Size(401, 4);
            this.abreDe.MinimumSize = new System.Drawing.Size(4, 20);
            this.abreDe.Name = "abreDe";
            this.abreDe.ReadOnly = true;
            this.abreDe.Size = new System.Drawing.Size(401, 20);
            this.abreDe.TabIndex = 1;
            this.abreDe.UseWaitCursor = true;
            // 
            // abreTexto
            // 
            this.abreTexto.Location = new System.Drawing.Point(14, 109);
            this.abreTexto.Multiline = true;
            this.abreTexto.Name = "abreTexto";
            this.abreTexto.ReadOnly = true;
            this.abreTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.abreTexto.Size = new System.Drawing.Size(461, 168);
            this.abreTexto.TabIndex = 6;
            this.abreTexto.UseWaitCursor = true;
            // 
            // abreAnex
            // 
            this.abreAnex.AutoSize = true;
            this.abreAnex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abreAnex.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.abreAnex.Image = ((System.Drawing.Image)(resources.GetObject("abreAnex.Image")));
            this.abreAnex.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.abreAnex.Location = new System.Drawing.Point(6, 68);
            this.abreAnex.MinimumSize = new System.Drawing.Size(2, 20);
            this.abreAnex.Name = "abreAnex";
            this.abreAnex.Size = new System.Drawing.Size(64, 20);
            this.abreAnex.TabIndex = 3;
            this.abreAnex.Text = "   Anexos:";
            this.abreAnex.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 42);
            this.label2.MinimumSize = new System.Drawing.Size(0, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Assunto:";
            this.label2.UseWaitCursor = true;
            // 
            // abreLabel
            // 
            this.abreLabel.AutoSize = true;
            this.abreLabel.CausesValidation = false;
            this.abreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abreLabel.Image = ((System.Drawing.Image)(resources.GetObject("abreLabel.Image")));
            this.abreLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.abreLabel.Location = new System.Drawing.Point(15, 14);
            this.abreLabel.MinimumSize = new System.Drawing.Size(2, 20);
            this.abreLabel.Name = "abreLabel";
            this.abreLabel.Size = new System.Drawing.Size(51, 20);
            this.abreLabel.TabIndex = 0;
            this.abreLabel.Text = "      De:";
            this.abreLabel.UseWaitCursor = true;
            // 
            // abrirMensagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 329);
            this.Controls.Add(this.abreAnexos);
            this.Controls.Add(this.abreEncaminhar);
            this.Controls.Add(this.abreResponder);
            this.Controls.Add(this.abreAssunto);
            this.Controls.Add(this.abreDe);
            this.Controls.Add(this.abreTexto);
            this.Controls.Add(this.abreAnex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.abreLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "abrirMensagem";
            this.Text = "Mensagem";
            this.UseWaitCursor = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox abreAnexos;
        private System.Windows.Forms.Button abreEncaminhar;
        private System.Windows.Forms.Button abreResponder;
        private System.Windows.Forms.TextBox abreAssunto;
        private System.Windows.Forms.TextBox abreDe;
        private System.Windows.Forms.TextBox abreTexto;
        private System.Windows.Forms.Label abreAnex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label abreLabel;



    }
}