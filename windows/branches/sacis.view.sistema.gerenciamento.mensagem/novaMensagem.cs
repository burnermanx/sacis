///<summary>
/// Implementação do formulario de nova mensagem
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

namespace sacis.view.sistema.gerenciamento.mensagem
{
    public partial class novaMensagem : Form
    {
        private static string MSG_CONFIRMA_SAIDA = "Deseja realmente descartar a mensagem?";
        private static string MSG_SAIR = "Sair da Mensagem";
        private static string MSG_ENVIO_OK = "Mensagem enviada com Sucesso!";
        private static string MSG_ENVIO_FAIL = "Ocorreu um erro ao enviar a mensagem!";
        private static string MSG_INFO = "Informação";
        private static string MSG_ERRO = "Erro";

        private int controleAnexos;
        private string usuario;

        private HashSet<String> CriptoFiles = new HashSet<String>();
        private HashSet<String> PlainFiles = new HashSet<String>();
        private List<contato> lista = new List<contato>();

        ///<summary>
        ///
        /// Metodo construtor para inicializar os componentes do formulario 
        /// atraves do login
        /// 
        ///</summary>
        public novaMensagem(string nome)
        {
            usuario = nome;
            controleAnexos = 0;
            InitializeComponent();
        }

        ///<summary>
        ///
        /// Metodo para chamar o formulario do catalogo pessoal
        ///
        ///</summary>
        private void paraLabelClick(object sender, EventArgs e)
        {
            try
            {
                catalogoPessoal newForm;

                if (lista.Count == 0)
                {
                    newForm = new catalogoPessoal(usuario);
                }
                else
                {
                    lista.Clear();
                    lista = gerenciaServlet.converteParaLista(novoPara.Text);
                    newForm = new catalogoPessoal(usuario, lista);
                }

                newForm.FormClosed += new FormClosedEventHandler(formVisivel);
                newForm.ShowDialog();

                lista = newForm.getListaContatos();

                exibeNomeContatos();
            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                novoPara.Clear();
            }
        }

        ///<summary>
        ///
        /// Metodo para exibir nome dos contatos no textbox para
        /// 
        ///</summary>
        private void exibeNomeContatos() {

            string contatos = "";

            foreach (contato c in lista) contatos += c.getNome() + "(" + c.getEmail() + ")" + ";";

            novoPara.Text = contatos;
        
        }

        ///<summary>
        ///
        /// Metodo para chamar o formulario de anexar arquivos
        ///
        ///</summary>
        private void anexarClick(object sender, EventArgs e)
        {

            novaMensagemAnexar newForm;

            if (controleAnexos == 0)
            {
                newForm = new novaMensagemAnexar();
                controleAnexos++;
            }
            else
            {
                newForm = new novaMensagemAnexar(CriptoFiles, PlainFiles);
                CriptoFiles.Clear();
                PlainFiles.Clear();
                
            }

            newForm.FormClosed += new FormClosedEventHandler(formVisivel);
            newForm.ShowDialog();

            foreach (String f in newForm.getCriptoFiles()) CriptoFiles.Add(f);
            foreach (String f in newForm.getPlainFiles()) PlainFiles.Add(f);

            exibeNomeArquivos();
            
        }

        ///<summary>
        ///
        /// Metodo para exibir o nome dos arquivos escolhidos no campo de anexos
        ///
        ///</summary>
        private void exibeNomeArquivos() {

            String naText = "";

            foreach (String f in CriptoFiles)
            {
                String ret = gerenciaServlet.retornaNome(f);
                naText += ret + "; ";

            }

            foreach (String f in PlainFiles)
            {
                String ret = gerenciaServlet.retornaNome(f);
                naText += ret + "; ";

            }

            nomeAnexos.Text = naText;     
                
        }

        ///<summary>
        ///
        /// Metodo para enviar a nova mensagem através do botao de enviar
        ///
        ///</summary>
        private void novoEnviarClick(object sender, EventArgs e)
        {

            try
            {
                preMensagem msg = new preMensagem(usuario, novoPara.Text, novoAssunto.Text, novoTexto.Text, novoCripto.Checked, novoAssina.Checked, CriptoFiles, PlainFiles);
                bool ret = gerenciaServlet.criaMensagem(msg);

                if (ret) MessageBox.Show(MSG_ENVIO_OK, MSG_INFO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(MSG_ENVIO_FAIL, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                novoPara.Clear();
            }

        }

        ///<summary>
        ///
        /// Metodo para o botao de fechar
        ///
        ///</summary>
        private void fecharClick(object sender, EventArgs e)
        {

            if (DialogResult.OK == MessageBox.Show(MSG_CONFIRMA_SAIDA, MSG_SAIR, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
                this.Close();

        }

        ///<summary>
        ///
        /// Metodo para mudar a cor do label com o mouse sobre ele
        ///
        ///</summary>
        private void anexarOver(object sender, EventArgs e)
        {
            novoAnarq.BorderStyle = BorderStyle.Fixed3D;
            novoAnarq.BackColor = System.Drawing.Color.PaleGoldenrod;
        }

        ///<summary>
        ///
        /// Metodo para mudar a cor do label com o mouse fora dele
        ///
        ///</summary>
        private void anexarOut(object sender, EventArgs e)
        {
            novoAnarq.BorderStyle = BorderStyle.None;
            novoAnarq.BackColor = System.Drawing.Color.Empty;
        }

        ///<summary>
        ///
        /// Metodo para mudar a cor do label com o mouse sobre ele
        ///
        ///</summary>
        private void paraOver(object sender, EventArgs e)
        {
            paraLabel.BorderStyle = BorderStyle.Fixed3D;
            paraLabel.BackColor = System.Drawing.Color.PaleGoldenrod;
        }

        ///<summary>
        ///
        /// Metodo para mudar a cor do label com o mouse fora dele
        ///
        ///</summary>
        private void paraOut(object sender, EventArgs e)
        {
            paraLabel.BorderStyle = BorderStyle.None;
            paraLabel.BackColor = System.Drawing.Color.Empty;
        }

        ///<summary>
        ///
        /// Método para tornar o formulário visivel
        ///
        ///</summary>
        private void formVisivel(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }
        
    }
}
