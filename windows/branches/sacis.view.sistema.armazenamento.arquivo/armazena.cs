///<summary>
/// Formulário contendo a interface que o usuario irá utilizar para manipular os arquivos.
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

        ///<summary>
        /// 
        /// Metodo para inicializar os componentes do formulario e selecionar os arquivos
        /// desejados para sua manipulação.
        ///
        ///</summary>   
        public armazena()
        {
            InitializeComponent();

            if (anexar.ShowDialog() == DialogResult.OK)
            {
                insereArquivos();
            }
            else
            {
                this.Close();
            }             
        }

        ///<summary>
        /// 
        /// Metodo para inserir os arquivos no dataGridView e no HashSet.
        ///
        ///</summary>
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
        
        ///<summary>
        /// 
        /// Método que chama metodo cripto através do clique no botao criptografar.
        ///
        ///</summary>
        private void criptoButtonClick(object sender, EventArgs e)
        {           
            cripto();            
        }

        ///<summary>
        /// 
        /// Método que chama metodo cripto através do teclado.
        ///
        ///</summary>
        private void criptoButtonClick(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Enter)
            {
                cripto();
            }
        }

        ///<summary>
        /// 
        /// Método para cifrar arquivo.
        ///
        ///</summary>
        private void cripto() 
        {
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

        ///<summary>
        /// 
        /// Método que chama metodo descripto através do clique no botao descriptografar.
        ///
        ///</summary>
        private void descButtonClick(object sender, EventArgs e)
        {
            descripto();
        }

        ///<summary>
        /// 
        /// Método que chama metodo descripto através do teclado.
        ///
        ///</summary>
        private void descButtonClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                descripto();
            }
        }

        ///<summary>
        /// 
        /// Método para decifrar arquivo. 
        ///
        ///</summary>
        private void descripto() 
        {
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

        ///<summary>
        /// 
        /// Método para chamar metodo cancela através do clique no botao cancelar.
        ///
        ///</summary>
        private void cancelarButtonClick(object sender, EventArgs e)
        {
            cancela();
        }

        ///<summary>
        /// 
        /// Método para chamar metodo cancela através do teclado.
        ///
        ///</summary>
        private void cancelarButtonClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                cancela();
            }
        }

        ///<summary>
        /// 
        /// Método para cancelar a operação de armazenamento.
        ///
        ///</summary>
        private void cancela() 
        {
            DialogResult result = MessageBox.Show(MSG_CANCELAMENTO, MSG_AVISO, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                arquivos.Clear();

                MessageBox.Show(MSG_OPERACAO_CANCELADA, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }              
        }

        ///<summary>
        /// 
        /// Método para remover arquivos selecionados no dataGridView.
        ///
        ///</summary>
        private void removeArquivosSelecionados()
        {
            for (int i = 0; i < valor; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value.Equals(true))
                {
                    dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                    i--;
                    valor--;
                }
            }
        }

        ///<summary>
        /// 
        /// Método para atualizar o hashset com os arquivos selecionados.
        ///
        ///</summary>
        private void atualiza() 
        {
            arquivos.Clear();

            for (int i = 0; i < valor; i++)
            {
                arquivos.Add(dataGridView2.Rows[i].Cells[1].Value.ToString());
            }        
        }

        ///<summary>
        /// 
        /// Método para selecionar pasta destino dos arquivos.
        ///
        ///</summary>    
        private void selecionaPastaDestino()
        {
            folderBrowserDialog2.SelectedPath = "";
            folderBrowserDialog2.ShowDialog();

            if (folderBrowserDialog2.SelectedPath.Length != 0)
            {
                pastaDestino = folderBrowserDialog2.SelectedPath;
            }
        }

        ///<summary>
        /// 
        /// Metodo para armazenar arquivos selecionados localmente cifrados ou decifrados 
        /// através de uma flag.
        ///
        ///</summary>  
        private void manipulaArquivo(int flag) 
        {
            removeArquivosSelecionados();
            atualiza();
            selecionaPastaDestino();

            for (int i = 0; i < valor; i++)
            {
                String caminho;
                caminho = dataGridView2.Rows[i].Cells[1].Value.ToString();

                armazenaServlet.armazenaArquivo(caminho, pastaDestino, flag);
            }                        
        }
    }
}
