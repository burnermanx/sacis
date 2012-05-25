///<summary>
/// Classe para verificar existencia do usuario registrado localmente 
///
/// @author Fabio Augusto
///</summary>

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

        ///<summary>
        ///
        /// Método que verifica a existência do cadastro do login e hash passados no arquivo de log 
        /// local retornando verdadeiro caso exista
        ///
        ///</summary>
        public static bool verificaCadastroUsuarioLocal(string login, string hash)
        {
            StreamReader le = new StreamReader(CAM_LOG);

            string chave;

            while ((chave = le.ReadLine()) != null)
            {
                if (chave == login + " " + hash)
                {
                    le.Close();
                    return true;
                }
            }

            le.Close();

            return false;
        }    
    }
}
