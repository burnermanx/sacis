/*
 * Classe para tratamento de exceções (erros) personalizadas.
 *
 * @author Fabio Augusto
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sacis.model.excecao
{
    public class excecao: Exception{

        /*
        * Metodo que recebe a mensagem e passa para a base EXCEPTION.
        *
        * @param mensagem       Variavel do tipo String
        * 
        */
        public excecao(string mensagem) : base(mensagem)
        {            

        }
        
    }
}
