///<summary>
/// Classe para objetos do tipo contato
///
/// @author Fabio Augusto
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sacis.model.entidades
{
    public class contato : IEquatable<contato>
    {

        private string _nome;
        private string _email;

        ///<summary>
        ///
        /// Método contrutor para inicializar o objeto
        ///
        ///</summary>
        public contato() { }

        ///<summary>
        ///
        /// Método contrutor para inicializar o objeto atraves de parâmetros
        ///
        ///</summary>
        public contato(string name, string email)
        {
            _nome = name;
            _email = email;
        }

        ///<summary>
        ///
        /// Métodos nome e email sao gets e sets usados para 
        /// a serialização e deserialização do objeto em XML
        ///
        ///</summary>
        public string nome
        {

            get { return _nome; }

            set { _nome = value; }

        }

        public string email
        {

            get { return _email; }

            set { _email = value; }

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
        /// Método set para o email
        ///
        ///</summary>
        public void setEmail(string email)
        {

            _email = email;

        }

        ///<summary>
        ///
        /// Método get para o email
        ///
        ///</summary>
        public string getEmail(){

            return _email;
        
        }

        ///<summary>
        ///
        /// Método de sobrecarga para comparação de objetos
        ///
        ///</summary>
        public bool Equals(contato other)
        {
            if (Object.ReferenceEquals(other, null)) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return _nome.Equals(other._nome) && _email.Equals(other._email);
        }

        ///<summary>
        ///
        /// Método de sobrecarga para obter o hash do objeto
        ///
        ///</summary>
        public override int GetHashCode()
        {
            int hashName = _nome == null ? 0 : _nome.GetHashCode();

            int hashEmail = _email.GetHashCode();

            return hashName ^ hashEmail;
        }
        
    }
}
