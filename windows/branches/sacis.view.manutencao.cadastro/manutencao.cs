///<summary>
/// Implementação do formulário de manutenção
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
using sacis.model.entidades;
using sacis.view.control;
using sacis.model.excecao;

namespace sacis.view.manutencao.cadastro
{
    public partial class manutencao : Form
    {

        private static string MSG_SAIDA = "Deseja Realmente Sair do Sistema de Manutenção?";
        private static string MSG_AVISO = "Mensagem de Aviso!";
        private static string MSG_ERRO = "Erro de Cadastro!";
        private static string MSG_CADASTRO = "Usuário Cadastrado!";
        private static string MSG_CADASTRO_EXISTENTE = "Usuário Já Existe!";       
        private static string MSG_RESETAR_SENHA = "Senha Resetada com Sucesso!";       
        private static string MSG_ALTERAR_NOME = "Nome Alterado com Sucesso!";
        private static string MSG_ALTERAR_CERTIFICADO = "Certificado Alterado com Sucesso!";
        private static string MSG_ALTERAR_PERMISSAO = "Permissão Alterada com Sucesso!";
        private static string MSG_ALTERAR = "Deseja Realmente Alterar os Dados do Usuário?";
        private static string MSG_ERRO_ALTERAR = "Selecione Pelo Menos Uma Opção";
        private static string MSG_EXCLUIR = "Deseja Realmente Excluir Usuário?";
        private static string MSG_EXCLUIR_SUCESSO = "Usuário Excluido com Sucesso!";

        ///<summary>
        ///
        /// Método para inicializar os componentes do formulários
        /// 
        ///</summary>     
        public manutencao()
        {
            InitializeComponent();
        }
        
        ///<summary>
        ///
        /// Método para selecionar através do botão ok a função a ser executada a partir da 
        /// aba selecionada
        /// 
        ///</summary>     
        private void okButtonClick(object sender, EventArgs e)
        {
            if (abasManutencao.SelectedIndex == 0)
            {
                cadastrarUsuario();
            }
            else if (abasManutencao.SelectedIndex == 1)
            {
                alterarUsuario();                
            }
            else if (abasManutencao.SelectedIndex == 2)
            {
                excluirUsuario();
            }

        }

        ///<summary>
        /// 
        /// Método para chamar metodo sair através do clique no botao sair.
        ///
        ///</summary>
        private void sairButtonClick(object sender, EventArgs e)
        {
            sair();
        }

        ///<summary>
        /// 
        /// Método para chamar metodo cancela através do teclado.
        ///
        ///</summary>
        private void sairButtonClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                sair();
            }
        }

        ///<summary>
        /// 
        /// Método para cancelar a operação de armazenamento.
        ///
        ///</summary>
        private void sair()
        {
            DialogResult result = MessageBox.Show(MSG_SAIDA, MSG_AVISO, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        ///<summary>
        ///
        /// Método para chamar o metodo que busca arquivo na Aba de cadastro através do clique do botão OK
        /// e exibir seu nome
        /// 
        ///</summary>  
        private void cadastrarCertificadoButtonClick(object sender, EventArgs e)
        {
            string caminhoChave = buscaArquivo();
            cadastrarCertificadoTextBox.Text = caminhoChave;
        }

        ///<summary>
        ///
        /// Método para buscar o arquivo
        /// 
        ///</summary>  
        private string buscaArquivo()
        {
            string caminho = null;
            
            if (anexar.ShowDialog() == DialogResult.OK)
            {
                caminho = anexar.FileName;                
            }

            return caminho;
        }

        ///<summary>
        ///
        /// Metodo para criar o objeto usuario e chamar o servlet para cadastro
        /// 
        ///</summary>  
        private void cadastrarUsuario()
        {
            try
            {
                string data = manutencaoServlet.retornaData(cadastrarCertificadoTextBox.Text);

                usuario user = new usuario(cadastrarNomeTextBox.Text, null, cadastrarLoginTextBox.Text, cadastrarCertificadoTextBox.Text, data, cadastrarPermissaoComboBox.SelectedIndex);

                if (manutencaoServlet.antesCadastro(user))
                {
                    MessageBox.Show(MSG_CADASTRO, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
                else
                {
                    MessageBox.Show(MSG_CADASTRO_EXISTENTE, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                }
                
                limpaCamposCadastro();

            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpaCamposCadastro();
            }
        }

        ///<summary>
        ///
        /// Método para limpar os campos da aba Cadastrar Usuario
        /// 
        ///</summary>  
        private void limpaCamposCadastro()
        {
            this.cadastrarNomeTextBox.Clear();
            this.cadastrarLoginTextBox.Clear();
            this.cadastrarCertificadoTextBox.Clear();
            this.cadastrarPermissaoComboBox.SelectedIndex = -1;
        }

        ///<summary>
        ///
        /// Metodo para chamar o servlet para alterar os dados selecionados do usuário
        /// 
        ///</summary>  
        private void alterarUsuario() {
            try
            {
                string login = alterarLoginTextBox.Text;
                string nome = alterarNomeTextBox.Text;
                string certificado = alterarCertificadoTextBox.Text;
                int permissao = alterarPermissaoComboBox.SelectedIndex;
                
                if (!resetarSenhaCheckBox.Checked && !alterarNomeCheckBox.Checked && !alterarCertificadoCheckBox.Checked && !alterarPermissaoCheckBox.Checked)
                {
                    MessageBox.Show(MSG_ERRO_ALTERAR, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                } else {

                    DialogResult result = MessageBox.Show(MSG_ALTERAR, MSG_AVISO, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.OK)                    
                    {
                        if (resetarSenhaCheckBox.Checked && manutencaoServlet.resetar(login))
                        {
                            MessageBox.Show(MSG_RESETAR_SENHA, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        if (alterarNomeCheckBox.Checked && manutencaoServlet.alterarNome(login, nome))
                        {
                            MessageBox.Show(MSG_ALTERAR_NOME, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        if (alterarCertificadoCheckBox.Checked && manutencaoServlet.alterarCertificado(login, certificado, manutencaoServlet.retornaData(alterarCertificadoTextBox.Text)))
                        {
                            MessageBox.Show(MSG_ALTERAR_CERTIFICADO, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                            
                        if (alterarPermissaoCheckBox.Checked && manutencaoServlet.alterarPermissao(login, permissao))
                        {
                            MessageBox.Show(MSG_ALTERAR_PERMISSAO, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        limpaCamposAltera();
                    }                             
                }
            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpaCamposAltera();
            }                    
        }

        ///<summary>
        ///
        /// Método para chamar o metodo que busca arquivo da aba alteração através do clique do botão OK
        /// e exibir seu nome
        /// 
        ///</summary>  
        private void alteraCertificadoButtonClick(object sender, EventArgs e)
        {
            string caminhoChave = buscaArquivo();
            alterarCertificadoTextBox.Text = caminhoChave;
        }

        ///<summary>
        ///
        /// Método para marcar o checkbox alterar nome quando texto do campo alterar nome
        /// for mudado na aba Alterar Usuario
        /// 
        ///</summary>  
        private void alterarNomeTextBoxChanged(object sender, EventArgs e)
        {
            alterarNomeCheckBox.Checked = true;
        }

        ///<summary>
        ///
        /// Método para marcar o checkbox alterar certificado quando texto do campo alterar certificado
        /// for mudado na aba Alterar Usuario
        /// 
        ///</summary>  
        private void alteraCertificadoTextBoxChanged(object sender, EventArgs e)
        {
            alterarCertificadoCheckBox.Checked = true;
        }

        ///<summary>
        ///
        /// Método para marcar o checkbox alterar permissão quando opção for selecionada no comboBox alterar permissão
        /// for mudado na aba Alterar Usuario
        /// 
        ///</summary> 
        private void alteraPermissaoComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            alterarPermissaoCheckBox.Checked = true;
        }

        ///<summary>
        ///
        /// Método para limpar os campos da aba Alterar Usuario
        /// 
        ///</summary>  
        private void limpaCamposAltera()
        {
            this.alterarLoginTextBox.Clear();
            this.alterarNomeTextBox.Clear();
            this.alterarCertificadoTextBox.Clear();
            this.alterarPermissaoComboBox.SelectedIndex = -1;
            this.resetarSenhaCheckBox.Checked = false;
            this.alterarNomeCheckBox.Checked = false;
            this.alterarCertificadoCheckBox.Checked = false;
            this.alterarPermissaoCheckBox.Checked = false;            
        }

        ///<summary>
        ///
        /// Metodo para chamar o servlet para excluir um usuário
        /// 
        ///</summary>  
        private void excluirUsuario() {

            try {

                string login = excluirLoginTextBox.Text;

                DialogResult result = MessageBox.Show(MSG_EXCLUIR, MSG_AVISO, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    if (manutencaoServlet.excluirUsuario(login))
                    {
                        MessageBox.Show(MSG_EXCLUIR_SUCESSO, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    limpaCamposExcluir();
                }
            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpaCamposExcluir();
            }  
        }

        ///<summary>
        ///
        /// Método para limpar os campos da aba Excluir Usuario
        /// 
        ///</summary>  
        private void limpaCamposExcluir() {

            this.excluirLoginTextBox.Clear();
        
        }

    }
}
