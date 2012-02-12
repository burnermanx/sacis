namespace inicio
{
    partial class form_inicial
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
            this.label_inicial = new System.Windows.Forms.Label();
            this.button_inicial = new System.Windows.Forms.Button();
            this.comboBox_inicial = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label_inicial
            // 
            this.label_inicial.AutoSize = true;
            this.label_inicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_inicial.Location = new System.Drawing.Point(40, 55);
            this.label_inicial.Name = "label_inicial";
            this.label_inicial.Size = new System.Drawing.Size(175, 13);
            this.label_inicial.TabIndex = 0;
            this.label_inicial.Text = "Selecione a opção de acesso";
            // 
            // button_inicial
            // 
            this.button_inicial.Location = new System.Drawing.Point(78, 142);
            this.button_inicial.Name = "button_inicial";
            this.button_inicial.Size = new System.Drawing.Size(75, 23);
            this.button_inicial.TabIndex = 2;
            this.button_inicial.Text = "Ok";
            this.button_inicial.UseVisualStyleBackColor = true;
            this.button_inicial.Click += new System.EventHandler(this.click_inicial);
            // 
            // comboBox_inicial
            // 
            this.comboBox_inicial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_inicial.FormattingEnabled = true;
            this.comboBox_inicial.Items.AddRange(new object[] {
            "Sistema de Cadastro",
            "Sistema S.A.C.I.S."});
            this.comboBox_inicial.Location = new System.Drawing.Point(59, 91);
            this.comboBox_inicial.Name = "comboBox_inicial";
            this.comboBox_inicial.Size = new System.Drawing.Size(121, 21);
            this.comboBox_inicial.TabIndex = 1;
            // 
            // Form_inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 221);
            this.Controls.Add(this.comboBox_inicial);
            this.Controls.Add(this.button_inicial);
            this.Controls.Add(this.label_inicial);
            this.KeyPreview = true;
            this.Name = "Form_inicial";
            this.Text = "Iniciando o Sistema...";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.click_inicial);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_inicial;
        private System.Windows.Forms.Button button_inicial;
        private System.Windows.Forms.ComboBox comboBox_inicial;
    }
}

