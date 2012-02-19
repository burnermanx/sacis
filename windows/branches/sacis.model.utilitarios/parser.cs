


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
//biblioteca para manipular arquivos
using System.IO;
using sacis.model.utilitarios;
using sacis.model.entidades;

namespace sacis.model.utilitarios
{
    // Classe que contem os metodos para Montagem e Parser do Attachment
    public class parser
    {

        /**
         * 
         * Metodo montaAttachment   monta string para Attachment
         * 
         * @param nomesArq          string que contem os nomes dos anexos
         * @param CriptoFiles       HashSet<String> que contem os nomes dos arquivos a serem cifrados
         * @return attStr           string que contem a tag <attachment> e seu conteudo (nomes, chaves e conteudos dos arquivos Anexos)
         * 
         */

        public static string montaAttachment(string nomesArq, HashSet<String> CriptoFiles)
        {

            // retira o ultimo ";" e preenche o vetor de nomes dos arquivos anexos 
            string sub = nomesArq.Substring(0, nomesArq.Length - 2);
            string[] arq = sub.Split(';');

            // inicia a string com a tag <attachment>
            String attStr = "<attachment>";

            if (arq.Length != 0)
            {
                // Cria vetor de Corpos de anexos
                corpo[] corpo = null;

                corpo[0] = new corpo();

                string co = "";
                string ch = "";

                int k = 0;

                foreach (string a in arq)
                {
                    co = manipulaArquivo.leArquivo(a);

                    ch = "";

                    if (CriptoFiles.Contains(a))
                    {
                        /// prepara a chave e conteudo de cada arquivo anexo           
                        /// chamada da funcao que gera Chave Simetrica
                        ch = "chave simetrica gerada";

                        /// criptografa o conteudo do arquivo
                        /// co = cripto_hash.cripto_hash

                    }

                    // guarda a chave e conteudo do arq anexo (cifrado ou claro) no vetor de corpos de anexos
                    corpo[k] = new corpo(a, ch, co);

                    k++;

                }


                //adiciona as tags e conteudos de nomes, chaves e conteudos de arquivos Anexos

                for (int n = 0; n < k; n++)
                {
                    attStr += "<ch>" + corpo[n].getNome() + "</ch>";
                }

                for (int n = 0; n < k; n++)
                {
                    attStr += "<ch>" + corpo[n].getChave() + "</ch>";
                }

                for (int n = 0; n < k; n++)
                {
                    attStr += "<att>" + corpo[n].getConteudo() + "</att>";
                }


            }

            // finaliza a string com a tag </attachment>
            attStr += "</attachment>";

            return attStr;

        }


        /**
         * 
         * Metodo buscaNovaTag     buscar uma ocorrencia de tag ( <nome da tag> )
         * 
         * @param s                 string com conteudo geral dos Attachments 
         * @return tag              string com o nome da tag
         * 
         */

        public static string buscaNovaTag(ref string s)
        {

            int i = 0; // contador de caracters lidos da string s

            StringReader sr = new StringReader(s);

            // A convencao adotada para tag_aberta eh: 
            // se foi lido um < e nao foi lido um > entao temos tag_aberta = true 
            Boolean tag_aberta = false;
            char ch;
            string tag = "";

            while (sr.Peek() > -1)
            {
                ch = (char)sr.Read();

                i++; // conta mais um caractere lido 

                if (!tag_aberta)
                {

                    if (ch.Equals('<'))
                    {
                        tag_aberta = true;
                        tag = "";

                    }
                    else continue;

                }
                else
                {
                    if (ch.Equals('>'))
                    {
                        tag_aberta = false;
                        break;
                    }
                    else
                    {
                        tag += ch;
                    }

                }

            }

            if (tag_aberta)
            {
                MessageBox.Show("tag incompleta: " + tag);
                tag = "";
            }

            sr.Close();

            s = s.Substring(i);  // tira os primeiros i caracteres lidos da string s

            return tag;

        }


        /**
         * 
         * Metodo buscaConteudoTag     recupera o conteudo da Tag sem caracteres < 
         * 
         * @param tagFim                string com o nome da tag de Fim
         * @param s                     string com conteudo geral dos Attachments 
         * @return conteudo             string com conteudo entre as tags 
         * 
         */

        public static string buscaConteudoTag(string tagFim, ref string s)
        {

            StringReader sr = new StringReader(s);

            string conteudo = "";
            char ch;

            while (sr.Peek() > -1)
            {

                ch = (char)sr.Read();

                // Se chegou ao caracter de fim do conteudo da tag 
                if (ch.Equals('<'))
                {
                    ///string tagLida = "";

                    s = s.Substring(conteudo.Length); // tira os caracteres do conteudo lidos até antes do <

                    string tagLida = buscaNovaTag(ref s);

                    if (tagLida.Equals(tagFim))
                    {
                        break;
                    }
                    else
                    {
                        // Erro na tag Lida
                        conteudo = "erro";
                        ///MessageBox.Show("ERRO - tagFim: " + tagFim + " - tagLida: " + tagLida, "", MessageBoxButtons.OK, MessageBoxIcon.Error);  
                    }

                }

                conteudo += ch;

            }

            sr.Close();

            return conteudo;

        }


        /**
         * 
         * Metodo  parserAttachment         interpreta as tags do Attachment e retorna o vetor corpo 
         *                                  de objetos Corpo com nome ,chave e conteudo de cada Anexo ou 
         *                                  retorna null se houver erro  .
         * 
         * @param s                         string com conteudo Geral do Attachment
         * @return corpo                    vetor de objetos Corpo (do Attachment) com nomes, chaves e conteudos dos Anexos.
         * 
         * tags  do Attachment :  <n>, <ch>, <att> 
         * 
         */

        public static corpo[] parserAttachment(string s)
        {

            //usa a lista dinamica até saber o numero de elementos  (j+1)
            List<corpo> list = new List<corpo>();

            corpo c;

            string novaTag = "";
            string conteudoTemp = "";

            string tagInicio = "n";  // tag  <n> do nome de arquivo anexo

            int j = 0; // contador do numero de nomes de Arquivos Anexos

            // busca a 1a. tag do Attachment
            novaTag = buscaNovaTag(ref s);

            // Se a 1a. tag do Attachment for igual a tagInicio 
            if (novaTag.Equals(tagInicio))
            {

                // enqto. existir alguma tag igual a tagInicio 
                while (novaTag.Equals(tagInicio))
                {

                    // recupera o nome do arquivo anexo 
                    string tagFim = "/" + tagInicio;
                    conteudoTemp = "";

                    conteudoTemp = buscaConteudoTag(tagFim, ref s);

                    if (conteudoTemp.Equals("erro"))
                    {
                        return null;
                    }
                    if (conteudoTemp.Equals(""))
                    {
                        MessageBox.Show("tag: " + tagInicio + " vazia - sem nome de arquivo! ");
                        return null;
                    }

                    c = new corpo(conteudoTemp, "", "");

                    list.Add(c);

                    j++;

                    novaTag = buscaNovaTag(ref s);

                }


            }
            else
            {
                if (novaTag.Equals(""))
                {
                    MessageBox.Show("Attachment vazio!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("A 1a tag do attachment ehdiferente de <n> : " + novaTag, "", MessageBoxButtons.OK);

                }

                return null;

            }


            // copia os elementos da lista para um vetor de tamanho j+1
            corpo[] corpo = list.ToArray();

            // recupera as tags "ch" de chaves dos arquivos anexos        
            tagInicio = "ch";

            if (novaTag.Equals(tagInicio))
            {

                for (int k = 0; k < j; k++)
                {

                    // recupera a chave do arquivo anexo 
                    string tagFim = "/" + tagInicio;
                    conteudoTemp = "";

                    conteudoTemp = buscaConteudoTag(tagFim, ref s);

                    if (conteudoTemp.Equals("erro"))
                    {
                        return null;
                    }

                    if (conteudoTemp.Equals(""))
                    {
                        MessageBox.Show("tag chave " + tagInicio + " esta vazia. ");
                    }

                    corpo[k].setChave(conteudoTemp);

                    novaTag = buscaNovaTag(ref s);

                }

            }


            // recupera as tags "att" com conteudos dos arquivos anexos
            tagInicio = "att";

            if (novaTag.Equals(tagInicio))
            {

                for (int k = 0; k < j; k++)
                {
                    // recupera o conteudo do arquivo anexo 
                    string tagFim = "/" + tagInicio;
                    conteudoTemp = "";

                    conteudoTemp = buscaConteudoTag(tagFim, ref s);

                    if (conteudoTemp.Equals("erro"))
                    {
                        return null;
                    }

                    if (conteudoTemp.Equals(""))
                    {
                        MessageBox.Show("tag conteudo " + tagInicio + " esta vazia. ");
                    }

                    corpo[k].setConteudo(conteudoTemp);

                    novaTag = buscaNovaTag(ref s);

                }

            }


            /// Resultado do teste
            ///for (int p = 0; p < j; p++) MessageBox.Show("corpo[" + p + "].nome  - " + corpo[p].nome);
            ///for (int p = 0; p < j; p++) MessageBox.Show("corpo[" + p + "].chave  - " + corpo[p].chave);
            ///for (int p = 0; p < j; p++) MessageBox.Show("corpo[" + p + "].conteudo  - " + corpo[p].conteudo);


            //retorna o vetor de objeto da classe Corpo que contem o nome, chave e conteudo dos Anexos ou null
            return corpo;

        }

    
    }
 

}
