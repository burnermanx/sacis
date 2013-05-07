///<summary>
/// Implementação do formulario do catalogo pessoal
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
    public partial class catalogoPara : Form
    {
        private static string user;
        private static string MSG_ERRO = "Mensagem de Erro";
        private static string MSG_INFO = "Informação";
        private static string MSG_SELECAO = "Selecione Contato a Ser Removido!";
        private List<contato> listaAdicionar = new List<contato>();

        ///<summary>
        ///
        /// Metodo contrutor para inicializar os componentes do formulario utilizando o login do usuario
        /// 
        ///</summary>
        public catalogoPara(string usuario)
        {
            user = usuario;
            InitializeComponent();
            exibeContatos();
        }

        ///<summary>
        ///
        /// Metodo contrutor para inicializar os componentes do formulario utilizando o login do usuario
        /// e passando a lista de contatos        
        /// 
        ///</summary>
        public catalogoPara(string usuario, List<contato> lista)
        {
            user = usuario;
            listaAdicionar = lista;
            InitializeComponent();
            exibeContatos();
        }

        ///<summary>
        ///
        /// Metodo get para listaAdicionar
        ///
        ///</summary>
        public List<contato> getListaContatos()
        {

            return listaAdicionar;

        }

        ///<summary>
        ///
        /// Metodo para listar os contatos pessoais no dataGridView
        /// 
        ///</summary>
        private void exibeContatos()
        {

            try
            {
                int contador = 0;

                List<contato> lista = gerenciaServlet.buscaContatosPessoais(user);

                foreach (contato c in lista)
                {
                    catalogoPessoalDataGridView.Rows.Add(1);
                    catalogoPessoalDataGridView.Rows[contador].Cells[0].Value = c.getNome();
                    catalogoPessoalDataGridView.Rows[contador].Cells[1].Value = c.getEmail();
                    catalogoPessoalDataGridView.Rows[contador].Cells[2].Value = false;
                    contador++;
                }

                catalogoPessoalDataGridView.Visible = true;
            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        ///<summary>
        ///
        /// Metodo para o botao ok inserir na lista os contatos selecionados
        ///
        ///</summary>
        private void okButtonClick(object sender, EventArgs e)
        {
            int contagem = catalogoPessoalDataGridView.Rows.Count;
            List<contato> listaAdd = new List<contato>();

            for (int i = 0; i < contagem; i++)
            {
                if (catalogoPessoalDataGridView.Rows[i].Cells[2].Value.Equals(true))
                {
                    string nome = catalogoPessoalDataGridView.Rows[i].Cells[0].Value.ToString();
                    string email = catalogoPessoalDataGridView.Rows[i].Cells[1].Value.ToString();
                    contato contact = new contato(nome, email);
                    listaAdd.Add(contact);
                }

            }

            removeDuplicidade(listaAdd);

            this.Close();

        }

        ///<summary>
        ///
        /// Metodo para remover contatos duplicados na lista de contatos
        ///
        ///</summary>
        private void removeDuplicidade(List<contato> lista)
        {

            List<contato> listaAdd = new List<contato>();
            IEnumerable<contato> IContatos = listaAdicionar.Union<contato>(lista);

            foreach (contato c in IContatos) listaAdd.Add(c);
            listaAdicionar.Clear();
            listaAdicionar = listaAdd;

        }

        ///<summary>
        ///
        /// Metodo para o botao sair
        ///
        ///</summary>        
        private void cancelarButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
