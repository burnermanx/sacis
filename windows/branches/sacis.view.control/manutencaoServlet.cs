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
        private static string MSG_LOGIN_INVALIDO = "Login Inválido!";
        private static string MSG_ERRO_NOME = "Nome Inválido!";        
        private static string MSG_ERRO_PERMISSAO = "Selecione um Tipo de Permissão!";

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
        public static bool verificaLoginUsuario(string login, string senha)
        {
            try
            {
                if (WService.verificaLoginUsuarioManutencao(login, senha))
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
        /// Retorna excecao: Erro de usuário inválido e de seleção de permissão
        /// 
        ///</summary>
        public static bool antesCadastro(usuario user) 
        {
            if (user.getPermissao() == -1) throw new excecao(MSG_ERRO_PERMISSAO);

            try 
            {
                if(verificaCampos.verificaValidadeUsuario(user))
                {                                        
                    if (WService.verificaUsuario(user.getLogin())) return false;
                    else cadastro(user);                
                }

            } catch (excecao except) 
            {                
                throw except;
            }

            return true;
        }

        ///<summary>
        ///
        /// Método para cadastrar o usuario no webservice 
        /// 
        /// Retorna excecao: Erro de cadastro
        /// 
        ///</summary>
        private static void cadastro(usuario user) 
        {        
            try
            {
                string senha = simetrica.geraSenha();
                user.setSenha(senha);

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

        ///<summary>
        ///
        /// Método para resetar senha do usuario no webservice
        /// 
        /// Retorna excecao: Login invalido
        /// 
        ///</summary>
        public static bool resetar(string login)
        {
            try
            {
                if (WService.resetaSenha(login)) return true;
                else throw new excecao(MSG_LOGIN_INVALIDO);
            }
            catch (excecao except)
            {
                throw except;
            }
        }

        ///<summary>
        ///
        /// Método para alterar o nome do usuário no webservice
        /// 
        /// Retorna excecao: Login invalido e erro de verificação de nome
        /// 
        ///</summary>
        public static bool alterarNome(string login, string nome)
        {
            try
            {
                if (!verificaCampos.verificaValidadeCampos(nome))
                {
                    if (WService.alteraNome(login, nome)) return true;
                    else throw new excecao(MSG_LOGIN_INVALIDO);
                }
                else throw new excecao(MSG_ERRO_NOME);
            }
            catch (excecao except)
            {
                throw except;
            }
        }

        ///<summary>
        ///
        /// Método para alterar a permissão do usuário no webservice
        /// 
        /// Retorna excecao: Login invalido e erro de seleção de permissão
        /// 
        ///</summary>
        public static bool alterarPermissao(string login, int permissao)
        {
            if (permissao == -1) throw new excecao(MSG_ERRO_PERMISSAO);

            try
            {
                if (WService.alteraPermissao(login, permissao)) return true;
                else throw new excecao(MSG_LOGIN_INVALIDO);
            }
            catch (excecao except)
            {
                throw except;
            }
            
        }

        ///<summary>
        ///
        /// Método para alterar o certificado do usuário no webservice
        /// 
        /// Retorna excecao: Login invalido
        /// 
        ///</summary>
        public static bool alterarCertificado(string login, string caminho, string validade) {

            try
            {
                string conteudo = manipulaArquivo.leArquivoTexto(caminho);

                if (WService.alteraCertificado(login, conteudo, validade)) return true;
                else throw new excecao(MSG_LOGIN_INVALIDO);
            }
            catch (excecao except)
            {
                throw except;
            }               
        }

        ///<summary>
        ///
        /// Método para excluir um usuário no webservice
        /// 
        /// Retorna excecao: Login invalido
        /// 
        ///</summary>
        public static bool excluirUsuario(string login){
        
            try
            {
                if (WService.excluiUsuario(login)) return true;
                else throw new excecao(MSG_LOGIN_INVALIDO);
            }
            catch (excecao except)
            {
                throw except;
            }    

        }

    }
}
