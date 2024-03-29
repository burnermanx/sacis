﻿///<summary>
/// Classe para objetos do tipo mensagem nova 
///
/// @author Fabio Augusto
///</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sacis.model.entidades
{
    public class mensagem
    {
        private string _de;
        private string _para;
        private string _assunto;
        private string _texto;
        private string _assinatura;
        private bool _criptografar;
        private bool _assinar;
        private string _listaDestinatarios;
        private List<anexo> _anexos;


        ///<summary>
        ///
        /// Métodos de, para, assunto, texto, criptografar, assinatura, anexos e assinar
        /// sao gets e sets usados para a serialização e deserialização do objeto em XML
        ///
        ///</summary>
        public string de
        {
            get { return _de; }
            set { _de = value; }
        }

        public string para
        {
            get { return _para; }
            set { _para = value; }
        }

        public string assunto
        {
            get { return _assunto; }
            set { _assunto = value; }
        }

        public string texto
        {
            get { return _texto; }
            set { _texto = value; }
        }
        
        public string assinatura {

            get { return _assinatura; }
            set { _assinatura = value; }
        }

        public bool criptografar
        {
            get { return _criptografar; }
            set { _criptografar = value; }
        }

        public bool assinar
        {
            get { return _assinar; }
            set { _assinar = value; }
        }

        public List<anexo> anexos
        {
            get { return _anexos; }
            set { _anexos = value; }
        }

        public string listaDestinatarios
        {
            get { return _listaDestinatarios; }
            set { _listaDestinatarios = value; }
        }

        ///<summary>
        ///
        /// Método contrutor para inicializar o objeto
        ///
        ///</summary>
        public mensagem() { }

        ///<summary>
        ///
        /// Método contrutor para inicializar o objeto atraves de parâmetros
        ///
        ///</summary>
        public mensagem(string from, string to, string subject, string text, string signature, bool cript, bool sign, List<anexo> attachments, string listaDestinatarios)
        {

            _de = from;
            _para = to;
            _assunto = subject;
            _texto = text;
            _assinatura = signature;
            _criptografar = cript;
            _assinar = sign;
            _anexos = attachments;
            _listaDestinatarios = listaDestinatarios;

        }

        ///<summary>
        ///
        /// Método get para o remetente
        ///
        ///</summary>
        public string getDe(){

            return _de;

        }

        ///<summary>
        ///
        /// Método set para o remetente
        ///
        ///</summary>
        public void setDe(string from)
        {
            _de = from;
        }

        ///<summary>
        ///
        /// Método get para o destinatario
        ///
        ///</summary>
        public string getPara()
        {
            return _para;
        }

        ///<summary>
        ///
        /// Método set para o destinatario
        ///
        ///</summary>
        public void setPara(string to)
        {
            _para = to;
        }

        ///<summary>
        ///
        /// Método get para o assunto
        ///
        ///</summary>
        public string getAssunto()
        {
            return _assunto;
        }

        ///<summary>
        ///
        /// Método set para o assunto
        ///
        ///</summary>
        public void setAssunto(string subject)
        {
            _assunto = subject;
        }

        ///<summary>
        ///
        /// Método get para o texto da mensagem
        ///
        ///</summary>
        public string getTexto()
        {
            return _texto;
        }

        ///<summary>
        ///
        /// Método set para o texto da mensagem
        ///
        ///</summary>
        public void setTexto(string text)
        {
            _texto = text;
        }

        ///<summary>
        ///
        /// Método get para a assinatura da mensagem
        ///
        ///</summary>
        public string getAssinatura()
        {
            return _assinatura;
        }

        ///<summary>
        ///
        /// Método set para a assinatura da mensagem
        ///
        ///</summary>
        public void setAssinatura(string signature)
        {
            _assinatura = signature;
        }

        ///<summary>
        ///
        /// Método get para saber se a mensagem é criptografada
        ///
        ///</summary>
        public bool getCriptografar()
        {
            return _criptografar;
        }

        ///<summary>
        ///
        /// Método set para informar se a mensagem é criptografada
        ///
        ///</summary>
        public void setCriptografar(bool cript)
        {
            _criptografar = cript;
        }

        ///<summary>
        ///
        /// Método get para saber se a mensagem é assinada
        ///
        ///</summary>
        public bool getAssinar()
        {
            return _assinar;
        }

        ///<summary>
        ///
        /// Método set para informar se a mensagem é assinada
        ///
        ///</summary>
        public void setAssinar(bool sign)
        {
            _assinar = sign;
        }

        ///<summary>
        ///
        /// Método get para a listaDestinatarios da mensagem
        ///
        ///</summary>
        public string getListaDestinatarios()
        {
            return _listaDestinatarios;
        }

        ///<summary>
        ///
        /// Método set para a listaDestinatarios da mensagem
        ///
        ///</summary>
        public void setListaDestinatarios(string listaDestinatarios)
        {
            _listaDestinatarios = listaDestinatarios;
        }

        ///<summary>
        ///
        /// Método get para os anexos
        ///
        ///</summary>
        public List<anexo> getAnexos()
        {
            return _anexos;
        }

        ///<summary>
        ///
        /// Método set para os anexos
        ///
        ///</summary>
        public void setAnexos(List<anexo> attachments)
        {
            _anexos = attachments;
        }        

    }
}
