﻿/*
 * Classe para implementação do hash 
 *
 * @author Fabio Augusto
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace sacis.model.criptografia
{
    public class hash
    {

        /**
        *
        * Método para criar um hash de um texto utilizando SHA512
        *
        * @Param text                  Variável do tipo string
        * 
        * @return string                Hash do texto passado
        * 
        */
        public static string hashing(string text)
        {

            UTF8Encoding cod = new UTF8Encoding();
            SHA512Managed hasher = new SHA512Managed();
            byte[] data = hasher.ComputeHash(cod.GetBytes(text));

            // armazena os bytes criando uma string
            StringBuilder texto = new StringBuilder();

            // cria uma string hexadecimal para evitar erro nas mensagens transmitidas
            for (int i = 0; i < data.Length; i++) texto.Append(data[i].ToString("x2"));

            // retorna a string em hexadecimal
            return texto.ToString();

        }

    }
}