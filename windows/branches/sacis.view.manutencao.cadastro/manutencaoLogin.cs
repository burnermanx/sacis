///<summary>
/// Formulário de login para acessar o sistema de manutenção de usuarios
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

namespace sacis.view.manutencao.cadastro
{
    public partial class manutencaoLogin : Form
    {
        private static string MSG_ACESSO_NEGADO = "Acesso Negado!";
        private static string MSG_ERRO = "Erro";

        ///<summary>
        /// 
        /// Metodo para inicializar os componentes do formulario.
        ///
        ///</summary>
        public manutencaoLogin()
        {
            InitializeComponent();
        }

        ///<summary>
        /// 
        /// Método para chamar o metodo acessaManutencao através do clique no botao OK.
        ///
        ///</summary>
        private void okManutencaoClick(object sender, EventArgs e)
        {
            acessaManutencao();
        }

        ///<summary>
        /// 
        /// Método para chamar o metodo acessaManutencao através do teclado.
        ///
        ///</summary>
        private void okManutencaoClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                acessaManutencao();
            }
            else if (e.KeyCode == Keys.Escape) this.Close();
        }

        ///<summary>
        /// 
        /// Método para acessar formulário de manipulação de arquivos se usuario cadastrado
        ///
        ///</summary>
        private void acessaManutencao()
        {
            try
            {
                string name = loginManutencaoTextBox.Text;
                string pass = senhaManutencaoTextBox.Text;

                string hashpass = manutencaoServlet.geraHash(pass);

                if (manutencaoServlet.verificaUsuario(name, hashpass))
                {
                    manutencao newForm = new manutencao();
                    newForm.FormClosed += new FormClosedEventHandler(formVisivel);
                    this.Visible = false;
                    newForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(MSG_ACESSO_NEGADO, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpaCampos();
                }

            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpaCampos();
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
            limpaCampos();
        }

        ///<summary>
        ///
        /// Método para limpar os campos do formulário
        /// 
        ///</summary>  
        private void limpaCampos()
        {
            this.senhaManutencaoTextBox.Clear();
            this.loginManutencaoTextBox.Clear();
        }

    }
}
