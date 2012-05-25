///<summary>
/// Classe para implementação do servlet de controle do armazenamento 
///
/// @author Fabio Augusto
///</summary>

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sacis.model.criptografia;
using sacis.model.utilitarios;
using sacis.model.excecao;

namespace sacis.view.control
{
    public class armazenaServlet
    {

        ///<summary>
        ///
        /// Método que retorna o hash de uma string passada
        ///
        ///</summary>
        public static string geraHash(string texto) {

            return hash.hashing(texto);            
        
        }

        ///<summary>
        ///
        /// Método que verifica a existencia do login e hash da senha passados no arquivo local
        /// retornando verdadeiro caso exista.
        /// 
        ///</summary>
        public static bool confirmaUsuario(string login, string senha) {

            if (verificaUsuario.verificaCadastroUsuarioLocal(login, senha)) return true;
            else return false;
        
        }

        ///<summary>
        ///
        /// Método que armazena o arquivo desejado selecionando o tipo de armazenamento de arquivo 
        /// a ser feito através do inteiro (1 para cifrar ou 2 para decifrar), manipulando a string passada
        /// contendo o caminho do arquivo completo incluindo o nome dele e sua extensão e a string 
        /// passada contendo o caminho de destino do arquivo.
        /// 
        /// Retorna excecao: Erro de leitura ou gravação de arquivo
        /// 
        ///</summary>
        public static void armazenaArquivo(string origem, string destino, int flag) 
        {
            try
            {
                string arquivo = manipulaString.retornaNomeArquivo(origem);
                string conteudo = manipulaArquivo.leArquivo(origem);

                string pastaDestino;
                string novoArquivo = null;                              
                string conteudoFinal;

                if (flag == 1) {
                    
                    novoArquivo = manipulaString.mudaExtensaoArquivo(arquivo);
                    // conteudoFinal = (metodo _criptografar passando conteudo do arquivo e retornado conteudo cifrado)
                
                }
                else if (flag == 2) {

                    novoArquivo = manipulaString.recuperaNomeOriginalArquivo(arquivo);
                    // conteudoFinal = (metodo descriptografar passando conteudo do arquivo e retornado conteudo decifrado)

                }

                if (destino.Length > 4)
                {
                    pastaDestino = destino + "\\" + novoArquivo;
                }
                else
                {
                    pastaDestino = destino + novoArquivo;                
                }
                
                manipulaArquivo.criaArquivo(pastaDestino, conteudo);
 
            }
            catch (excecao except)
            {                
                throw except;
            }     
        }
    }
}
