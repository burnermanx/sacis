///<summary>
/// Implementação do formulario de login
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


namespace sacis.view.sistema.gerenciamento.mensagem
{
    public partial class gerenciaLogin : Form
    {

        private static string MSG_ACESSO_NEGADO = "Acesso Negado! Login ou Senha não existe!";
        private static string MSG_CHAVE_EXPIRADA = "Acesso Negado! Chave Certificada Expirada!";
        private static string MSG_ERRO = "Erro!";
        private static string MSG_AVISO = "Aviso!";
        private static string MSG_ALTERACAO = "Senha expirada! É necessária sua alteração para acessar novamente o sistema.";
        private static string MSG_FALTA = "Faltam ";
        private static string MSG_EXPIRA = " dias para seu Certificado expirar! Entre em contato com o Administrador e efetue a troca de seu Certificado o mais breve possível.";

        ///<summary>
        ///
        /// Metodo para inicializar os componentes do formularios
        ///
        ///</summary>
        public gerenciaLogin()
        {
            InitializeComponent();
        }

        ///<summary>
        /// 
        /// Método para chamar o metodo login atraves do click no botao de OK
        /// 
        ///</summary>
        private void clickCliente(object sender, EventArgs e)
        {

            login();

        }
        
        ///<summary>
        /// 
        /// Método para chamar o metodo login atraves do teclado
        /// 
        ///</summary>
        private void clickCliente(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                login();

            }
            else if (e.KeyCode == Keys.Escape) this.Close();

        }

        ///<summary>
        /// 
        /// Método para chamar formulário de gerenciamento de mensagens
        /// 
        ///</summary>
        private void login() {

            try
            {
                string name = textBoxNome.Text;
                string pass = textBoxPass.Text;

                string hash = gerenciaServlet.geraHash(pass);
                
                int indice = gerenciaServlet.consultaUsuario(name, hash);

                if (indice >= 100 && indice <= 130) 
                {
                    MessageBox.Show(MSG_FALTA + indice + MSG_EXPIRA, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    indice = 0;
                }

                if (indice == 1)
                {
                    MessageBox.Show(MSG_ALTERACAO, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    gerenciaSenha newForm = new gerenciaSenha(name);
                    newForm.FormClosed += new FormClosedEventHandler(formVisivel);
                    this.Visible = false;
                    newForm.ShowDialog();
                }
                else if (indice == 2)
                {
                    MessageBox.Show(MSG_CHAVE_EXPIRADA, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpaCampos();
                }
                else if (indice == 0)
                {
                    gerenciaServlet.atualizaUsuarioLogLocal(name, hash);

                    gerenciaMensagem newForm = new gerenciaMensagem(name);
                    newForm.FormClosed += new FormClosedEventHandler(formVisivel);
                    this.Visible = false;
                    newForm.ShowDialog();
                }
                else if (indice == 3)
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
            this.textBoxNome.Clear();
            this.textBoxPass.Clear();
        }

    }
}
