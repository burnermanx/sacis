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
        private string _validade;
        private int _permissao;

        ///<summary>
        ///
        /// Métodos nome, senha, login, chave, validade e permissao sao gets e sets usados para 
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

        public string validade
        {

            get { return _validade; }

            set { _validade = value; }

        }

        public int permissao
        {

            get { return _permissao; }

            set { _permissao = value; }

        }

        ///<summary>
        ///
        /// Método contrutor para inicializar o objeto        
        ///
        ///</summary>
        public usuario()
        {
            _validade = "";
            _nome = "";
            _senha = "";
            _login = "";
            _chave = "";
            _permissao = 0;

        }
        
        ///<summary>
        ///
        /// Método contrutor para inicializar o objeto atraves de parâmetros
        ///
        ///</summary>
        public usuario(string name, string pass, string log, string key, string validade, int permissao) {

            _nome = name;
            _senha = pass;
            _login = log;
            _chave = key;
            _validade = validade;
            _permissao = permissao;

        }

        ///<summary>
        ///
        /// Método set para o nome      
        /// 
        ///</summary>
        public void setNome(string name)
        {

            _nome = name;

        }

        ///<summary>
        ///
        /// Método get para o nome      
        /// 
        ///</summary>
        public string getNome(){
        
            return _nome;
        
        }

        ///<summary>
        ///
        /// Método set para a senha     
        /// 
        ///</summary>
        public void setSenha(string pass)
        {

            _senha = pass;

        }

        ///<summary>
        ///
        /// Método get para a senha     
        /// 
        ///</summary>
        public string getSenha(){
        
            return _senha;
        
        }

        ///<summary>
        ///
        /// Método set para o login     
        /// 
        ///</summary>
        public void setLogin(string log)
        {

            _login = log;

        }

        ///<summary>
        ///
        /// Método get para o login     
        /// 
        ///</summary>
        public string getLogin(){
        
            return _login;
        
        }

        ///<summary>
        ///
        /// Método set para a chave    
        /// 
        ///</summary>
        public void setChave(string key)
        {

            _chave = key;

        }

        ///<summary>
        ///
        /// Método get para a chave    
        /// 
        ///</summary>
        public string getChave(){
        
            return _chave;
        
        }

        ///<summary>
        ///
        /// Método set para a validade    
        /// 
        ///</summary>
        public void setValidade(string validade)
        {

            _validade = validade;

        }

        ///<summary>
        ///
        /// Método get para a validade    
        /// 
        ///</summary>
        public string getValidade()
        {

            return _validade;

        }

        ///<summary>
        ///
        /// Método set para a permissao    
        /// 
        ///</summary>
        public void setPermissao(int permissao)
        {

            _permissao = permissao;

        }

        ///<summary>
        ///
        /// Método get para a permissao    
        /// 
        ///</summary>
        public int getPermissao()
        {

            return _permissao;

        }

    }
}
