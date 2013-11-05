using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.POCO.Audiences;

namespace Zero.POCO.Donnees
{
    public interface ISignalitique
    {

        int Genre { get; set; }
         Vague Vague { get; set; }
         Individu Individu { get; set; }
         float Poid { get; set; }
         int RevenueTotalFoyer { get; set; }
         int NbVoiture { get; set; }
         int NbPiece { get; set; }
         int Habitat { get; set; }
         int TypeHabitat { get; set; }
         int TailleFoyer { get; set; }
         bool PCConnexion { get; set; }
         bool SecheLinge { get; set; }
         bool LaveVaissele { get; set; }
         bool Console { get; set; }
         bool Camescope { get; set; }
         bool Climatiseur { get; set; }
         bool LecteurCD { get; set; }
         bool Magnetoscope { get; set; }
         bool AppareilPhotoNumerique { get; set; }
         bool Congelateur { get; set; }
         bool Pcsansconnexion { get; set; }
         bool Aspirateur { get; set; }
         bool LecteurDVD { get; set; }
         bool LaveLinge { get; set; }
         bool Chainestereo { get; set; }
         bool Fourmicroonde { get; set; }
         bool Telephone { get; set; }
         bool Cuisiniere { get; set; }
         bool Mobile { get; set; }
         bool Decodeur { get; set; }
         bool Lecteurradiocassette { get; set; }
         bool Televisionencouleur { get; set; }
         bool Refrigirateur { get; set; }
         int CSE { get; set; }
         int Situationmatrimoniale { get; set; }
         int Statutfamilial { get; set; }
         int Niveau { get; set; }
         int CSP { get; set; }
         int TrancheAge { get; set; }
         int Age { get; set; }
         int Ville { get; set; }
         int Mois { get; set; }
         int Jour { get; set; }

         List<AudienceTV> AudienceTVs { get; set; }
         List<AudienceRadio> AudienceRadios { get; set; }
         List<AudienceJournal> AudienceJournals { get; set; } 

    }
}
