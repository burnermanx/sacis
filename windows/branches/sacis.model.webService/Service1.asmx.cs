﻿///<summary>
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
    /// <summary>
    /// Summary description for Service1
    /// </summary>
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

        [WebMethod]
        public string teste()
        {
            return "O teste foi um sucesso!!!";
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
                string str = "select login from conecta where login = '" + login + "'";
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

                string key = user.getlogin() + ".key";

                MySqlConnection conecta = conectaMysql.conectaMSQL();
                conecta.Open();

                string str = "INSERT INTO conecta(login, senha, chave, nome)VALUES('" + user.getlogin() + "','" + user.getsenha() + "','" + key + "','" + user.getnome() + "')";

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

            manipulaArquivo.criaDiretorio(CAMINHO_SERVER + user.getlogin());
            manipulaArquivo.criaDiretorio(CAMINHO_SERVER + user.getlogin() + ENTRADA);
            manipulaArquivo.criaDiretorio(CAMINHO_SERVER + user.getlogin() + ENVIADOS);
            manipulaArquivo.criaDiretorio(CAMINHO_SERVER + user.getlogin() + CONTATOS);
            manipulaArquivo.copiaArquivo(user.getchave(), CAMINHO_SERVER + CHAVEIRO + key);
            manipulaArquivo.criaArquivo(CAMINHO_SERVER + user.getlogin() + CONTATOS + ARQUIVO_CONTATO, null);

        }

        ///<summary>
        ///
        /// Método Web que consulta o login e hash da senha passado retornando 
        /// verdadeiro caso exista cadastro do usuario no banco de dados.  
        ///                    
        /// Retorna excecao: Erro de conexão com o banco de dados
        /// 
        ///</summary>
        [WebMethod]
        public bool consultaUsuario(string login, string senha)
        {
            try
            {
                string str = "select senha from conecta where login = '" + login + "'";
                string result = retornaConsultaSql(str);

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
                string str = "select nome,login from conecta";
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
                string contatoLocal = manipulaArquivo.leArquivo(caminho);

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
                throw new excecao.excecao(ERRO_CADASTRO);
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
                throw new excecao.excecao(ERRO_REMOVER);
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
    }
}
