using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;

namespace Zero.DataLayer.Donnees
{
    public class AudienceRadio: XPBaseObject
    {
         public AudienceRadio()
            : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

         public AudienceRadio(Session session)
            : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }


         private Guid _Oid;
        [Key]
        public Guid Oid
        {
            get { return _Oid; }
            set { SetPropertyValue("Oid", ref _Oid, value); }
        }



        private XpoSupportRadio _SupportRadio;
        public XpoSupportRadio SupportRadio
        {
            get { return _SupportRadio; }
            set { SetPropertyValue("SupportRadio", ref _SupportRadio, value); }
        }



        private int _QuartHeure;
        public int QuartHeure
        {
            get { return _QuartHeure; }
            set { SetPropertyValue("QuartHeure", ref _QuartHeure, value); }
        }



        private int _NumeroJour;
        public int NumeroJour
        {
            get { return _NumeroJour; }
            set { SetPropertyValue("NumeroJour", ref _NumeroJour, value); }
        }


        private Signalitique _Signalitique;
        [Association("SignalitiquesAudienceRadios")]
        public Signalitique Signalitique
        {
            get { return _Signalitique; }
            set { SetPropertyValue("Signalitique", ref _Signalitique, value); }

        }
    }
}
