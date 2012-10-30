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
        private static string MSG_ERRO_EXCLUSAO_ARQUIVO = "Erro ao Excluir Arquivo!";
        private static string MSG_ERRO_EXCLUSAO_DIRETORIO = "Erro ao Excluir Diretorio!";

        ///<summary>
        ///
        /// Metodo para excluir arquivo texto através do caminho
        ///       
        /// Retorna excecao: Erro de exclusão de arquivo
        ///
        ///</summary>
        public static void excluiArquivoTexto(string caminho) {
            
            try
            {
                FileInfo file = new FileInfo(caminho);
                file.Delete();
            }
            catch (Exception except)
            {
                throw new excecao.excecao(MSG_ERRO_EXCLUSAO_ARQUIVO);
            }

        }

        ///<summary>
        ///
        /// Metodo para excluir diretorios e subdiretorios através do caminho
        ///       
        /// Retorna excecao: Erro de exclusão de diretorio
        ///
        ///</summary>
        public static void excluiDiretorios(string caminho) {
            
            try
            {
                DirectoryInfo diretorio = new DirectoryInfo(caminho);
                diretorio.Delete(true);                                
            }
            catch (Exception except)
            {
                throw new excecao.excecao(MSG_ERRO_EXCLUSAO_DIRETORIO);
            }

        }

        ///<summary>
        ///
        /// Metodo para criar arquivo texto atraves do caminho destino e do conteudo em string
        ///       
        /// Retorna excecao: Erro de gravação
        ///
        ///</summary>
        public static void criaArquivoTexto(string caminho, string conteudo) {

            try{

                FileStream file = new FileStream(caminho, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);
                sw.Write(conteudo);

                sw.Close();
                file.Close();
        
            }
            catch (Exception except)
            {
                throw new excecao.excecao(MSG_ERRO_GRAVACAO);
            }
        }

        ///<summary>
        ///
        /// Método para retornar uma string do conteúdo do arquivo passado através de uma string contendo 
        /// o caminho completo incluindo o nome do arquivo e sua extensão
        /// 
        /// Retorna excecao: Erro de leitura de arquivo
        ///
        ///</summary>
        public static string leArquivoTexto(string caminho)
        {

            try
            {
                FileStream file = new FileStream(caminho, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(file);

                string conteudo = sr.ReadToEnd();

                file.Close();
                sr.Close();

                return conteudo;

            }
            catch (Exception except)
            {
                throw new excecao.excecao(MSG_ERRO_LEITURA);
            }
        }
        
        ///<summary>
        ///
        /// Metodo para recriar arquivo original atraves do caminho destino e do conteudo em byte
        ///       
        /// Retorna excecao: Erro de gravação
        ///
        ///</summary>
        public static void arquivoCriaOriginal(string destino, byte[] conteudo)
        {
            try
            {             
                int tamanho = (int)conteudo.Length;

                FileInfo info = new FileInfo(destino);
                FileStream stream = info.OpenWrite();

                stream.Write(conteudo, 0, tamanho);

                stream.Close();

            }
            catch (Exception except)
            {
                throw new excecao.excecao(MSG_ERRO_GRAVACAO);
            }
        }
        
        ///<summary>
        ///
        /// Método para retornar o conteúdo em byte do arquivo original através de uma string contendo 
        /// o caminho completo incluindo o nome do arquivo e sua extensão
        /// 
        /// Retorna excecao: Erro de leitura de arquivo
        ///
        ///</summary>
        public static byte[] arquivoLeOriginal(string caminho)
        {

            try
            {
                FileInfo info = new FileInfo(caminho);
                FileStream stream = info.OpenRead();

                int tamanho = (int)stream.Length;
                byte[] array = new byte[tamanho];
                stream.Read(array, 0, tamanho);

                stream.Close();

                return array;

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
                StreamWriter wr = new StreamWriter(CAMINHO_LOG, true);

                wr.WriteLine(login + " " + hash);

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
               
                    StreamWriter wr = new StreamWriter(CAMINHO_LOG, false);

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
