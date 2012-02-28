﻿/*
 * Classe para objetos do tipo mensagem nova 
 *
 * @author Fabio Augusto
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sacis.model.entidades
{
    public class mensagemNovo
    {
        private string _de;
        private string _para;
        private string _assunto;
        private string _texto;
        private bool _criptografar;
        private bool _assinar;


        ///<summary>
        ///
        /// Métodos de, para, texto, criptografar, assinar, arquivoCripto e arquivoPlain
        /// sao gets e sets usados para a serialização e deserialização do objeto em XML
        ///
        ///</summary>
        public string de
        {
            get { return _de; }
            set { _de = value; }
        }

        public string para
        {
            get { return _para; }
            set { _para = value; }
        }

        public string assunto
        {
            get { return _assunto; }
            set { _assunto = value; }
        }

        public string texto
        {
            get { return _texto; }
            set { _texto = value; }
        }
        
        public bool criptografar
        {
            get { return _criptografar; }
            set { _criptografar = value; }
        }

        public bool assinar
        {
            get { return _assinar; }
            set { _assinar = value; }
        }


        ///<summary>
        ///
        /// Método contrutor para inicializar o objeto
        ///
        ///</summary>
        public mensagemNovo() { }

        /**
        *
        * Método contrutor para inicializar o objeto
        *
        */
        public mensagemNovo(string from, string to, string subject, string text, bool cript, bool sign, HashSet<string> cripto, HashSet<string> plain) {

            _de = from;
            _para = to;
            _assunto = subject;
            _texto = text;
            _criptografar = cript;
            _assinar = sign;
        
        }

        /**
        *
        * Método get para a variavel _de
        *
        * @return _de       Variavel do tipo String      
        *
        */
        public string getDe(){

            return _de;

        }

        /**
        *
        * Método set para a variavel _de
        *
        * @param from       Variavel do tipo String      
        *
        */
        public void setDe(string from)
        {

            _de = from;

        }

        /**
        *
        * Método get para a variavel _para
        *
        * @return _para       Variavel do tipo String      
        *
        */
        public string getPara()
        {

            return _para;

        }

        /**
        *
        * Método set para a variavel _para
        *
        * @param to       Variavel do tipo String      
        *
        */
        public void setPara(string to)
        {

            _para = to;

        }

        /**
        *
        * Método get para a variavel _assunto
        *
        * @return _assunto       Variavel do tipo String      
        *
        */
        public string getAssunto()
        {

            return _assunto;

        }

        /**
        *
        * Método set para a variavel _assunto
        *
        * @param subject       Variavel do tipo String      
        *
        */
        public void setAssunto(string subject)
        {

            _assunto = subject;

        }

        /**
        *
        * Método get para a variavel _texto
        *
        * @return _texto       Variavel do tipo String      
        *
        */
        public string getTexto()
        {

            return _texto;

        }

        /**
        *
        * Método set para a variavel _texto
        *
        * @param text       Variavel do tipo String      
        *
        */
        public void setTexto(string text)
        {

            _texto = text;

        }

        /**
        *
        * Método get para a variavel _criptografar
        *
        * @return _criptografar       Variavel do tipo bool      
        *
        */
        public bool getCriptografar()
        {

            return _criptografar;

        }

        /**
        *
        * Método set para a variavel _criptografar
        *
        * @param cript       Variavel do tipo bool      
        *
        */
        public void setCriptografar(bool cript)
        {

            _criptografar = cript;

        }

        /**
        *
        * Método get para a variavel _assinar
        *
        * @return _assinar       Variavel do tipo bool      
        *
        */
        public bool getAssinar()
        {

            return _assinar;

        }

        /**
        *
        * Método set para a variavel _assinar
        *
        * @param sign       Variavel do tipo bool      
        *
        */
        public void setAssinar(bool sign)
        {

            _assinar = sign;

        }




    }
}
