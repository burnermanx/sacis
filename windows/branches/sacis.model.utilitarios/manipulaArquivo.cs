///<summary>
/// Classe contendo implementação para manipular arquivos e diretorios
///
/// @author Fabio Augusto 
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
        /// Método para criar arquivo através de uma string contendo o caminho destino completo incluindo 
        /// o nome do arquivo e sua extensão e uma string contendo o conteúdo do arquivo
        ///       
        /// Retorna excecao: Erro de gravação
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
        /// Método para retornar o conteúdo do arquivo passado através de uma string contendo 
        /// o caminho completo incluindo o nome do arquivo e sua extensão
        /// 
        /// Retorna excecao: Erro de leitura de arquivo
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
                //Console.Out.WriteLine("copia - " + conteudo.Length);
                //Console.Out.WriteLine(conteudo);
                //FileInfo file = new FileInfo(caminho);
                //FileStream f2 = file.OpenRead();
                
                //Console.Out.WriteLine(file.Length.ToString());
                return conteudo;
            }
            catch (Exception except)
            {                
                throw new excecao.excecao(MSG_ERRO_LEITURA);
            }            
        }

        ///<summary>
        ///
        /// Metodo para atualizar arquivo de log local com o login e o hash da senha
        /// 
        /// Retorna excecao: Erro de escrita no arquivo
        /// 
        ///</summary>
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

        ///<summary>
        ///
        /// Método para criar diretório para o usuário local e arquivo de log
        /// 
        /// Retorna excecao: Erro de criação de arquivo ou diretório
        /// 
        ///</summary>
        public static void criaDiretorioLogLocal()
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
        /// Método para criar diretorio
        ///
        /// Retorna excecao: Erro de criação de diretório
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
        /// Método para copiar um arquivo através de uma string contendo o nome do arquivo e uma string 
        /// contendo apenas o caminho destino
        ///
        /// Retorna excecao: Erro de copia de arquivo 
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
        /// Método para escrever no arquivo através de uma string contendo o caminho destino incluindo
        /// o nome do arquivo e sua extensão, uma string contendo o conteúdo a ser escrito no arquivo e
        /// um parâmetro tipo booleano para determinar a sobrescrita(false) ou inclusão(true)
        ///
        /// Retorna excecao: Erro de escrita de arquivo   
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
