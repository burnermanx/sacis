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
        //private static string CAMINHO_USUARIOS = @"C:\sacis\usuarios\";
        //private static string CAMINHO_CHAVEIRO = @"C:\sacis\server\chaveiro\";        
        private static string CAMINHO_SERVER = @"C:\sacis\server\";
        private static string CAMINHO_TEMP = @"C:\sacis\temp\";
        private static string MSG_PASTA_NAO_ENCONTRADA = @"Pasta nao encontrada";
        private static string USUARIO_INEXISTENTE = "Digite Usuário Válido!";
        private static string EXTENSAO = ".key";
        private static string EXTENSAO_SAC = ".sac";
        private static string BARRA = @"\";
        private static string MSG_ERRO_ABRIR = "Não foi possível abrir a mensagem. Motivo: Mensagem Corrompida.";
        private static List<string> anexosValidados = new List<string>();
        private static string EMAIL = "@sacis.com.br;";

        private static localhost.Service1 WService = new localhost.Service1();

        ///<summary>
        ///
        /// Método que altera a senha de um usuário cadastrado no web service atraves do login e 
        /// senha passados retornando verdadeiro caso seja alterada a senha
        ///                    
        /// Retorna excecao: Erro de conexão com o banco de dados e de usuario inexistente
        /// 
        ///</summary>
        public static bool alteraSenha(string login, string senha)
        {
            string hashsenha = hash.hashing(senha);

            try
            {
                return WService.alteraSenha(login, hashsenha);
            }
            catch (excecao except)
            {
                throw except;
            }
        }

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
        /// Método que realiza a consulta do status do usuário através do login e hash da senha passados
        /// no servidor web e retorna um indice referente a ele.
        ///
        /// Retorna excecao
        /// 
        ///</summary>
        public static int consultaUsuario(string login, string senha) 
        {
            try
            {
                if (!verificaCampos.verificaValidadeCampos(login)) 
                    return WService.consultaUsuario(login, senha);
                else throw new excecao(USUARIO_INEXISTENTE);
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

                if (!verificaUsuario.verificaCadastroUsuarioLocal(login, senha))
                {
                    if (verificaUsuario.verificaCadastroUsuarioLocal(login))
                    {
                        manipulaArquivo.atualizaUsuarioLog(login, senha);
                    }
                    else
                    {
                        manipulaArquivo.atualizaLog(login, senha);
                    }
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
        /// Método que abre o arquivo através do nome passado.
        /// 
        ///</summary>
        public static void abreArquivo(string nomeArq, int id, string caminhoChave) {

            string xml = WService.abreAnexo(nomeArq, id);

            anexo anexos = serial.Deserializar(xml, typeof(anexo)) as anexo;

            string nome;
            string conteudo;

            if (anexos.getCripto())
            {
                nome = manipulaString.recuperaNomeOriginalArquivo(anexos.getNome());
                string chaveCifrada = simetrica.convertToString(anexos.getChave());
                string chaveDecifrada = assimetrica.decifraAssimetrica(caminhoChave, chaveCifrada);
                
                string conteudoCifrado = simetrica.convertToString(anexos.getConteudo());
                conteudo = simetrica.decifraAnexos(chaveDecifrada, conteudoCifrado);
            }
            else
            {
                nome = anexos.getNome();
                string conteudoOriginal = simetrica.convertToString(anexos.getConteudo());
                conteudo = conteudoOriginal;
            }

            byte[] conteudoByte = serial.Deserializar(conteudo, typeof(byte[])) as byte[];
            manipulaArquivo.arquivoCriaOriginal(CAMINHO_TEMP + nome, conteudoByte);

            System.Diagnostics.Process.Start(CAMINHO_TEMP + nome);        
        }
/*
         ///<summary>
        ///
        /// Método que abre o arquivo referente ao caminho passado.
        /// 
        ///</summary>
        public static void abreArquivo(string caminho) {

            string nome;
            string conteudo;

            if (caminho.Contains(".sac"))
            {
                //nome = manipulaString.recuperaNomeOriginalArquivo(anexos.getNome());
                //string chave = simetrica.convertToString(anexos.getChave());
                //string conteudoCifrado = simetrica.convertToString(anexos.getConteudo());
                //conteudo = simetrica.decifraAnexos(chave, conteudoCifrado);
            }
            else
            {
                System.Diagnostics.Process.Start(caminho);
            }
            //System.Diagnostics.Process.Start(CAMINHO_TEMP + nome);

        }
*/
        ///<summary>
        ///
        /// Método que realiza chamada para apagar mensagem no servidor
        ///
        ///</summary>
        public static bool apagaMensagem(int id) {

            if (WService.apagaMensagem(id)) return true;
            else return false;

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
        public static List<string> criaMensagem(preMensagem msg, string caminhoChave)
        {
            try
            {
                string destinatarios = msg.getPara() + msg.getDe() + EMAIL;
                string[] para = manipulaString.retornaLoginsContatos(destinatarios);
                string de = msg.getDe();
                string assunto = msg.getAssunto();
                string body = "";
                string assinatura = "";
                bool cripto = msg.getCriptografar();
                bool sign = msg.getAssinar();
                List<anexo> arquivosPlain = new List<anexo>();
                List<anexo> arquivosCripto = new List<anexo>();
                List<string> destinatarioInexistentes = new List<string>();
                
                // trazendo os arquivos que nao serao criptografados para a lista
                foreach (string s in msg.getArquivoPlain())
                {
                    bool cript = false;
                    anexo next = retornaConteudoAnexo(s, cript, "");
                    arquivosPlain.Add(next);
                }
                               
                // criando a mensagem para enviar a cada destinatario
                foreach (string destinatario in para)
                {
                    if (WService.verificaUsuario(destinatario))
                    {
                        body = msg.getTexto();
                        arquivosCripto.Clear();

                        foreach (string s in msg.getArquivoCripto())
                        {
                            string nome = s;
                            bool cript = true;
                            if (s.Contains(EXTENSAO_SAC)) nome = manipulaString.recuperaNomeOriginalArquivo(s);
                            anexo next = retornaConteudoAnexo(nome, cript, destinatario);
                            arquivosCripto.Add(next);
                        }

                        foreach (anexo ap in arquivosPlain) arquivosCripto.Add(ap);

                        if (sign)
                        {
                            assinatura = assimetrica.assinaTexto(caminhoChave, body);
                        }

                        if (cripto)
                        {
                            string chaveCertificada = WService.retornaChavePublica(destinatario);
                            string caminhoChaveCert = CAMINHO_TEMP + destinatario + EXTENSAO;
                            manipulaArquivo.criaArquivoTexto(caminhoChaveCert, chaveCertificada);

                            body = simetrica.cifraMensagem(body, caminhoChaveCert);
                            body = simetrica.convertToHexa(body);
                        }

                        mensagem mensagem = new mensagem(de, destinatario, assunto, body, assinatura, cripto, sign, arquivosCripto, msg.getPara());
                        string xml = serial.serializarObjeto(mensagem);
                        WService.enviaMensagem(xml);
                        excluiArquivos();
                    }
                    else destinatarioInexistentes.Add(destinatario);
                }
                return destinatarioInexistentes;
            }
            catch (excecao except)
            {
                throw except;
            }       
        }
/*
        ///<summary>
        ///
        /// Método que retorna a assinatura da mensagem
        ///
        ///</summary>
        private static String assinaMensagem(string caminho, string mensagem) {

            return assimetrica.assinaTexto(caminho, mensagem);

        }
*/
        ///<summary>
        ///
        /// Método que retorna o conteudo do anexo da mensagem cifrado ou não
        ///
        ///</summary>
        private static anexo retornaConteudoAnexo(string s, bool cripto, string destinatario) {

            byte[] conteudoByte = manipulaArquivo.arquivoLeOriginal(s);
            string conteudo = serial.serializarObjeto(conteudoByte);
            string nome = manipulaString.retornaNomeArquivo(s).Trim();
            string nomeCodificado;
            string chave = "";
            anexo next;
            string caminhoChave = CAMINHO_TEMP + destinatario + EXTENSAO;
            nome = uniformizaAnexos(nome);

            if (cripto)
            {
                nomeCodificado = manipulaString.mudaExtensaoArquivo(nome);                
                string conteudocifrado = simetrica.cifraAnexos(conteudo);
                string conteudoHexa = simetrica.convertToHexa(conteudocifrado);
                
                chave = simetrica.getChave();

                string chaveDestinatario = WService.retornaChavePublica(destinatario);
                manipulaArquivo.criaArquivoTexto(caminhoChave, chaveDestinatario);

                string conteudoChaveCifrada = assimetrica.cifraAssimetrica(caminhoChave, chave);
                string chaveHexa = simetrica.convertToHexa(conteudoChaveCifrada);
                next = new anexo(nomeCodificado, cripto, chaveHexa, conteudoHexa);
            }
            else
            {
                string conteudoHexa = simetrica.convertToHexa(conteudo);
                next = new anexo(nome, cripto, chave, conteudoHexa);
            }

            return next;

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

        ///<summary>
        ///
        /// Método para buscar os cabecalhos das mensagens do usuario
        /// 
        ///</summary>
        public static List<mensagemCabecalho> buscaCabecalho(string login, string tipo)
        {
            string xml = WService.retornaCabecalho(login, tipo);
            if (xml != null) return serial.Deserializar(xml, typeof(List<mensagemCabecalho>)) as List<mensagemCabecalho>;

            return null;       
        }

        ///<summary>
        ///
        /// Método para verificar se a mensagem do usuario está cifrada ou não
        /// 
        ///</summary>
        public static bool verificaMensagemCriptografada(int id) 
        {
            return WService.verificaMensagemCriptografada(id);
        }

        ///<summary>
        ///
        /// Método para buscar a mensagem do usuario
        /// 
        ///</summary>
        public static preMensagem buscaMensagem(int id, string caminhoChavePrivada){
        
            string xml = WService.buscaMensagem(id);
            mensagem msg = serial.Deserializar(xml, typeof(mensagem)) as mensagem;
            preMensagem pmsg;

            HashSet<string> cripto = new HashSet<string>();
            HashSet<string> plain = new HashSet<string>();

            foreach (anexo a in msg.anexos)
            {
                if (a.getCripto()) cripto.Add(a.getNome());
                else plain.Add(a.getNome());
            }

            if (msg.getCriptografar())
            {
                string conteudoCifrado = simetrica.convertToString(msg.getTexto());
                string conteudo = simetrica.decifraMensagem(conteudoCifrado, caminhoChavePrivada);
                msg.setTexto(conteudo);
            }

            if (msg.getAssinar()) 
            {
                string conteudoChave = WService.retornaChavePublica(msg.getDe());
                string caminhoChave = CAMINHO_TEMP + msg.getDe() + EXTENSAO;
                manipulaArquivo.criaArquivoTexto(caminhoChave, conteudoChave);                
                bool textoOk = assimetrica.verificaAssinatura(caminhoChave,msg.getAssinatura(),msg.getTexto());

                if (textoOk)
                {
                    pmsg = new preMensagem(msg.getDe(), msg.getPara(), msg.getAssunto(), msg.getTexto(), msg.getCriptografar(), msg.getAssinar(), cripto, plain);
                    return pmsg;
                }
                else
                {
                    throw new excecao(MSG_ERRO_ABRIR);
                }
            }

            pmsg = new preMensagem(msg.getDe(), msg.getPara(), msg.getAssunto(), msg.getTexto(), msg.getCriptografar(), msg.getAssinar(), cripto, plain);
            return pmsg;
        }

        ///<summary>
        ///
        /// Método para baixar anexo da mensagem do usuario localmente para ser encaminhada
        /// 
        ///</summary>
        public static void anexoEncaminhar(int id, string caminhoChave)
        {
            string xml = WService.buscaAnexo(id);

            List<anexo> anexos = serial.Deserializar(xml, typeof(List<anexo>)) as List<anexo>;

            foreach (anexo a in anexos) 
            {
                string nome;
                string conteudo;

                if (a.getCripto()) 
                {                 
                    nome = manipulaString.recuperaNomeOriginalArquivo(a.getNome());
                    string chave = simetrica.convertToString(a.getChave());
                    string chaveDecifrada = assimetrica.decifraAssimetrica(caminhoChave, chave);                    
                    string conteudoCifrado = simetrica.convertToString(a.getConteudo());
                    conteudo = simetrica.decifraAnexos(chaveDecifrada, conteudoCifrado);
                } 
                else {
                    nome = a.getNome();
                    string conteudoOriginal = simetrica.convertToString(a.getConteudo());
                    conteudo = conteudoOriginal;
                }

                byte[] conteudoByte = serial.Deserializar(conteudo, typeof(byte[])) as byte[];
                manipulaArquivo.arquivoCriaOriginal(CAMINHO_TEMP + nome, conteudoByte);
            }
        }

        ///<summary>
        ///
        /// Método para excluir arquivos da pasta temporaria
        /// 
        ///</summary>
        public static void excluiArquivos() {
            try
            {
                manipulaArquivo.limpaDiretorio(CAMINHO_TEMP);

            } catch (excecao ex)
            {
                throw ex;
            }
        }

        ///<summary>
        ///
        /// Método para uniformizar os nomes dos arquivos removendo os arquivos repetidos
        /// 
        ///</summary>
        private static string uniformizaAnexos(string nomeAnexo) {

            string nome = manipulaString.substituiEspacos(nomeAnexo);
            int count = 1;

            if (anexosValidados.Count > 0)
            {
                foreach (string s in anexosValidados)
                {
                    if (s.Equals(nome))
                    {
                        int indice = nome.LastIndexOf(".");
                        string nomeTemp = nome.Remove(indice)+ "(";

                        foreach(string s2 in anexosValidados)
                        {
                            if(s2.Contains(nomeTemp) & s2.Contains(").")) count++;                      
                        }
                                                
                        string EXT = nome.Substring(indice, 4);
                        nome = nomeTemp + count + ")" + EXT;
                    }
                }

                anexosValidados.Add(nome);

            } else anexosValidados.Add(nome);

            return nome;

        }

        public static string recuperaNomeOriginalArquivo(string nome)
        {    
            return manipulaString.recuperaNomeOriginalArquivo(nome);        
        }

        public static string substituiespaco(string arq)
        {    
            return manipulaString.substituiEspacos(arq);
        }

    }
}
