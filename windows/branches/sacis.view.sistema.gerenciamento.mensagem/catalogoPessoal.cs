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
    public partial class catalogoPessoal : Form
    {
        private static string user;
        private static string MSG_ERRO = "Mensagem de Erro";
        private static string MSG_INFO = "Informação";
        private static string MSG_REMOCAO_OK = "Contatos Removidos com Sucesso!";
        private static string MSG_SELECAO = "Selecione Contato a Ser Removido!";
        private List<contato> listaAdicionar = new List<contato>();

        ///<summary>
        ///
        /// Metodo contrutor _para inicializar os componentes do formulario
        ///
        /// @param usuario        Variavel do tipo string
        /// 
        ///</summary>
        public catalogoPessoal(string usuario)
        {
            user = usuario;
            InitializeComponent();
            exibeContatos();
        }

        ///<summary>
        ///
        /// Metodo contrutor _para inicializar os componentes do formulario
        ///
        /// @param usuario        Variavel do tipo string
        /// @paran lista          Variavel do tipo List<contato>
        /// 
        ///</summary>
        public catalogoPessoal(string usuario, List<contato> lista)
        {
            user = usuario;
            listaAdicionar = lista;
            InitializeComponent();
            exibeContatos();
        }

        ///<summary>
        ///
        /// Metodo get _para listaAdicionar
        ///
        /// @param List<contato>        Lista _de contatos
        /// 
        ///</summary>
        public List<contato> getListaContatos() {

            return listaAdicionar;
        
        }

        ///<summary>
        ///
        /// Metodo _para listar os contatos pessoais no dataGridView
        /// 
        ///</summary>
        private void exibeContatos() {
                        
            try
            {
                int contador = 0;

                List<contato> lista = gerenciaServlet.buscaContatosPessoais(user);

                foreach (contato c in lista)
                {
                    catalogoPessoal_dataGridView.Rows.Add(1);
                    catalogoPessoal_dataGridView.Rows[contador].Cells[0].Value = c.getNome();
                    catalogoPessoal_dataGridView.Rows[contador].Cells[1].Value = c.getEmail();
                    catalogoPessoal_dataGridView.Rows[contador].Cells[2].Value = false;
                    catalogoPessoal_dataGridView.Rows[contador].Cells[3].Value = false;
                    contador++;
                }

                catalogoPessoal_dataGridView.Visible = true;
            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }        
        }

        ///<summary>
        ///
        /// Metodo _para o botao ok
        ///
        /// @param sender        Objeto com os dados do formulário
        /// @param e             Objeto base _para classes que contém dados _de evento
        ///
        ///</summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            int contagem = catalogoPessoal_dataGridView.Rows.Count;
            List<contato> listaAdd = new List<contato>();

            for (int i = 0; i < contagem; i++)
            {
                if (catalogoPessoal_dataGridView.Rows[i].Cells[2].Value.Equals(true))
                {
                    string nome = catalogoPessoal_dataGridView.Rows[i].Cells[0].Value.ToString();
                    string email = catalogoPessoal_dataGridView.Rows[i].Cells[1].Value.ToString();
                    contato contact = new contato(nome, email);
                    listaAdd.Add(contact);                
                }

            }
                                    
            removeDuplicidade(listaAdd);

            this.Close();

        }

        ///<summary>
        ///
        /// Metodo _para remover contatos duplicados na lista _de contatos
        ///
        /// @param lista        Variável do tipo List<contato>
        ///
        ///</summary>
        private void removeDuplicidade(List<contato> lista) {

            List<contato> listaAdd = new List<contato>();
            IEnumerable<contato> IContatos = listaAdicionar.Union<contato>(lista);
            
            foreach (contato c in IContatos) listaAdd.Add(c);
            listaAdicionar.Clear();
            listaAdicionar = listaAdd;

        }

        ///<summary>
        ///
        /// Metodo _para o botao sair
        ///
        /// @param sender        Objeto com os dados do formulário
        /// @param e             Objeto base _para classes que contém dados _de evento
        ///
        ///</summary>        
        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ///<summary>
        ///
        /// Metodo _para o botao remover
        ///
        /// @param sender        Objeto com os dados do formulário
        /// @param e             Objeto base _para classes que contém dados _de evento
        ///
        ///</summary>
        private void remover_botao_Click(object sender, EventArgs e)
        {
            try
            {
                bool vazio = true;
                int contagem = catalogoPessoal_dataGridView.Rows.Count;
                List<contato> lista = new List<contato>();
                List<int> cels = new List<int>();

                for (int i = 0; i < contagem; i++)
                {
                    if (catalogoPessoal_dataGridView.Rows[i].Cells[3].Value.Equals(false))
                    {
                        string nome = catalogoPessoal_dataGridView.Rows[i].Cells[0].Value.ToString();
                        string email = catalogoPessoal_dataGridView.Rows[i].Cells[1].Value.ToString();
                        contato contact = new contato(nome, email);
                        lista.Add(contact);
                    }
                    else if (catalogoPessoal_dataGridView.Rows[i].Cells[3].Value.Equals(true))
                    {
                        cels.Add(i);
                        vazio = false;                        
                    }
                }

                cels.Reverse();

                foreach (int i in cels) catalogoPessoal_dataGridView.Rows.Remove(catalogoPessoal_dataGridView.Rows[i]);

                catalogoPessoal_dataGridView.Refresh();                
                
                if (vazio) MessageBox.Show(MSG_SELECAO, MSG_INFO, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (gerenciaServlet.removeContatos(lista, user)) MessageBox.Show(MSG_REMOCAO_OK, MSG_INFO, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (excecao except)
            {
                MessageBox.Show(except.Message, MSG_ERRO, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }
    }
}
