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
            this.abaCadastrarUsuario = new System.Windows.Forms.TabPage();
            this.cadastrarPermissaoComboBox = new System.Windows.Forms.ComboBox();
            this.cadastrarCertificadoButton = new System.Windows.Forms.Button();
            this.cadastrarCertificadoTextBox = new System.Windows.Forms.TextBox();
            this.cadastrarLoginTextBox = new System.Windows.Forms.TextBox();
            this.cadastrarNomeTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.abaAlterarUsuario = new System.Windows.Forms.TabPage();
            this.alterarCertificadoButton = new System.Windows.Forms.Button();
            this.alterarPermissaoCheckBox = new System.Windows.Forms.CheckBox();
            this.alterarCertificadoCheckBox = new System.Windows.Forms.CheckBox();
            this.alterarNomeCheckBox = new System.Windows.Forms.CheckBox();
            this.resetarSenhaCheckBox = new System.Windows.Forms.CheckBox();
            this.alterarPermissaoComboBox = new System.Windows.Forms.ComboBox();
            this.alterarCertificadoTextBox = new System.Windows.Forms.TextBox();
            this.alterarNomeTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.alterarLoginTextBox = new System.Windows.Forms.TextBox();
            this.abaExcluirUsuario = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.excluirLoginTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.sairButton = new System.Windows.Forms.Button();
            this.anexar = new System.Windows.Forms.OpenFileDialog();
            this.abasManutencao.SuspendLayout();
            this.abaCadastrarUsuario.SuspendLayout();
            this.abaAlterarUsuario.SuspendLayout();
            this.abaExcluirUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // abasManutencao
            // 
            this.abasManutencao.Controls.Add(this.abaCadastrarUsuario);
            this.abasManutencao.Controls.Add(this.abaAlterarUsuario);
            this.abasManutencao.Controls.Add(this.abaExcluirUsuario);
            this.abasManutencao.Location = new System.Drawing.Point(2, 5);
            this.abasManutencao.Name = "abasManutencao";
            this.abasManutencao.SelectedIndex = 0;
            this.abasManutencao.Size = new System.Drawing.Size(365, 227);
            this.abasManutencao.TabIndex = 0;
            // 
            // abaCadastrarUsuario
            // 
            this.abaCadastrarUsuario.BackColor = System.Drawing.Color.Transparent;
            this.abaCadastrarUsuario.Controls.Add(this.cadastrarPermissaoComboBox);
            this.abaCadastrarUsuario.Controls.Add(this.cadastrarCertificadoButton);
            this.abaCadastrarUsuario.Controls.Add(this.cadastrarCertificadoTextBox);
            this.abaCadastrarUsuario.Controls.Add(this.cadastrarLoginTextBox);
            this.abaCadastrarUsuario.Controls.Add(this.cadastrarNomeTextBox);
            this.abaCadastrarUsuario.Controls.Add(this.label4);
            this.abaCadastrarUsuario.Controls.Add(this.label3);
            this.abaCadastrarUsuario.Controls.Add(this.label2);
            this.abaCadastrarUsuario.Controls.Add(this.label1);
            this.abaCadastrarUsuario.Location = new System.Drawing.Point(4, 22);
            this.abaCadastrarUsuario.Name = "abaCadastrarUsuario";
            this.abaCadastrarUsuario.Padding = new System.Windows.Forms.Padding(3);
            this.abaCadastrarUsuario.Size = new System.Drawing.Size(357, 201);
            this.abaCadastrarUsuario.TabIndex = 0;
            this.abaCadastrarUsuario.Text = "Cadastrar Usuário";
            // 
            // cadastrarPermissaoComboBox
            // 
            this.cadastrarPermissaoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cadastrarPermissaoComboBox.FormattingEnabled = true;
            this.cadastrarPermissaoComboBox.Items.AddRange(new object[] {
            "Administrador",
            "Usuário"});
            this.cadastrarPermissaoComboBox.Location = new System.Drawing.Point(133, 151);
            this.cadastrarPermissaoComboBox.Name = "cadastrarPermissaoComboBox";
            this.cadastrarPermissaoComboBox.Size = new System.Drawing.Size(113, 21);
            this.cadastrarPermissaoComboBox.TabIndex = 4;
            // 
            // cadastrarCertificadoButton
            // 
            this.cadastrarCertificadoButton.Location = new System.Drawing.Point(250, 112);
            this.cadastrarCertificadoButton.Name = "cadastrarCertificadoButton";
            this.cadastrarCertificadoButton.Size = new System.Drawing.Size(27, 20);
            this.cadastrarCertificadoButton.TabIndex = 3;
            this.cadastrarCertificadoButton.Text = "...";
            this.cadastrarCertificadoButton.UseVisualStyleBackColor = true;
            this.cadastrarCertificadoButton.Click += new System.EventHandler(this.cadastrarCertificadoButtonClick);
            // 
            // cadastrarCertificadoTextBox
            // 
            this.cadastrarCertificadoTextBox.Location = new System.Drawing.Point(133, 110);
            this.cadastrarCertificadoTextBox.Name = "cadastrarCertificadoTextBox";
            this.cadastrarCertificadoTextBox.Size = new System.Drawing.Size(111, 20);
            this.cadastrarCertificadoTextBox.TabIndex = 2;
            // 
            // cadastrarLoginTextBox
            // 
            this.cadastrarLoginTextBox.Location = new System.Drawing.Point(133, 68);
            this.cadastrarLoginTextBox.Name = "cadastrarLoginTextBox";
            this.cadastrarLoginTextBox.Size = new System.Drawing.Size(111, 20);
            this.cadastrarLoginTextBox.TabIndex = 1;
            // 
            // cadastrarNomeTextBox
            // 
            this.cadastrarNomeTextBox.Location = new System.Drawing.Point(133, 28);
            this.cadastrarNomeTextBox.Name = "cadastrarNomeTextBox";
            this.cadastrarNomeTextBox.Size = new System.Drawing.Size(111, 20);
            this.cadastrarNomeTextBox.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Permissão:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Certificado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Login:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nome:";
            // 
            // abaAlterarUsuario
            // 
            this.abaAlterarUsuario.BackColor = System.Drawing.Color.Transparent;
            this.abaAlterarUsuario.Controls.Add(this.alterarCertificadoButton);
            this.abaAlterarUsuario.Controls.Add(this.alterarPermissaoCheckBox);
            this.abaAlterarUsuario.Controls.Add(this.alterarCertificadoCheckBox);
            this.abaAlterarUsuario.Controls.Add(this.alterarNomeCheckBox);
            this.abaAlterarUsuario.Controls.Add(this.resetarSenhaCheckBox);
            this.abaAlterarUsuario.Controls.Add(this.alterarPermissaoComboBox);
            this.abaAlterarUsuario.Controls.Add(this.alterarCertificadoTextBox);
            this.abaAlterarUsuario.Controls.Add(this.alterarNomeTextBox);
            this.abaAlterarUsuario.Controls.Add(this.label6);
            this.abaAlterarUsuario.Controls.Add(this.alterarLoginTextBox);
            this.abaAlterarUsuario.Location = new System.Drawing.Point(4, 22);
            this.abaAlterarUsuario.Name = "abaAlterarUsuario";
            this.abaAlterarUsuario.Padding = new System.Windows.Forms.Padding(3);
            this.abaAlterarUsuario.Size = new System.Drawing.Size(357, 201);
            this.abaAlterarUsuario.TabIndex = 1;
            this.abaAlterarUsuario.Text = "Alterar Usuário";
            // 
            // alterarCertificadoButton
            // 
            this.alterarCertificadoButton.Location = new System.Drawing.Point(299, 117);
            this.alterarCertificadoButton.Name = "alterarCertificadoButton";
            this.alterarCertificadoButton.Size = new System.Drawing.Size(30, 21);
            this.alterarCertificadoButton.TabIndex = 6;
            this.alterarCertificadoButton.Text = "...";
            this.alterarCertificadoButton.UseVisualStyleBackColor = true;
            this.alterarCertificadoButton.Click += new System.EventHandler(this.alteraCertificadoButtonClick);
            // 
            // alterarPermissaoCheckBox
            // 
            this.alterarPermissaoCheckBox.AutoSize = true;
            this.alterarPermissaoCheckBox.Location = new System.Drawing.Point(65, 150);
            this.alterarPermissaoCheckBox.Name = "alterarPermissaoCheckBox";
            this.alterarPermissaoCheckBox.Size = new System.Drawing.Size(110, 17);
            this.alterarPermissaoCheckBox.TabIndex = 7;
            this.alterarPermissaoCheckBox.Text = "Alterar Permissão:";
            this.alterarPermissaoCheckBox.UseVisualStyleBackColor = true;
            // 
            // alterarCertificadoCheckBox
            // 
            this.alterarCertificadoCheckBox.AutoSize = true;
            this.alterarCertificadoCheckBox.Location = new System.Drawing.Point(65, 117);
            this.alterarCertificadoCheckBox.Name = "alterarCertificadoCheckBox";
            this.alterarCertificadoCheckBox.Size = new System.Drawing.Size(112, 17);
            this.alterarCertificadoCheckBox.TabIndex = 4;
            this.alterarCertificadoCheckBox.Text = "Alterar Certificado:";
            this.alterarCertificadoCheckBox.UseVisualStyleBackColor = true;
            // 
            // alterarNomeCheckBox
            // 
            this.alterarNomeCheckBox.AutoSize = true;
            this.alterarNomeCheckBox.Location = new System.Drawing.Point(65, 83);
            this.alterarNomeCheckBox.Name = "alterarNomeCheckBox";
            this.alterarNomeCheckBox.Size = new System.Drawing.Size(90, 17);
            this.alterarNomeCheckBox.TabIndex = 2;
            this.alterarNomeCheckBox.Text = "Alterar Nome:";
            this.alterarNomeCheckBox.UseVisualStyleBackColor = true;
            // 
            // resetarSenhaCheckBox
            // 
            this.resetarSenhaCheckBox.AutoSize = true;
            this.resetarSenhaCheckBox.Location = new System.Drawing.Point(65, 50);
            this.resetarSenhaCheckBox.Name = "resetarSenhaCheckBox";
            this.resetarSenhaCheckBox.Size = new System.Drawing.Size(90, 17);
            this.resetarSenhaCheckBox.TabIndex = 1;
            this.resetarSenhaCheckBox.Text = "Alterar Senha";
            this.resetarSenhaCheckBox.UseVisualStyleBackColor = true;
            // 
            // alterarPermissaoComboBox
            // 
            this.alterarPermissaoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.alterarPermissaoComboBox.FormattingEnabled = true;
            this.alterarPermissaoComboBox.Items.AddRange(new object[] {
            "Administrador",
            "Usuário"});
            this.alterarPermissaoComboBox.Location = new System.Drawing.Point(180, 148);
            this.alterarPermissaoComboBox.Name = "alterarPermissaoComboBox";
            this.alterarPermissaoComboBox.Size = new System.Drawing.Size(113, 21);
            this.alterarPermissaoComboBox.TabIndex = 8;
            this.alterarPermissaoComboBox.SelectedIndexChanged += new System.EventHandler(this.alteraPermissaoComboBoxSelectedIndexChanged);
            // 
            // alterarCertificadoTextBox
            // 
            this.alterarCertificadoTextBox.Location = new System.Drawing.Point(180, 115);
            this.alterarCertificadoTextBox.Name = "alterarCertificadoTextBox";
            this.alterarCertificadoTextBox.Size = new System.Drawing.Size(113, 20);
            this.alterarCertificadoTextBox.TabIndex = 5;
            this.alterarCertificadoTextBox.TextChanged += new System.EventHandler(this.alteraCertificadoTextBoxChanged);
            // 
            // alterarNomeTextBox
            // 
            this.alterarNomeTextBox.Location = new System.Drawing.Point(180, 82);
            this.alterarNomeTextBox.Name = "alterarNomeTextBox";
            this.alterarNomeTextBox.Size = new System.Drawing.Size(113, 20);
            this.alterarNomeTextBox.TabIndex = 3;
            this.alterarNomeTextBox.TextChanged += new System.EventHandler(this.alterarNomeTextBoxChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Digite o Login do usuario:";
            // 
            // alterarLoginTextBox
            // 
            this.alterarLoginTextBox.Location = new System.Drawing.Point(178, 14);
            this.alterarLoginTextBox.Name = "alterarLoginTextBox";
            this.alterarLoginTextBox.Size = new System.Drawing.Size(115, 20);
            this.alterarLoginTextBox.TabIndex = 0;
            // 
            // abaExcluirUsuario
            // 
            this.abaExcluirUsuario.BackColor = System.Drawing.Color.Transparent;
            this.abaExcluirUsuario.Controls.Add(this.label7);
            this.abaExcluirUsuario.Controls.Add(this.excluirLoginTextBox);
            this.abaExcluirUsuario.Controls.Add(this.label5);
            this.abaExcluirUsuario.Location = new System.Drawing.Point(4, 22);
            this.abaExcluirUsuario.Name = "abaExcluirUsuario";
            this.abaExcluirUsuario.Padding = new System.Windows.Forms.Padding(3);
            this.abaExcluirUsuario.Size = new System.Drawing.Size(357, 201);
            this.abaExcluirUsuario.TabIndex = 3;
            this.abaExcluirUsuario.Text = "Excluir Usuário";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(73, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Digite o Login do Usuário a ser Excluído";
            // 
            // excluirLoginTextBox
            // 
            this.excluirLoginTextBox.Location = new System.Drawing.Point(147, 99);
            this.excluirLoginTextBox.Name = "excluirLoginTextBox";
            this.excluirLoginTextBox.Size = new System.Drawing.Size(100, 20);
            this.excluirLoginTextBox.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Login:";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(84, 238);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButtonClick);
            // 
            // sairButton
            // 
            this.sairButton.Location = new System.Drawing.Point(197, 238);
            this.sairButton.Name = "sairButton";
            this.sairButton.Size = new System.Drawing.Size(75, 23);
            this.sairButton.TabIndex = 2;
            this.sairButton.Text = "Sair";
            this.sairButton.UseVisualStyleBackColor = true;
            this.sairButton.Click += new System.EventHandler(this.sairButtonClick);
            // 
            // manutencao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 267);
            this.Controls.Add(this.sairButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.abasManutencao);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "manutencao";
            this.Text = "S.A.C.I.S. - Sistema de Manutenção de Usuários";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sairButtonClick);
            this.abasManutencao.ResumeLayout(false);
            this.abaCadastrarUsuario.ResumeLayout(false);
            this.abaCadastrarUsuario.PerformLayout();
            this.abaAlterarUsuario.ResumeLayout(false);
            this.abaAlterarUsuario.PerformLayout();
            this.abaExcluirUsuario.ResumeLayout(false);
            this.abaExcluirUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl abasManutencao;
        private System.Windows.Forms.TabPage abaCadastrarUsuario;
        private System.Windows.Forms.TabPage abaAlterarUsuario;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button sairButton;
        private System.Windows.Forms.TabPage abaExcluirUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cadastrarPermissaoComboBox;
        private System.Windows.Forms.Button cadastrarCertificadoButton;
        private System.Windows.Forms.TextBox cadastrarCertificadoTextBox;
        private System.Windows.Forms.TextBox cadastrarLoginTextBox;
        private System.Windows.Forms.TextBox cadastrarNomeTextBox;
        private System.Windows.Forms.OpenFileDialog anexar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox alterarLoginTextBox;
        private System.Windows.Forms.CheckBox alterarNomeCheckBox;
        private System.Windows.Forms.CheckBox resetarSenhaCheckBox;
        private System.Windows.Forms.ComboBox alterarPermissaoComboBox;
        private System.Windows.Forms.TextBox alterarCertificadoTextBox;
        private System.Windows.Forms.TextBox alterarNomeTextBox;
        private System.Windows.Forms.Button alterarCertificadoButton;
        private System.Windows.Forms.CheckBox alterarPermissaoCheckBox;
        private System.Windows.Forms.CheckBox alterarCertificadoCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox excluirLoginTextBox;
        private System.Windows.Forms.Label label5;
    }
}