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
        private static string MSG_PASTA_DESTINO = "Selecione uma pasta de destino!";

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

            try
            {
                if (verificaUsuario.verificaCadastroUsuarioLocal(login, senha)) return true;
                else return false;
            }
            catch (excecao except)
            {                
                throw except;
            }
        
        }

        ///<summary>
        ///
        /// Método para cifrar arquivo
        /// 
        /// Retorna excecao: Erro de leitura ou gravação de arquivo
        /// 
        ///</summary>
        public static void criptoArquivo(string origem, string destino, string chave) {

            try
            {
                string arquivo = manipulaString.retornaNomeArquivo(origem);
                string novoArquivo = manipulaString.mudaExtensaoArquivo(arquivo);
                string destinoFinal = pastaDestino(destino, novoArquivo);

                byte[] conteudoByte = manipulaArquivo.arquivoLeOriginal(origem);
                string conteudo = serial.serializarObjeto(conteudoByte);               
                string conteudoCifrado = simetrica.cifraArquivosLocais(chave, conteudo);
                string conteudoHexa = simetrica.convertToHexa(conteudoCifrado);

                manipulaArquivo.criaArquivoTexto(destinoFinal, conteudoHexa);
                manipulaArquivo.excluiArquivoTexto(origem);
            }
            catch (excecao except)
            {
                throw except;
            }

        }

        ///<summary>
        ///
        /// Método para decifrar arquivo
        /// 
        /// Retorna excecao: Erro de leitura ou gravação de arquivo e de criptografia
        /// 
        ///</summary>
        public static void descriptoArquivo(string origem, string destino, string chave) {

            try
            {
                string arquivo = manipulaString.retornaNomeArquivo(origem);
                string novoArquivo = manipulaString.recuperaNomeOriginalArquivo(arquivo);
                string destinoFinal = pastaDestino(destino, novoArquivo);

                string conteudoHexa = manipulaArquivo.leArquivoTexto(origem);
                string conteudoCifrado = simetrica.convertToString(conteudoHexa);                
                string conteudo = simetrica.decifraArquivosLocais(chave, conteudoCifrado);
                byte[] conteudoByte = serial.Deserializar(conteudo, typeof(byte[])) as byte[]; 
               
                manipulaArquivo.arquivoCriaOriginal(destinoFinal, conteudoByte);
                manipulaArquivo.excluiArquivoTexto(origem);
             }
            catch (excecao except)
            {
                throw except;

            }            
        
        }

        ///<summary>
        ///
        /// Método para criar arquivo local
        /// 
        ///</summary>
        private static string pastaDestino(string destino, string novoArquivo) {
                        
            try{  

                string pastaDestino;

                if (destino.Length > 4)
                {
                    pastaDestino = destino + "\\" + novoArquivo;
                }
                else
                {
                    pastaDestino = destino + novoArquivo;
                }

                return pastaDestino;

            } catch (NullReferenceException nre) {

                throw new excecao(MSG_PASTA_DESTINO);
            
            }

        }
    
    }
}
