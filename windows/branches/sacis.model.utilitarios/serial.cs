///<summary>
/// Classe contendo a implementação para transformar um objeto em XML e vice-versa
///
/// @author Fabio Augusto
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using sacis.model.entidades;

namespace sacis.model.utilitarios
{
    public class serial
    {

        ///<summary>
        ///
        /// Método que retorna o XML serializado de um objeto passado
        ///
        ///</summary>
        public static string serializarObjeto(object objeto) {

            StringWriter texto = new StringWriter();
            XmlSerializer serial = new XmlSerializer(objeto.GetType());
            serial.Serialize(texto, objeto);

            return texto.ToString();

         }

        ///<summary>
        ///
        /// Método que retorna o objeto deserializado a partir de um xml serializado 
        /// e o tipo de objeto a deserializar passados
        /// 
        ///</summary>
        public static object Deserializar(string xml, Type tipo) {

            StringReader leitor = new StringReader(xml);
            XmlSerializer serial = new XmlSerializer(tipo);

            object obj = (object)serial.Deserialize(leitor);
             
            return obj;

         }

    }
}

 
