/*
 * Classe contendo implementação para manipular arquivos
 * 
 *
 * @author Fabio Augusto
 * 
 */

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

        private static string MSG_ERRO_LEITURA = "Erro ao Ler Arquivo";
        private static string MSG_ERRO_GRAVACAO = "Erro ao Gravar Arquivo";
        private static string MSG_ERRO_ESCRITA = "Erro ao Escrever no Arquivo";
        private static string MSG_ERRO_CRIACAO = "Erro ao Criar Arquivo ou Diretorio";
        private static string CAMINHO_USUARIOS = @"C:\sacis\usuarios\";
        private static string CAMINHO_LOG = @"C:\sacis\sacis.log";             

        /**
        *
        * Metodo para criar arquivo
        * 
        * @param destino            String com o caminho destino do arquivo a ser criado
        * @param conteudo           String com o conteudo do arquivo      
        * @throw excecao
        *
        */
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

        /**
        *
        * Metodo para ler arquivo
        * 
        * @param caminho             String com o caminho de origem do arquivo a ser lido
        * @return conteudo           String com o conteudo do arquivo
        * @throw excecao
        *
        */
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

        /**
        *
        * Metodo para atualizar arquivo de log
        * 
        * @param login            Variavel do tipo string
        * @param hash             Variavel do tipo string     
        *
        * @throw excecao
        * 
        */
        public static void atualizaLog(string login, string hash)
        {

            try
            {
                //atualizar arquivo de log com login e hash
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

        /**
        *
        * Método para verificar a existência do diretorio principal e do usuario localmente
        * e criá-los caso nao exista junto com o arquivo de log
        * 
        * @throw excecao
        * 
        */
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

    }
}
