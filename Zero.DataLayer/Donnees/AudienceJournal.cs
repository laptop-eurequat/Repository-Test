using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;

namespace Zero.DataLayer.Donnees
{
    public class AudienceJournal: XPBaseObject
    {
         public AudienceJournal()
            : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

         public AudienceJournal(Session session)
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



        int _Jour;
        public int Jour
        {
            get { return _Jour; }
            set { SetPropertyValue("Jour", ref _Jour, value); }
        }



  
        XpoSupportPresse _SupportPresse;
        public XpoSupportPresse SupportPresse
        {
            get { return _SupportPresse; }
            set { SetPropertyValue("SupportPresse", ref _SupportPresse, value); }
        }



        int _NombreOccurence;
        public int NombreOccurence
        {
            get { return _NombreOccurence; }
            set { SetPropertyValue("NombreOccurence", ref _NombreOccurence, value); }
        }




        int _NumJournal;
        public int NumJournal
        {
            get { return _NumJournal; }
            set { SetPropertyValue("NumJournal", ref _NumJournal, value); }
        }
        private Signalitique _Signalitique;
        [Association("SignalitiquesAudienceJournals")]
        public Signalitique Signalitique
        {
            get { return _Signalitique; }
            set { SetPropertyValue("Signalitique", ref _Signalitique, value); }

        }
    }
}
