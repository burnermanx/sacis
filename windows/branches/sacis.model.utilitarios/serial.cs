///<summary>
/// Classe contendo a implementação _para transformar um objeto em XML e vice-versa
/// 
///
/// @author Fabio Augusto
/// 
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
        /// Método _para serializar um objeto em XML
        ///
        /// @param objeto        Objeto qualquer passado
        /// @return string       string em XML do objeto passado
        ///
        ///</summary>
        public static string Serializar(object objeto) {

            StringWriter texto = new StringWriter();
            XmlSerializer serial = new XmlSerializer(objeto.GetType());
            serial.Serialize(texto, objeto);

            return texto.ToString();

         }

        ///<summary>
        ///
        /// Método _para deserializar uma XML em objeto
        ///
        /// @param XML            XML do objeto
        /// @param tipo           Tipo do objeto passado em XML
        /// 
        /// @return object        Objeto deserializado
        ///
        ///<summary>
        public static object Deserializar(string xml, Type tipo) {

            StringReader leitor = new StringReader(xml);
            XmlSerializer serial = new XmlSerializer(tipo);

            object obj = (object)serial.Deserialize(leitor);
             
            return obj;

         }

    }
}

 
