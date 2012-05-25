///<summary>
/// Formulário inicial contendo a interface que o usuário irá utilizar,
/// para acessar as funções do administrador ou do cliente.
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
using sacis.view.cliente;

namespace inicio{

    public partial class inicio : Form
    {
        ///<summary>
        ///
        /// Metodo para inicializar os componentes do formularios
        ///
        ///</summary>
        public inicio(){

            InitializeComponent();

        }

        ///<summary>
        ///
        /// Método para chamar formulário selecionado pelo usuário através do clique no botao OK
        ///
        ///</summary>
        private void clickInicial(object sender, EventArgs e)
        {
            if (comboBox_inicial.SelectedIndex == 1)
            {
                cliente();
            } 
            else if (comboBox_inicial.SelectedIndex == 0)
            {
                manutencao();
            } 
        }

        ///<summary>
        ///
        /// Método para chamar formulário selecionado pelo usuário através do teclado
        ///
        ///</summary>
        private void clickInicial(object sender, KeyEventArgs e)
        {
            if (comboBox_inicial.SelectedIndex == 1 && e.KeyCode == Keys.Enter)
            {
                cliente();
            } 
            else if (comboBox_inicial.SelectedIndex == 0 && e.KeyCode == Keys.Enter)
            {
                manutencao();
            } 
            else if (e.KeyCode == Keys.Escape) this.Close();            
        }

        ///<summary>
        ///
        /// Método para chamar formulário de manutenção
        ///
        ///</summary>
        private void manutencao() 
        {
            sacis.view.manutencao.cadastro.cadastro newForm = new sacis.view.manutencao.cadastro.cadastro();
            newForm.FormClosed += new FormClosedEventHandler(formVisivel);
            this.Visible = false;
            newForm.ShowDialog();        
        }

        ///<summary>
        ///
        /// Método para chamar formulário de cliente
        ///
        ///</summary>
        private void cliente() 
        {
            sistema_sacis newForm = new sistema_sacis();
            newForm.FormClosed += new FormClosedEventHandler(formVisivel);
            this.Visible = false;
            newForm.ShowDialog();             
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
    }
}
