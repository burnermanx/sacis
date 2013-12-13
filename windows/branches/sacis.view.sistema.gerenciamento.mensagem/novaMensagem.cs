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
        private static string MSG_ERRO_EXCLUIR = "Ocorreu um erro ao excluir arquivos temporários.";
        private static string MSG_CONFIRMA_SAIDA = "Deseja realmente descartar a mensagem?";
        private static string MSG_SEM_DESTINATARIO = "Mensagem não pode ser enviada sem um destinatário!";
        private static string MSG_SAIR = "Sair da Mensagem";
        private static string MSG_ENVIO_OK = "Mensagem enviada com Sucesso!";
        //private static string MSG_ENVIO_FAIL = "Ocorreu um erro ao enviar a mensagem!";
        private static string MSG_ENVIO_OK_DESTINATARIOS_INEXISTENTES = "Mensagem enviada com Sucesso, porém os seguintes destinatários nao foram encontrados: ";
        private static string MSG_INFO = "Informação";
        private static string MSG_ERRO = "Erro";
        private static string EMAIL = "@sacis.com.br;";
        private static string RE = "RE: ";
        private static string TRACEJADO = "=============================================";
        private static string DE = "De: ";
        private static string PARA = "Para: ";
        private static string ASSUNTO = "Assunto: ";
        private static string SEPARADOR = ";";
        private string caminho = @"C:\sacis\temp\";
        private int controleAnexos;
        private string usuario;        
        private int control = 0;
        

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
        /// Metodo construtor para inicializar os componentes do formulario 
        /// atraves de uma premensagem e um indicador do tipo de mensagem nova
        /// 
        ///</summary>
        public novaMensagem(preMensagem msg, int flag, int idmensagem)
        {
            control = flag;
            usuario = msg.getPara();
            controleAnexos = 0;            
            InitializeComponent();
            novoAssunto.Text = RE + msg.getAssunto();
            novoTexto.Text = Environment.NewLine + Environment.NewLine + Environment.NewLine + TRACEJADO + Environment.NewLine + DE + msg.getDe() + EMAIL + Environment.NewLine + PARA + msg.getPara() + EMAIL + Environment.NewLine + ASSUNTO + msg.getAssunto() + Environment.NewLine + Environment.NewLine + msg.getTexto();
            
            if (flag == 1) 
            {
                string caminhoChave = "";

                if(msg.getArquivoCripto().Count > 0)
                {
                    foreach (string s in msg.getArquivoCripto()) 
                    {
                        string nome = gerenciaServlet.recuperaNomeOriginalArquivo(s);
                        nomeAnexos.Text = nome + "; " + nomeAnexos.Text;
                        CriptoFiles.Add(caminho + s);                   
                    }

                    gerenciaChave gerenciaChaveForm = new gerenciaChave();
                    gerenciaChaveForm.ShowDialog();
                    caminhoChave = gerenciaChaveForm.getCaminho(); 
                }

                if (msg.getArquivoPlain().Count > 0)
                {
                    foreach (string s in msg.getArquivoPlain())
                    {
                        nomeAnexos.Text = s + "; " + nomeAnexos.Text;
                        PlainFiles.Add(caminho + s);
                    }
                }

                if (CriptoFiles.Count > 0 || PlainFiles.Count > 0) controleAnexos = 1;

                gerenciaServlet.anexoEncaminhar(idmensagem, caminhoChave);
            }
            else novoPara.Text = msg.getDe() + EMAIL;
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
                catalogoPara newForm;

                if (lista.Count == 0)
                {
                    newForm = new catalogoPara(usuario);
                }
                else
                {
                    lista.Clear();
                    lista = gerenciaServlet.converteParaLista(novoPara.Text);
                    newForm = new catalogoPara(usuario, lista);
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
                string destinatarios = novoPara.Text;
                if (!destinatarios.EndsWith(SEPARADOR)) destinatarios += SEPARADOR;

                preMensagem msg = new preMensagem(usuario, destinatarios, novoAssunto.Text, novoTexto.Text, novoCripto.Checked, novoAssina.Checked, CriptoFiles, PlainFiles);
                string caminhoChave = "";

                if (novoAssina.Checked) 
                {
                    gerenciaChave gerenciaChaveForm = new gerenciaChave();
                    gerenciaChaveForm.ShowDialog();
                    caminhoChave = gerenciaChaveForm.getCaminho();  
                }

                if (novoPara.Text == null || novoPara.Text == "") MessageBox.Show(MSG_SEM_DESTINATARIO, MSG_INFO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    List<string> destinatariosInexistentes = gerenciaServlet.criaMensagem(msg, caminhoChave);
                    //bool ret = gerenciaServlet.criaMensagem(msg,caminhoChave);

                    if (destinatariosInexistentes.Count == 0) MessageBox.Show(MSG_ENVIO_OK, MSG_INFO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (destinatariosInexistentes.Count > 1)
                    {
                        string nomesInexistentes = "";
                        foreach (string s in destinatariosInexistentes) nomesInexistentes += s + ", ";
                        nomesInexistentes = nomesInexistentes.Remove(nomesInexistentes.LastIndexOf(", "), 2);
                        
                        MessageBox.Show(MSG_ENVIO_OK_DESTINATARIOS_INEXISTENTES + nomesInexistentes, MSG_INFO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }//else MessageBox.Show(MSG_ENVIO_FAIL, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    gerenciaServlet.excluiArquivos();
                    this.Close();
                }
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

            try
            {
                if (DialogResult.OK == MessageBox.Show(MSG_CONFIRMA_SAIDA, MSG_SAIR, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
                {
                    gerenciaServlet.excluiArquivos();
                    this.Close();
                }
            }
            catch (excecao ex)
            {
                MessageBox.Show(MSG_ERRO_EXCLUIR, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }

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

        private void nomeAnexos_DoubleClick(object sender, EventArgs e)
        { 
            if (!String.IsNullOrEmpty(nomeAnexos.Text))
            {                
                int selInicio = nomeAnexos.SelectionStart;
                int selFim = nomeAnexos.Text.IndexOf(";", selInicio);
                int selTamanho = selFim - selInicio;

                string nome = nomeAnexos.Text.Substring(selInicio, selTamanho);

                nomeAnexos.SelectionStart = selInicio;
                nomeAnexos.SelectionLength = selTamanho;

                string[] listArq = nomeAnexos.Text.Split(';');
                int listCount = 0;
                int count = 0;
                int listCountInicio = 0;
                int listCountFim = 0;

                foreach (string arq in listArq)
                {
                    listCountFim += arq.Trim().Length + 2;
                    if (arq.Contains(nome) && listCountInicio <= selInicio && listCountFim > selInicio)
                    {
                        nome = arq.Trim();
                        selInicio = listCountInicio;
                        break;
                    }
                    listCountInicio = listCountFim;
                }
                
                if (control == 1)
                {
                    if(nome.Contains(".sac")) nome = gerenciaServlet.recuperaNomeOriginalArquivo(nome);
                    System.Diagnostics.Process.Start(caminho + nome);
                }
                else
                {                    
                    HashSet<string> files = new HashSet<string>();
                    
                    if(CriptoFiles != null) foreach(string path in CriptoFiles) files.Add(path);
                    if(PlainFiles != null) foreach(string path in PlainFiles) files.Add(path);

                    foreach (string file in files)
                    {
                        if (file.Contains(nome) && count == selInicio)
                        {
                            nome = files.ElementAt(listCount);
                            break;
                        }

                        count += gerenciaServlet.retornaNome(file).Length + 2;
                        listCount++;
                    }
                    
                    System.Diagnostics.Process.Start(nome);
                }

            }
        }
        
    }
}
