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
    public class manutencaoServlet
    {
        
        private static localhost.Service1 WService = new localhost.Service1();

        ///<summary>
        ///
        /// Método que retorna o hash de uma string passada
        ///
        ///</summary>
        public static string geraHash(string texto)
        {
            return hash.hashing(texto);
        }

        ///<summary>
        ///
        /// Método que verifica se o usuario passado tem acesso ao sistema de manutenção
        /// retornando verdadeiro caso exista.
        /// 
        ///</summary>
        public static bool verificaUsuario(string login, string senha)
        {
            try
            {
                if (WService.verificaUsuarioManutencao(login, senha))
                {
                    return true;
                }
                else return false;
            }
            catch (excecao except)
            {
                throw except;
            }
        }

        ///<summary>
        ///
        /// Metodo que retorna a data de expiracao da chave certificada convertida 
        /// para o formato "yyyy/mm/dd hh:min:seg" e a compara com a data atual.
        /// 
        /// Retorna excecao
        /// 
        ///</summary>
        public static string retornaData(string caminho) {

            string data;

            try
            {
                data = assimetrica.dataExpiracao(caminho);

                verificaData.comparaData(data);

                data = verificaData.converteData(data);
                               
            } catch (excecao except){

                throw except;

            }       
        
            return data;

        }

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
                    
                    if (WService.verificaUsuario(user.getLogin())) return false;
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
                string pass = hash.hashing(user.getSenha());
                user.setSenha(pass);

                string conteudo = manipulaArquivo.leArquivoTexto(user.getChave());
                user.setChave(conteudo);

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
