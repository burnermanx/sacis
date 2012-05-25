///<summary>
/// Formulário de login para acessar o sistema de armazenamento de arquivos
/// 
/// @author Fabio Augusto
///</summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sacis.view.control;

namespace sacis.view.sistema.armazenamento
{
    public partial class login : Form
    {
        private static string MSG_ACESSO_NEGADO = "Acesso Negado!";
        private static string MSG_ERRO = "Erro";

        ///<summary>
        /// 
        /// Metodo para inicializar os componentes do formularios.
        ///
        ///</summary>
        public login()
        {
            InitializeComponent();
        }

        ///<summary>
        /// 
        /// Método para chamar acesso ao sistema de armazenamento através do clique no botao OK.
        ///
        ///</summary>
        private void armazenaButtonClick(object sender, EventArgs e)
        {
            acessaArmazenamento();
        }

        ///<summary>
        /// 
        /// Método para chamar acesso ao sistema de armazenamento através do teclado.
        ///
        ///</summary>
        private void armazenaButtonClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                acessaArmazenamento();
            }
            else if (e.KeyCode == Keys.Escape) this.Close();
        }

        ///<summary>
        /// 
        /// Método para acessar formulário de manipulação de arquivos se usuario cadastrado
        ///
        ///</summary>
        private void acessaArmazenamento() {
                         
            string name = textbox_login.Text;
            string pass = textbox_senha.Text;

            string hashpass = armazenaServlet.geraHash(pass);

            if (armazenaServlet.confirmaUsuario(name, hashpass))
            {
                armazena newForm = new armazena();
                newForm.FormClosed += new FormClosedEventHandler(formVisivel);
                this.Visible = false;
                newForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(MSG_ACESSO_NEGADO, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpaCampos();
            }               
        }

        ///<summary>
        ///
        /// Método para tornar o formulário visivel
        ///
        ///</summary>
        private void formVisivel(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
            textbox_login.Clear();
            textbox_senha.Clear();
        }

        ///<summary>
        ///
        /// Método para limpar os campos do formulário
        /// 
        ///</summary>  
        private void limpaCampos()
        {
            this.textbox_login.Clear();
            this.textbox_senha.Clear();
        }
    }
}
