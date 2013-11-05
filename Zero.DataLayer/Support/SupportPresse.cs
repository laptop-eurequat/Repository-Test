using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Zero.POCO.Data;

namespace Zero.DataLayer.Support
{
    class SupportPresse : XPBaseObject
    {
        private string _Sujet;
        private int _Code;
        private Langue _Langue ;
        private string _Type;
        private string _Libelle;

        public string Sujet
        {
            get { return _Sujet; }
            set { SetPropertyValue("Sujet", ref _Sujet, value); }
        }

        public int Code
        {
            get { return _Code; }
            set { SetPropertyValue("Code", ref _Code, value); }
        }

        public Langue Code
        {
            get { return _Code; }
            set { SetPropertyValue("Code", ref _Code, value); }
        }



    }
}
