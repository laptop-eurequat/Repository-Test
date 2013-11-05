using System;
using System.Collections.Generic;
using Zero.Core.Domain;
using Zero.POCO.Audiences;

namespace Zero.POCO.Donnees
{
    public class Signalitique : EntityBase<Guid>, IAggregateRoot, ISignalitique
    {
      

        protected override void Validate()
        {
            throw new NotImplementedException();
        }

        public int Genre { get; set; }
        public Vague Vague { get; set; }
        public Individu Individu { get; set; }
        public float Poid { get; set; }
        public int RevenueTotalFoyer { get; set; }
        public int NbVoiture { get; set; }
        public int NbPiece { get; set; }
        public int Habitat { get; set; }
        public int TypeHabitat { get; set; }
        public int TailleFoyer { get; set; }
        public bool PCConnexion { get; set; }
        public bool SecheLinge { get; set; }
        public bool LaveVaissele { get; set; }
        public bool Console { get; set; }
        public bool Camescope { get; set; }
        public bool Climatiseur { get; set; }
        public bool LecteurCD { get; set; }
        public bool Magnetoscope { get; set; }
        public bool AppareilPhotoNumerique { get; set; }
        public bool Congelateur { get; set; }
        public bool Pcsansconnexion { get; set; }
        public bool Aspirateur { get; set; }
        public bool LecteurDVD { get; set; }
        public bool LaveLinge { get; set; }
        public bool Chainestereo { get; set; }
        public bool Fourmicroonde { get; set; }
        public bool Telephone { get; set; }
        public bool Cuisiniere { get; set; }
        public bool Mobile { get; set; }
        public bool Decodeur { get; set; }
        public bool Lecteurradiocassette { get; set; }
        public bool Televisionencouleur { get; set; }
        public bool Refrigirateur { get; set; }
        public int CSE { get; set; }
        public int Situationmatrimoniale { get; set; }
        public int Statutfamilial { get; set; }
        public int Niveau { get; set; }
        public int CSP { get; set; }
        public int TrancheAge { get; set; }
        public int Age { get; set; }
        public int Ville { get; set; }
        public int Mois { get; set; }
        public int Jour { get; set; }
        public List<AudienceTV> AudienceTVs { get; set; }
        public List<AudienceRadio> AudienceRadios { get; set; }
        public List<AudienceJournal> AudienceJournals { get; set; } 



    }
}