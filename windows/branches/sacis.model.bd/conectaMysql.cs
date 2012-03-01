///<summary>
/// Classe para realizar a conexao com o banco de dados MYSQL
///
/// @author Fabio Augusto
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using sacis.model.excecao;

namespace sacis.model.bd
{
    public class conectaMysql
    {

        private static string DADOS_CONEXAO = @"Persist Security info=False; server=localhost; database=conectividade; uid=root; pwd='123';";
        private static string MSG_CONEXAO = "Erro Conectando ao Banco de Dados!";
        private static string MSG_DESCONEXAO = "Erro Desconectando ao Banco de Dados!";
        private static MySqlConnection bdConn;

        ///<summary>
        ///
        /// Método que realiza a conexão com o banco de dados
        ///
        ///</summary>
        public static MySqlConnection conectaMSQL()
        {

            try
            {
                bdConn = new MySqlConnection(DADOS_CONEXAO);

                return bdConn;

            }
            catch (excecao.excecao except)
            {

                throw new excecao.excecao(MSG_CONEXAO);
                
            }
        
        }

        ///<summary>
        ///
        /// Método que realiza a desconexão com o banco de dados
        ///
        ///</summary>
        public static void desconectaMSQL()
        {

            try
            {
                bdConn.Close();
            }
            catch (excecao.excecao except)
            {

                throw new excecao.excecao(MSG_DESCONEXAO);
            }

        }


    }
}
