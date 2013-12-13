///<summary>
/// Classe para verificar, validar e manipular a data
///
/// @author Fabio Augusto
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sacis.model.utilitarios
{
    public class verificaData
    {

        private static string MSG_DATA_INVALIDA = "Certificado Expirado!";

        ///<summary>
        ///
        /// Método que compara a data passada com a data atual
        /// e retorna verdadeiro caso seja válido.
        ///
        /// Retorna excecao: Certificado Expirado.
        /// 
        ///</summary>
        public static bool comparaData(string data) {

            if (DateTime.Parse(data) >= DateTime.Today) return true;
            else throw new excecao.excecao(MSG_DATA_INVALIDA);

        }

        ///<summary>
        ///
        /// Método que converte o formato da data passada para o formato
        /// "yyyy/mm/dd hh:min:seg" retornando a data com o novo formato.
        ///
        ///</summary>
        public static string converteData(string data) {

            string date = DateTime.Parse(data).ToString("yyyy/MM/dd hh:mm:ff");
            return date;
        
        }

    }
}
