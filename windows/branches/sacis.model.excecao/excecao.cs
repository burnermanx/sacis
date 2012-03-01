///<summary>
/// Classe para tratamento de exceções personalizadas
/// 
/// @author Fabio Augusto
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sacis.model.excecao
{
    public class excecao: Exception{

        ///<summary>
        ///
        /// Metodo que recebe a mensagem e passa para a base EXCEPTION.
        /// 
        ///</summary>
        public excecao(string mensagem) : base(mensagem)
        {            

        }
        
    }
}
