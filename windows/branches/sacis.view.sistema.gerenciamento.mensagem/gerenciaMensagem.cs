/*
 * 
 * Implementação do formulario _de gerenciamento _de mensagem
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
using sacis.model.excecao;
using System.IO;
using System.Collections;

namespace sacis.view.sistema.gerenciamento.mensagem
{
    public partial class gerenciaMensagem : Form
    {

        private static string MSG_ERRO = "Erro";
        private static string MSG_APAGAR = "Apagar Mensagem";
        private static string ARQUIVO = "Arquivo";
        private static string MSG_CONFIRMA_APAGAR = "Deseja realmente apagar a mensagem?";
        private static string MSG_CONFIRMA_SAIDA = "Deseja realmente sair?";
        private static string MSG_SAIR = "Saida do Sistema";
        private static string ENTRADA = "entrada";
        private static string ENVIADOS = "enviados";
        private string caminhoCompleto = null;
        private string usuario;

        /**
        *
        * Metodo _para inicializar os componentes do formulario
        *
        */
        public gerenciaMensagem()
        {
            InitializeComponent();
        }

        /**
        *
        * Metodo _para inicializar os componentes do formularios
        * e chamar o metodo MCLoad
        * 
        * @param nome       Variavel do tipo string
        *
        */
        public gerenciaMensagem(string nome)
        {
            InitializeComponent();
            usuario = nome;
            MCLoad(nome);

        }

        /**
        *
        * Metodo _para carregar a treewiew automaticamente
        * 
        * @param nome       Variavel do tipo string
        * @throw excecao
        *
        */
        private void MCLoad(string nome)
        {

            try
            {
                DirectoryInfo info = gerenciaServlet.listaDiretorios(nome);
                
                TreeNode root = new TreeNode(info.Name);
                
                GetDirectories(info.GetDirectories(), root);

                mc_treeview.Nodes.Add(root);

                root.Expand();

            }
            catch (excecao except)
            {

                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        /**
        *
        * Metodo _para visualizar diretorios
        * 
        * @param subDirs            Variavel do tipo DirectoryInfo
        * @param nodeToAddTo        Variável do tipo TreeNode 
        *
        */
        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {

            foreach (DirectoryInfo subDir in subDirs)
            {

                if (subDir.Name == ENTRADA || subDir.Name == ENVIADOS)
                {

                    TreeNode aNode = new TreeNode(subDir.Name, 0, 0);

                    DirectoryInfo[] subSubDirs = subDir.GetDirectories();

                    GetDirectories(subSubDirs, aNode);

                    nodeToAddTo.Nodes.Add(aNode);

                }

            }

        }

        /**
        *
        * Metodo _para visualizar conteudo _de um nó da treeview e colocá-la numa 
        * listview atraves do mouse
        *
        * @param sender        Objeto com os dados do formulário
        * @param no            Objeto contendo conteudo do nó selecionado
        * 
        */
        private void mc_treeview_node_click(object sender, TreeNodeMouseClickEventArgs no)
        {

            caminhoCompleto = gerenciaServlet.caminhoTotal(no.Node.FullPath);

            TreeNode selecionado = no.Node;

            mc_list.Items.Clear();

            DirectoryInfo nodir = gerenciaServlet.listaDiretorios(no.Node.FullPath);

            ListViewItem.ListViewSubItem[] subitems;

            ListViewItem item = null;

            if (nodir.Exists)
            {

                foreach (FileInfo file in nodir.GetFiles())
                {

                    item = new ListViewItem(file.Name, 1);

                    subitems = new ListViewItem.ListViewSubItem[]{ new ListViewItem.ListViewSubItem(item, ARQUIVO), 
                               new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToShortDateString()),
                               new ListViewItem.ListViewSubItem(item, file.Length.ToString())};

                    item.SubItems.AddRange(subitems);

                    mc_list.Items.Add(item);

                }

                mc_list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            }

        }

        /**
        *
        * Metodo _para o botao novo chamar formulario
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base _para classes que contém dados _de evento
        *
        */
        private void novo_Click(object sender, EventArgs e)
        {

            novaMensagem newform = new novaMensagem(usuario);
            newform.ShowDialog();

        }

        /**
        *
        * Metodo _para o botao _de sair
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base _para classes que contém dados _de evento
        *
        */
        private void sair_Click(object sender, EventArgs e)
        {

            saidaSistema();

        }

        /**
        *
        * Metodo _para o botao _de sair
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base contendo a tecla acionada no evento.
        *
        */
        private void sair_Click(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                saidaSistema();

            }
        }

        /**
        *
        * Metodo com a implementação do botao fechar 
        *
        */
        private void saidaSistema() {

            if (DialogResult.OK == MessageBox.Show(MSG_CONFIRMA_SAIDA, MSG_SAIR, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
                this.Close();        
        
        }

        /**
        *
        * Metodo _para ordenar colunas
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base _para classes que contém dados _de evento
        * 
        */
        private void coluna_click(object sender, ColumnClickEventArgs e)
        {

            this.mc_list.Sorting = ((this.mc_list.Sorting.Equals(SortOrder.Ascending)) ?
                                    SortOrder.Descending : SortOrder.Ascending);

            this.mc_list.ListViewItemSorter = new OrdenaListView(this.mc_list.Sorting, e.Column);

            this.mc_list.Sort();

        }

        /**
        *
        * Metodo _para abrir a mensagem com duplo click
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base _para classes que contém dados _de evento
        * 
        */
        private void duplo_click(object sender, EventArgs e)
        {

            string arq = mc_list.SelectedItems[0].SubItems[0].Text;

            gerenciaServlet.abreArquivo(caminhoCompleto + arq);

        }

        /**
        *
        * Método _para apagar mensagem
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base contendo a tecla acionada no evento.
        *
        */
        private void apagar(object sender, KeyEventArgs e)
       {

            if (e.KeyCode == Keys.Delete)
            {

                string arq = mc_list.SelectedItems[0].SubItems[0].Text;

                if (DialogResult.OK == MessageBox.Show(MSG_CONFIRMA_APAGAR, MSG_APAGAR, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
                {

                    gerenciaServlet.apagaArquivo(caminhoCompleto + arq);
                    mc_list.Items.Remove(mc_list.SelectedItems[0]);
                    mc_list.Refresh();

                }

            }

        }

        /**
        *
        * Metodo _para o botao Catálogo chamar formulario
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base _para classes que contém dados _de evento
        *
        */
        private void catalogoGeral_Click(object sender, EventArgs e)
        {
            catalogoGeral newform = new catalogoGeral(usuario);
            newform.ShowDialog();        
        }
    }

    /**
    *
    * Classe _para ordenar as mensagens
    *
    */
    public class OrdenaListView : IComparer
    {

        private int col;
        private SortOrder sortOrder;

        /**
        *
        * Metodo construtor _para inicializar as variaveis da classe
        * 
        * @param sortOrder          Variavel do tipo SortOrder
        * @param col                Variável do tipo inteiro 
        *
        */
        public OrdenaListView(SortOrder sortOrder, int col)
        {

            this.sortOrder = sortOrder;
            this.col = col;
        }

        #region IComparer Members

        /**
        *
        * Metodo _para comparar dois objetos da classe _para ordená-los
        * 
        * @param x          Variavel do tipo object
        * @param y          Variável do tipo object 
        *
        */
        public int Compare(object x, object y)
        {

            ListViewItem objetoA = (ListViewItem)x;
            ListViewItem objetoB = (ListViewItem)y;

            if (this.sortOrder.Equals(SortOrder.Ascending))
                return objetoA.SubItems[this.col].Text.CompareTo(objetoB.SubItems[this.col].Text);
            else
                return objetoB.SubItems[this.col].Text.CompareTo(objetoA.SubItems[this.col].Text);

        }

        #endregion

    }

}
