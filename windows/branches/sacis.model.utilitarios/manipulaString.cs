///<summary>
/// Classe contendo implementação para manipular strings
///
/// @author Fabio Augusto
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using sacis.model.excecao;
using sacis.model.entidades;

namespace sacis.model.utilitarios
{
    public class manipulaString
    {

        private static string MSG_CAMINHO = "Caminho Inválido!";
        private static string MSG_EXTENSAO = "Insira o Nome de um Arquivo Válido!";
        private static string MSG_CONTATO = "Verifique Contato Inválido!";
        private static string extensao = ".sac";
        private static string ponto = ".";
        private static string sublinhado = "_";
        private static string barra = @"\";
        private static string arroba = "@";
        private static char separador = ';';
        private static char abreParenteses = '(';
        private static char fechaparenteses = ')';

        ///<summary>
        ///
        /// Metodo que retorna o nome do arquivo removendo todo o caminho passado na string.
        ///
        /// Retorna excecao: Erro de caminho inválido.
        /// 
        ///</summary>   
        public static string retornaNomeArquivo(string arquivo)
        {

            if (!arquivo.Contains(barra)) throw new excecao.excecao(MSG_CAMINHO);

            int indice = arquivo.LastIndexOf(barra);
            string novoNome = arquivo.Substring(indice + 1);

            return novoNome;

        }

        ///<summary>
        ///
        /// Metodo que retorna o nome do arquivo passado numa string mudando sua extensão 
        /// para .sac.
        ///
        /// Retorna excecao: Erro de arquivo inválido.
        /// 
        ///</summary>     
        public static string mudaExtensaoArquivo(string arquivo) {

            if (!arquivo.Contains(ponto)) throw new excecao.excecao(MSG_EXTENSAO);

            string novoNome = arquivo;
            int indice = novoNome.LastIndexOf(ponto);

            novoNome = novoNome.Remove(indice, 1);
            novoNome = novoNome.Insert(indice, sublinhado);
            novoNome = novoNome.Insert(arquivo.Length, extensao);

            return novoNome;
        
        }

        ///<summary>
        ///
        /// Metodo que retorna o nome do arquivo original através de uma string passada com 
        /// a extensão .sac.
        ///
        /// Retorna excecao: Erro de arquivo inválido.
        /// 
        ///</summary>  
        public static string recuperaNomeOriginalArquivo(string arquivo) {

            if (!arquivo.Contains(sublinhado)) throw new excecao.excecao(MSG_EXTENSAO);

            string novoNome = arquivo.Substring(0, (arquivo.Length - 4));
            int indice = novoNome.LastIndexOf(sublinhado);

            novoNome = novoNome.Remove(indice, 1);
            novoNome = novoNome.Insert(indice, ponto);
                        
            return novoNome;

        }

        ///<summary>
        ///
        /// Método que retorna a conversão dos contatos passados numa string para uma lista de contatos.
        ///
        /// Retorna excecao: Erro de contato inválido.
        /// 
        ///</summary>
        public static List<contato> retornaListaContatos(string listaContatos)
        {                    
		    List<contato> contatos = new List<contato>();
            string[] vetor = listaContatos.Split(separador);            

            foreach (string s in vetor) {
            
                if (!s.Equals(""))
                {
                    string nome;
                    string email;
                    contato novo = new contato();

                    if (s.Contains(abreParenteses))
                    {
                        int index = s.IndexOf(abreParenteses);
                        nome = s.Substring(0, index);
                        email = s.Substring(index + 1);
                        email = email.Remove(email.IndexOf(fechaparenteses));
                        novo.setNome(nome);
                        novo.setEmail(email);
                    }
                    else if(s.Contains(arroba))
                    {
                        email = s;
                        novo.setEmail(email);   
                    }
                    else throw new excecao.excecao(MSG_CONTATO);

                    contatos.Add(novo);
                }
	        }

            return contatos;                       
        }

        ///<summary>
        ///
        /// Método que retorna um array de logins a partir de uma string passada contendo o email dos 
        /// contatos.
        /// 
        /// Retorna excecao: Erro de contato invalido.
        ///
        ///</summary>
        public static string[] retornaLoginsContatos(string listaContatos)
        {
            string[] vetor = listaContatos.Split(separador);
            int contador = 0;
            string[] logins = new string[vetor.Length-1];

            foreach (string s in vetor)
            {
                if (!s.Equals(""))
                {
                    string log;

                    if (s.Contains(abreParenteses))
                    {
                        int indexParenteses = s.IndexOf(abreParenteses) + 1;
                        log = s.Substring(indexParenteses);

                        int indexArroba = log.IndexOf(arroba);
                        log = log.Substring(0, indexArroba);
                        logins[contador] = log;
                        contador++;
                    }
                    else if (s.Contains(arroba))
                    {
                        try
                        {
                            int indexArroba = s.IndexOf(arroba);
                            log = s.Substring(0, indexArroba);
                            logins[contador] = log;
                            contador++;
                        }
                        catch (Exception ex)
                        {                            
                            throw new excecao.excecao(MSG_CONTATO);
                        }
                    }
                    else throw new excecao.excecao(MSG_CONTATO);
                }
            }
            return logins;
        }

        ///<summary>
        ///
        /// Método que substitui os espaços pelo "_"
        ///
        ///</summary>
        public static string substituiEspacos(string nome) {

            return nome.Replace(" ", sublinhado);
        
        }

    }
}
