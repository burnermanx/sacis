/*
 * 
 * Implementação do formulario de login
 *
 * @author Fabio Augusto
 * 
 */

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

        private static string MSG_ACESSO_NEGADO = "Acesso Negado!";
        private static string MSG_ERRO = "Erro";

        /**
        *
        * Metodo para inicializar os componentes do formularios
        *
        */
        public gerenciaLogin()
        {
            InitializeComponent();
        }

        /**
        *
        * Método para chamar o metodo login atraves do click no botao de OK
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
        *
        */
        private void click_cliente(object sender, EventArgs e)
        {

            login();

        }

        /**
        *
        * Método para chamar formulário para gerenciar as mensagens atraves do teclado
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base contendo a tecla acionada no evento.
        *
        */
        private void click_cliente(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                login();

            }
            else if (e.KeyCode == Keys.Escape) this.Close();

        }

        /**
        *
        * Método para chamar formulário para gerenciar as mensagens
        *
        */
        private void login() {

            try
            {
                string name = textBox_nome.Text;
                string pass = textBox_pass.Text;

                string hash = gerenciaServlet.geraHash(pass);

                if (gerenciaServlet.consultaUsuario(name, hash))
                {

                    //gerenciaMensagem newForm = new gerenciaMensagem(name);
                    gerenciaMensagem newForm = new gerenciaMensagem();
                    newForm.FormClosed += new FormClosedEventHandler(form_visivel);
                    this.Visible = false;
                    newForm.ShowDialog();

                }
                else
                {

                    MessageBox.Show(MSG_ACESSO_NEGADO, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpa_campos();

                }
            }
            catch (excecao except)
            {

                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpa_campos();

            }           
        
        }

        /**
        *
        * Método para tornar o formulário visivel
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base contendo a tecla acionada no evento.
        *
        */
        private void form_visivel(object sender, FormClosedEventArgs e)
        {

            this.Visible = true;
            textBox_nome.Clear();
            textBox_pass.Clear();

        }

        /**
        *
        * Método para limpar os campos do formulário
        *
        */
        private void limpa_campos()
        {

            this.textBox_nome.Clear();
            this.textBox_pass.Clear();

        }

    }
}
