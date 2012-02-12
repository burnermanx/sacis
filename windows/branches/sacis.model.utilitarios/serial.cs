/*
 * Classe contendo a implementação para transformar um objeto em XML e vice-versa
 * 
 *
 * @author Fabio Augusto
 * 
 */

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

        /**
        *
        * Método para serializar um objeto em XML
        *
        * @param objeto        Objeto qualquer passado
        * @return string       string em XML do objeto passado
        *
        */
        public static string Serializar(object objeto) {

            StringWriter texto = new StringWriter();
            XmlSerializer serial = new XmlSerializer(objeto.GetType());
            serial.Serialize(texto, objeto);

            return texto.ToString();

         }

        /**
        *
        * Método para deserializar uma XML em objeto
        *
        * @param XML            XML do objeto
        * @param tipo           Tipo do objeto passado em XML
        * 
        * @return object        Objeto deserializado
        *
        */
        public static object Deserializar(string xml, Type tipo) {

             StringReader leitor = new StringReader(xml);
             XmlSerializer serial = new XmlSerializer(tipo);

             return serial.Deserialize(leitor);

         }


    }
}
