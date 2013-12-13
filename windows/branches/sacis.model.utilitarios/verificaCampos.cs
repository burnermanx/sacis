///<summary>
/// Classe para validar os atributos do objeto do tipo Usuario
///
/// @author Fabio Augusto
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sacis.model.entidades;
using sacis.model.excecao;

namespace sacis.model.utilitarios
{
    public class verificaCampos
    {
        private static string MSG_ERRO = "Erro nos Dados";

        ///<summary>
        ///
        /// Método que verifica a validade dos atributos do objeto usuario passado
        /// e retorna verdadeiro caso seja válido.
        ///
        /// Retorna excecao: Erro nos dados
        /// 
        ///</summary>
        public static bool verificaValidadeUsuario(usuario user) {

            if (user.getChave() == "" || user.getChave() == null ||
                verificaValidadeCampos(user.getNome()) == true || 
                verificaValidadeCampos(user.getLogin()) == true ||
                string.Compare(user.getLogin(), user.getNome()) == 0)
            {

                throw new excecao.excecao(MSG_ERRO);

            } else return true;
                    
        }

        ///<summary>
        ///
        /// Método que verifica se o texto passado está de acordo com os parâmetros determinados 
        /// na função retornando verdadeiro caso nao seja válido
        /// 
        ///</summary>
        public static bool verificaValidadeCampos(string texto) {

            int cont = 0, i;

            // Verifica se texto é nulo, vazio ou tem menos de 8 caracteres
            if (texto == "" || texto.Length == 0 || texto.Length < 8) return true;

            // Verifica se texto inicia com caracteres abaixo do 32, del e espaço em ASCII
            if (texto[0] <= 32 || texto[0] == 127 || texto[0] == 240 || texto[0] == 255) return true;

            // Verifica se texto termina com caracteres abaixo do 32, del e espaço em ASCII
            if (texto[texto.Length - 1] <= 32 || texto[texto.Length - 1] == 127 || texto[texto.Length - 1] == 240 || texto[texto.Length - 1] == 255) return true;

            // Verifica caracteres da string se contem dois espaços seguidos, estao entre 32 e 255 e tem del
            for (i = 1; i < texto.Length; i++)
            {
                if (texto[i] >= 32 && texto[i] <= 255)
                {
                    if (texto[i] == 32 || texto[i] == 240 || texto[i] == 255)
                    {
                        cont++;
                        if (cont == 2) return true;
                    }
                    else cont = 0;

                    if (texto[i] == 127) return true;
                }
                else return true;
            }

            return false;        
        }

    }
}
