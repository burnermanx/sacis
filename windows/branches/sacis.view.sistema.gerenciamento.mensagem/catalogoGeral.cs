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
        /// Metodo contrutor _para inicializar os componentes do formulario
        ///
        /// @param usuario        Variavel do tipo string
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
        /// Metodo _para exibir os contatos no DataGridView _de catalogo geral
        ///
        ///</summary>
        private void exibeContatos() {

            try
            {
                int contador = 0;

                List<contato> contatos = gerenciaServlet.buscaContatosGeral();

                foreach (contato c in contatos)
                {
                    catalogo_DataGridView.Rows.Add(1);
                    catalogo_DataGridView.Rows[contador].Cells[0].Value = c.getNome();
                    catalogo_DataGridView.Rows[contador].Cells[1].Value = c.getEmail();
                    catalogo_DataGridView.Rows[contador].Cells[2].Value = false;
                    contador++;
                }

                catalogo_DataGridView.Visible = true;
            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Information);          
            }
        }

        ///<summary>
        ///
        /// Metodo _para o botao Adicionar
        ///
        /// @param sender        Objeto com os dados do formulário
        /// @param e             Objeto base _para classes que contém dados _de evento
        ///
        ///</summary>
        private void adicionaBotao_Click(object sender, EventArgs e)
        {
            try
            {
                int contagem = catalogo_DataGridView.Rows.Count;
                List<contato> lista = new List<contato>();

                for (int i = 0; i < contagem; i++)
                {

                    if (catalogo_DataGridView.Rows[i].Cells[2].Value.Equals(true))
                    {
                        string nome = catalogo_DataGridView.Rows[i].Cells[0].Value.ToString();
                        string email = catalogo_DataGridView.Rows[i].Cells[1].Value.ToString();
                        contato contact = new contato(nome, email);
                        lista.Add(contact);
                    }
                }

                if (gerenciaServlet.insereContatos(lista, user)) MessageBox.Show(MSG_ADICIONAR, MSG_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information);

                for (int i = 0; i < contagem; i++)
                {
                    catalogo_DataGridView.Rows[i].Cells[2].Value = false;
                }
            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }           
        }

        ///<summary>
        ///
        /// Metodo _para o botao Cancelar
        ///
        /// @param sender        Objeto com os dados do formulário
        /// @param e             Objeto base _para classes que contém dados _de evento
        ///
        ///</summary>
        private void cancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
