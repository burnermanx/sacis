///<summary>
/// Classe contendo implementação _para manipular arquivos e diretorios
/// 
///
/// @author Fabio Augusto
/// 
///</summary>

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sacis.model.excecao;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace sacis.model.utilitarios
{
    public class manipulaArquivo
    {
        private static string MSG_ERRO_COPIA = "Erro ao Copiar Arquivo";
        private static string MSG_ERRO_LEITURA = "Erro ao Ler Arquivo";
        private static string MSG_ERRO_GRAVACAO = "Erro ao Gravar Arquivo";
        private static string MSG_ERRO_ESCRITA = "Erro ao Escrever no Arquivo";
        private static string MSG_ERRO_CRIACAO = "Erro ao Criar Arquivo ou Diretorio";
        private static string CAMINHO_USUARIOS = @"C:\sacis\usuarios\";
        private static string CAMINHO_LOG = @"C:\sacis\sacis.log";

        ///<summary>
        ///
        /// Metodo _para criar arquivo
        /// 
        /// @param destino            String com o caminho destino do arquivo a ser criado
        /// @param conteudo           String com o conteudo do arquivo      
        /// @throw excecao
        ///
        ///</summary>
        public static void criaArquivo(string destino, string conteudo)
        {
            try
            {                
                StreamWriter write = new StreamWriter(destino);
                write.Write(conteudo);
                write.Close();
            }
            catch (Exception except)
            {
                throw new excecao.excecao(MSG_ERRO_GRAVACAO);
            }
        }

        ///<summary>
        ///
        /// Metodo _para ler arquivo
        /// 
        /// @param caminho             String com o caminho _de origem do arquivo a ser lido
        /// @return conteudo           String com o conteudo do arquivo
        /// @throw excecao
        ///
        ///</summary>
        public static string leArquivo(string caminho)
        {
            string conteudo = null;

            try
            {                                
                StreamReader le = new StreamReader(caminho,true);
                conteudo = le.ReadToEnd();                
                le.Close();  
             
                return conteudo;
            }
            catch (Exception except)
            {                
                throw new excecao.excecao(MSG_ERRO_LEITURA);
            }            
        }

        ///<summary>
        ///
        /// Metodo _para atualizar arquivo _de log
        /// 
        /// @param login            Variavel do tipo string
        /// @param hash             Variavel do tipo string     
        ///
        /// @throw excecao
        /// 
        ///</summary>
        public static void atualizaLog(string login, string hash)
        {
            try
            {
                //atualizar arquivo _de log com login e hash
                StreamWriter wr = new StreamWriter(CAMINHO_LOG, true);

                //Escrevendo no arquivo
                wr.WriteLine(login + " " + hash);

                //fechando o arquivo
                wr.Close();            
            }
            catch (Exception except)
            {
                throw new excecao.excecao(MSG_ERRO_ESCRITA);
            }
        }

        ///<summary>
        ///
        /// Método _para verificar a existência do diretorio principal e do usuario localmente
        /// e criá-los caso nao exista junto com o arquivo _de log
        /// 
        /// @throw excecao
        /// 
        ///</summary>
        public static void verificaDiretorio()
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(CAMINHO_USUARIOS);

                if (!info.Exists)
                {
                    info.Create();

                    //Cria o arquivo na pasta do programa. 
                    //False sobrescreve todos os dados no arquivo enquanto true agrega.                
                    StreamWriter wr = new StreamWriter(CAMINHO_LOG, false);

                    //fechando o arquivo
                    wr.Close();
                }
            }
            catch (Exception except)
            {
                throw new excecao.excecao(MSG_ERRO_CRIACAO);
            }
        }

        ///<summary>
        ///
        /// Método _para criar diretorio
        ///
        /// @param path         Variavel do tipo String
        /// @throw excecao     
        /// 
        ///</summary>
        public static void criaDiretorio(string path) {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception except)
            {
                throw new excecao.excecao(MSG_ERRO_CRIACAO);
            }        
        }

        ///<summary>
        ///
        /// Método _para copiar arquivo
        ///
        /// @param nomeArquivo         Variavel do tipo String
        /// @param caminhodestino         Variavel do tipo String
        /// @throw excecao     
        /// 
        ///</summary>
        public static void copiaArquivo(string nomeArquivo, string caminhodestino) {
            try
            {
                FileInfo arquivo = new FileInfo(nomeArquivo);
                arquivo.CopyTo(caminhodestino);
            }
            catch (Exception except)
            {
                throw new excecao.excecao(MSG_ERRO_COPIA);
            }        
        }

        ///<summary>
        ///
        /// Método _para escrever no arquivo
        ///
        /// @param path          Variavel do tipo String
        /// @param conteudo      Variavel do tipo String
        /// @param tipo          Variavel do tipo booleano
        /// @throw excecao     
        /// 
        ///</summary>
        public static void escreveArquivo(string path, string conteudo, bool tipo)
        {
            try
            {
                StreamWriter wr = new StreamWriter(path, tipo);
                wr.WriteLine(conteudo);
                wr.Close();
            }
            catch (Exception except)
            {
                throw new excecao.excecao(MSG_ERRO_ESCRITA);
            }
        }

    }
}
