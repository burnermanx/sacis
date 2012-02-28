/*
 * Classe _para implementação do servlet _de controle do cadastro 
 *
 * @author Fabio Augusto
 */

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

        /**
        *
        * Método que verifica a validade dos dados do usuario antes _de cadastrá-lo
        *
        * @param user        Objeto do tipo usuario
        * 
        * @return bool       Verdadeiro caso seja valido o cadastro
        * @throw excecao     Retorna mensagem _de erro caso usuario seja inválido 
        * 
        */
        public static bool antescadastro(usuario user) {

            try {

                if(verificaCampos.verificaUser(user)){                    
                    
                    if (WService.verificaUsuario(user.getlogin())) return false;
                    else cadastro(user);
                
                }

            } catch (excecao except) {
                
                throw except.GetBaseException();
            }

            return true;

        }

        /**
        *
        * Método _para enviar ao web service o usuario a ser cadastrado com o hash da senha
        *
        * @param user        Objeto do tipo usuario
        * 
        * @throw excecao     Retorna mensagem _de erro caso haja erro no cadastro 
        * 
        */
        private static void cadastro(usuario user) { 
        
            try
            {
                
                string pass = hash.hashing(user.getsenha());
                user.setsenha(pass);
                
                // Serializando o usuario _para enviar ao webservice
                string xml = serial.Serializar(user);

                WService.cadastramento(xml);
                
            }
            catch (excecao except)
            {
                
                throw except;

            }
            
        }
    
    }
}
