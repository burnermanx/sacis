/*
 * Classe _para verificar existencia do usuario registrado localmente 
 *
 * @author Fabio Augusto
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace sacis.model.utilitarios
{
    public class verificaUsuario
    {
        private static string CAM_LOG = @"C:\sacis\sacis.log";

        /**
        *
        * Método _para verificar a existencia do usuario no arquivo _de log
        *
        * @param login          String _de _texto
        * @param hash           String _de _texto
        * 
        * @return bool          Retorna verdadeiro caso exista e falso caso contrario
        * 
        */
        public static bool verifica_usuario(string login, string hash)
        {

            // le arquivo _de log
            StreamReader le = new StreamReader(CAM_LOG);

            string chave;

            // Lê cada linha do arquivo
            while ((chave = le.ReadLine()) != null)
            {

                if (chave == login + " " + hash)
                {

                    //fecha o arquivo
                    le.Close();

                    //retorna verdadeira caso ache o login e hash
                    return true;

                }

            }

            //fecha o arquivo
            le.Close();

            //retorna falso caso nao ache o login e hash
            return false;

        }
          

    }
}
