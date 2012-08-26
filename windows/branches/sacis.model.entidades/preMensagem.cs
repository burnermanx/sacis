///<summary>
/// Classe para objetos do tipo preMensagem 
///
/// @author Fabio Augusto
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sacis.model.entidades
{
    public class preMensagem
    {
        private string _de;
        private string _para;
        private string _assunto;
        private string _texto;
        private bool _criptografar;
        private bool _assinar;
        private HashSet<string> _arquivoCripto;
        private HashSet<string> _arquivoPlain;

        ///<summary>
        ///
        /// Método contrutor para inicializar o objeto
        ///
        ///</summary>
        public preMensagem() { }

        ///<summary>
        ///
        /// Método contrutor para inicializar o objeto atraves de parâmetros
        ///
        ///</summary>
        public preMensagem(string from, string to, string subject, string text, bool cript, bool sign, HashSet<string> cripto, HashSet<string> plain)
        {
            _de = from;
            _para = to;
            _assunto = subject;
            _texto = text;
            _criptografar = cript;
            _assinar = sign;
            _arquivoCripto = cripto;
            _arquivoPlain = plain;
        }

        ///<summary>
        ///
        /// Método get para o remetente
        ///
        ///</summary>
        public string getDe()
        {
            return _de;
        }

        ///<summary>
        ///
        /// Método set para o remetente
        ///
        ///</summary>
        public void setDe(string from)
        {
            _de = from;
        }

        ///<summary>
        ///
        /// Método get para o destinatario
        ///
        ///</summary>
        public string getPara()
        {
            return _para;
        }

        ///<summary>
        ///
        /// Método set para o destinatario
        ///
        ///</summary>
        public void setPara(string to)
        {
            _para = to;
        }

        ///<summary>
        ///
        /// Método get para o assunto
        ///
        ///</summary>
        public string getAssunto()
        {
            return _assunto;
        }

        ///<summary>
        ///
        /// Método set para o assunto
        ///
        ///</summary>
        public void setAssunto(string subject)
        {
            _assunto = subject;
        }

        ///<summary>
        ///
        /// Método get para o texto da mensagem
        ///
        ///</summary>
        public string getTexto()
        {
            return _texto;
        }

        ///<summary>
        ///
        /// Método set para o texto da mensagem
        ///
        ///</summary>
        public void setTexto(string text)
        {
            _texto = text;
        }

        ///<summary>
        ///
        /// Método get para saber se a mensagem é criptografada
        ///
        ///</summary>
        public bool getCriptografar()
        {
            return _criptografar;
        }

        ///<summary>
        ///
        /// Método set para saber se a mensagem é criptografada
        ///
        ///</summary> 
        public void setCriptografar(bool cript)
        {
            _criptografar = cript;
        }

        ///<summary>
        ///
        /// Método get para saber se a mensagem é assinada
        ///
        ///</summary>
        public bool getAssinar()
        {
            return _assinar;
        }

        ///<summary>
        ///
        /// Método set para saber se a mensagem é assinada
        ///
        ///</summary>
        public void setAssinar(bool sign)
        {
            _assinar = sign;
        }

        ///<summary>
        ///
        /// Método get para os arquivos a serem criptografados
        ///
        ///</summary>
        public HashSet<string> getArquivoCripto()
        {
            return _arquivoCripto;
        }

        ///<summary>
        ///
        /// Método set para os arquivos a serem criptografados
        ///
        ///</summary>
        public void setArquivoCripto(HashSet<string> cripto)
        {
            _arquivoCripto = cripto;
        }

        ///<summary>
        ///
        /// Método get para os arquivos claros
        ///
        ///</summary>
        public HashSet<string> getArquivoPlain()
        {
            return _arquivoPlain;
        }

        ///<summary>
        ///
        /// Método set para os arquivos claros
        ///
        ///</summary>
        public void setArquivoPlain(HashSet<string> plain)
        {
            _arquivoPlain = plain;
        }


    }
}
