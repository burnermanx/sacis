///<summary>
/// Classe para objetos do tipo Usuario
///
/// @author Fabio Augusto
///</summary>

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
        
        ///<summary>
        ///
        /// Métodos nome, senha, login e chave sao gets e sets usados _para 
        /// a serialização e deserialização do objeto em XML
        ///
        ///</summary>
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

        ///<summary>
        ///
        /// Método contrutor para inicializar o objeto        
        ///
        ///</summary>
        public usuario()
        {

            _nome = "";
            _senha = "";
            _login = "";
            _chave = "";

        }
        
        ///<summary>
        ///
        /// Método contrutor para inicializar o objeto atraves de parâmetros
        ///
        ///</summary>
        public usuario(string name, string pass, string log, string key) {

            _nome = name;
            _senha = pass;
            _login = log;
            _chave = key;

        }

        ///<summary>
        ///
        /// Método set para o nome      
        /// 
        ///</summary>
        public void setnome(string name)
        {

            _nome = name;

        }

        ///<summary>
        ///
        /// Método get para o nome      
        /// 
        ///</summary>
        public string getnome(){
        
            return _nome;
        
        }

        ///<summary>
        ///
        /// Método set para a senha     
        /// 
        ///</summary>
        public void setsenha(string pass)
        {

            _senha = pass;

        }

        ///<summary>
        ///
        /// Método get para a senha     
        /// 
        ///</summary>
        public string getsenha(){
        
            return _senha;
        
        }

        ///<summary>
        ///
        /// Método set para o login     
        /// 
        ///</summary>
        public void setlogin(string log)
        {

            _login = log;

        }

        ///<summary>
        ///
        /// Método get para o login     
        /// 
        ///</summary>
        public string getlogin(){
        
            return _login;
        
        }

        ///<summary>
        ///
        /// Método set para a chave    
        /// 
        ///</summary>
        public void setchave(string key)
        {

            _chave = key;

        }

        ///<summary>
        ///
        /// Método get para a chave    
        /// 
        ///</summary>
        public string getchave(){
        
            return _chave;
        
        }

    }
}
