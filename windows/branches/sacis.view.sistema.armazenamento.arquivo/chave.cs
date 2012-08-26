///<summary>
/// Formulário contendo a interface que o usuario irá utilizar para informar a frase senha a 
/// ser utilizada na criptografia ou descriptografia dos arquivos.
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

namespace sacis.view.sistema.armazenamento
{
    public partial class chave : Form
    {
        private static string MSG_INVALIDO = "Digite uma senha valida com 32 caracteres!";
        private static string MSG_AVISO = "Mensagem de Aviso!";
        private static string frase;
        
        ///<summary>
        /// 
        /// Metodo para inicializar os componentes do formulario
        ///
        ///</summary>  
        public chave()
        {
            InitializeComponent();
        }
        
        ///<summary>
        /// 
        /// Metodo para chamar o metodo confereChave atraves do botao OK
        ///
        ///</summary>  
        private void botaoOKClick(object sender, EventArgs e)
        {

            confereChave();

        }

        ///<summary>
        /// 
        /// Metodo para chamar o metodo confereChave atraves do teclado
        ///
        ///</summary>  
        private void botaoOKClick(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                confereChave();
            }

        }

        ///<summary>
        /// 
        /// Metodo para conferir o tamanho da chave passada
        ///
        ///</summary>  
        private void confereChave() {

            if (chaveTextBox.TextLength == 32)
            {

                frase = chaveTextBox.Text;
                this.Close();

            }
            else {

                MessageBox.Show(MSG_INVALIDO, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                chaveTextBox.Clear();
                            
            }                             
        
        }

        ///<summary>
        /// 
        /// Metodo get para frase
        ///
        ///</summary>  
        public string getChave(){
        
            return frase;
        
        }

    }
}
