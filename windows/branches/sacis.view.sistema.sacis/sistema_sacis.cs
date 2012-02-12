/*
 * Formulário inicial contendo a interface que o usuário irá utilizar,
 * para acessar as funções de armazenamento ou de gerenciamento de mensagens.
 *
 * @author Fabio Augusto
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sacis.view.sistema.gerenciamento.mensagem;
using sacis.view.sistema.armazenamento;

namespace sacis.view.cliente
{
    public partial class sistema_sacis : Form
    {
        /**
        *
        * Metodo para inicializar os componentes do formularios
        *
        */
        public sistema_sacis()
        {
            InitializeComponent();
        }

        /**
        *
        * Método para chamar formulário selecionado pelo usuário através do clique no botao OK
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
        *
        */
        private void click_sacis(object sender, EventArgs e)
        {

            if (sacis_combo.SelectedIndex == 0)
            {
                armazenamento();

            }
            else if (sacis_combo.SelectedIndex == 1)
            {

                gerenciamento();

            }
           
        }

        /**
        *
        * Método para chamar formulário selecionado pelo usuário através do teclado
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base contendo a tecla acionada no evento.
        *
        */
        private void click_sacis(object sender, KeyEventArgs e)
        {

            if (sacis_combo.SelectedIndex == 0 && e.KeyCode == Keys.Enter)
            {

                armazenamento();

            }
            else if (sacis_combo.SelectedIndex == 1 && e.KeyCode == Keys.Enter)
            {

                gerenciamento();

            }
            else if (e.KeyCode == Keys.Escape) this.Close();

        }

        /**
        *
        * Método para chamar formulário de armazenamento
        *
        */
        private void armazenamento()
        {

            login newForm = new login();
            newForm.FormClosed += new FormClosedEventHandler(form_visivel);
            this.Visible = false;
            newForm.ShowDialog();

        }

        /**
        *
        * Método para chamar formulário de login do gerenciamento de mensagens
        *
        */
        private void gerenciamento()
        {

            gerenciaLogin newForm = new gerenciaLogin();
            newForm.FormClosed += new FormClosedEventHandler(form_visivel);
            this.Visible = false;
            newForm.ShowDialog();

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

        }


    }
}
