using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Zero.POCO.Donnees;

namespace Zero.DataLayer.Donnees
{
    public class Signalitique : XPBaseObject
    {
         public Signalitique()
            : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

         public Signalitique(Session session)
            : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }



        [Key(AutoGenerate = true)]
         public Guid Oid;


        private int _Genre;
        public int Genre
        {
            get { return _Genre; }
            set { SetPropertyValue("Genre", ref _Genre, value); }
        }


        private Vague _Vague;
        [Association("Signalitique-vague")]
         public Vague Vague
         {
             get { return _Vague; }
             set { SetPropertyValue("Vague", ref _Vague, value); }
         }


        private Individu _Individu;
        [ Association("IndividuSignalitiques")]
        public Individu Individu
         {
             get { return _Individu; }
             set { SetPropertyValue("Individu", ref _Individu, value); }
         }


        private float _Poid;
        public float Poid
         {
             get { return _Poid; }
             set { SetPropertyValue("Poid", ref _Poid, value); }
         }


        private int _RevenueTotalFoyer;
         public int RevenueTotalFoyer
         {
             get { return _RevenueTotalFoyer; }
             set { SetPropertyValue("RevenueTotalFoyer", ref _RevenueTotalFoyer, value); }
         }


        private int _NbVoiture;
         public int NbVoiture 
         {
             get { return _NbVoiture; }
             set { SetPropertyValue("NbVoiture", ref _NbVoiture, value); }
         }


        private int _NbPiece;
        public int NbPiece
         {
             get { return _NbPiece; }
             set { SetPropertyValue("NbPiece", ref _NbPiece, value); }
         }


        private int _Habitat;
         public int Habitat
         {
             get { return _Habitat; }
             set { SetPropertyValue("Habitat", ref _Habitat, value); }
         }


        private int _TypeHabitat;
        public int TypeHabitat
         {
             get { return _TypeHabitat; }
             set { SetPropertyValue("TypeHabitat", ref _TypeHabitat, value); }
         }


        private int _TailleFoyer;
        public int TailleFoyer
         {
             get { return _TailleFoyer; }
             set { SetPropertyValue("TailleFoyer", ref _TailleFoyer, value); }
         }


        private bool _PCConnexion;
        public bool PCConnexion
         {
             get { return _PCConnexion; }
             set { SetPropertyValue("PCConnexion", ref _PCConnexion, value); }
         }


        private bool _SecheLinge;

        public bool SecheLinge
         {
             get { return _SecheLinge; }
             set { SetPropertyValue("SecheLinge", ref _SecheLinge, value); }
         }


        private bool _LaveVaissele;
         public bool LaveVaissele
         {
             get { return _LaveVaissele; }
             set { SetPropertyValue("LaveVaissele", ref _LaveVaissele, value); }
         }


        private bool _Console;
         public bool Console
         {
             get { return _Console; }
             set { SetPropertyValue("Console", ref _Console, value); }
         }


        private bool _Camescope;
         public bool Camescope
         {
             get { return _Camescope; }
             set { SetPropertyValue("Camescope", ref _Camescope, value); }
         }


        private bool _Climatiseur;
         public bool Climatiseur
         {
             get { return _Climatiseur; }
             set { SetPropertyValue("Climatiseur", ref _Climatiseur, value); }
         }


        private bool _LecteurCD;
        public bool LecteurCD
         {
             get { return _LecteurCD; }
             set { SetPropertyValue("LecteurCD", ref _LecteurCD, value); }
         }


        private bool _Magnetoscope;
         public bool Magnetoscope
         {
             get { return _Magnetoscope; }
             set { SetPropertyValue("Magnetoscope", ref _Magnetoscope, value); }
         }


        private bool _AppareilPhotoNumerique;
         public bool AppareilPhotoNumerique
         {
             get { return _AppareilPhotoNumerique; }
             set { SetPropertyValue("AppareilPhotoNumerique", ref _AppareilPhotoNumerique, value); }
         }


        private bool _Congelateur;
        public bool Congelateur
         {
             get { return _Congelateur; }
             set { SetPropertyValue("Congelateur", ref _Congelateur, value); }
         }





         private bool _Pcsansconnexion;
         public bool Pcsansconnexion
         {
             get { return _Pcsansconnexion; }
             set { SetPropertyValue("Pcsansconnexion", ref _Pcsansconnexion, value); }
         }







         private bool _Aspirateur;
         public bool Aspirateur
         {
             get { return _Aspirateur; }
             set { SetPropertyValue("Aspirateur", ref _Aspirateur, value); }
         }



         private bool _LecteurDVD;
         public bool LecteurDVD
         {
             get { return _LecteurDVD; }
             set { SetPropertyValue("LecteurDVD", ref _LecteurDVD, value); }
         }





         private bool _LaveLinge;
         public bool LaveLinge
         {
             get { return _LaveLinge; }
             set { SetPropertyValue("LaveLinge", ref _LaveLinge, value); }
         }


        private bool _Chainestereo;
         public bool Chainestereo
         {
             get { return _LaveLinge; }
             set { SetPropertyValue("Chainestereo", ref _Chainestereo, value); }
         }





         private bool _Fourmicroonde;
         public bool Fourmicroonde
         {
             get { return _Fourmicroonde; }
             set { SetPropertyValue("Fourmicroonde", ref _Fourmicroonde, value); }
         }






         private bool _Telephone;
         public bool Telephone
         {
             get { return _Telephone; }
             set { SetPropertyValue("Telephone", ref _Telephone, value); }
         }







         private bool _Cuisiniere;
         public bool Cuisiniere
         {
             get { return _Cuisiniere; }
             set { SetPropertyValue("Cuisiniere", ref _Cuisiniere, value); }
         }





         private bool _Mobile;
         public bool Mobile
         {
             get { return _Mobile; }
             set { SetPropertyValue("Mobile", ref _Mobile, value); }
         }



         private bool _Decodeur;
         public bool Decodeur
         {
             get { return _Decodeur; }
             set { SetPropertyValue("Decodeur", ref _Decodeur, value); }
         }



         private bool _Lecteurradiocassette;
         public bool Lecteurradiocassette
         {
             get { return _Lecteurradiocassette; }
             set { SetPropertyValue("Lecteurradiocassette", ref _Lecteurradiocassette, value); }
         }




         private bool _Televisionencouleur;
         public bool Televisionencouleur
         {
             get { return _Televisionencouleur; }
             set { SetPropertyValue("Televisionencouleur", ref _Televisionencouleur, value); }
         }







         private bool _Refrigirateur;
         public bool Refrigirateur
         {
             get { return _Refrigirateur; }
             set { SetPropertyValue("Refrigirateur", ref _Refrigirateur, value); }
         }





         private int _CSE;
         public int CSE
         {
             get { return _CSE; }
             set { SetPropertyValue("CSE", ref _CSE, value); }
         }




         private int _Situationmatrimoniale;
         public int Situationmatrimoniale
         {
             get { return _Situationmatrimoniale; }
             set { SetPropertyValue("Situationmatrimoniale", ref _Situationmatrimoniale, value); }
         }


         private int _Statutfamilial;
         public int Statutfamilial
         {
             get { return _Statutfamilial; }
             set { SetPropertyValue("Statutfamilial", ref _Statutfamilial, value); }
         }



         private bool _Niveau;
         public bool Niveau
         {
             get { return _Niveau; }
             set { SetPropertyValue("Niveau", ref _Niveau, value); }
         }



         private int _CSP;
         public int CSP
         {
             get { return _CSP; }
             set { SetPropertyValue("CSP", ref _CSP, value); }
         }





         private int _TrancheAge;
         public int TrancheAge
         {
             get { return _TrancheAge; }
             set { SetPropertyValue("TrancheAge", ref _TrancheAge, value); }
         }




         private int _Age;
         public  int Age
         {
             get { return _Age; }
             set { SetPropertyValue("Age", ref _Age, value); }
         }



         private int _Ville;
         public int Ville
         {
             get { return _Ville; }
             set { SetPropertyValue("Ville", ref _Ville, value); }
         }





         private int _Mois;
         public int Mois
         {
             get { return _Mois; }
             set { SetPropertyValue("Mois", ref _Mois, value); }
         }




         private int _Jour;
         public int Jour
         {
             get { return _Jour; }
             set { SetPropertyValue("Jour", ref _Jour, value); }
         }




         /*[Aggregated, Association("IndividuSignalitiques")]
         public XPCollection<Signalitique> Signalitiques
         {
             get { return GetCollection<Signalitique>("Signalitiques"); }
         }*/


         [Aggregated, Association("SignalitiquesAudienceTVs")]
         public XPCollection<AudienceTV> AudienceTVs
         {
             get { return GetCollection<AudienceTV>("AudienceTVs"); }
         }


         [Aggregated, Association("SignalitiquesAudienceRadios")]
         public XPCollection<AudienceRadio> AudienceRadios
         {
             get { return GetCollection<AudienceRadio>("AudienceRadios"); }
         }


         [Aggregated, Association("SignalitiquesAudienceJournals")]
         public XPCollection<AudienceJournal> AudienceJournals
         {
             get { return GetCollection<AudienceJournal>("AudienceJournals"); }
         } 
    }
}
