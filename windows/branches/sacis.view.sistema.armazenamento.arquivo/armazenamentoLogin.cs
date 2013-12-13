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
using sacis.model.excecao;

namespace sacis.view.sistema.armazenamento
{
    public partial class armazenamentoLogin : Form
    {
        private static string MSG_ACESSO_NEGADO = "Usuário ou Senha Inválido!";
        private static string MSG_ERRO = "Erro";

        ///<summary>
        /// 
        /// Metodo para inicializar os componentes do formulario.
        ///
        ///</summary>
        public armazenamentoLogin()
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

            try
            {
                string name = textboxLogin.Text;
                string pass = textboxSenha.Text;

                string hashpass = armazenaServlet.geraHash(pass);

                if (armazenaServlet.confirmaUsuario(name, hashpass))
                {
                    armazenamento newForm = new armazenamento();
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
            catch (excecao except)
            {                
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            limpaCampos();

        }

        ///<summary>
        ///
        /// Método para limpar os campos do formulário
        /// 
        ///</summary>  
        private void limpaCampos()
        {
            this.textboxLogin.Clear();
            this.textboxSenha.Clear();
        }
    }
}
