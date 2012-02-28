using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sacis.model.entidades
{
    public class msg : anexo
    {

        private string _de;
        private string _para;
        private anexo[] _anexos;

        public msg() { }

        public msg(string de, string para, anexo[] nex) {
            _de = de;
            _para = para;
            _anexos = nex;        
        }

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
        public anexo[] anexos
        {

            get { return _anexos; }

            set { _anexos = value; }

        }

        public string getDe() { return _de; }
        public string getPara() { return _para; }
        public anexo[] getAnexos() { return _anexos; }

        public void setDe(string de) {_de = de;}
        public void setPara(string para) {_para = para;}
        public void setAnexos(anexo[] next) {_anexos = next;}

    }
}
