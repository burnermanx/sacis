///<summary>
/// Classe para implementação do WebService 
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
using sacis.model.excecao;
using sacis.model.bd;
using sacis.model.entidades;
using sacis.model.utilitarios;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace sacis.model.webService
{

    [WebService(Namespace = "http://tempuri.org/")]
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
        private static string ERRO_CADASTRO = "Erro ao Cadastrar Usuário!";
        private static string ERRO_REMOVER = "Erro ao Remover Contato!";

        ///<summary>
        ///
        /// Método Web que verifica a existencia _de um usuario cadastrado atraves do login
        ///
        /// @param login       Objeto do tipo string
        /// 
        /// @return bool       Verdadeiro caso exista login cadastrado no banco _de dados
        ///                    Falso caso não exista
        /// @throw excecao     Retorna mensagem _de erro caso exista algum erro na conexão com o banco _de dados
        /// 
        ///</summary>
        [WebMethod]
        public bool verificaUsuario(string login)
        {
            try
            {

                string str = "select login from conecta where login = '" + login + "'";

                string result = retornaConsulta(str);

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
        /// Método Web que cadastra um usuario no banco _de dados
        ///
        /// @param user       Objeto do tipo usuario
        /// 
        /// @return bool       Verdadeiro caso cadastrado efetuado com sucesso
        ///                    Falso caso erro ao cadastrar usuario
        /// @throw excecao     Retorna mensagem _de erro caso exista algum erro na conexão com o banco _de dados
        /// 
        ///</summary>
        [WebMethod]
        public void cadastramento(string xmluser) {

            try
            {   
                //deserializando o xml passado _para o objeto usuario
                usuario user = serial.Deserializar(xmluser, typeof(usuario)) as usuario;

                string key = user.getlogin() + ".key";

                MySqlConnection conecta = conectaMysql.conectaMSQL();
                conecta.Open();

                //Sql Query
                string str = "INSERT INTO conecta(login, senha, chave, nome)VALUES('" + user.getlogin() + "','" + user.getsenha() + "','" + key + "','" + user.getnome() + "')";

                //Instância do objeto command, atribuindo a ele a conexão
                MySqlCommand exec = new MySqlCommand(str, conecta);

                //inserindo dados
                exec.ExecuteNonQuery();

                conectaMysql.desconectaMSQL();

                criaDiretorios(user, key);

            }
            catch (excecao.excecao except)
            {
                throw except;
            }    
        }

        ///<summary>
        ///
        /// Método _para criar diretorios e arquivos _para novo usuario cadastrado         
        /// 
        ///</summary>
        private void criaDiretorios(usuario user, string key) {

            manipulaArquivo.criaDiretorio(CAMINHO_SERVER + user.getlogin());
            manipulaArquivo.criaDiretorio(CAMINHO_SERVER + user.getlogin() + ENTRADA);
            manipulaArquivo.criaDiretorio(CAMINHO_SERVER + user.getlogin() + ENVIADOS);
            manipulaArquivo.criaDiretorio(CAMINHO_SERVER + user.getlogin() + CONTATOS);
            manipulaArquivo.copiaArquivo(user.getchave(), CAMINHO_SERVER + CHAVEIRO + key);
            manipulaArquivo.criaArquivo(CAMINHO_SERVER + user.getlogin() + CONTATOS + ARQUIVO_CONTATO, null);   
        
        }

        ///<summary>
        ///
        /// Método Web _para consulta _de login e senha
        ///
        /// @param user        Objeto do tipo usuario
        /// @return bool       Verdadeiro caso login e senha sejam iguais
        ///                    Falso caso contrário              
        /// @throw excecao     Retorna mensagem _de erro caso exista algum erro na conexão com o banco _de dados
        /// 
        ///</summary>
        [WebMethod]
        public bool consultaUsuario(string login, string senha)
        {
            try
            {

                string str = "select senha from conecta where login = '" + login + "'";

                string result = retornaConsulta(str);

                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                if (comparer.Compare(senha, result) == 0) return true;
                else return false;

            }
            catch (excecao.excecao except)
            {

                throw except;

            }

        }

        ///<summary>
        ///
        /// Método Web que retorna contatos existentes na base _de dados
        /// 
        /// @return string       Contatos da base _de dados
        ///                    
        /// @throw excecao       Retorna mensagem _de erro caso exista algum erro na conexão com o banco _de dados
        /// 
        ///</summary>
        [WebMethod]
        public string retornaContato() { 
        
            try{

                string str = "select nome,login from conecta";
                List<contato> lista = new List<contato>();
                
                DataTable data = retornaDados(str);

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    string nome = data.Rows[i][data.Columns[0]].ToString();
                    string email = data.Rows[i][data.Columns[1]].ToString() + EMAIL;
                    contato contact = new contato(nome, email);
                    lista.Add(contact);
                }

                string dados = serial.Serializar(lista);

                return dados;

            }
            catch (excecao.excecao except)
            {
                throw except;
            }        
        }

        ///<summary>
        ///
        /// Método Web que insere contatos no contato local
        /// 
        /// @param xml          Variavel do tipo string
        /// @param user         Variavel do tipo string
        /// @return bool        Verdadeiro caso cadastro feito com sucesso
        ///                     Falso caso contrário                     
        /// @throw excecao      Retorna mensagem _de erro caso exista algum erro na conexão com o banco _de dados
        /// 
        ///</summary>
        [WebMethod]
        public bool cadastraContato(string xml, string user) {

            try
            {
                string caminho = CAMINHO_SERVER + user + CONTATOS + ARQUIVO_CONTATO;
                string contatos;
                IEnumerable<contato> IContatos;
                List<contato> uniao = new List<contato>();

                List<contato> contatosXml = serial.Deserializar(xml, typeof(List<contato>)) as List<contato>;
                string contatoLocal = manipulaArquivo.leArquivo(caminho);

                if (contatoLocal.Length != 0)
                {
                    List<contato> local = serial.Deserializar(contatoLocal, typeof(List<contato>)) as List<contato>;
                    IContatos = contatosXml.Union<contato>(local);
                    foreach (contato c in IContatos) uniao.Add(c);
                    contatos = serial.Serializar(uniao);
                }
                else contatos = serial.Serializar(contatosXml);

                manipulaArquivo.escreveArquivo(caminho, contatos, false);

                return true;
            }
            catch (Exception excp)
            {                
                throw new excecao.excecao(ERRO_CADASTRO);
            }
        
        }

        ///<summary>
        ///
        /// Método Web que retorna contatos do usuario passado
        /// 
        /// @param user          Variavel do tipo string
        /// @return string       Contatos pessoais
        ///                    
        /// @throw excecao       
        /// 
        ///</summary>
        [WebMethod]
        public string retornaContatoPessoal(string user) {

            try
            {
                string caminho = CAMINHO_SERVER + user + CONTATOS + ARQUIVO_CONTATO;
                string xml = manipulaArquivo.leArquivo(caminho);

                return xml;
            }
            catch (excecao.excecao except)
            {                
                throw except;
            }

        }

        ///<summary>
        ///
        /// Método Web que insere contatos no contato local
        /// 
        /// @param xml          Variavel do tipo string
        /// @param user         Variavel do tipo string
        /// @return bool        Verdadeiro caso remoção feita com sucesso
        ///                     Falso caso contrário                     
        /// @throw excecao      Retorna mensagem _de erro caso exista algum erro na remoção
        /// 
        ///</summary>
        [WebMethod]
        public bool removeContato(string xml, string user) {

            try
            {
                string caminho = CAMINHO_SERVER + user + CONTATOS + ARQUIVO_CONTATO;
                manipulaArquivo.escreveArquivo(caminho,xml,false);

                return true;

            }
            catch (Exception excp)
            {
                throw new excecao.excecao(ERRO_REMOVER);
            }

        }

        ///<summary>
        ///
        /// Método _para retornar a consulta no banco _de dados
        /// 
        /// @return string       Dados recebidos do banco _de dados
        /// 
        ///</summary>
        private string retornaConsulta(string str) {

            MySqlConnection conecta = conectaMysql.conectaMSQL();
            conecta.Open();

            MySqlCommand exec = new MySqlCommand(str, conecta);
            string result = (string)exec.ExecuteScalar();

            conectaMysql.desconectaMSQL();

            return result;

        }

        ///<summary>
        ///
        /// Método _para retornar a consulta no banco _de dados
        /// 
        /// @return DataTable        Dados contidos do banco _de dados
        /// 
        ///</summary>
        private DataTable retornaDados(string str)
        {

            MySqlConnection conecta = conectaMysql.conectaMSQL();
            conecta.Open();

            MySqlCommand cmd = new MySqlCommand(str, conecta);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable ds = new DataTable();
            da.Fill(ds);       
            
            conectaMysql.desconectaMSQL();

            return ds;

        }
    }
}
