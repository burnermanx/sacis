///<summary>
/// Classe para implementação dos metodos para o WebService 
///
/// @author Fabio Augusto
///</summary>

using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Diagnostics;
using sacis.model.excecao;
using sacis.model.bd;
using sacis.model.entidades;
using sacis.model.utilitarios;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

using System.Xml.Serialization;

namespace sacis.model.webService
{

    [WebService(Namespace = "http://sacis.com.br")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {        
        private static string CAMINHO_SERVER = @"c:\sacis\server\";
        private static string ENTRADA = @"\entrada";
        private static string ENVIADOS = @"\enviados";
        private static string CONTATOS = @"\contatos";
        private static string ARQUIVO_CONTATO = @"\contatos.cnt";
        private static string EMAIL = "@sacis.com.br";
        private static string CHAVEIRO = @"\chaveiro\";
        private static string MSG_ERRO_CADASTRO = "Erro ao Cadastrar Usuário!";
        private static string MSG_ERRO_REMOVER = "Erro ao Remover Contato!";
        private static string EXTENSAO = ".key";

        #region Sistema Manutenção              

        ///<summary>
        ///
        /// Método Web que verifica se o usuario passado tem permissao de acesso ao sistema de manutenção
        /// retornando verdadeiro caso usuario tenha permissão
        ///                    
        /// Retorna excecao: Erro de conexão com o banco de dados
        /// 
        ///</summary>
        [WebMethod]
        public bool verificaLoginUsuarioManutencao(string login, string senha){

            try
            {
                string str = "select permissao from usuario where login = '" + login + "' and senha = '" + senha + "'";
                string result = retornaConsultaSql(str);

                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                if (comparer.Compare("a", result) == 0) return true;
                else return false;
            }
            catch (excecao.excecao except)
            {
                throw except;
            }
        
        }

        ///<summary>
        ///
        /// Método Web que verifica a existencia de um usuario cadastrado atraves do login passado
        /// retornando verdadeiro caso usuario seja cadastrado
        ///                    
        /// Retorna excecao: Erro de conexão com o banco de dados
        /// 
        ///</summary>
        [WebMethod]
        public bool verificaUsuario(string login)
        {
            try
            {
                string str = "select login from usuario where login = '" + login + "'";
                string result = retornaConsultaSql(str);

                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                if (comparer.Compare(login, result) == 0) return true;
                else return false;
            }
            catch (excecao.excecao except)
            {
                throw except;
            }
        }

        ///<summary>
        ///
        /// Método Web que reseta a senha de um usuário cadastrado através do login e senha passados
        /// retornando verdadeiro caso reset seja realizado com sucesso.
        ///                    
        /// Retorna excecao: Erro de conexão com o banco de dados
        /// 
        ///</summary>
        [WebMethod]
        public bool resetaSenha(string login)
        {
            try
            {
                if (verificaUsuario(login))
                {
                    MySqlConnection conecta = conectaMysql.conectaMSQL();
                    conecta.Open();

                    string str = "UPDATE usuario SET alterasenha = 's' WHERE login = '" + login + "'";

                    MySqlCommand exec = new MySqlCommand(str, conecta);
                    exec.ExecuteNonQuery();

                    conectaMysql.desconectaMSQL();

                    return true;

                }
                else return false;
            }
            catch (excecao.excecao except)
            {
                throw except;
            }
        }

        ///<summary>
        ///
        /// Método Web que alterar o nome do usuário cadastrado através do login passado
        /// retornando verdadeiro caso alteração seja realizada com sucesso.
        ///                    
        /// Retorna excecao: Erro de conexão com o banco de dados
        /// 
        ///</summary>
        [WebMethod]
        public bool alteraNome(string login, string nome)
        {
            try
            {
                if (verificaUsuario(login))
                {

                    MySqlConnection conecta = conectaMysql.conectaMSQL();
                    conecta.Open();

                    string str = "UPDATE usuario SET nome = '" + nome + "' WHERE login = '" + login + "'";

                    MySqlCommand exec = new MySqlCommand(str, conecta);
                    exec.ExecuteNonQuery();

                    conectaMysql.desconectaMSQL();

                    return true;

                }
                else return false;
            }
            catch (excecao.excecao except)
            {
                throw except;
            }
        }

        ///<summary>
        ///
        /// Método Web que altera a permissão do usuário cadastrado através do login passado
        /// retornando verdadeiro caso alteração seja realizada com sucesso.
        ///                    
        /// Retorna excecao: Erro de conexão com o banco de dados
        /// 
        ///</summary>
        [WebMethod]
        public bool alteraPermissao(string login, int permissao)
        {
            try
            {
                if (verificaUsuario(login))
                {
                    char permite = 'u';

                    MySqlConnection conecta = conectaMysql.conectaMSQL();
                    conecta.Open();

                    if (permissao == 0) permite = 'a';
                    else if (permissao == 1) permite = 'u';

                    string str = "UPDATE usuario SET permissao = '" + permite + "' WHERE login = '" + login + "'";

                    MySqlCommand exec = new MySqlCommand(str, conecta);
                    exec.ExecuteNonQuery();

                    conectaMysql.desconectaMSQL();

                    return true;

                }
                else return false;
            }
            catch (excecao.excecao except)
            {
                throw except;
            }

        }

        ///<summary>
        ///
        /// Método Web que alterar o certificado do usuário cadastrado através do login passado
        /// retornando verdadeiro caso alteração seja realizada com sucesso.
        ///                    
        /// Retorna excecao: Erro de conexão com o banco de dados
        /// 
        ///</summary>
        [WebMethod]
        public bool alteraCertificado(string login, string certificado, string validade)
        {
            try
            {
                if (verificaUsuario(login))
                {
                    string key = login + EXTENSAO;
                    manipulaArquivo.criaArquivoTexto(CAMINHO_SERVER + CHAVEIRO + key, certificado);

                    MySqlConnection conecta = conectaMysql.conectaMSQL();
                    conecta.Open();

                    string str = "UPDATE usuario SET expirachave = 'n', validade = '" + validade + "' WHERE login = '" + login + "';";

                    MySqlCommand exec = new MySqlCommand(str, conecta);
                    exec.ExecuteNonQuery();

                    conectaMysql.desconectaMSQL();

                    return true;
                }
                else return false;
            }
            catch (excecao.excecao except)
            {
                throw except;
            }
        }

        ///<summary>
        ///
        /// Método Web que exclui um usuário cadastrado através do login passado
        /// retornando verdadeiro caso exclusão seja realizada com sucesso.
        ///                    
        /// Retorna excecao: Erro de conexão com o banco de dados
        /// 
        ///</summary>
        [WebMethod]
        public bool excluiUsuario(string login)
        {
            try
            {
                if (verificaUsuario(login))
                {
                    MySqlConnection conecta = conectaMysql.conectaMSQL();
                    conecta.Open();

                    string str = "DELETE FROM usuario WHERE login = '" + login + "'";

                    MySqlCommand exec = new MySqlCommand(str, conecta);
                    exec.ExecuteNonQuery();

                    conectaMysql.desconectaMSQL();

                    string key = login + EXTENSAO;
                    manipulaArquivo.excluiArquivoTexto(CAMINHO_SERVER + CHAVEIRO + key);
                    manipulaArquivo.excluiDiretorios(CAMINHO_SERVER + login);

                    return true;

                }
                else return false;
            }
            catch (excecao.excecao except)
            {
                throw except;
            }
        }        

        ///<summary>
        ///
        /// Método Web que cadastra o usuário passado em xml no banco de dados    
        ///                    
        /// Retorna excecao: Erro de conexão com o banco de dados
        /// 
        ///</summary>
        [WebMethod]
        public void cadastraUsuario(string xmluser)
        {
            try
            {
                usuario user = serial.Deserializar(xmluser, typeof(usuario)) as usuario;

                string key = user.getLogin() + EXTENSAO;
                char permissao = 'u';

                MySqlConnection conecta = conectaMysql.conectaMSQL();
                conecta.Open();

                if (user.getPermissao() == 0) permissao = 'a';
                else if (user.getPermissao() == 1) permissao = 'u';              

                string str = "INSERT INTO usuario(login, senha, nome, validade, permissao, expirachave)VALUES('" + user.getLogin() + "','" + user.getSenha() + "','" + user.getNome() + "','" + user.getValidade() + "','" + permissao + "','n');";

                MySqlCommand exec = new MySqlCommand(str, conecta);
                exec.ExecuteNonQuery();

                conectaMysql.desconectaMSQL();
                criaDiretoriosUsuario(user, key);

            }
            catch (excecao.excecao except)
            {
                throw except;
            }
        }

        ///<summary>
        ///
        /// Método que cria diretorios e arquivos para o novo usuario cadastrado         
        /// 
        ///</summary>
        private void criaDiretoriosUsuario(usuario user, string key)
        {
            manipulaArquivo.criaDiretorio(CAMINHO_SERVER + user.getLogin());
            manipulaArquivo.criaDiretorio(CAMINHO_SERVER + user.getLogin() + ENTRADA);
            manipulaArquivo.criaDiretorio(CAMINHO_SERVER + user.getLogin() + ENVIADOS);
            manipulaArquivo.criaDiretorio(CAMINHO_SERVER + user.getLogin() + CONTATOS);
            manipulaArquivo.criaArquivoTexto(CAMINHO_SERVER + user.getLogin() + CONTATOS + ARQUIVO_CONTATO, null);
            manipulaArquivo.criaArquivoTexto(CAMINHO_SERVER + CHAVEIRO + key, user.getChave());
        }

        #endregion

        #region Sistema de Mensagens

        ///<summary>
        ///
        /// Método Web que consulta o login e hash da senha passado retornando 
        /// verdadeiro caso exista cadastro do usuario no banco de dados.  
        ///                    
        /// Retorna excecao: Erro de conexão com o banco de dados
        /// 
        ///</summary>
        [WebMethod]
        public int consultaUsuario(string login, string senha)
        {
            try
            {
                string sql = "select senha, alterasenha, expirachave, dias from usuario where login = '" + login + "'";
                
                string pass = "";
                string alteraSenha = "";
                string expirachave = "";
                string dias = "";

                DataTable data = retornaDataTableSql(sql);

                if (data.Rows.Count > 0)
                {
                    pass = data.Rows[0][data.Columns[0]].ToString();
                    alteraSenha = data.Rows[0][data.Columns[1]].ToString();
                    expirachave = data.Rows[0][data.Columns[2]].ToString();
                    dias = data.Rows[0][data.Columns[3]].ToString();
                }
                
                if (alteraSenha.Equals("s")) return 1;
                else if (expirachave.Equals("s")) return 2;
                else if (expirachave.Equals("t")) return 100 + Convert.ToInt32(dias);
                else if (senha.Equals(pass)) return 0;                
                else return 3;
            }
            catch (excecao.excecao except)
            {
                throw except;
            }
            catch (NullReferenceException nu)
            {
                return 3;            
            }
        }

        ///<summary>
        ///
        /// Método Web que altera a senha de um usuário cadastrado através do login e senha passados
        /// retornando verdadeiro caso alteração seja realizada com sucesso.
        ///                    
        /// Retorna excecao: Erro de conexão com o banco de dados
        /// 
        ///</summary>
        [WebMethod]
        public bool alteraSenha(string login, string senha)
        {
            try
            {
                MySqlConnection conecta = conectaMysql.conectaMSQL();
                conecta.Open();

                string str = "UPDATE usuario SET senha = '" + senha + "', alterasenha = 'n' WHERE login = '" + login + "'";

                MySqlCommand exec = new MySqlCommand(str, conecta);
                exec.ExecuteNonQuery();

                conectaMysql.desconectaMSQL();

                return true;

            }
            catch (excecao.excecao except)
            {
                throw except;
            }
            
        }

        ///<summary>
        ///
        /// Método Web que retorna os contatos existentes na base de dados
        /// 
        /// Retorna excecao: Erro de conexão com o banco de dados
        /// 
        ///</summary>
        [WebMethod]
        public string retornaContatos()
        {
            try
            {
                string str = "select nome,login from usuario";
                List<contato> lista = new List<contato>();

                DataTable data = retornaDataTableSql(str);

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    string nome = data.Rows[i][data.Columns[0]].ToString();
                    string email = data.Rows[i][data.Columns[1]].ToString() + EMAIL;
                    contato contact = new contato(nome, email);
                    lista.Add(contact);
                }

                string dados = serial.serializarObjeto(lista);

                return dados;
            }
            catch (excecao.excecao except)
            {
                throw except;
            }
        }

        ///<summary>
        ///
        /// Método Web que cadastra uma lista de contatos passados em xml no arquivo de contato pessoal 
        /// do usuario passado retornando verdadeiro caso cadastro seja realizado com sucesso.
        ///                     
        /// Retorna excecao: Erro de conexão com o banco de dados ou erro de cadastro
        ///  
        ///</summary>
        [WebMethod]
        public bool cadastraContatoPessoal(string xml, string user)
        {
            try
            {
                string caminho = CAMINHO_SERVER + user + CONTATOS + ARQUIVO_CONTATO;
                string contatos;
                IEnumerable<contato> IContatos;
                List<contato> uniao = new List<contato>();

                List<contato> contatosXml = serial.Deserializar(xml, typeof(List<contato>)) as List<contato>;
                string contatoLocal = manipulaArquivo.leArquivoTexto(caminho);

                if (contatoLocal.Length != 0)
                {
                    List<contato> local = serial.Deserializar(contatoLocal, typeof(List<contato>)) as List<contato>;
                    IContatos = contatosXml.Union<contato>(local);
                    foreach (contato c in IContatos) uniao.Add(c);
                    contatos = serial.serializarObjeto(uniao);
                }
                else contatos = serial.serializarObjeto(contatosXml);

                manipulaArquivo.escreveArquivo(caminho, contatos, false);

                return true;
            }
            catch (Exception excp)
            {
                throw new excecao.excecao(MSG_ERRO_CADASTRO);
            }
        }

        ///<summary>
        ///
        /// Método Web que retorna os contatos do usuario passado
        ///                    
        /// Retorna excecao: Erro de leitura de arquivo 
        /// 
        ///</summary>
        [WebMethod]
        public string retornaContatoPessoal(string user)
        {
            try
            {
                string caminho = CAMINHO_SERVER + user + CONTATOS + ARQUIVO_CONTATO;
                string xml = manipulaArquivo.leArquivoTexto(caminho);

                return xml;
            }
            catch (excecao.excecao except)
            {
                throw except;
            }
        }

        ///<summary>
        ///
        /// Método Web que remove uma lista de contatos passado em xml no arquivo de contato pessoal 
        /// do usuario passado retornando verdadeiro caso cadastro seja realizado com sucesso.  
        ///                     
        /// Retorna excecao: Erro na remoção de contato 
        /// 
        ///</summary>
        [WebMethod]
        public bool removeContatoPessoal(string xml, string user)
        {
            try
            {
                string caminho = CAMINHO_SERVER + user + CONTATOS + ARQUIVO_CONTATO;
                manipulaArquivo.escreveArquivo(caminho, xml, false);

                return true;
            }
            catch (Exception excp)
            {
                throw new excecao.excecao(MSG_ERRO_REMOVER);
            }
        }

        ///<summary>
        ///
        /// Método que retorna dados referentes a consulta da sql passada no banco de dados
        /// 
        ///</summary>
        private string retornaConsultaSql(string sql)
        {
            MySqlConnection conecta = conectaMysql.conectaMSQL();
            conecta.Open();

            MySqlCommand exec = new MySqlCommand(sql, conecta);
            string result = (string)exec.ExecuteScalar();

            conectaMysql.desconectaMSQL();

            return result;
        }

        ///<summary>
        ///
        /// Método que retorna um DataTable contendo os dados da consulta sql passada no banco de dados
        /// 
        ///</summary>
        private DataTable retornaDataTableSql(string sql)
        {
            MySqlConnection conecta = conectaMysql.conectaMSQL();
            conecta.Open();

            MySqlCommand cmd = new MySqlCommand(sql, conecta);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable ds = new DataTable();
            da.Fill(ds);

            conectaMysql.desconectaMSQL();

            return ds;
        }

        ///<summary>
        ///
        /// Método para enviar as mensagem aos destinatarios
        /// 
        ///</summary>
        [WebMethod]
        public bool enviaMensagem(string xml) {
            try{
                mensagem mensagem = serial.Deserializar(xml, typeof(mensagem)) as mensagem;
                            
                string caminhoDestinatario = CAMINHO_SERVER + mensagem.getPara() + ENTRADA + "\\";
                string caminhoRemetente = CAMINHO_SERVER + mensagem.getDe() + ENVIADOS + "\\";
                string caminhoRemetenteErro = CAMINHO_SERVER + mensagem.getDe() + ENTRADA + "\\";
                string INSERT = "INSERT INTO mensagem(id, loginusuario, assunto, lida, logremdest, tipo, data, tamanho, listadestinatarios)VALUES";

                MySqlConnection conecta = conectaMysql.conectaMSQL();
                conecta.Open();

                string sql = "select id from seq_mensagem;";                
                MySqlCommand exec = new MySqlCommand(sql, conecta);
                string maxId = exec.ExecuteScalar().ToString();
                int id = Convert.ToInt16(maxId)+1;

                sql = "Update seq_mensagem set id = " + id + ";";
                new MySqlCommand(sql, conecta).ExecuteNonQuery();

                if (mensagem.getDe() == mensagem.getPara())
                {
                    sql = INSERT + "(" + id + ",'" + mensagem.getDe() + "','" + mensagem.getAssunto() + "'," + 1 + ",'" + mensagem.getPara() + "','ENVIADOS', now()," + xml.Length + ",'" + mensagem.getListaDestinatarios() + "');";
                    manipulaArquivo.criaArquivoTexto(caminhoRemetente + id + ".msg", xml);
                }
                else
                {
                    sql = INSERT + "(" + id + ",'" + mensagem.getPara() + "','" + mensagem.getAssunto() + "', 0 ,'" + mensagem.getDe() + "','ENTRADA', now()," + xml.Length + ",'" + mensagem.getListaDestinatarios() + "');";
                    manipulaArquivo.criaArquivoTexto(caminhoDestinatario + id + ".msg", xml);
                }

                new MySqlCommand(sql, conecta).ExecuteNonQuery();     
        
                conectaMysql.desconectaMSQL();
                return true;            
            
            }catch (excecao.excecao except)
            {
                throw except;
            }
          }

        ///<summary>
        ///
        /// Método para enviar o cabeçalho das mensagem do usuario
        /// 
        ///</summary>
        [WebMethod]
        public string retornaCabecalho(string login, string tipo){

            try
            {
                string xml = null;
                string sql = "select id, assunto, data, tamanho, logremdest, lida from mensagem where tipo = '" + tipo + "' and loginusuario = '" + login + "';";

                List<mensagemCabecalho> listaCabecalho = new List<mensagemCabecalho>();

                DataTable data = retornaDataTableSql(sql);
                int i;

                    for (i = 0; i < data.Rows.Count; i++)
                    {
                        int codigo = Convert.ToInt32(data.Rows[i][data.Columns[0]]);
                        string assunto = data.Rows[i][data.Columns[1]].ToString();
                        DateTime date = Convert.ToDateTime(data.Rows[i][data.Columns[2]]);
                        int tamanho = Convert.ToInt32(data.Rows[i][data.Columns[3]]);
                        string logremdest = data.Rows[i][data.Columns[4]].ToString();
                        bool lida = Convert.ToBoolean(data.Rows[i][data.Columns[5]]);

                        mensagemCabecalho cabeca = new mensagemCabecalho(codigo, date, assunto, tipo, lida, tamanho, logremdest);

                        listaCabecalho.Add(cabeca);
                    }

                    if (listaCabecalho.Count > 0) xml = serial.serializarObjeto(listaCabecalho);

                    return xml;
                
            }
            catch (excecao.excecao except)
            {
                throw except;
            }
        }

        ///<summary>
        ///
        /// Método para apagar mensagem do usuario
        /// 
        ///</summary>
        [WebMethod]
        public bool apagaMensagem(int id) {
 
            try
            {
                string sql = "select loginusuario, tipo from mensagem where id = " + id + ";";

                DataTable data = retornaDataTableSql(sql);

                if (data.Rows.Count > 0)
                {

                    string login = data.Rows[0][data.Columns[0]].ToString();
                    string tipo = data.Rows[0][data.Columns[1]].ToString();

                    string caminho = CAMINHO_SERVER + "\\" + login + "\\" + tipo + "\\" + id + ".msg";

                    manipulaArquivo.excluiArquivoTexto(caminho);

                    MySqlConnection conecta = conectaMysql.conectaMSQL();
                    conecta.Open();

                    sql = "delete from mensagem where id = " + id + ";";

                    MySqlCommand exec = new MySqlCommand(sql, conecta);
                    exec.ExecuteNonQuery();

                    conectaMysql.desconectaMSQL();

                    return true;

                } else return false;

            }
            catch (excecao.excecao except)
            {
                throw except;
            }

        }

        ///<summary>
        ///
        /// Método para retornar mensagem do usuario
        /// 
        ///</summary>
        [WebMethod]
        public string buscaMensagem(int id) {

            try
            {
                string sql = "select loginusuario, tipo from mensagem where id = " + id + ";";

                DataTable data = retornaDataTableSql(sql);

                if (data.Rows.Count > 0)
                {
                    string login = data.Rows[0][data.Columns[0]].ToString();
                    string tipo = data.Rows[0][data.Columns[1]].ToString();

                    string caminho = CAMINHO_SERVER + "\\" + login + "\\" + tipo + "\\" + id + ".msg";
                    string xml = manipulaArquivo.leArquivoTexto(caminho);
                    
                    mensagem msg = serial.Deserializar(xml, typeof(mensagem)) as mensagem;

                    for (int i = 0; i < msg.anexos.Count; i++)
                    {
                        msg.anexos[i].setChave("");
                        msg.anexos[i].setConteudo("");
                    }

                    return serial.serializarObjeto(msg);  

                }
                else return null;
            }
            catch (excecao.excecao except)
            {
                throw except;
            }
        }

        ///<summary>
        ///
        /// Método para retornar anexo do usuario ao encaminhar
        /// 
        ///</summary>
        [WebMethod]
        public string buscaAnexo(int id)
        {
            try
            {
                string sql = "select loginusuario, tipo from mensagem where id = " + id + ";";

                DataTable data = retornaDataTableSql(sql);

                string login = data.Rows[0][data.Columns[0]].ToString();
                string tipo = data.Rows[0][data.Columns[1]].ToString();

                string caminho = CAMINHO_SERVER + "\\" + login + "\\" + tipo + "\\" + id + ".msg";
                string xml = manipulaArquivo.leArquivoTexto(caminho);

                mensagem msg = serial.Deserializar(xml, typeof(mensagem)) as mensagem;

                return serial.serializarObjeto(msg.anexos);
            }
            catch (excecao.excecao except)
            {
                throw except;
            }
        }
        
        ///<summary>
        ///
        /// Método para abrir anexo do usuario
        /// 
        ///</summary>
        [WebMethod]
        public string abreAnexo(string nomeArq, int id)
        {

            try
            {
                string sql = "select loginusuario, tipo from mensagem where id = " + id + ";";

                DataTable data = retornaDataTableSql(sql);

                string login = data.Rows[0][data.Columns[0]].ToString();
                string tipo = data.Rows[0][data.Columns[1]].ToString();

                string caminho = CAMINHO_SERVER + "\\" + login + "\\" + tipo + "\\" + id + ".msg";
                string xml = manipulaArquivo.leArquivoTexto(caminho);

                mensagem msg = serial.Deserializar(xml, typeof(mensagem)) as mensagem;

                anexo anexoFinal = new anexo();

                foreach (anexo a in msg.anexos)
                {
                    if (a.getNome().Equals(nomeArq)) 
                    {
                        anexoFinal = a;
                    }
                }

                return serial.serializarObjeto(anexoFinal);
            }
            catch (excecao.excecao except)
            {
                throw except;
            }
        }

        ///<summary>
        ///
        /// Método para retornar a chave publica de um usuario
        /// 
        ///</summary>
        [WebMethod]
        public string retornaChavePublica(string destinatario) {

            string chave = manipulaArquivo.leArquivoTexto(CAMINHO_SERVER+CHAVEIRO+destinatario+EXTENSAO);

            return chave;
        }

        ///<summary>
        ///
        /// Método para verificar se a mensagem do usuario está criptografada
        /// 
        ///</summary>
        [WebMethod]
        public bool verificaMensagemCriptografada(int id) {
            try
            {
                bool verifica = false;

                string sql = "select loginusuario, tipo from mensagem where id = " + id + ";";

                DataTable data = retornaDataTableSql(sql);

                if (data.Rows.Count > 0)
                {
                    string login = data.Rows[0][data.Columns[0]].ToString();
                    string tipo = data.Rows[0][data.Columns[1]].ToString();

                    string caminho = CAMINHO_SERVER + "\\" + login + "\\" + tipo + "\\" + id + ".msg";
                    string xml = manipulaArquivo.leArquivoTexto(caminho);

                    mensagem msg = serial.Deserializar(xml, typeof(mensagem)) as mensagem;

                    if (msg.getCriptografar()) verifica = true;
                    else verifica = false;
                }
                
                return verifica;
            }
            catch (excecao.excecao except)
            {
                throw except;
            }
        }
        
        #endregion
        
    }
}
