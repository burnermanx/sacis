///<summary>
/// Implementação do formulario de anexar arquivos para a mensagem nova
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
using System.Collections;

namespace sacis.view.sistema.gerenciamento.mensagem
{
    public partial class novaMensagemAnexar : Form
    {
        private HashSet<string> ConjFiles = new HashSet<string>();
        private HashSet<string> CriptoFiles = new HashSet<string>();
        private HashSet<string> PlainFiles = new HashSet<string>();
        private HashSet<string> cancelaPlain = new HashSet<string>();
        private HashSet<string> cancelaCripto = new HashSet<string>();
        private static int contador;

        ///<summary>
        ///
        /// Metodo construtor para inicializar os componentes do formulario 
        /// 
        ///</summary>
        public novaMensagemAnexar()
        {

            InitializeComponent();
            contador = 0;

            if (anexar.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in anexar.FileNames) ConjFiles.Add(file);
                dataGridInserir(ConjFiles);
            }

            exibeDatagrid();

        }

        ///<summary>
        ///
        /// Metodo construtor para inicializar os componentes do formulario 
        /// atraves das listas de arquivos a serem cifrados e os em claro passados
        /// 
        ///</summary>
        public novaMensagemAnexar(HashSet<string> cripto, HashSet<string> plain)
        {
            InitializeComponent();
            contador = 0;
            cancelaCripto = cripto;
            cancelaPlain = plain;

            if (anexar.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in anexar.FileNames) ConjFiles.Add(file);                
            }

            uniaoHash(cripto);
            uniaoHash(plain);
            dataGridInserir(ConjFiles);
            exibeDatagrid();

        }

        ///<summary>
        ///
        /// Metodo get para retornar hashset dos arquivos a serem criptografados
        /// 
        ///</summary>
        public HashSet<string> getCriptoFiles()
        {
            return this.CriptoFiles;
        }

        ///<summary>
        ///
        /// Metodo get para retornar hashset dos arquivos que não serão criptografados
        /// 
        ///</summary>
        public HashSet<string> getPlainFiles()
        {
            return this.PlainFiles;
        }

        ///<summary>
        ///
        /// Metodo para unir os hashsets e remove duplicidade de nomes
        /// 
        ///</summary>
        private void uniaoHash(HashSet<string> hash) {

            HashSet<string> uniao = new HashSet<string>();
            IEnumerable<string> IAnexos = ConjFiles.Union<string>(hash);
            
            foreach (string str in IAnexos) uniao.Add(str);
            ConjFiles.Clear();
            ConjFiles = uniao;
        
        }

        ///<summary>
        ///
        /// Metodo para inserir os dados do hashset no dataGridView
        /// 
        ///</summary>
        private void dataGridInserir(HashSet<string> anexar)
        {            
            foreach (String file in anexar)
            {
                String ret = gerenciaServlet.retornaNome(file);

                anexosDataGridView.Rows.Add(1);
                anexosDataGridView.Rows[contador].Cells[0].Value = ret;
                anexosDataGridView.Rows[contador].Cells[1].Value = false;
                anexosDataGridView.Rows[contador].Cells[2].Value = false;

                if (cancelaCripto.Count != 0)
                {
                    foreach (string str in cancelaCripto)
                    {
                        if (file.Equals(str)) anexosDataGridView.Rows[contador].Cells[2].Value = true;                        
                    }
                }

                contador++;
            }                                
        }        

        ///<summary>
        ///
        /// Metodo para exibir dataGridView
        /// 
        ///</summary>
        private void exibeDatagrid() {

            anexosDataGridView.Visible = true;
        
        }

        ///<summary>
        ///
        /// Metodo para remover os arquivos selecionados no dataGridView
        /// 
        ///</summary>
        private void removeArquivos()
        {
            for (int i = 0; i < contador; i++)
            {
                if (anexosDataGridView.Rows[i].Cells[1].Value.Equals(true))
                {
                    anexosDataGridView.Rows.Remove(anexosDataGridView.Rows[i]);
                    i--;
                    contador--;
                }
            }     
        }

        ///<summary>
        ///
        /// Metodo para inserir o caminho dos arquivos nos hashsets CriptoFiles e PlainFiles
        /// 
        ///</summary>
        private void atualizaHashset() {
        
            for (int i = 0; i < contador; i++)
            {
                if (anexosDataGridView.Rows[i].Cells[2].Value.Equals(true))
                {                    
                    foreach (string f in ConjFiles)
                    {

                        String ret = gerenciaServlet.retornaNome(f);
                        String ret2 = anexosDataGridView.Rows[i].Cells[0].Value.ToString();

                        if (ret.Equals(ret2)) CriptoFiles.Add(f);

                    }
                }
                else
                {
                    foreach (string f in ConjFiles)
                    {

                        String ret = gerenciaServlet.retornaNome(f);
                        String ret2 = anexosDataGridView.Rows[i].Cells[0].Value.ToString();

                        if (ret.Equals(ret2)) PlainFiles.Add(f);

                    }
                }
            }           
        }

        ///<summary>
        ///
        /// Metodo para chamar metodos de remover arquivos, atualizar o hashset
        /// e fechar formulario através do botão ok
        /// 
        ///</summary>
        private void okButtonClick(object sender, EventArgs e)
        {            
            removeArquivos();
            atualizaHashset();
            fecharForm();
        }

        ///<summary>
        ///
        /// Metodo para o botao cancelar
        /// 
        ///</summary>
        private void cancelarButtonClick(object sender, EventArgs e)
        {
            fecharForm();
        }

        ///<summary>
        ///
        /// Metodo para fechar formulario
        /// 
        ///</summary>
        private void fecharForm() {

            this.Close();
        
        }
    }
}
