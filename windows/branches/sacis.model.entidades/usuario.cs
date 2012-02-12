/*
 * Classe para objetos do tipo Usuario 
 *
 * @author Fabio Augusto
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sacis.model.entidades
{
    public class usuario
    {
        private string _nome;
        private string _senha;
        private string _login;
        private string _chave;
        
        /**
        *
        * Métodos nome, senha, login e chave sao gets e sets usados para 
        * a serialização e deserialização do objeto em XML
        *
        */
        public string nome
        {

            get { return _nome; }

            set { _nome = value; }

        }

        public string senha
        {

            get { return _senha; }

            set { _senha = value; }

        }

        public string login
        {

            get { return _login; }

            set { _login = value; }

        }

        public string chave
        {

            get { return _chave; }

            set { _chave = value; }

        }

        /**
        *
        * Método contrutor para inicializar o objeto
        *
        */
        public usuario()
        {

            _nome = "";
            _senha = "";
            _login = "";
            _chave = "";

        }
        
        /**
        *
        * Método contrutor para inicializar o objeto
        *
        * @param name       Variavel do tipo String 
        * @param pass       Variavel do tipo String 
        * @param log        Variavel do tipo String 
        * @param key        Variavel do tipo String        
        *
        */
        public usuario(string name, string pass, string log, string key) {

            _nome = name;
            _senha = pass;
            _login = log;
            _chave = key;

        }

        /**
        *
        * Método set para o nome
        *
        * @param name       Variavel do tipo String      
        *
        */
        public void setnome(string name)
        {

            _nome = name;

        }

        /**
        *
        * Método get para o nome
        *
        * @return nome       Variavel do tipo String      
        *
        */
        public string getnome(){
        
            return _nome;
        
        }

        /**
        *
        * Método set para a senha
        *
        * @param pass       Variavel do tipo String      
        *
        */
        public void setsenha(string pass)
        {

            _senha = pass;

        }

        /**
        *
        * Método get para a senha
        *
        * @return senha       Variavel do tipo String      
        *
        */
        public string getsenha(){
        
            return _senha;
        
        }

        /**
        *
        * Método set para o login
        *
        * @param log       Variavel do tipo String      
        *
        */
        public void setlogin(string log)
        {

            _login = log;

        }

        /**
        *
        * Método get para o login
        *
        * @return login       Variavel do tipo String      
        *
        */
        public string getlogin(){
        
            return _login;
        
        }

        /**
        *
        * Método set para a chave
        *
        * @param key       Variavel do tipo String      
        *
        */
        public void setchave(string key)
        {

            _chave = key;

        }

        /**
        *
        * Método get para a chave
        *
        * @return chave       Variavel do tipo String      
        *
        */
        public string getchave(){
        
            return _chave;
        
        }

    }
}
