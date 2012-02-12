﻿/*
 * Formulário inicial contendo a interface que o usuário irá utilizar,
 * para acessar as funções do administrador ou do cliente.
 *
 * @author Fabio Augusto
 */

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

    public partial class form_inicial : Form{

        /**
        *
        * Metodo para inicializar os componentes do formularios
        *
        */
        public form_inicial(){

            InitializeComponent();

        }

        /**
        *
        * Método para chamar formulário selecionado pelo usuário através do clique no botao OK
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base para classes que contém dados de evento
        *
        */
        private void click_inicial(object sender, EventArgs e){

            if (comboBox_inicial.SelectedIndex == 1){

                cliente();

            } else if (comboBox_inicial.SelectedIndex == 0)
            {

                manutencao();

            } 

        }

        /**
        *
        * Método para chamar formulário selecionado pelo usuário através do teclado
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base contendo a tecla acionada no evento.
        *
        */
        private void click_inicial(object sender, KeyEventArgs e){

            if (comboBox_inicial.SelectedIndex == 1 && e.KeyCode == Keys.Enter){

                cliente();


            } else if (comboBox_inicial.SelectedIndex == 0 && e.KeyCode == Keys.Enter)
            {

                manutencao();

            } else if (e.KeyCode == Keys.Escape) this.Close();
            
        }

        /**
        *
        * Método para chamar formulário de manutenção
        *
        */
        private void manutencao() {

            sacis.view.manutencao.cadastro.cadastro newForm = new sacis.view.manutencao.cadastro.cadastro();
            newForm.FormClosed += new FormClosedEventHandler(form_visivel);
            this.Visible = false;
            newForm.ShowDialog();
        
        }

        /**
        *
        * Método para chamar formulário de cliente
        *
        */
        private void cliente() {

            sistema_sacis newForm = new sistema_sacis();
            newForm.FormClosed += new FormClosedEventHandler(form_visivel);
            this.Visible = false;
            newForm.ShowDialog();        
        
        }

        /**
        *
        * Método para tornar o formulário visivel
        *
        * @param sender        Objeto com os dados do formulário
        * @param e             Objeto base contendo a tecla acionada no evento.
        *
        */
        private void form_visivel(object sender, FormClosedEventArgs e){

            this.Visible = true;

        }

    }
}
