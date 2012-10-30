///<summary>
/// Classe para implementação dos metodos para a criptografia assimetrica 
///
/// @author Fabio Augusto 
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using sacis.model.excecao;
using System.Security.Cryptography;

namespace sacis.model.criptografia
{
    public class assimetrica
    {
        private static string MSG_CERTIFICADO = "Certificado Inválido ou com senha!";
        private static string MSG_CERTIFICADO_INEXISTENTE = "Certificado Inexistente!";

        ///<summary>
        ///
        /// Método que retorna a data da expiração da chave certificada
        /// através do caminho passado.
        /// 
        /// Retorna excecao: Certificado Inválido ou com senha
        /// 
        ///</summary>
        public static string dataExpiracao(string caminho) {

            try
            {
                    X509Certificate2 data = new X509Certificate2(caminho);
                    return data.GetExpirationDateString();

            } catch (CryptographicException ce) {
            
                throw new excecao.excecao(MSG_CERTIFICADO);

            } catch (ArgumentException ae) {

                throw new excecao.excecao(MSG_CERTIFICADO_INEXISTENTE);

            }
        
        }

    }
}
