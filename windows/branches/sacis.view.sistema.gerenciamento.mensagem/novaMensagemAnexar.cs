/*
 * 
 * Implementação do formulario _de anexar arquivos _para a mensagem nova
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

namespace sacis.view.sistema.gerenciamento.mensagem
{
    public partial class novaMensagemAnexar : Form
    {
        private HashSet<string> AnexarFiles = new HashSet<string>();
        private HashSet<string> ConjFiles = new HashSet<string>();
        private HashSet<string> CriptoFiles = new HashSet<string>();
        private HashSet<string> PlainFiles = new HashSet<string>();
        private static int contador;

        /**
        *
        * Metodo construtor _para inicializar os componentes do formulario
        *
        */
        public novaMensagemAnexar()
        {

            InitializeComponent();
            contador = 0;

            if (anexar.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in anexar.FileNames) AnexarFiles.Add(file);
                dataGridInserir(AnexarFiles);
            }

            exibeDatagrid();

        }

        /**
        *
        * Metodo construtor _para inicializar os componentes do formulario
        *
        * @param _arquivoCripto         Variavel do tipo HashSet<string>
        * @param _arquivoPlain          Variavel do tipo HashSet<string>
        * 
        */
        public novaMensagemAnexar(HashSet<string> cripto, HashSet<string> plain)
        {

            InitializeComponent();
            contador = 0;
            dataGridCripto(cripto);
            dataGridInserir(plain);

            if (anexar.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in anexar.FileNames) AnexarFiles.Add(file);
                dataGridInserir(AnexarFiles);
            }

            exibeDatagrid();

        }

        /**
        *
        * Metodo get _para retornar hashset dos arquivos a serem criptografados
        *
        */
        public HashSet<string> getCriptoFiles()
        {
            return this.CriptoFiles;
        }

        /**
        *
        * Metodo get _para retornar hashset dos arquivos que não serão criptografados
        *
        */
        public HashSet<string> getPlainFiles()
        {
            return this.PlainFiles;
        }

        /**
         *
         * Metodo _para inserir os dados escolhidos _para criptografia do hashset no dataGridView
         *
         * @param _arquivoCripto         Variavel do tipo HashSet<string>
         * 
         */
        private void dataGridCripto(HashSet<string> cripto)
        {
            foreach (String file in cripto)
            {
                    String ret = gerenciaServlet.retornaNome(file);
                    ConjFiles.Add(file);

                    anexos_dataGridView.Rows.Add(1);
                    anexos_dataGridView.Rows[contador].Cells[0].Value = ret;
                    anexos_dataGridView.Rows[contador].Cells[1].Value = false;
                    anexos_dataGridView.Rows[contador].Cells[2].Value = true;
                    contador++;
            }       
        }

        /**
         *
         * Metodo _para inserir os dados do hashset no dataGridView
         *
         * @param _arquivoCripto         Variavel do tipo HashSet<string>
         * 
         */
        private void dataGridInserir(HashSet<string> anexar)
        {            
            foreach (String file in anexar)
            {
                    ConjFiles.Add(file);
                    String ret = gerenciaServlet.retornaNome(file);

                    anexos_dataGridView.Rows.Add(1);
                    anexos_dataGridView.Rows[contador].Cells[0].Value = ret;
                    anexos_dataGridView.Rows[contador].Cells[1].Value = false;
                    anexos_dataGridView.Rows[contador].Cells[2].Value = false;                    
                    contador++;
            }                                
        }

        /**
        *
        * Metodo _para exibir dataGridView
        * 
        */
        private void exibeDatagrid() {

            anexos_dataGridView.Visible = true;
        
        }

        /**
        *
        * Metodo _para remover os arquivos selecionados no dataGridView
        * 
        */
        private void removeArquivos()
        {
            for (int i = 0; i < contador; i++)
            {
                //Se o checkbox Remover estiver checked
                if (anexos_dataGridView.Rows[i].Cells[1].Value.Equals(true))
                {
                    //apaga linha do dataGridView1
                    anexos_dataGridView.Rows.Remove(anexos_dataGridView.Rows[i]);
                    i--;
                    contador--;
                }
            }     
        }

        /**
        *
        * Metodo _para inserir o caminho dos arquivos nos hashsets CriptoFiles e PlainFiles 
        * 
        */
        private void atualizaHashset() {
        
            for (int i = 0; i < contador; i++)
            {
                //Se checkbox Criptografar estiver checked
                if (anexos_dataGridView.Rows[i].Cells[2].Value.Equals(true))
                {                    
                    foreach (string f in ConjFiles)
                    {

                        String ret = gerenciaServlet.retornaNome(f);
                        String ret2 = anexos_dataGridView.Rows[i].Cells[0].Value.ToString();

                        if (ret.Equals(ret2)) CriptoFiles.Add(f);

                    }
                }
                else
                {
                    //Adiciona arquivo Plain no hashset PlainFiles 
                    foreach (string f in ConjFiles)
                    {

                        String ret = gerenciaServlet.retornaNome(f);
                        String ret2 = anexos_dataGridView.Rows[i].Cells[0].Value.ToString();

                        if (ret.Equals(ret2)) PlainFiles.Add(f);

                    }
                }
            }           
        }

        /**
        *
        * Metodo _para o botao _de ok
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base _para classes que contém dados _de evento
        *
        */
        private void okButton_Click(object sender, EventArgs e)
        {
            removeArquivos();
            atualizaHashset();
            this.Close();
        }

        /**
        *
        * Metodo _para o botao _de cancelar
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base _para classes que contém dados _de evento
        *
        */
        private void cancelarButton_Click(object sender, EventArgs e)
        {

            ConjFiles.Clear();
            this.Close();

        }
        
    }
}
