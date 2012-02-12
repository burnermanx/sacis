using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sacis.model.criptografia;
using sacis.model.excecao;

namespace sacis.view.control
{
    public class gerenciaServlet
    {
        private static localhost.Service1 WService = new localhost.Service1();

        /**
        *
        * Método que retorna uma string em hash
        *
        * @param texto          String de texto
        * 
        * @return string        Retorna texto em hash
        * 
        */
        public static string geraHash(string texto)
        {

            return hash.hashing(texto);

        }

        public static bool consultaUsuario(string login, string senha) {                       

            try
            {
                if (WService.consultaUsuario(login, senha))
                {

                    //Verifica.verifica.atualiza_copia(login, senha);
                    return true;
                }
                else return false;                

            }
            catch (excecao except)
            {

                throw except;

            }

        }

    }
}
