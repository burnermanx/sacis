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
            MCLoad(nome);          
        }

        ///<summary>
        ///
        /// Metodo para carregar a treewiew automaticamente
        ///
        ///</summary>
        private void MCLoad(string nome)
        {

            try
            {
                DirectoryInfo info = gerenciaServlet.listaDiretorios(nome);
                
                TreeNode root = new TreeNode(info.Name);
                
                GetDirectories(info.GetDirectories(), root);

                mcTreeview.Nodes.Add(root);

                root.Expand();

            }
            catch (excecao except)
            {

                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        ///<summary>
        ///
        /// Metodo para visualizar o conteudo dos diretorios
        ///
        ///</summary>
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

        ///<summary>
        ///
        /// Metodo para visualizar conteudo de um nó da treeview e colocá-la numa 
        /// listview atraves do mouse
        ///
        ///</summary>
        private void mcTreeviewNodeClick(object sender, TreeNodeMouseClickEventArgs no)
        {

            caminhoCompleto = gerenciaServlet.caminhoTotal(no.Node.FullPath);

            TreeNode selecionado = no.Node;

            mcList.Items.Clear();

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

                    mcList.Items.Add(item);

                }

                mcList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

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
                this.Close();        
        
        }

        ///<summary>
        ///
        /// Metodo para ordenar colunas
        ///
        ///</summary>
        private void colunaClick(object sender, ColumnClickEventArgs e)
        {

            this.mcList.Sorting = ((this.mcList.Sorting.Equals(SortOrder.Ascending)) ?
                                    SortOrder.Descending : SortOrder.Ascending);

            this.mcList.ListViewItemSorter = new OrdenaListView(this.mcList.Sorting, e.Column);

            this.mcList.Sort();

        }

        ///<summary>
        ///
        /// Metodo para abrir a mensagem com duplo click
        ///
        ///</summary>
        private void duploClick(object sender, EventArgs e)
        {

            string arq = mcList.SelectedItems[0].SubItems[0].Text;

            gerenciaServlet.abreArquivo(caminhoCompleto + arq);

        }

        ///<summary>
        ///
        /// Metodo para apagar mensagem
        ///
        ///</summary>
        private void apagar(object sender, KeyEventArgs e)
       {

            if (e.KeyCode == Keys.Delete)
            {

                string arq = mcList.SelectedItems[0].SubItems[0].Text;

                if (DialogResult.OK == MessageBox.Show(MSG_CONFIRMA_APAGAR, MSG_APAGAR, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
                {

                    gerenciaServlet.apagaArquivo(caminhoCompleto + arq);
                    mcList.Items.Remove(mcList.SelectedItems[0]);
                    mcList.Refresh();

                }

            }

        }

        ///<summary>
        ///
        /// Metodo para o botao Catálogo chamar formulario
        ///
        ///</summary>
        private void catalogoGeralClick(object sender, EventArgs e)
        {
            catalogoGeral newform = new catalogoGeral(usuario);
            newform.ShowDialog();        
        }
    }

    ///<summary>
    ///
    /// Classe para ordenar as mensagens
    ///
    ///</summary>
    public class OrdenaListView : IComparer
    {

        private int col;
        private SortOrder sortOrder;

        ///<summary>
        ///
        /// Metodo construtor para inicializar as variaveis da classe
        /// atraves do modo da ordenação e a coluna a ser ordenada passados
        /// 
        ///</summary>
        public OrdenaListView(SortOrder sortOrder, int col)
        {

            this.sortOrder = sortOrder;
            this.col = col;
        }

        #region IComparer Members

        ///<summary>
        ///
        /// Metodo para comparar dois objetos passados da classe para ordená-los
        /// 
        ///</summary>
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
