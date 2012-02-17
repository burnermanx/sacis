/**
 * 
 * 
 *  Classe Base para Objeto hierarquico de Mensagem 
 * 
 * 
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace sacis.model.entidades
{
        
    public class XmlMsg
    {

        [XmlRootAttribute(ElementName = "mensagem", IsNullable = false)]
        public class Mensagem
        {

            //public Mensagem(){}

            private String mheader;
            private String mfrom;
            private String mto;
            private String msubject;
            private String msignature;
            private String mkey;
            private String mbody;
            private String mattachment;


            public String header
            {
                get { return "\n" + mheader; }
                set { mheader = "\n"; }
            }

            public String from
            {
                get { return "\n" + mfrom; }
                set { mfrom = value; }
            }

            public String to
            {
                get { return "\n" + mto; }
                set { mto = value; }
            }

            public String subject
            {
                get { return "\n" + msubject; }
                set { msubject = value; }
            }

            public String signature
            {
                get { return "\n" + msignature; }
                set { msignature = value; }
            }

            public String key
            {
                get { return "\n" + mkey; }
                set { mkey = value; }
            }

            public String body
            {
                get { return "\n" + mbody; }
                set { mbody = value; }
            }

            public String attachment
            {
                get { return "\n" + mattachment; }
                set { mattachment = value; }
            }


            /**
             * 
             *  Converte o Unicode Byte Array (UTF-8 encoded) para uma String.
             *  
             * @param characters     Unicode Byte Array a ser convertido para String
             * 
             * @return String        String convertida do Unicode Byte Array
             * 
             */
            public String UTF8ByteArrayToString(Byte[] characters)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                String constructedString = encoding.GetString(characters);
                return (constructedString);
            }


            /**
             * 
             *  Converte a String para UTF8 Byte array a ser usada para Deserialization
             *  
             * @param pXmlString
             * 
             * @return  Byte[]
             * 
             */ 
            public Byte[] StringToUTF8ByteArray(String pXmlString)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                Byte[] byteArray = encoding.GetBytes(pXmlString);
                return byteArray;
            }


            /**
             * 
             * Metodo para converter um Objeto customizado para string XML 
             * 
             * @param pObject      Objeto a ser serializado para XML
             * 
             * @return XML string
             * 
             */
            public String SerializeObject(Object pObject)
            {

                try
                {
                    String XmlizedString = null;
                    MemoryStream memoryStream = new MemoryStream();
                    XmlSerializer xs = new XmlSerializer(typeof(Mensagem));
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                    xs.Serialize(xmlTextWriter, pObject);
                    memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                    XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                    return XmlizedString;
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);
                    return null;
                }

            }


            /**
             * 
             * Metodo para reconstruir um Objeto a partir de uma string XML 
             * 
             * @param pXmlizedString
             * 
             * @returns Object
             * 
             */
            public Object DeserializeObject(String pXmlizedString)
            {
                XmlSerializer xs = new XmlSerializer(typeof(Mensagem));
                MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                return xs.Deserialize(memoryStream);
            }


        }


    }


}
