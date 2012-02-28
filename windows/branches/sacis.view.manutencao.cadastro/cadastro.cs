/*
 * Formulário contendo a interface que o administrador irá utilizar,
 * _para cadastrar o usuário do sistema.
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
using sacis.view.control;
using sacis.model.entidades;
using sacis.model.excecao;
using sacis.model.utilitarios;

namespace sacis.view.manutencao.cadastro
{
    public partial class cadastro : Form
    {

        private static string MSG_ERRO = "Erro de Cadastro!";
        private static string MSG_CADASTRO = "Usuário Cadastrado!";
        private static string MSG_CADASTRO_EXISTENTE = "Usuário Já Existe!";
        private static string MSG_AVISO = "Aviso de Cadastro!";

        /**
        *
        * Metodo _para inicializar os componentes do formularios
        *
        */        
        public cadastro()
        {
            InitializeComponent();
        }

        /**
        *
        * Método _para receber os dados do formulário através do clique no botao OK
        * e chamar o metodo privado
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base _para classes que contém dados _de evento
        *
        */
        private void click_privado (object sender, EventArgs e) {

            privado();
        
        }

        /**
        *
        * Método _para receber os dados do formulário através do teclado
        * e chamar o metodo privado
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base contendo a tecla acionada no evento.
        *
        */
        private void click_privado(object sender, KeyEventArgs e) {
            
            if (e.KeyCode == Keys.Enter){

                privado();

            } else if (e.KeyCode == Keys.Escape) this.Close();
            
        }

        /**
        *
        * Metodo _para criar o objeto usuario e chamar o servlet _para cadastro
        * 
        * @throw excecao
        *
        */ 
        private void privado() {

            try
            {

                usuario user = new usuario(textBoxp_nome.Text, textBoxp_pass.Text, textBoxp_login.Text, textBoxp_chave.Text);

                if (cadastroServlet.antescadastro(user))
                {

                    MessageBox.Show(MSG_CADASTRO, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpa_campos();

                }
                else
                {

                    MessageBox.Show(MSG_CADASTRO_EXISTENTE, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        * Método _para chamar o metodo busca_chave através do clique do botão OK
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base _para classes que contém dados _de evento
        *
        */
        private void button_chave_Click(object sender, EventArgs e)
        {

            busca_chave();
        }

        /**
        *
        * Método _para chamar o metodo busca_chave através do teclado
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base contendo a tecla acionada no evento.
        *
        */
        private void button_chave_Click(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                busca_chave();

            }
            else if (e.KeyCode == Keys.Escape) this.Close();
        }

        /**
        *
        * Método _para visualizar os arquivos e imprimir o nome do arquivo
        * no campo textBoxp_chave
        *
        */
        private void busca_chave() {

            if (anexar.ShowDialog() == DialogResult.OK)
            {

                foreach (String file in anexar.FileNames)
                {

                    textBoxp_chave.Text += file;

                }
            }
        
        }
        
        /**
        *
        * Método _para limpar os campos do formulário
        *
        */
        private void limpa_campos()
        {

            this.textBoxp_pass.Clear();
            this.textBoxp_nome.Clear();
            this.textBoxp_login.Clear();
            this.textBoxp_chave.Clear();

        }
  
    }
}
