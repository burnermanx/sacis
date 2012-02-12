/*
 * Classe contendo implementação para manipular strings
 * 
 *
 * @author Fabio Augusto
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using sacis.model.excecao;

namespace sacis.model.utilitarios
{
    public class manipulaString
    {

        private static string MSG_ERRO = "Erro ao Remover Caminho!";
        private static string MSG_EXTENSAO = "Insira o Nome de um Arquivo Válido!";
        private static string extensao = ".sac";
        private static string ponto = ".";
        private static string sublinhado = "_";
        private static string barra = @"\";

        /**
        *
        * Metodo para remover todo o conteudo de um caminho anterior ao \         
        * e retornando apenas o nome do arquivo.
        * 
        * @param texto          String com o caminho
        * @return string        Retorna nome do arquivo
        * @throw excecao         
        *
        */
        public static string retornaNome(string texto)
        {

            if (!texto.Contains(barra)) throw new excecao.excecao(MSG_ERRO);
            
            int indice = texto.LastIndexOf(barra);
            string novoNome = texto.Substring(indice);

            return novoNome;

        }

        /**
        *
        * Metodo para renomear o arquivo salvando sua extensao com _ e adicionando 
        * a extensao .sac
        * 
        * @param arquivo          Variavel do tipo string
        * @return string          Retorna nome do arquivo renomeado
        * @throw excecao         
        *
        */       
        public static string mudaExtensao(string arquivo) {

            if (!arquivo.Contains(ponto)) throw new excecao.excecao(MSG_EXTENSAO);

            string novoNome = arquivo;
            int indice = novoNome.LastIndexOf(ponto);

            novoNome = novoNome.Remove(indice, 1);
            novoNome = novoNome.Insert(indice, sublinhado);
            novoNome = novoNome.Insert(arquivo.Length, extensao);

            return novoNome;
        
        }

        /**
        *
        * Metodo para recuperar o nome do arquivo original excluindo a extensao .sac 
        * e restaurando a extensao original
        * 
        * @param arquivo          Variavel do tipo string
        * @return string          Retorna nome do arquivo original
        * @throw excecao         
        *
        */   
        public static string recuperaNome(string arquivo) {

            if (!arquivo.Contains(sublinhado)) throw new excecao.excecao(MSG_EXTENSAO);

            string novoNome = arquivo.Substring(0, (arquivo.Length - 4));
            int indice = novoNome.LastIndexOf(sublinhado);

            novoNome = novoNome.Remove(indice, 1);
            novoNome = novoNome.Insert(indice, ponto);
                        
            return novoNome;

        }

    }
}
