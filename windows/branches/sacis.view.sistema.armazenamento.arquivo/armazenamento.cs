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
using sacis.view.control;
using sacis.model.excecao;

namespace sacis.view.sistema.armazenamento
{
    public partial class armazenamento : Form
    {

        private static string MSG_CANCELAMENTO = "Deseja Realmente Cancelar o Armazenamento?";
        private static string MSG_AVISO = "Mensagem de Aviso!";
        private static string MSG_ERRO = "Mensagem de Erro!";
        private static string MSG_EXCLUSAO = "Mensagem de Exclusão!";
        private static string MSG_OPERACAO_CANCELADA = "Operação Cancelada";
        private static string MSG_CRIPTO = "Criptografia Realizada com Sucesso!";
        private static string MSG_DESCRIPTO = "Descriptografia Realizada com Sucesso!";
        private static string MSG_REMOCAO = "Deseja realmente remover esse arquivo da lista";
        private static string MSG_SELECAO = "Selecione pelo menos um arquivo!";
        private static HashSet<string> arquivosCripto = new HashSet<string>();
        private static HashSet<string> arquivosDescripto = new HashSet<string>();
        private static int valorCripto, valorDescripto;
        private static String pastaDestino;
        private static DialogResult resultado;
                
        ///<summary>
        /// 
        /// Metodo para inicializar os componentes do formulario
        ///
        ///</summary>  
        public armazenamento()
        {
            InitializeComponent();
        }
       
        ///<summary>
        /// 
        /// Método que chama metodo selecionaArquivos através do clique no botao selecionar arquivos.
        ///
        ///</summary>  
        private void selecionarButtonClick(object sender, EventArgs e)
        {

            selecionaArquivos();

        }

        ///<summary>
        /// 
        /// Método para selecionar os arquivos e chamar metodo para inserir
        /// no dataGridView
        ///
        ///</summary>
        private void selecionaArquivos() {
            
            resultado = anexar.ShowDialog();

            if (resultado.Equals(DialogResult.OK) && tabArmazena.SelectedIndex == 0)
            {

                insereCriptoDataGridView();

            }
            else if (resultado.Equals(DialogResult.OK) && tabArmazena.SelectedIndex == 1)
            {

                insereDescriptoDataGridView();

            }
        }
        
        ///<summary>
        /// 
        /// Método para inserir arquivos selecionados no dataGridView na aba de criptografia.
        ///
        ///</summary>
        private void insereCriptoDataGridView() {

            foreach (String file in anexar.FileNames)
            {
                if (arquivosCripto.Add(file))
                {
                    criptoDataGridView.Rows.Add(1);
                    criptoDataGridView.Rows[valorCripto].Cells[0].Value = file;
                    valorCripto++;
                }
            }
        
        }

        ///<summary>
        /// 
        /// Método para inserir arquivos selecionados no dataGridView na aba de descriptografia.
        ///
        ///</summary>
        private void insereDescriptoDataGridView()
        {

            foreach (String file in anexar.FileNames)
            {
                if (arquivosDescripto.Add(file))
                {
                    descriptoDataGridView.Rows.Add(1);
                    descriptoDataGridView.Rows[valorDescripto].Cells[0].Value = file;
                    valorDescripto++;
                }
            }

        }

        ///<summary>
        /// 
        /// Método para remover arquivo selecionado no dataGridView atraves do clique na lixeira.
        /// 
        ///</summary>
        private void removerArquivoLista(object sender, MouseEventArgs e)
        {

            int linha;
            int coluna;
            
            try{

                if (tabArmazena.SelectedIndex == 0)
                {
                    linha = Convert.ToInt16(criptoDataGridView.SelectedCells[0].RowIndex.ToString());
                    coluna = Convert.ToInt16(criptoDataGridView.SelectedCells[0].ColumnIndex.ToString());
                   
                    if (coluna == 1) removeListaCripto(linha);

                    if (valorCripto == 0) limpaCamposCripto();
                
                }
                else if (tabArmazena.SelectedIndex == 1)
                {
                    linha = Convert.ToInt16(descriptoDataGridView.SelectedCells[0].RowIndex.ToString());
                    coluna = Convert.ToInt16(descriptoDataGridView.SelectedCells[0].ColumnIndex.ToString());
                    
                    if (coluna == 1) removeListaDescripto(linha);

                    if (valorDescripto == 0) limpaCamposDescripto();

                }

            } catch (ArgumentOutOfRangeException arg){
            
            }
           
        }

        ///<summary>
        /// 
        /// Método que remove arquivo selecionado do dataGridView na aba de criptografia.
        ///
        ///</summary>
        private void removeListaCripto(int linha) {

            DialogResult resultado = MessageBox.Show(MSG_REMOCAO, MSG_EXCLUSAO, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                criptoDataGridView.Rows.Remove(criptoDataGridView.Rows[linha]);
                valorCripto--;                
            }
            
            limpaListaCripto();

        }

        ///<summary>
        /// 
        /// Método que remove arquivo selecionado do dataGridView na aba de descriptografia.
        ///
        ///</summary>
        private void removeListaDescripto(int linha)
        {
            DialogResult resultado = MessageBox.Show(MSG_REMOCAO, MSG_EXCLUSAO, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                descriptoDataGridView.Rows.Remove(descriptoDataGridView.Rows[linha]);
                valorDescripto--;                
            }

            limpaListaDescripto();

        }

        ///<summary>
        /// 
        /// Método que limpa seleção no dataGridView na aba de criptografia.
        ///
        ///</summary>
        private void limpaListaCripto() {

            criptoDataGridView.ClearSelection();
           
        }

        ///<summary>
        /// 
        /// Método que limpa seleção no dataGridView na aba de descriptografia.
        ///
        ///</summary>
        private void limpaListaDescripto() {

            descriptoDataGridView.ClearSelection();

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
            if (e.KeyCode == Keys.Escape)
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
                MessageBox.Show(MSG_OPERACAO_CANCELADA, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        
        ///<summary>
        /// 
        /// Método que chama metodo captura arquivos através do clique no botao ok.
        ///
        ///</summary> 
        private void okButtonClick(object sender, EventArgs e)
        {

            okCaptura();

        }

        ///<summary>
        /// 
        /// Método para chamar metodo de cripto ou descripto
        ///
        ///</summary> 
        private void okCaptura() {

            if (criptoDataGridView.RowCount > 0 && tabArmazena.SelectedIndex == 0)
            {
                
                cripto();
                limpaCamposCripto();
                
            }
            else if (descriptoDataGridView.RowCount > 0 && tabArmazena.SelectedIndex == 1)
            {
                
                descripto();
                limpaCamposDescripto();

            } else {
            
                MessageBox.Show(MSG_SELECAO, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
            }          

        }

        ///<summary>
        /// 
        /// Método para selecionar pasta destino dos arquivos
        ///
        ///</summary>    
        private void selecionaDestino()
        {
            selecionaPastaDestino.SelectedPath = "";
            selecionaPastaDestino.ShowDialog();
            
            if (selecionaPastaDestino.SelectedPath.Length > 0)
            {
                pastaDestino = selecionaPastaDestino.SelectedPath;
            }
        }

        ///<summary>
        /// 
        /// Metodo que retorna a chave escolhida pelo usuario para cifrar ou decifrar o arquivo 
        ///
        ///</summary>  
        private string chave() {

            chave newForm = new chave();
            newForm.FormClosed += new FormClosedEventHandler(formVisivel);
            newForm.ShowDialog();
            
            return newForm.getChave();
        
        }

        ///<summary>
        /// 
        /// Metodo que passa os parametros caminho destino, origem e a chave do usuario para o metodo
        /// de criptografia de arquivo
        ///
        ///</summary>  
        private void cripto() {

            try
            {

                string frase = chave();
                selecionaDestino();

                for (int i = 0; i < valorCripto; i++)
                {
                    string caminho = criptoDataGridView.Rows[i].Cells[0].Value.ToString();
                    armazenaServlet.criptoArquivo(caminho, pastaDestino, frase);
                }

                MessageBox.Show(MSG_CRIPTO, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   

        }

        ///<summary>
        /// 
        /// Metodo que passa os parametros caminho destino, origem e a chave do usuario para o metodo
        /// de descriptografia de arquivo
        ///
        ///</summary> 
        private void descripto(){

            try
            {                
                for (int i = 0; i < valorDescripto; i++)
                {
                    string frase = chave();
                    selecionaDestino();
                    string caminho = descriptoDataGridView.Rows[i].Cells[0].Value.ToString();
                    armazenaServlet.descriptoArquivo(caminho, pastaDestino, frase);
                }
                
                MessageBox.Show(MSG_DESCRIPTO, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  

        }
        
        ///<summary>
        ///
        /// Método para tornar o formulário visivel
        ///
        ///</summary>
        private void formVisivel(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
          
        }

        ///<summary>
        ///
        /// Método para reiniciar as variaveis referentes a criptografia
        ///
        ///</summary>
        private void limpaCamposCripto() {

            criptoDataGridView.Rows.Clear();            
            arquivosCripto.Clear();
            valorCripto = 0;
        
        }

        ///<summary>
        ///
        /// Método para reiniciar as variaveis referentes a descriptografia
        ///
        ///</summary>
        private void limpaCamposDescripto()
        {

            descriptoDataGridView.Rows.Clear();
            arquivosDescripto.Clear();
            valorDescripto = 0;

        }

    }
}
