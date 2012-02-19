/**
 * 
 * CLASSE Corpo     corpo de cada arquivo anexo ( attachment )
 * 
 * atributos:
 * nome             nome do arquivo Anexo ( atributo obrigatorio ),
 * chave            chave de criptografia simetrica ( se o arquivo for claro , sera "" )
 * conteudo         conteudo do arquivo anexo 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sacis.model.entidades
{
            
        public class corpo
        {

            private String nome = "";
            private String chave = "";
            private String conteudo = "";

            public corpo() {}

            public corpo(String n, String k, String c)
            {
                this.nome = n;
                this.chave = k;
                this.conteudo = c;
            }

            public String getNome()
            {
                return this.nome;
            }
            public String getChave()
            {
                return this.chave;
            }
            public String getConteudo()
            {
                return this.conteudo;
            }
            public void setNome( String n )
            {
                this.nome = n;
            }
            public void setChave( String ch)
            {
                this.chave = ch;
            }
            public void setConteudo( String co)
            {
                this.conteudo = co;
            }


        }



    
}



