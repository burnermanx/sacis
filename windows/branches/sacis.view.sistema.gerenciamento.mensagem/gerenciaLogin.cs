﻿///<summary>
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

        private static string MSG_ACESSO_NEGADO = "Acesso Negado!";
        private static string MSG_ERRO = "Erro";

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

                if (gerenciaServlet.consultaUsuario(name, hash))
                {

                    gerenciaServlet.atualizaUsuarioLogLocal(name, hash);

                    gerenciaMensagem newForm = new gerenciaMensagem(name);
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

            this.textBoxNome.Clear();
            this.textBoxPass.Clear();

        }

    }
}
