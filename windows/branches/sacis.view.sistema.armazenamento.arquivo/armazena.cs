/*
 * Formulário contendo a interface que o usuario irá utilizar para manipular os arquivos.
 *
 * @author Fabio Augusto
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using sacis.view.control;
using sacis.model.excecao;

namespace sacis.view.sistema.armazenamento
{
    public partial class armazena : Form
    {

        private static string MSG_CANCELAMENTO = "Deseja Realmente Cancelar o Armazenamento?";
        private static string MSG_AVISO = "Mensagem de Aviso!";
        private static string MSG_ERRO = "Mensagem de Erro!";
        private static string MSG_OPERACAO_CANCELADA = "Operação Cancelada";
        private static string MSG_CRIPTO = "Criptografia Realizada com Sucesso!";
        private static string MSG_DESCRIPTO = "Descriptografia Realizada com Sucesso!";

        private static HashSet<string> arquivos = new HashSet<string>();
        private static int valor;
        private static String pastaDestino;       

        /**
        *
        * Metodo para inicializar os componentes do formulario e selecionar os arquivos
        * desejados para sua manipulação
        *
        */    
        public armazena()
        {
            InitializeComponent();

            //abre janela para escolher arquivos   
            if (anexar.ShowDialog() == DialogResult.OK)
            {
                //insere o Array no DataGridView2
                insereArquivos();
            }
            else
            {
                this.Close();
            }  
           
        }

        /**
        *
        * Metodo para inserir os arquivos no dataGridView e no HashSet
        *
        */  
        private void insereArquivos()
        {

            valor = 0;

            foreach (String file in anexar.FileNames)
            {
                if (arquivos.Add(file))
                {
                    dataGridView2.Rows.Add(1);
                    dataGridView2.Rows[valor].Cells[0].Value = false;
                    dataGridView2.Rows[valor].Cells[1].Value = file;
                    valor++;
                }
            }

            dataGridView2.Visible = true;

        }
        
        /**
        *
        * Método para chamar metodo cripto através do clique no botao criptografar
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
        *
        */
        private void CriptoButton_Click(object sender, EventArgs e)
        {
           
            cripto();
            
        }

        /**
        *
        * Método para chamar metodo cripto através do teclado
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base contendo a tecla acionada no evento.
        *
        */
        private void CriptoButton_Click(object sender, KeyEventArgs e) {

            if (e.KeyCode == Keys.Enter)
            {

                cripto();

            }

        }

        /**
        *
        * Método para chamar metodo manipulaArquivo 
        *
        */
        private void cripto() {

            try
            {
                int controle = 1;

                manipulaArquivo(controle);

                MessageBox.Show(MSG_CRIPTO, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

            }
            catch (excecao except)
            {
                
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }     
        
        }

        /**
        *
        * Método para chamar metodo descripto através do clique no botao descriptografar
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
        *
        */
        private void DescButton_Click(object sender, EventArgs e)
        {

            descripto();

        }

        /**
        *
        * Método para chamar metodo descripto através do teclado
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base contendo a tecla acionada no evento.
        *
        */
        private void DescButton_Click(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                descripto();

            }

        }

        /**
        *
        * Método para chamar metodo manipulaArquivo 
        *
        */
        private void descripto() {

            try
            {
                int controle = 2;

                manipulaArquivo(controle);

                MessageBox.Show(MSG_DESCRIPTO, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

            }
            catch (excecao except)
            {

                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }         
        
        }

        /**
        *
        * Método para chamar metodo cancela através do clique no botao cancelar
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
        *
        */
        private void CancelarButton_Click(object sender, EventArgs e)
        {

            cancela();

        }

        /**
        *
        * Método para chamar metodo cancela através do teclado
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base contendo a tecla acionada no evento.
        *
        */
        private void CancelarButton_Click(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter) {

                cancela();

            }

        }

        /**
        *
        * Método para cancelar a operação de armazenamento
        *
        */
        private void cancela() {

            DialogResult result = MessageBox.Show(MSG_CANCELAMENTO, MSG_AVISO, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                arquivos.Clear();

                MessageBox.Show(MSG_OPERACAO_CANCELADA, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }        
        
        }

        /**
        *
        * Método para remover arquivos selecionados no dataGridView 
        *
        */
        private void removeArquivosSelecionados()
        {
            for (int i = 0; i < valor; i++)
            {
                //Se checkbox Remover estiver marcado
                if (dataGridView2.Rows[i].Cells[0].Value.Equals(true))
                {
                    //apaga linha do dataGridView1
                    dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                    i--;
                    valor--;

                }
            }
        }

        /**
        *
        * Método para atualizar o hashset com os arquivos selecionados
        *
        */
        private void atualiza() {

            arquivos.Clear();

            for (int i = 0; i < valor; i++)
            {
                arquivos.Add(dataGridView2.Rows[i].Cells[1].Value.ToString());
            }
        
        }

        /**
        *
        * Método para selecionar pasta destino dos arquivos
        *
        */        
        private void selecionaPastaDestino()
        {

            folderBrowserDialog2.SelectedPath = "";
            folderBrowserDialog2.ShowDialog();

            if (folderBrowserDialog2.SelectedPath.Length != 0)
            {
                pastaDestino = folderBrowserDialog2.SelectedPath;

            }


        }

        /**
        *
        * Metodo para cifrar ou decifrar os arquivos selecionados através do metodo no
        * armazenaServlet e uma flag.
        * 
        * @param flag       Variável inteiro representando a opção escolhida
        * 
        */ 
        private void manipulaArquivo(int flag) {

            removeArquivosSelecionados();
            atualiza();
            selecionaPastaDestino();

            for (int i = 0; i < valor; i++)
            {

                String caminho;
                caminho = dataGridView2.Rows[i].Cells[1].Value.ToString();

                armazenaServlet.armazenando(caminho, pastaDestino, flag);

            }        
                
        }

    }
}
