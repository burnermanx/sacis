///<summary>
/// Classe para implementação do servlet de controle do gerenciamento de mensagens 
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
using System.Net;

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
        /// Método que retorna o hash de uma string passada.
        ///
        ///</summary>
        public static string geraHash(string texto)
        {
            return hash.hashing(texto);
        }

        ///<summary>
        ///
        /// Método que consulta a existência do usuário através do login e hash da senha passados
        /// no servidor web e retorna verdadeiro caso exista.
        ///
        /// Retorna excecao
        /// 
        ///</summary>
        public static bool consultaUsuario(string login, string senha) 
        {
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
        /// Método que atualiza usuario nao registrado localmente no arquivo local 
        /// através do login e hash da senha passados.
        ///
        /// Retorna excecao: erro de escrita ou criação de arquivo ou diretorio.
        /// 
        ///</summary>
        public static void atualizaUsuarioLogLocal(string login, string senha) 
        {
            try
            {
                manipulaArquivo.criaDiretorioLogLocal();

                if (verificaUsuario.verificaCadastroUsuarioLocal(login, senha) == false)
                {
                    //mudar este codigo para acessar webservice e
                    //copiar chave publica para diretorio do chaveiro local
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
        /// Método que retorna o conteúdo do diretorio do usuario passado.
        ///
        ///</summary>
        public static DirectoryInfo listaDiretorios(string nomeUsuario) {

            DirectoryInfo info = new DirectoryInfo(CAMINHO_SERVER + nomeUsuario);

            if (info.Exists) return info;
            else throw new excecao(MSG_PASTA_NAO_ENCONTRADA);
        
        }

        ///<summary>
        ///
        /// Método que retorna o caminho completo.
        ///
        ///</summary>
        public static string caminhoTotal(string path){

            string caminho = CAMINHO_SERVER + path + BARRA;

            return caminho;

        }

        ///<summary>
        ///
        /// Método que abre o arquivo referente ao caminho passado.
        /// 
        ///</summary>
        public static void abreArquivo(string path) {

            System.Diagnostics.Process.Start(path);
        
        }

        ///<summary>
        ///
        /// Método que apaga o arquivo referente ao caminho passado.
        ///
        ///</summary>
        public static void apagaArquivo(string path) {

            System.IO.File.Delete(path);

        }

        ///<summary>
        ///
        /// Método que retorna o nome do arquivo referente ao caminho passado.
        ///
        ///</summary>
        public static string retornaNome(string path) {

            string nome = manipulaString.retornaNomeArquivo(path);

            return nome;
        
        }

        ///<summary>
        ///
        /// Método que retorna a lista de contatos convertida de uma string passada.
        ///
        /// Retorna excecao: Erro de contato inválido.
        /// 
        ///</summary>
        public static List<contato> converteParaLista(string para)
        {
            try
            {
                List<contato> contatos = manipulaString.retornaListaContatos(para);
                return contatos;
            }
            catch (excecao except)
            {                
                throw except;
            }
        }

        ///<summary>
        ///
        /// Método que cria mensagem a ser enviada a partir da pre-mensagem passada retornando 
        /// verdadeiro caso o envio seja feito com sucesso.
        ///
        /// Retorna excecao.
        /// 
        ///</summary>
        public static bool criaMensagem(preMensagem msg)
        {
            // tem que arrumar ainda a criptografia e assinatura do body. 
            // Provavelmente desmembrar este metodo em outros metodos
            try
            {
                string[] para = manipulaString.retornaLoginsContatos(msg.getPara());
                string de = msg.getDe();
                string assunto = msg.getAssunto();
                string body = msg.getTexto();
                string assinatura = "ok";
                bool cripto = msg.getCriptografar();
                bool sign = msg.getAssinar();
                List<anexo> arquivosPlain = new List<anexo>();
                List<anexo> arquivosCripto = new List<anexo>();
                 
                foreach (string s in msg.getArquivoPlain())
                {
                    string conteudo = manipulaArquivo.leArquivoTexto(s);
                    string nome = manipulaString.retornaNomeArquivo(s);
                    anexo next = new anexo(nome, false, "", conteudo);
                    arquivosPlain.Add(next);
                }

                foreach (string nome in para)
                {
                    arquivosCripto.Clear();

                    foreach (string s in msg.getArquivoCripto())
                    {
                        string conteudo = manipulaArquivo.leArquivoTexto(s);
                        string name = manipulaString.retornaNomeArquivo(s);
                        string nomeCodificado = manipulaString.mudaExtensaoArquivo(name);

                        // fazer chamada para enviar conteudo lido para ser cifrado,
                        // retorná-lo junto com a chave simetrica
                        //cifrar a chave simetrica com a cifra assimetrica

                        anexo next = new anexo(nomeCodificado, true, "cifra assimétrica da chave simetrica", conteudo);
                        arquivosCripto.Add(next);
                    }

                    if (sign) {
                    
                        // fazer a parte da assinatura

                    }

                    foreach (anexo a in arquivosCripto) arquivosPlain.Add(a);

                    mensagem mensagem = new mensagem(de, nome, assunto, body, assinatura, cripto, sign, arquivosPlain);
                    
                    string xml = serial.serializarObjeto(mensagem);
                    Console.Out.WriteLine(xml);
                    manipulaArquivo.criaArquivoTexto(@"d:\"+nome+".txt", xml);

                }                               

                return true;
            }
            catch (excecao except)
            {
                throw except;
            }       
        }

        ///<summary>
        ///
        /// Método que retorna a lista dos contatos existentes no sistema.
        /// 
        /// Retorna excecao.
        ///
        ///</summary>
        public static List<contato> buscaContatosGeral()
        { 
            try
            {
                string xml = WService.retornaContatos();
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
        /// Método que insere nos contatos do catalogo pessoal do usuario passado a lista de contatos
        /// passada.
        ///
        /// Retorna excecao.
        /// 
        ///</summary>
        public static bool insereContatosPessoal(List<contato> lista, string user) 
        {
            try
            {
                string xml = serial.serializarObjeto(lista);

                if (WService.cadastraContatoPessoal(xml, user)) return true;
                else return false;
            }
            catch (excecao except)
            {                
                throw except;
            }      
        }

        ///<summary>
        ///
        /// Método que retorna os contatos pessoais do usuario passado
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
        /// Método que remove os contatos no catalogo pessoal do usuario passado a lista de contatos
        /// passada.
        ///
        /// Retorna excecao.
        ///
        ///</summary>
        public static bool removeContatosPessoal(List<contato> lista, string user) 
        {
            try
            {
                string xml = serial.serializarObjeto(lista);

                if (WService.removeContatoPessoal(xml, user)) return true;
                else return false;
            }
            catch (excecao except)
            {
                throw except;
            }            
        }
    }
}
