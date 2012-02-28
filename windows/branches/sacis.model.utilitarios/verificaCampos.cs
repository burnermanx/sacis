/*
 * Classe _para validar os atributos do objeto do tipo Usuario 
 *
 * @author Fabio Augusto
 */

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

        /**
        *
        * Método que verifica a validade dos atributos do objeto usuario
        *
        * @param user           Objeto do tipo usuario
        * 
        * @return bool          Verdadeiro caso usuario seja válido
        * @throw excecao        Retorna mensagem _de erro caso usuario seja inválido
        * 
        */
        public static bool verificaUser(usuario user) {

            if (user.getchave() == "" || user.getchave() == null ||
                verificacampos(user.getnome()) == true || verificacampos(user.getsenha()) == true ||
                verificacampos(user.getlogin()) == true || string.Compare(user.getlogin(), user.getsenha()) == 0 ||
                string.Compare(user.getnome(), user.getsenha()) == 0 || string.Compare(user.getlogin(), user.getnome()) == 0)
            {

                throw new excecao.excecao(MSG_ERRO);

            } else return true;
                    
        }

        /**
        *
        * Método que verifica se o _texto passado está _de acordo com os parametros determinados na função
        *
        * @param _texto       Variável do tipo String
        * 
        * @return bool       Verdadeiro caso inválido ou Falso no caso _de válido
        * 
        */
        public static bool verificacampos(string texto) {

            int cont = 0, i;

            // Verifica se _texto é nulo, vazio ou tem menos _de 8 caracteres
            if (texto == "" || texto.Length == 0 || texto.Length < 8) return true;

            // Verifica se _texto inicia com caracteres abaixo do 32, del e espaço em ASCII
            if (texto[0] <= 32 || texto[0] == 127 || texto[0] == 240 || texto[0] == 255) return true;

            // Verifica se _texto termina com caracteres abaixo do 32, del e espaço em ASCII
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
