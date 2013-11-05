using System;
using DevExpress.Xpo;
using Zero.POCO.Data;

namespace Zero.DataLayer.Donnees
{
    public class XpoSupportPresse : XPBaseObject
    {


         XpoSupportPresse()
            : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

         XpoSupportPresse(Session session)
            : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }


        private Guid _Oid ;

        [Key]
         public Guid Oid
        {
            get { return _Oid; }
            set { SetPropertyValue("Oid", ref _Oid, value); }
        }



        private string _sujet;
        private int _code;
        private Langue _langue;
        private string _type;
        private string _libelle;

        public string Sujet
        {
            get { return _sujet; }
            set { SetPropertyValue("Sujet", ref _sujet, value); }
        }

        public int Code
        {
            get { return _code; }
            set { SetPropertyValue("Code", ref _code, value); }
        }

        public Langue Langue
        {
            get { return _langue; }
            set { SetPropertyValue("Langue", ref _langue, value); }
        }

        public string Type
        {
            get { return _type; }
            set { SetPropertyValue("Type", ref _type, value); }
        }



        public string Libelle
        {
            get { return _libelle; }
            set { SetPropertyValue("Libelle", ref _libelle, value); }
        }

    }
}
