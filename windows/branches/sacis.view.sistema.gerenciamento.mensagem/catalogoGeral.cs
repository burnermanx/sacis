///<summary>
/// Implementação do formulario do catalogo geral
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
using sacis.model.entidades;
using sacis.view.control;
using sacis.model.excecao;

namespace sacis.view.sistema.gerenciamento.mensagem
{
    public partial class catalogoGeral : Form
    {

        private static string MSG_ADICIONAR = "Contatos Adicionados!";
        private static string MSG_AVISO = "Mensagem de Aviso";
        private static string MSG_ERRO = "Mensagem de Erro";
        private static string user;

        ///<summary>
        ///
        /// Metodo contrutor para inicializar os componentes do formulario utilizando o login do usuario
        /// 
        ///</summary>
        public catalogoGeral(string usuario)
        {
            user = usuario;
            InitializeComponent();
            exibeContatos();

        }

        ///<summary>
        ///
        /// Metodo para exibir os contatos no DataGridView do catalogo geral
        ///
        ///</summary>
        private void exibeContatos() {

            try
            {
                int contador = 0;

                List<contato> contatos = gerenciaServlet.buscaContatosGeral();

                foreach (contato c in contatos)
                {
                    catalogoDataGridView.Rows.Add(1);
                    catalogoDataGridView.Rows[contador].Cells[0].Value = c.getNome();
                    catalogoDataGridView.Rows[contador].Cells[1].Value = c.getEmail();
                    catalogoDataGridView.Rows[contador].Cells[2].Value = false;
                    contador++;
                }

                catalogoDataGridView.Visible = true;
            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Information);          
            }
        }

        ///<summary>
        ///
        /// Método para adicionar contatos através do clique no botão Adicionar.
        ///
        ///</summary>
        private void adicionaBotaoClick(object sender, EventArgs e)
        {
            try
            {
                int contagem = catalogoDataGridView.Rows.Count;
                List<contato> lista = new List<contato>();

                for (int i = 0; i < contagem; i++)
                {

                    if (catalogoDataGridView.Rows[i].Cells[2].Value.Equals(true))
                    {
                        string nome = catalogoDataGridView.Rows[i].Cells[0].Value.ToString();
                        string email = catalogoDataGridView.Rows[i].Cells[1].Value.ToString();
                        contato contact = new contato(nome, email);
                        lista.Add(contact);
                    }
                }

                if (gerenciaServlet.insereContatosPessoal(lista, user)) MessageBox.Show(MSG_ADICIONAR, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);

                for (int i = 0; i < contagem; i++)
                {
                    catalogoDataGridView.Rows[i].Cells[2].Value = false;
                }
            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }           
        }

        ///<summary>
        ///
        /// Método para cancelar a adição de contatos através do botão Cancelar.
        ///
        ///</summary>
        private void cancelaClick(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
