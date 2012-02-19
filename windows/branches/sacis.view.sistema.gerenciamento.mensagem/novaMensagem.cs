/*
 * 
 * Implementação do formulario de nova mensagem
 *
 * @author Fabio Augusto
 * 
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

        /**
        *
        * Metodo contrutor para inicializar os componentes do formulario
        *
        */
        public novaMensagem(string nome)
        {
            usuario = nome;
            controleAnexos = 0;
            InitializeComponent();
        }

        /**
        *
        * Metodo para chamar formulario para anexar arquivos
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
        *
        */
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

        /**
        *
        * Metodo para exibir o nome dos arquivos escolhidos no campo de anexos
        *
        */
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

        /**
        *
        * Metodo para o botao de enviar
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
        *
        */
        private void novo_enviar_Click(object sender, EventArgs e)
        {

            mensagemNovo msg = new mensagemNovo(usuario, novo_para.Text, novo_assunto.Text, novo_texto.Text, novo_cripto.Checked, novo_assina.Checked, CriptoFiles, PlainFiles);
            bool ret = gerenciaServlet.enviaMensagem(msg);

            if (ret) MessageBox.Show(MSG_ENVIO_OK, MSG_INFO, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show(MSG_ENVIO_FAIL, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();

        }

        /**
        *
        * Metodo para o botao de fechar
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
        *
        */
        private void fechar_Click(object sender, EventArgs e)
        {

            if (DialogResult.OK == MessageBox.Show(MSG_CONFIRMA_SAIDA, MSG_SAIR, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
                this.Close();

        }

        /**
        *
        * Metodo para mudar a cor do label com o mouse sobre ele
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
        *
        */
        private void anexar_over(object sender, EventArgs e)
        {
            novo_anarq.BorderStyle = BorderStyle.Fixed3D;
            novo_anarq.BackColor = System.Drawing.Color.PaleGoldenrod;
        }

        /**
        *
        * Metodo para mudar a cor do label com o mouse fora dele
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
        *
        */
        private void anexar_out(object sender, EventArgs e)
        {
            novo_anarq.BorderStyle = BorderStyle.None;
            novo_anarq.BackColor = System.Drawing.Color.Empty;
        }

        /**
        *
        * Metodo para mudar a cor do label com o mouse sobre ele
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
        *
        */
        private void para_over(object sender, EventArgs e)
        {
            para_label.BorderStyle = BorderStyle.Fixed3D;
            para_label.BackColor = System.Drawing.Color.PaleGoldenrod;
        }

        /**
        *
        * Metodo para mudar a cor do label com o mouse fora dele
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
        *
        */
        private void para_out(object sender, EventArgs e)
        {
            para_label.BorderStyle = BorderStyle.None;
            para_label.BackColor = System.Drawing.Color.Empty;
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
