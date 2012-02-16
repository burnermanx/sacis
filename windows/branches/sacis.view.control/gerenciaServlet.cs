/*
 * Classe para implementação do servlet de controle do gerenciamento de mensagens 
 *
 * @author Fabio Augusto
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sacis.model.criptografia;
using sacis.model.excecao;
using sacis.model.utilitarios;
using System.IO;

namespace sacis.view.control
{
    public class gerenciaServlet
    {
        private static string CAMINHO_USUARIOS = @"C:\sacis\usuarios\";
        private static string CAMINHO_CHAVEIRO = @"C:\sacis\server\chaveiro\";
        private static string CAMINHO_SERVER = @"C:\sacis\server\";

        private static string MSG_PASTA_NAO_ENCONTRADA = @"Pasta nao encontrada";
        private static string EXTENSAO = ".key";
        private static string BARRA = @"\";

        private static localhost.Service1 WService = new localhost.Service1();

        /**
        *
        * Método que retorna uma string em hash
        *
        * @param texto          Variavel string
        * 
        * @return string        Retorna texto em hash
        * 
        */
        public static string geraHash(string texto)
        {

            return hash.hashing(texto);

        }

        /**
        *
        * Método para consultar usuario no web service
        *
        * @param login          Variavel do tipo string
        * @param senha          Variavel do tipo string
        *
        * @return bool          Retorna verdadeiro caso exista e falso caso não
        * @throw excecao
        * 
        */
        public static bool consultaUsuario(string login, string senha) {                       

            try
            {
                if (WService.consultaUsuario(login, senha))
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

        /**
        *
        * Método para atualizar usuario novo localmente
        *
        * @param login          Variavel do tipo string
        * @param senha          Variavel do tipo string
        *
        * @throw excecao
        * 
        */
        public static void atualizaUsuario(string login, string senha) {

            try
            {
                manipulaArquivo.verificaDiretorio();

                if (verificaUsuario.verifica_usuario(login, senha) == false)
                {

                    //mudar codigo para acessar webservice
                    //copiar chave publica para diretorio do usuario
                    FileInfo arquivo = new FileInfo(CAMINHO_CHAVEIRO + login + EXTENSAO);
                    arquivo.CopyTo(CAMINHO_USUARIOS + login + EXTENSAO);

                    manipulaArquivo.atualizaLog(login, senha);

                }
            }
            catch (excecao except)
            {

                throw except;

            }   
        
        }

        /**
        *
        * Método para retornar diretorio referente ao usuario passado
        *
        * @param nome          Variavel do tipo string
        * 
        */
        public static DirectoryInfo listaDiretorios(string nome) {

            DirectoryInfo info = new DirectoryInfo(CAMINHO_SERVER + nome);

            if (info.Exists) return info;
            else throw new excecao(MSG_PASTA_NAO_ENCONTRADA);

        
        }

        /**
        *
        * Método para retornar caminho para abertura de arquivo
        *
        * @param nome          Variavel do tipo string
        * 
        */
        public static string caminhoTotal(string path){

            string caminho = CAMINHO_SERVER + path + BARRA;

            return caminho;

        }

        /**
        *
        * Método para abrir arquivo solicitado
        *
        * @param path          Variavel do tipo string
        * 
        */
        public static void abreArquivo(string path) {

            System.Diagnostics.Process.Start(path);
        
        }

        /**
        *
        * Método para apagar arquivo solicitado
        *
        * @param path          Variavel do tipo string
        * 
        */
        public static void apagaArquivo(string path) {

            System.IO.File.Delete(path);

        }

    }
}
