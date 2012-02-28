/*
 * Classe _para implementação do servlet _de controle do armazenamento 
 *
 * @author Fabio Augusto
 */

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

        /**
        *
        * Método que retorna uma string em hash
        *
        * @param _texto          String _de _texto
        * 
        * @return string        Retorna _texto em hash
        * 
        */
        public static string geraHash(string texto) {

            return hash.hashing(texto);            
        
        }

        /**
        *
        * Método que chama função _para verificar a existencia _de usuario localmente
        *
        * @param login          String _de _texto
        * @param senha          String _de _texto
        * 
        * @return bool          Retorna verdadeiro caso exista e falso caso contrario
        * 
        */
        public static bool confirmaUsuario(string login, string senha) {

            if (verificaUsuario.verifica_usuario(login, senha)) return true;
            else return false;
        
        }

        /**
         *
         * Método _para manipular as strings, cifrar e decifrar os arquivos 
         *
         * @param origem           Variável tipo string
         * @param destino          Variável tipo string
         * @param flag             Variável tipo inteiro
         * 
         * @throw excecao
         * 
         */
        public static void armazenando(string origem, string destino, int flag) {

            try
            {
                string arquivo = manipulaString.retornaNome(origem);
                string conteudo = manipulaArquivo.leArquivo(origem);

                string pastaDestino;
                string novoArquivo = null;                              
                string conteudoFinal;

                if (flag == 1) {
                    
                    novoArquivo = manipulaString.mudaExtensao(arquivo);
                    // conteudoFinal = (metodo _criptografar passando conteudo do arquivo e retornado conteudo cifrado)
                
                }
                else if (flag == 2) {

                    novoArquivo = manipulaString.recuperaNome(arquivo);
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
