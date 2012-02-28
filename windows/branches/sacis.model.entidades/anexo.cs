using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sacis.model.entidades
{
    public class anexo
    {

        private string _nome;
        private bool _cripto;
        private string _chave;
        private string _conteudo;

        public anexo() { }

        public anexo(string nome, bool cripto, string chave, string conteudo)
        {
            _nome = nome;
            _cripto = cripto;
            _chave = chave;
            _conteudo = conteudo;
        }

        public string nome
        {

            get { return _nome; }

            set { _nome = value; }

        }

        public bool cripto
        {

            get { return _cripto; }

            set { _cripto = value; }

        }

        public string chave
        {

            get { return _chave; }

            set { _chave = value; }

        }

        public string conteudo
        {

            get { return _conteudo; }

            set { _conteudo = value; }

        }

        public string getNome() {

            return _nome;
        }

        public bool getCripto()
        {

            return _cripto;

        }

        public string getChave()
        {

            return _chave;

        }

        public string getConteudo()
        {

            return _conteudo;

        }

        public void setNome(string nome) {

            _nome = nome;

        }

        public void setCripto(bool cripto)
        {
            _cripto = cripto;
        }

        public void setChave(string chave)
        {
            _chave = chave;
        }

        public void setConteudo(string conteudo)
        {
            _conteudo = conteudo;
        }

    }
}
