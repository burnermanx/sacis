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

namespace sacis.view.sistema.gerenciamento.mensagem
{
    public partial class abrirMensagem : Form
    {
        private static preMensagem msg;
        private static string MSG_ERRO_ASSUNTO = "Mail Delivery Service Fail";
        private static int idmensagem;
        private static string ARQUIVO_EXTENSAO = ".sac";
        private static string MSG_ATENCAO = "Atenção";
        private static string MSG_CRIPTO = "Sua mensagem está criptografada. Informe sua Chave Privada.";

        public abrirMensagem()
        {
            InitializeComponent();
        }

        public abrirMensagem(int id)
        {
            idmensagem = id;
            InitializeComponent();

            string caminhoChave = "";

            if (gerenciaServlet.verificaMensagemCriptografada(id)) 
            {
                MessageBox.Show(MSG_CRIPTO, MSG_ATENCAO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                gerenciaChave gerenciaChaveForm = new gerenciaChave();
                gerenciaChaveForm.ShowDialog();

                caminhoChave = gerenciaChaveForm.getCaminho();    
            }

            msg = gerenciaServlet.buscaMensagem(id, caminhoChave);

            abreDe.Text = msg.getDe();
            abreAssunto.Text = msg.getAssunto();
            abreTexto.Text = msg.getTexto();

            foreach (string s in msg.getArquivoCripto()) abreAnexos.Text = s + "; " + abreAnexos.Text;
            foreach (string s in msg.getArquivoPlain()) abreAnexos.Text = s + "; " + abreAnexos.Text;

            if (msg.getAssunto().Equals(MSG_ERRO_ASSUNTO))
            {
                abreResponder.Visible = false;
                abreEncaminhar.Visible = false;
            }
        }

        private void abreResponder_Click(object sender, EventArgs e)
        {
            novaMensagem newform = new novaMensagem(msg, 0, idmensagem);
            newform.ShowDialog();
        }

        private void abreEncaminhar_Click(object sender, EventArgs e)
        {
            novaMensagem newform = new novaMensagem(msg, 1, idmensagem);
            newform.ShowDialog();
        }

        private void abreAnexos_DoubleClick(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(abreAnexos.Text))
            {
                string caminho = "";
                int selInicio = abreAnexos.SelectionStart;
                int selFim = abreAnexos.Text.IndexOf(";", selInicio);
                int selTamanho = selFim - selInicio;
                
                string nome = abreAnexos.Text.Substring(selInicio, selTamanho);

                abreAnexos.SelectionStart = selInicio;
                abreAnexos.SelectionLength = selTamanho;

                string[] listArq = abreAnexos.Text.Split(';');

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

                if (nome.Contains(ARQUIVO_EXTENSAO)) 
                {
                    gerenciaChave gerenciaChaveForm = new gerenciaChave();
                    gerenciaChaveForm.ShowDialog();
                    
                    caminho = gerenciaChaveForm.getCaminho();          
                }
                
                gerenciaServlet.abreArquivo(nome, idmensagem, caminho);                
            }
            
        }
    }
}
