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
        /// Metodo contrutor _para inicializar os componentes do formulario
        ///
        /// @param nome       Variável do tipo string
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
        /// Metodo _para chamar formulario _para catalogo pessoal
        ///
        /// @param sender        Objeto com os dados do formulário
        /// @param e             Objeto base _para classes que contém dados _de evento
        /// 
        ///</summary>
        private void para_label_Click(object sender, EventArgs e)
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
                    lista = gerenciaServlet.converteParaLista(novo_para.Text);
                    newForm = new catalogoPessoal(usuario, lista);
                }

                newForm.FormClosed += new FormClosedEventHandler(form_visivel);
                newForm.ShowDialog();

                lista = newForm.getListaContatos();

                exibeNomeContatos();
            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                novo_para.Clear();
            }
        }

        ///<summary>
        ///
        /// Metodo _para exibir nome dos contatos no textbox _para
        /// 
        ///</summary>
        private void exibeNomeContatos() {

            string contatos = "";

            foreach (contato c in lista) contatos += c.getNome() + "(" + c.getEmail() + ")" + ";";

            novo_para.Text = contatos;
        
        }

        ///<summary>
        ///
        /// Metodo _para chamar formulario _para anexar arquivos
        ///
        /// @param sender        Objeto com os dados do formulário
        /// @param e             Objeto base _para classes que contém dados _de evento
        ///
        ///</summary>
        private void anexar_Click(object sender, EventArgs e)
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

            newForm.FormClosed += new FormClosedEventHandler(form_visivel);
            newForm.ShowDialog();

            foreach (String f in newForm.getCriptoFiles()) CriptoFiles.Add(f);
            foreach (String f in newForm.getPlainFiles()) PlainFiles.Add(f);

            exibeNomeArquivos();
            
        }

        ///<summary>
        ///
        /// Metodo _para exibir o nome dos arquivos escolhidos no campo _de _anexos
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

            nome_anexos.Text = naText;     
                
        }

        ///<summary>
        ///
        /// Metodo _para o botao _de enviar
        ///
        /// @param sender        Objeto com os dados do formulário
        /// @param e             Objeto base _para classes que contém dados _de evento
        ///
        ///</summary>
        private void novo_enviar_Click(object sender, EventArgs e)
        {

            try
            {
                preMensagem msg = new preMensagem(usuario, novo_para.Text, novo_assunto.Text, novo_texto.Text, novo_cripto.Checked, novo_assina.Checked, CriptoFiles, PlainFiles);
                bool ret = gerenciaServlet.criaMensagem(msg);

                if (ret) MessageBox.Show(MSG_ENVIO_OK, MSG_INFO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(MSG_ENVIO_FAIL, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                novo_para.Clear();
            }

        }

        ///<summary>
        ///
        /// Metodo _para o botao _de fechar
        ///
        /// @param sender        Objeto com os dados do formulário
        /// @param e             Objeto base _para classes que contém dados _de evento
        ///
        ///</summary>
        private void fechar_Click(object sender, EventArgs e)
        {

            if (DialogResult.OK == MessageBox.Show(MSG_CONFIRMA_SAIDA, MSG_SAIR, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
                this.Close();

        }

        ///<summary>
        ///
        /// Metodo _para mudar a cor do label com o mouse sobre ele
        ///
        /// @param sender        Objeto com os dados do formulário
        /// @param e             Objeto base _para classes que contém dados _de evento
        ///
        ///</summary>
        private void anexar_over(object sender, EventArgs e)
        {
            novo_anarq.BorderStyle = BorderStyle.Fixed3D;
            novo_anarq.BackColor = System.Drawing.Color.PaleGoldenrod;
        }

        ///<summary>
        ///
        /// Metodo _para mudar a cor do label com o mouse fora dele
        ///
        /// @param sender        Objeto com os dados do formulário
        /// @param e             Objeto base _para classes que contém dados _de evento
        ///
        ///</summary>
        private void anexar_out(object sender, EventArgs e)
        {
            novo_anarq.BorderStyle = BorderStyle.None;
            novo_anarq.BackColor = System.Drawing.Color.Empty;
        }

        ///<summary>
        ///
        /// Metodo _para mudar a cor do label com o mouse sobre ele
        ///
        /// @param sender        Objeto com os dados do formulário
        /// @param e             Objeto base _para classes que contém dados _de evento
        ///
        ///</summary>
        private void para_over(object sender, EventArgs e)
        {
            para_label.BorderStyle = BorderStyle.Fixed3D;
            para_label.BackColor = System.Drawing.Color.PaleGoldenrod;
        }

        ///<summary>
        ///
        /// Metodo _para mudar a cor do label com o mouse fora dele
        ///
        /// @param sender        Objeto com os dados do formulário
        /// @param e             Objeto base _para classes que contém dados _de evento
        ///
        ///</summary>
        private void para_out(object sender, EventArgs e)
        {
            para_label.BorderStyle = BorderStyle.None;
            para_label.BackColor = System.Drawing.Color.Empty;
        }

        ///<summary>
        ///
        /// Método _para tornar o formulário visivel
        ///
        /// @param sender        Objeto com os dados do formulário
        /// @param e             Objeto base contendo a tecla acionada no evento.
        ///
        ///</summary>
        private void form_visivel(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }
        
    }
}
