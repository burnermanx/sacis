///<summary>
/// Classe para implementação do servlet de controle do cadastro 
///
/// @author Fabio Augusto
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sacis.model.entidades;
using sacis.model.excecao;
using sacis.model.utilitarios;
using sacis.model.criptografia;

namespace sacis.view.control
{
    public class cadastroServlet
    {

        private static localhost.Service1 WService = new localhost.Service1();

        ///<summary>
        ///
        /// Método que verifica a validade dos dados e existência do usuario passado 
        /// retornando verdadeiro caso cadastro seja realizado
        /// 
        /// Retorna excecao: Erro de usuário inválido
        /// 
        ///</summary>
        public static bool antesCadastro(usuario user) 
        {
            try {

                if(verificaCampos.verificaValidadeUsuario(user)){                    
                    
                    if (WService.verificaUsuario(user.getlogin())) return false;
                    else cadastro(user);                
                }

            } catch (excecao except) {                
                throw except;
            }

            return true;
        }

        ///<summary>
        ///
        /// Método para cadastrar o usuario passado no servidor web 
        /// 
        /// Retorna excecao: Erro de cadastro
        /// 
        ///</summary>
        private static void cadastro(usuario user) 
        {        
            try
            {                
                string pass = hash.hashing(user.getsenha());
                user.setsenha(pass);

                string xml = serial.serializarObjeto(user);

                WService.cadastraUsuario(xml);                
            }
            catch (excecao except)
            {                
                throw except;
            }            
        }    
    }
}
