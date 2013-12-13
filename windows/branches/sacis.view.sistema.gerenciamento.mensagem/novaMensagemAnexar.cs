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
        private static DialogResult resultado;

        ///<summary>
        ///
        /// Metodo construtor para inicializar os componentes do formulario 
        /// 
        ///</summary>
        public novaMensagemAnexar()
        {
            InitializeComponent();
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
            foreach (string s in cripto) cancelaCripto.Add(s);
            foreach (string s in plain) cancelaPlain.Add(s);

            uniaoHash(cripto);
            uniaoHash(plain);
            dataGridInserir();
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
        private void dataGridInserir()
        {
            int contador = 0;

            anexosDataGridView.Rows.Clear();

            foreach (String file in ConjFiles)
            {
                String ret = file;// gerenciaServlet.retornaNome(file);

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
            int i = 0;
            HashSet<string> excluir = new HashSet<string>();

            foreach (string f in ConjFiles)
            {
                if (anexosDataGridView.Rows[i].Cells[1].Value.Equals(true))
                {                    
                    anexosDataGridView.Rows.Remove(anexosDataGridView.Rows[i]);                      
                    excluir.Add(f);                    
                } 
                else i++;
            }

            foreach (string f in excluir) ConjFiles.Remove(f);
        }

        ///<summary>
        ///
        /// Metodo para inserir o caminho dos arquivos nos hashsets CriptoFiles e PlainFiles
        /// 
        ///</summary>
        private void atualizaHashset() 
        {        
            int i = 0;

            foreach (string f in ConjFiles)
            {
                if (anexosDataGridView.Rows[i].Cells[2].Value.Equals(false))
                {
                    PlainFiles.Add(f);
                }
                else if (anexosDataGridView.Rows[i].Cells[2].Value.Equals(true))
                {
                    CriptoFiles.Add(f);
                }
                i++;
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
            CriptoFiles = cancelaCripto;
            PlainFiles = cancelaPlain;
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

        ///<summary>
        ///
        /// Metodo para selecionar arquivos para anexar a mensagem
        /// 
        ///</summary>
        private void selecionarBotao_Click(object sender, EventArgs e)
        {
            resultado = anexar.ShowDialog();
            HashSet<string> conjunto = new HashSet<string>();

            if (resultado.Equals(DialogResult.OK))
            {
                foreach (string file in anexar.FileNames)
                {
                    conjunto.Add(file);
                }
                uniaoHash(conjunto);
                dataGridInserir();
            }
        }
    }
}
