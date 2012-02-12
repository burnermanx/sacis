/*
 * Classe para implementação do WebService 
 *
 * @author Fabio Augusto
 */

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

namespace sacis.model.webService
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
        
    public class Service1 : System.Web.Services.WebService
    {

        private static string cam = @"c:\sacis\server\";

        /**
        *
        * Método Web que verifica a existencia de um usuario cadastrado atraves do login
        *
        * @param login       Objeto do tipo string
        * 
        * @return bool       Verdadeiro caso exista login cadastrado no banco de dados
        *                    Falso caso não exista
        * @throw excecao     Retorna mensagem de erro caso exista algum erro na conexão com o banco de dados
        * 
        */
        [WebMethod]
        public bool verificaUsuario(string login)
        {
            try
            {

                MySqlConnection conecta = conectaMysql.conectaMSQL();
                conecta.Open();

                string str = "select login from conecta where login = '" + login + "'";

                MySqlCommand exec = new MySqlCommand(str, conecta);
                string result = (string)exec.ExecuteScalar();

                conectaMysql.desconectaMSQL();

                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                if (comparer.Compare(login, result) == 0) return true;
                else return false;

            }
            catch (excecao.excecao except)
            {
                
                throw except;

            }
        }

        /**
        *
        * Método Web que cadastra um usuario no banco de dados
        *
        * @param user       Objeto do tipo usuario
        * 
        * @return bool       Verdadeiro caso cadastrado efetuado com sucesso
        *                    Falso caso erro ao cadastrar usuario
        * @throw excecao     Retorna mensagem de erro caso exista algum erro na conexão com o banco de dados
        * 
        */
        [WebMethod]
        public void cadastramento(string xmluser) {

            try
            {   
                //deserializando o xml passado para o objeto usuario
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

                //criando diretorios do usuario
                Directory.CreateDirectory(cam + user.getlogin());
                Directory.CreateDirectory(cam + user.getlogin() + @"\Entrada");
                Directory.CreateDirectory(cam + user.getlogin() + @"\Enviados");
                Directory.CreateDirectory(cam + user.getlogin() + @"\Contatos");

                FileInfo arquivo = new System.IO.FileInfo(user.getchave());
                arquivo.CopyTo(cam + @"\chaveiro\" + key);

            }
            catch (excecao.excecao except)
            {

                throw except;

            }
                    
        }

        /**
        *
        * Método Web para consulta de login e senha
        *
        * @param user        Objeto do tipo usuario
        * @return bool       Verdadeiro caso login e senha sejam iguais
        *                    Falso caso contrário              
        * @throw excecao     Retorna mensagem de erro caso exista algum erro na conexão com o banco de dados
        * 
        */
        [WebMethod]
        public bool consultaUsuario(string login, string senha)
        {
            try
            {

                MySqlConnection conecta = conectaMysql.conectaMSQL();
                conecta.Open();

                string str = "select senha from conecta where login = '" + login + "'";

                MySqlCommand exec = new MySqlCommand(str, conecta);
                string result = (string)exec.ExecuteScalar();

                conectaMysql.desconectaMSQL();

                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                if (comparer.Compare(senha, result) == 0) return true;
                else return false;

            }
            catch (excecao.excecao except)
            {

                throw except;

            }

        }


    }
}
