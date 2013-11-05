using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Zero.POCO.Donnees;

namespace Zero.DataLayer.Donnees
{
    public class Individu : XPBaseObject
    {
        public Individu()
            : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public Individu(Session session)
            : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        [Key(AutoGenerate = true)]
        public Guid Oid;


        private int _Sexe;
        public int Sexe
        {
            get { return _Sexe; }
            set { SetPropertyValue("Sexe", ref _Sexe, value); }
        }


        private String _IdQuest;
        public String IdQuest
        {
            get { return _IdQuest; }
            set { SetPropertyValue("IdQuest", ref _IdQuest, value); }
        }






        [Aggregated, Association("IndividuSignalitiques")]
        public XPCollection<Signalitique> Signalitiques
        {
            get { return GetCollection<Signalitique>("Signalitiques"); }
        }



    }
}
