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

namespace sacis.view.sistema.armazenamento
{
    public partial class login : Form
    {

        private static string MSG_ACESSO_NEGADO = "Acesso Negado!";
        private static string MSG_ERRO = "Erro";

        /**
        *
        * Metodo para inicializar os componentes do formularios
        *
        */
        public login()
        {
            InitializeComponent();
        }

        /**
        *
        * Método para chamar formulário para manipular arquivos armazenados pelo usuário 
        * através do clique no botao OK
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
        *
        */
        private void armazena_button_Click(object sender, EventArgs e)
        {

            acessa_armazenamento();

        }

        /**
        *
        * Método para chamar formulário para manipular arquivos armazenados pelo usuário 
        * através do teclado
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
        *
        */
        private void armazena_button_Click(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                acessa_armazenamento();

            }
            else if (e.KeyCode == Keys.Escape) this.Close();

        }

        /**
        *
        * Método para chamar servlet para verificações e formulario de manipulação 
        * de arquivos
        *
        */
        private void acessa_armazenamento() {
                         
            string name = textbox_login.Text;
            string pass = textbox_senha.Text;

            string hashpass = armazenaServlet.geraHash(pass);

            // verifica se campos de nome e senha sao validos e diferentes
            if (armazenaServlet.confirmaUsuario(name, hashpass))
            {

                armazena newForm = new armazena();
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
            textbox_login.Clear();
            textbox_senha.Clear();

        }

        /**
        *
        * Método para limpar os campos do formulário
        *
        */
        private void limpa_campos()
        {

            this.textbox_login.Clear();
            this.textbox_senha.Clear();

        }

    }
}
