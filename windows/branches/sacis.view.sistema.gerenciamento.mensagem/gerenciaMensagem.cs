///<summary>
/// Implementação do formulario de gerenciamento de mensagem
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
using sacis.model.excecao;
using System.IO;
using System.Collections;
using sacis.model.entidades;

namespace sacis.view.sistema.gerenciamento.mensagem
{
    public partial class gerenciaMensagem : Form
    {

        private static string MSG_ERRO = "Erro ao abrir mensagem";
        private static string MSG_APAGAR = "Apagar Mensagem";
        private static string MSG_APAGAR_SUCESSO = "Mensagem apagada com sucesso!";
        private static string MSG_APAGAR_NAO_SUCESSO = "Ocorreu um erro e a mensagem não foi apagada.";
        private static string MSG_CONFIRMA_APAGAR = "Deseja realmente apagar a mensagem?";
        private static string MSG_CONFIRMA_SAIDA = "Deseja realmente sair?";
        private static string MSG_SAIR = "Saida do Sistema";
        private static string ENTRADA = "ENTRADA";
        private static string ENVIADOS = "ENVIADOS";
        private string usuario;
        private List<mensagemCabecalho> listaEntrada;
        private List<mensagemCabecalho> listaEnviados;
        private static string remete = "Remetente";
        private static string destino = "Destinatário";

        ///<summary>
        ///
        /// Metodo para inicializar os componentes do formulario
        ///
        ///</summary>
        public gerenciaMensagem()
        {
            InitializeComponent();
        }

        ///<summary>
        ///
        /// Metodo para inicializar os componentes do formulario atraves do login
        ///
        ///</summary>
        public gerenciaMensagem(string nome)
        {
            InitializeComponent();
            usuario = nome;
            listaEntrada = gerenciaServlet.buscaCabecalho(nome, ENTRADA);
            carregaLista(remete);
            
        }

        ///<summary>
        ///
        /// Metodo para carregar a list view através do parametro passado 
        ///
        ///</summary>
        private void carregaLista(string tipo)
        {
            mensagensGridView.Columns[0].HeaderText = tipo;
            mensagensGridView.Columns[0].Name = tipo.ToLower();

            List<mensagemCabecalho> lista = new List<mensagemCabecalho>();
            
            if (tipo.Equals(remete)) lista = listaEntrada;
            else if (tipo.Equals(destino)) lista = listaEnviados;

            if (lista != null)
            {
                mensagensGridView.Rows.Clear();
                mensagensGridView.Rows.Add(lista.Count());
                
                for(int i=0; i < lista.Count(); i++){

                    mensagemCabecalho item = lista[i];
                    mensagensGridView.Rows[i].Cells[0].Value = item.getLogremdest();
                    mensagensGridView.Rows[i].Cells[1].Value = item.getAssunto();
                    mensagensGridView.Rows[i].Cells[2].Value = item.getData();
                    mensagensGridView.Rows[i].Cells[3].Value = item.getTamanho();
                    mensagensGridView.Rows[i].Cells[4].Value = item.getCodigo();
                }
            }
            else if (lista == null) mensagensGridView.Rows.Clear();
        }

        ///<summary>
        ///
        /// Metodo para visualizar conteudo de um nó da treeview e colocá-la numa 
        /// listview atraves do mouse
        ///
        ///</summary>
        private void mcTreeviewNodeClick(object sender, TreeNodeMouseClickEventArgs no)
        {            
            string nomeNo = no.Node.FullPath;

            if (nomeNo.ToUpper().Contains(ENTRADA)) {
                listaEntrada = gerenciaServlet.buscaCabecalho(usuario, ENTRADA);
                carregaLista(remete);
            }
            else if (nomeNo.ToUpper().Contains(ENVIADOS)) {
                listaEnviados = gerenciaServlet.buscaCabecalho(usuario, ENVIADOS);
                carregaLista(destino);
            }

        }

        ///<summary>
        ///
        /// Metodo para abrir formulario para nova mensagem atraves do botao novo
        ///
        ///</summary>
        private void novoClick(object sender, EventArgs e)
        {
            novaMensagem newform = new novaMensagem(usuario);
            newform.ShowDialog();
        }

        ///<summary>
        ///
        /// Metodo para o botao sair atraves do botao fechar
        ///
        ///</summary>
        private void sairClick(object sender, EventArgs e)
        {
            saidaSistema();
        }

        ///<summary>
        ///
        /// Metodo para o botao sair atraves do teclado
        ///
        ///</summary>
        private void sairClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                saidaSistema();
            }
        }

        ///<summary>
        ///
        /// Metodo para sair do sistema
        ///
        ///</summary>
        private void saidaSistema() {

            if (DialogResult.OK == MessageBox.Show(MSG_CONFIRMA_SAIDA, MSG_SAIR, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
            {
                gerenciaServlet.excluiArquivos();
                this.Close();
            }
        
        }

        ///<summary>
        ///
        /// Metodo para o botao Catálogo Geral chamar formulario
        ///
        ///</summary>
        private void catalogoGeralItem_Click(object sender, EventArgs e)
        {
            catalogoGeral newform = new catalogoGeral(usuario);
            newform.ShowDialog();   
        }

        ///<summary>
        ///
        /// Metodo para o botao Catálogo Pessoal chamar formulario
        ///
        ///</summary>
        private void catalogoPessoalItem_Click(object sender, EventArgs e)
        {
            catalogoPessoal newForm = new catalogoPessoal(usuario);
            newForm.ShowDialog(); 

        }

        ///<summary>
        ///
        /// Metodo para abrir a mensagem com duplo click
        ///
        ///</summary>
        private void mensagensGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(mensagensGridView.Rows[e.RowIndex].Cells[4].Value.ToString());

                if (e.ColumnIndex != 5)
                {
                    abrirMensagem newform = new abrirMensagem(id);
                    newform.ShowDialog();
                }                
            }
            catch (ArgumentOutOfRangeException exception)
            {
              
            } catch (excecao ex){
                MessageBox.Show(ex.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        ///<summary>
        ///
        /// Metodo para apagar mensagem
        ///
        ///</summary>
        private void mensagensGridView_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int linha = Convert.ToInt32(mensagensGridView.SelectedCells[0].RowIndex.ToString());
                int coluna = Convert.ToInt16(mensagensGridView.SelectedCells[0].ColumnIndex.ToString());

                if (coluna == 5)
                {
                    int id = Convert.ToInt32(mensagensGridView.Rows[linha].Cells[4].Value.ToString());

                    if (DialogResult.OK == MessageBox.Show(MSG_CONFIRMA_APAGAR, MSG_APAGAR, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
                    {
                        if (gerenciaServlet.apagaMensagem(id))
                        {
                            mensagensGridView.Rows.RemoveAt(linha);
                            mensagensGridView.ClearSelection();
                            MessageBox.Show(MSG_APAGAR_SUCESSO, MSG_APAGAR, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        }
                        else {
                            MessageBox.Show(MSG_APAGAR_NAO_SUCESSO, MSG_APAGAR, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException exception)
            {
                
            }           
        }       
    }
}