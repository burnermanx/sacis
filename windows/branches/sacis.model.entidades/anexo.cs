using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sacis.model.entidades
{
    public class anexo
    {

        private string _nome;
        private string _conteudo;

        public anexo() { }

        public anexo(string nome, string conteudo)
        {
            _nome = nome;
            _conteudo = conteudo;
        }

        public string nome
        {

            get { return _nome; }

            set { _nome = value; }

        }

        public string conteudo
        {

            get { return _conteudo; }

            set { _conteudo = value; }

        }

        public string getNome() {

            return _nome;
        }

        public string getConteudo() {

            return _conteudo;
        
        }

        public void setNome(string nome) {

            _nome = nome;

        }

        public void setConteudo(string conteudo)
        {
            _conteudo = conteudo;
        }

    }
}
