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
                
                //StreamWriter write = new StreamWriter(destino);
                //write.Write(conteudo);
                //write.Close();
                FileInfo fi = new FileInfo(destino);
                FileStream fs = fi.OpenWrite();
                Byte[] info = new UTF8Encoding(true).GetBytes(conteudo);
                fs.Write(info, 0, info.Length);
                fs.Close();

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
                                
                //StreamReader le = new StreamReader(caminho,true);
                //conteudo = le.ReadToEnd();                
                //le.Close();
                FileInfo fi = new FileInfo(caminho);
                FileStream fs = fi.OpenRead();
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    conteudo += temp.GetString(b);
                }

                fs.Close();
                
                return conteudo;

            }
            catch (Exception except)
            {
                
                throw new excecao.excecao(MSG_ERRO_LEITURA);
            }
            
        }

    }
}
