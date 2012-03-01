///<summary>
/// Classe para objetos do tipo anexo
///
/// @author Fabio Augusto
///</summary>

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

        ///<summary>
        ///
        /// Método contrutor para inicializar o objeto
        ///
        ///</summary>
        public anexo() { }

        ///<summary>
        ///
        /// Método contrutor para inicializar o objeto atraves de parâmetros
        ///
        ///</summary>
        public anexo(string nome, bool cripto, string chave, string conteudo)
        {
            _nome = nome;
            _cripto = cripto;
            _chave = chave;
            _conteudo = conteudo;
        }

        ///<summary>
        ///
        /// Métodos nome, cripto, chave e conteudo sao gets e sets usados para 
        /// a serialização e deserialização do objeto em XML
        ///
        ///</summary>
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

        ///<summary>
        ///
        /// Método get para o nome   
        ///
        ///</summary>
        public string getNome() {

            return _nome;
        }

        ///<summary>
        ///
        /// Método get para cripto   
        ///
        ///</summary>
        public bool getCripto()
        {

            return _cripto;

        }

        ///<summary>
        ///
        /// Método get para a chave   
        ///
        ///</summary>
        public string getChave()
        {

            return _chave;

        }

        ///<summary>
        ///
        /// Método get para o conteudo   
        ///
        ///</summary>
        public string getConteudo()
        {

            return _conteudo;

        }

        ///<summary>
        ///
        /// Método set para o nome   
        ///
        ///</summary>
        public void setNome(string nome) {

            _nome = nome;

        }

        ///<summary>
        ///
        /// Método set para cripto   
        ///
        ///</summary>
        public void setCripto(bool cripto)
        {
            _cripto = cripto;
        }

        ///<summary>
        ///
        /// Método set para a chave   
        ///
        ///</summary>
        public void setChave(string chave)
        {
            _chave = chave;
        }

        ///<summary>
        ///
        /// Método set para o conteudo   
        ///
        ///</summary>
        public void setConteudo(string conteudo)
        {
            _conteudo = conteudo;
        }

    }
}
