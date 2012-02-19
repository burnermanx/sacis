/*
 * Classe para objetos do tipo mensagem 
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
        private string de;
        private string para;
        private string assunto;
        private string texto;
        private bool criptografar;
        private bool assinar;
        private HashSet<string> arquivoCripto;
        private HashSet<string> arquivoPlain;

        /**
        *
        * Método contrutor para inicializar o objeto
        *
        */
        public mensagemNovo(string from, string to, string subject, string text, bool cript, bool sign, HashSet<string> cripto, HashSet<string> plain) {

            de = from;
            para = to;
            assunto = subject;
            texto = text;
            criptografar = cript;
            assinar = sign;
            arquivoCripto = cripto;
            arquivoPlain = plain;
        
        }

        /**
        *
        * Método get para a variavel de
        *
        * @return de       Variavel do tipo String      
        *
        */
        public string getDe(){

            return de;

        }

        /**
        *
        * Método set para a variavel de
        *
        * @param from       Variavel do tipo String      
        *
        */
        public void setDe(string from)
        {

            de = from;

        }

        /**
        *
        * Método get para a variavel para
        *
        * @return para       Variavel do tipo String      
        *
        */
        public string getPara()
        {

            return para;

        }

        /**
        *
        * Método set para a variavel para
        *
        * @param to       Variavel do tipo String      
        *
        */
        public void setPara(string to)
        {

            para = to;

        }

        /**
        *
        * Método get para a variavel assunto
        *
        * @return assunto       Variavel do tipo String      
        *
        */
        public string getAssunto()
        {

            return assunto;

        }

        /**
        *
        * Método set para a variavel assunto
        *
        * @param subject       Variavel do tipo String      
        *
        */
        public void setAssunto(string subject)
        {

            assunto = subject;

        }

        /**
        *
        * Método get para a variavel texto
        *
        * @return texto       Variavel do tipo String      
        *
        */
        public string getTexto()
        {

            return texto;

        }

        /**
        *
        * Método set para a variavel texto
        *
        * @param text       Variavel do tipo String      
        *
        */
        public void setTexto(string text)
        {

            texto = text;

        }

        /**
        *
        * Método get para a variavel criptografar
        *
        * @return criptografar       Variavel do tipo bool      
        *
        */
        public bool getCriptografar()
        {

            return criptografar;

        }

        /**
        *
        * Método set para a variavel criptografar
        *
        * @param cript       Variavel do tipo bool      
        *
        */
        public void setCriptografar(bool cript)
        {

            criptografar = cript;

        }

        /**
        *
        * Método get para a variavel assinar
        *
        * @return assinar       Variavel do tipo bool      
        *
        */
        public bool getAssinar()
        {

            return assinar;

        }

        /**
        *
        * Método set para a variavel assinar
        *
        * @param sign       Variavel do tipo bool      
        *
        */
        public void setAssinar(bool sign)
        {

            assinar = sign;

        }

        /**
        *
        * Método get para a variavel arquivoCripto
        *
        * @return arquivoCripto       Variavel do tipo HashSet<string>      
        *
        */
        public HashSet<string> getArquivoCripto()
        {

            return arquivoCripto;

        }

        /**
        *
        * Método set para a variavel arquivoCripto
        *
        * @param arquivoCripto       Variavel do tipo HashSet<string>      
        *
        */
        public void setArquivoCripto(HashSet<string> cripto)
        {

            arquivoCripto = cripto;

        }

        /**
        *
        * Método get para a variavel arquivoPlain
        *
        * @return arquivoPlain       Variavel do tipo HashSet<string>      
        *
        */
        public HashSet<string> getArquivoPlain()
        {

            return arquivoPlain;

        }

        /**
        *
        * Método set para a variavel arquivoPlain
        *
        * @param arquivoPlain       Variavel do tipo HashSet<string>      
        *
        */
        public void setArquivoPlain(HashSet<string> plain)
        {

            arquivoPlain = plain;

        }


    }
}
