using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sacis.view.sistema.gerenciamento.mensagem
{
    public partial class gerenciaChave : Form
    {
        private string caminho;

        public string getCaminho()
        {
            return caminho;
        }

        public gerenciaChave()
        {
            InitializeComponent();
        }

        private void selecionarButton(object sender, EventArgs e)
        {
            chave.ShowDialog();
            chaveTextBox.Text = chave.FileName;
            
        }

        private void okButton(object sender, EventArgs e)
        {
            caminho = chaveTextBox.Text;
            this.Close();
        }
    }
}
