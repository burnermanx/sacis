///<summary>
/// Implementação do formulário para alterar a senha
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
using sacis.model.excecao;
using sacis.view.control;
using sacis.model.utilitarios;

namespace sacis.view.sistema.gerenciamento.mensagem
{
    public partial class gerenciaSenha : Form
    {
        private static string nome;
        private static string MSG_ALTERACAO = "Senha alterada com Sucesso!";
        private static string MSG_AVISO = "Aviso!";
        private static string MSG_SAIDA = "Deseja Realmente Sair Sem Alterar a Senha?";
        private static string MSG_ERRO = "Erro de Alteração!";
        private static string MSG_ERRO_ALTERACAO = "Erro ao Trocar Senha! Digite Senha Válida.";

        ///<summary>
        ///
        /// Método para inicializar os componentes do formulário
        /// 
        ///</summary>   
        public gerenciaSenha(string login)
        {
            nome = login;
            InitializeComponent();
        }

        ///<summary>
        /// 
        /// Método para chamar o metodo alterasenha atraves do clique no botao ok
        /// 
        ///</summary>
        private void okButtonClick(object sender, EventArgs e)
        {
            alteraSenha();
        }

        ///<summary>
        /// 
        /// Método para chamar o metodo alterasenha atraves do teclado
        /// 
        ///</summary>
        private void okButtonClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                alteraSenha();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                DialogResult result = MessageBox.Show(MSG_SAIDA, MSG_AVISO, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }            
        }

        ///<summary>
        /// 
        /// Método para verificar e chamar metodo para mudar a senha
        /// 
        ///</summary>
        private void alteraSenha() {
           
            try
            {
                string senha = novaSenhaTextBox.Text;
                string confirma = confirmaSenhaTextBox.Text;
                
                if (senha.Equals(confirma) && !verificaCampos.verificaValidadeCampos(senha))
                {
                    gerenciaServlet.alteraSenha(nome, senha);
                    MessageBox.Show(MSG_ALTERACAO, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else {
                    MessageBox.Show(MSG_ERRO_ALTERACAO, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);               
                }

                limpaCampos();  
            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }

        ///<summary>
        /// 
        /// Método para limpar os campos do formulário
        /// 
        ///</summary>
        private void limpaCampos()
        {
            this.novaSenhaTextBox.Clear();
            this.confirmaSenhaTextBox.Clear();
        }
    }
}
