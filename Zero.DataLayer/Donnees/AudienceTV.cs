using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;

namespace Zero.DataLayer.Donnees
{
    public class AudienceTV: XPBaseObject
    {
         public AudienceTV()
            : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

         public AudienceTV(Session session)
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



        private int _NumeroQuertdheure;
        public int NumeroQuertdheure
       {
           get { return _NumeroQuertdheure; }
           set { SetPropertyValue("NumeroQuertdheure", ref _NumeroQuertdheure, value); }
       }


        private XpoSupportTV _SupportTV;
        public XpoSupportTV SupportTV
        {
            get { return _SupportTV; }
            set { SetPropertyValue("SupportTV", ref _SupportTV, value); }
        }



        private int _NumeroJour;
        public int NumeroJour
        {
            get { return _NumeroJour; }
            set { SetPropertyValue("NumeroJour", ref _NumeroJour, value); }

        }


        private Signalitique _Signalitique;
        [ Association("SignalitiquesAudienceTVs")]
        public Signalitique Signalitique
        {
            get { return _Signalitique; }
            set { SetPropertyValue("Signalitique", ref _Signalitique, value); }

        }
    }
}
