///<summary>
/// Formulário inicial contendo a interface que o usuário irá utilizar,
/// para acessar as funções de armazenamento ou de gerenciamento de mensagens.
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
using sacis.view.sistema.gerenciamento.mensagem;
using sacis.view.sistema.armazenamento;

namespace sacis.view.cliente
{
    public partial class sistemaSacis : Form
    {
        ///<summary>
        /// 
        /// Metodo para inicializar os componentes do formularios.
        /// 
        ///</summary>
        public sistemaSacis()
        {
            InitializeComponent();
        }

        ///<summary>
        /// 
        /// Método para chamar formulário selecionado pelo usuário através do clique no botao OK.
        /// 
        ///</summary>
        private void clickSacis(object sender, EventArgs e)
        {
            if (sacis_combo.SelectedIndex == 0)
            {
                armazenamento();
            }
            else if (sacis_combo.SelectedIndex == 1)
            {
                gerenciamento();
            }           
        }

        ///<summary>
        /// 
        /// Método para chamar formulário selecionado pelo usuário através teclado.
        /// 
        ///</summary>
        private void clickSacis(object sender, KeyEventArgs e)
        {
            if (sacis_combo.SelectedIndex == 0 && e.KeyCode == Keys.Enter)
            {
                armazenamento();
            }
            else if (sacis_combo.SelectedIndex == 1 && e.KeyCode == Keys.Enter)
            {
                gerenciamento();
            }
            else if (e.KeyCode == Keys.Escape) this.Close();
        }

        ///<summary>
        /// 
        /// Método para chamar formulário de armazenamento.
        /// 
        ///</summary>
        private void armazenamento()
        {
            armazenamentoLogin newForm = new armazenamentoLogin();
            newForm.FormClosed += new FormClosedEventHandler(formVisivel);
            this.Visible = false;
            newForm.ShowDialog();
        }

        ///<summary>
        /// 
        /// Método para chamar formulário de login do gerenciamento de mensagens.
        /// 
        ///</summary>
        private void gerenciamento()
        {
            gerenciaLogin newForm = new gerenciaLogin();
            newForm.FormClosed += new FormClosedEventHandler(formVisivel);
            this.Visible = false;
            newForm.ShowDialog();
        }

        ///<summary>
        /// 
        /// Método para tornar o formulário visivel.
        /// 
        ///</summary>
        private void formVisivel(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }
    }
}
