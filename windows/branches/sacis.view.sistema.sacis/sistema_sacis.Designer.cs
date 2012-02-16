namespace sacis.view.cliente
{
    partial class sistema_sacis
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
            this.sacis_combo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sacis_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sacis_combo
            // 
            this.sacis_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sacis_combo.FormattingEnabled = true;
            this.sacis_combo.Items.AddRange(new object[] {
            "Armazenamento de Arquivos",
            "Gerenciamento de Mensagens"});
            this.sacis_combo.Location = new System.Drawing.Point(43, 86);
            this.sacis_combo.Name = "sacis_combo";
            this.sacis_combo.Size = new System.Drawing.Size(153, 21);
            this.sacis_combo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selecione o sistema desejado";
            // 
            // sacis_ok
            // 
            this.sacis_ok.Location = new System.Drawing.Point(76, 136);
            this.sacis_ok.Name = "sacis_ok";
            this.sacis_ok.Size = new System.Drawing.Size(75, 23);
            this.sacis_ok.TabIndex = 2;
            this.sacis_ok.Text = "Ok";
            this.sacis_ok.UseVisualStyleBackColor = true;
            this.sacis_ok.Click += new System.EventHandler(this.click_sacis);
            // 
            // sistema_sacis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 219);
            this.Controls.Add(this.sacis_ok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sacis_combo);
            this.KeyPreview = true;
            this.Name = "sistema_sacis";
            this.Text = "Projeto S.A.C.I.S.";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.click_sacis);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox sacis_combo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sacis_ok;

    }
}

