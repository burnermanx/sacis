///<summary>
/// Classe _para implementação do servlet _de controle do gerenciamento _de mensagens 
///
/// @author Fabio Augusto
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sacis.model.criptografia;
using sacis.model.excecao;
using sacis.model.utilitarios;
using System.IO;
using sacis.model.entidades;

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

        ///<summary>
        ///
        /// Método que retorna uma string em hash
        ///
        /// @param _texto          Variavel string
        /// 
        /// @return string        Retorna _texto em hash
        /// 
        ///</summary>
        public static string geraHash(string texto)
        {

            return hash.hashing(texto);

        }

        ///<summary>
        ///
        /// Método _para consultar usuario no web service
        ///
        /// @param login          Variavel do tipo string
        /// @param senha          Variavel do tipo string
        ///
        /// @return bool          Retorna verdadeiro caso exista e falso caso não
        /// @throw excecao
        /// 
        ///</summary>
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

        ///<summary>
        ///
        /// Método _para atualizar usuario novo localmente
        ///
        /// @param login          Variavel do tipo string
        /// @param senha          Variavel do tipo string
        ///
        /// @throw excecao
        /// 
        ///</summary>
        public static void atualizaUsuario(string login, string senha) {

            try
            {
                manipulaArquivo.verificaDiretorio();

                if (verificaUsuario.verifica_usuario(login, senha) == false)
                {

                    //mudar codigo _para acessar webservice
                    //copiar chave publica _para diretorio do usuario
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

        ///<summary>
        ///
        /// Método _para retornar diretorio referente ao usuario passado
        ///
        /// @param nome          Variavel do tipo string
        /// 
        ///</summary>
        public static DirectoryInfo listaDiretorios(string nome) {

            DirectoryInfo info = new DirectoryInfo(CAMINHO_SERVER + nome);

            if (info.Exists) return info;
            else throw new excecao(MSG_PASTA_NAO_ENCONTRADA);

        
        }

        ///<summary>
        ///
        /// Método _para retornar caminho _para abertura _de arquivo
        ///
        /// @param nome          Variavel do tipo string
        /// 
        ///</summary>
        public static string caminhoTotal(string path){

            string caminho = CAMINHO_SERVER + path + BARRA;

            return caminho;

        }

        ///<summary>
        ///
        /// Método _para abrir arquivo solicitado
        ///
        /// @param path          Variavel do tipo string
        /// 
        ///</summary>
        public static void abreArquivo(string path) {

            System.Diagnostics.Process.Start(path);
        
        }

        ///<summary>
        ///
        /// Método _para apagar arquivo solicitado
        ///
        /// @param path          Variavel do tipo string
        /// 
        ///</summary>
        public static void apagaArquivo(string path) {

            System.IO.File.Delete(path);

        }

        ///<summary>
        ///
        /// Método _para apagar arquivo solicitado
        ///
        /// @param path        Variavel do tipo string
        /// @return nome       String com o nome do arquivo
        /// 
        ///</summary>
        public static string retornaNome(string path) {

            string nome = manipulaString.retornaNome(path);

            return nome;
        
        }

        ///<summary>
        ///
        /// Método _de criação da mensagem 
        ///
        /// @param msg        Variavel do tipo mensagemNovo
        /// 
        ///</summary>
        public static bool enviaMensagem(preMensagem msg)
        {

            string xml = serial.Serializar(msg);

            Console.Out.WriteLine(xml);

            return true;
       
        }

        ///<summary>
        ///
        /// Método _para retornar todos os contatos do sistema 
        ///
        /// @return List        Lista com todos os contatos existentes no sistema
        /// @throw excecao
        /// 
        ///</summary>
        public static List<contato> buscaContatosGeral()
        { 
            try
            {
                string xml = WService.retornaContato();

                List<contato> lista = serial.Deserializar(xml, typeof(List<contato>)) as List<contato>;

                return lista;
            }
            catch (excecao except)
            {
                
                throw except;
            }
        }

        ///<summary>
        ///
        /// Método _para inserir contatos no sistema 
        ///
        /// @param lista            Variável do tipo List<contato>
        /// @param user             Variável do tipo string
        /// @return bool            Verdadeiro caso cadastro tenha sucesso
        ///                         Falso caso contrario
        /// @throw excecao
        /// 
        ///</summary>
        public static bool insereContatos(List<contato> lista, string user) {

            try
            {
                string xml = serial.Serializar(lista);

                if (WService.cadastraContato(xml, user)) return true;
                else return false;
            }
            catch (excecao except)
            {                
                throw except;
            }          

        }

        ///<summary>
        ///
        /// Método _para retornar todos os contatos do usuario 
        ///
        /// @return List<contato>        Lista com todos os contatos existentes no sistema
        /// @throw excecao
        /// 
        ///</summary>
        public static List<contato> buscaContatosPessoais(string user)
        {
            try
            {
                string xml = WService.retornaContatoPessoal(user);
                List<contato> lista = new List<contato>();

                if(xml.Length != 0) lista = serial.Deserializar(xml, typeof(List<contato>)) as List<contato>;
                
                return lista;
            }
            catch (excecao except)
            {
                throw except;
            }
        }

        ///<summary>
        ///
        /// Método _para remover contatos no catalogo pessoal 
        ///
        /// @param lista            Variável do tipo List<contato>
        /// @param user             Variável do tipo string
        /// @return bool            Verdadeiro caso cadastro tenha sucesso
        ///                         Falso caso contrario
        /// @throw excecao
        /// 
        ///</summary>
        public static bool removeContatos(List<contato> lista, string user) {

            try
            {
                string xml = serial.Serializar(lista);

                if (WService.removeContato(xml, user)) return true;
                else return false;
            }
            catch (excecao except)
            {
                throw except;
            }    
        
        }

    }
}
