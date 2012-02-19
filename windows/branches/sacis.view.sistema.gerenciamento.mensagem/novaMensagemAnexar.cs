/*
 * 
 * Implementação do formulario de anexar arquivos para a mensagem nova
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
        * Metodo construtor para inicializar os componentes do formulario
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
        * Metodo construtor para inicializar os componentes do formulario
        *
        * @param arquivoCripto         Variavel do tipo HashSet<string>
        * @param arquivoPlain          Variavel do tipo HashSet<string>
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
        * Metodo get para retornar hashset dos arquivos a serem criptografados
        *
        */
        public HashSet<string> getCriptoFiles()
        {
            return this.CriptoFiles;
        }

        /**
        *
        * Metodo get para retornar hashset dos arquivos que não serão criptografados
        *
        */
        public HashSet<string> getPlainFiles()
        {
            return this.PlainFiles;
        }

        /**
         *
         * Metodo para inserir os dados escolhidos para criptografia do hashset no dataGridView
         *
         * @param arquivoCripto         Variavel do tipo HashSet<string>
         * 
         */
        private void dataGridCripto(HashSet<string> cripto)
        {
            foreach (String file in cripto)
            {
                    String ret = gerenciaServlet.retornaNome(file);
                    ConjFiles.Add(file);

                    dataGridView1.Rows.Add(1);
                    dataGridView1.Rows[contador].Cells[0].Value = ret;
                    dataGridView1.Rows[contador].Cells[1].Value = false;
                    dataGridView1.Rows[contador].Cells[2].Value = true;
                    contador++;
            }       
        }

        /**
         *
         * Metodo para inserir os dados do hashset no dataGridView
         *
         * @param arquivoCripto         Variavel do tipo HashSet<string>
         * 
         */
        private void dataGridInserir(HashSet<string> anexar)
        {            
            foreach (String file in anexar)
            {
                    ConjFiles.Add(file);
                    String ret = gerenciaServlet.retornaNome(file);

                    dataGridView1.Rows.Add(1);
                    dataGridView1.Rows[contador].Cells[0].Value = ret;
                    dataGridView1.Rows[contador].Cells[1].Value = false;
                    dataGridView1.Rows[contador].Cells[2].Value = false;                    
                    contador++;
            }                                
        }

        /**
        *
        * Metodo para exibir dataGridView
        * 
        */
        private void exibeDatagrid() {

            dataGridView1.Visible = true;
        
        }

        /**
        *
        * Metodo para remover os arquivos selecionados no dataGridView
        * 
        */
        private void removeArquivos()
        {
            for (int i = 0; i < contador; i++)
            {
                //Se o checkbox Remover estiver checked
                if (dataGridView1.Rows[i].Cells[1].Value.Equals(true))
                {
                    //apaga linha do dataGridView1
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                    i--;
                    contador--;
                }
            }     
        }

        /**
        *
        * Metodo para inserir o caminho dos arquivos nos hashsets CriptoFiles e PlainFiles 
        * 
        */
        private void atualizaHashset() {
        
            for (int i = 0; i < contador; i++)
            {
                //Se checkbox Criptografar estiver checked
                if (dataGridView1.Rows[i].Cells[2].Value.Equals(true))
                {                    
                    foreach (string f in ConjFiles)
                    {

                        String ret = gerenciaServlet.retornaNome(f);
                        String ret2 = dataGridView1.Rows[i].Cells[0].Value.ToString();

                        if (ret.Equals(ret2)) CriptoFiles.Add(f);

                    }
                }
                else
                {
                    //Adiciona arquivo Plain no hashset PlainFiles 
                    foreach (string f in ConjFiles)
                    {

                        String ret = gerenciaServlet.retornaNome(f);
                        String ret2 = dataGridView1.Rows[i].Cells[0].Value.ToString();

                        if (ret.Equals(ret2)) PlainFiles.Add(f);

                    }
                }
            }           
        }

        /**
        *
        * Metodo para o botao de ok
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
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
        * Metodo para o botao de cancelar
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
        *
        */
        private void cancelarButton_Click(object sender, EventArgs e)
        {

            ConjFiles.Clear();
            this.Close();

        }
        
    }
}
