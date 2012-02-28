///<summary>
/// Classe _para objetos do tipo contato
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
        /// Métodos nome e email sao gets e sets usados _para 
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
        /// Método contrutor _para inicializar o objeto
        ///
        ///</summary>
        public contato()
        {

            _nome = "";
            _email = "";

        }

        ///<summary>
        ///
        /// Método contrutor _para inicializar o objeto
        ///
        /// @param name        Variavel do tipo String 
        /// @param email       Variavel do tipo String     
        ///
        ///</summary>
        public contato(string name, string email) {

            _nome = name;
            _email = email;

        }

        ///<summary>
        ///
        /// Método set _para o nome
        ///
        /// @param name       Variavel do tipo String      
        ///
        ///</summary>
        public void setNome(string name)
        {

            _nome = name;

        }

        ///<summary>
        ///
        /// Método get _para o nome
        ///
        /// @return nome       Variavel do tipo String      
        ///
        ///</summary>
        public string getNome(){
        
            return _nome;
        
        }

        ///<summary>
        ///
        /// Método set _para o email
        ///
        /// @param email       Variavel do tipo String      
        ///
        ///</summary>
        public void setEmail(string email)
        {

            _email = email;

        }

        ///<summary>
        ///
        /// Método get _para o email
        ///
        /// @return _email       Variavel do tipo String      
        ///
        ///</summary>
        public string getEmail(){

            return _email;
        
        }

        ///<summary>
        ///
        /// Método de sobrecarga para comparação de objetos
        ///
        /// @return bool       Variavel do tipo booleano      
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
        /// Método _de sobrecarga _para obter o hash do objeto
        ///
        /// @return hash      Variavel do tipo String      
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
