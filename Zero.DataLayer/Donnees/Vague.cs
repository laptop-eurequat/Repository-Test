using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;

namespace Zero.DataLayer.Donnees
{
    public class Vague : XPBaseObject
    {
         public Vague()
            : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

         public Vague(Session session)
            : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }



        [Key(AutoGenerate = true)]
         public Guid Oid;


        private int _Rang;
        public int Rang
        {
            get { return _Rang; }
            set { SetPropertyValue("Rang", ref _Rang, value); }
        }


        [Association("Signalitique-vague"), Aggregated]
        public XPCollection<Signalitique> Signalitiques{get { return GetCollection<Signalitique>("Signalitiques"); }}




        private int _Annee;
        public int Annee
        {
            get { return _Annee; }
            set { SetPropertyValue("Annee", ref _Annee, value); }
        }






        private int _Mois;
        public int Mois
        {
            get { return _Mois; }
            set { SetPropertyValue("Mois", ref _Mois, value); }
        }





        private int _Evenement;
        public int Evenement
        {
            get { return _Evenement; }
            set { SetPropertyValue("Evenement", ref _Evenement, value); }
        }





        private string _Libelle;
        public string Libelle
        {
            get { return _Libelle; }
            set { SetPropertyValue("Libelle", ref _Libelle, value); }
        }




        private int _Numero;
        public int Numero
        {
            get { return _Numero; }
            set { SetPropertyValue("Numero", ref _Numero, value); }
        }
    }
}
