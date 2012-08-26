///<summary>
/// Formulário contendo a interface que o administrador irá utilizar
/// para cadastrar o usuário do sistema.
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
using sacis.model.entidades;
using sacis.model.excecao;

namespace sacis.view.manutencao.cadastro
{
    public partial class cadastro : Form
    {
        private static string MSG_ERRO = "Erro de Cadastro!";
        private static string MSG_CADASTRO = "Usuário Cadastrado!";
        private static string MSG_CADASTRO_EXISTENTE = "Usuário Já Existe!";
        private static string MSG_AVISO = "Aviso de Cadastro!";

        ///<summary>
        ///
        /// Método para inicializar os componentes do formulários
        /// 
        ///</summary>     
        public cadastro()
        {
            InitializeComponent();
        }

        ///<summary>
        ///
        /// Método para receber os dados do formulário através do clique no botao OK
        /// e chamar o metodo privado
        /// 
        ///</summary>  
        private void clickPrivado (object sender, EventArgs e) 
        {
            privado();        
        }

        ///<summary>
        ///
        /// Método para receber os dados do formulário através do teclado
        /// e chamar o metodo privado
        /// 
        ///</summary>  
        private void clickPrivado(object sender, KeyEventArgs e) 
        {            
            if (e.KeyCode == Keys.Enter)
            {
                privado();
            } 
            else if (e.KeyCode == Keys.Escape) this.Close();            
        }

        ///<summary>
        ///
        /// Metodo para criar o objeto usuario e chamar o servlet para cadastro
        /// 
        ///</summary>  
        private void privado() 
        {
            try
            {
                string data = manutencaoServlet.retornaData(textBoxpChave.Text);
                
                usuario user = new usuario(textBoxpNome.Text, textBoxpPass.Text, textBoxpLogin.Text, textBoxpChave.Text, data, comboBoxpPermissao.SelectedIndex);
                
                if (manutencaoServlet.antesCadastro(user))
                {
                    MessageBox.Show(MSG_CADASTRO, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpaCampos();
                }
                else
                {
                    MessageBox.Show(MSG_CADASTRO_EXISTENTE, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Método para chamar o metodo que busca arquivo através do clique do botão OK
        /// 
        ///</summary>  
        private void buttonChaveClick(object sender, EventArgs e)
        {
            buscaArquivo();
        }

        ///<summary>
        ///
        /// Método para chamar o metodo que busca arquivo através do teclado
        /// 
        ///</summary>  
        private void buttonChaveClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscaArquivo();
            }
            else if (e.KeyCode == Keys.Escape) this.Close();
        }

        ///<summary>
        ///
        /// Método para buscar o arquivo selecionado e exibir seu nome
        /// 
        ///</summary>  
        private void buscaArquivo() 
        {
            if (anexar.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in anexar.FileNames)
                {
                    textBoxpChave.Text += file;
                }
            }        
        }
        
        ///<summary>
        ///
        /// Método para limpar os campos do formulário
        /// 
        ///</summary>  
        private void limpaCampos()
        {
            this.textBoxpPass.Clear();
            this.textBoxpNome.Clear();
            this.textBoxpLogin.Clear();
            this.textBoxpChave.Clear();
        }

    }
}
