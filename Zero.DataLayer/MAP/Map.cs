using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Zero.DataLayer.Donnees;
using Zero.POCO.Donnees;
using AudienceJournal = Zero.POCO.Audiences.AudienceJournal;
using Vague = Zero.POCO.Donnees.Vague;

namespace Zero.DataLayer.MAP
{
    public static class Map
    {
        public static  Donnees.Signalitique MapSignalitique(ISignalitique signlitique, UnitOfWork uow)
        {
            var sig = new Donnees.Signalitique(uow);
            sig.Age = signlitique.Age;
            sig.AppareilPhotoNumerique = signlitique.AppareilPhotoNumerique;
            sig.Aspirateur = signlitique.Aspirateur;
            sig.CSE = signlitique.CSE;
            sig.CSP = signlitique.CSP;
            sig.Camescope = signlitique.Camescope;
            sig.Chainestereo = signlitique.Chainestereo;
            sig.Climatiseur = signlitique.Climatiseur;
            sig.Congelateur = signlitique.Congelateur;
            sig.Console = signlitique.Console;
            sig.Cuisiniere = signlitique.Cuisiniere;
            sig.Decodeur = signlitique.Decodeur;
            sig.Fourmicroonde=signlitique.Fourmicroonde;
            sig.Genre = signlitique.Genre;
            sig.Habitat = signlitique.Habitat;
            sig.Jour = signlitique.Jour;
            sig.LaveLinge = signlitique.LaveLinge;
            sig.LaveVaissele = signlitique.LaveVaissele;
            sig.LecteurCD = signlitique.LecteurCD;
            sig.LecteurDVD = signlitique.LecteurDVD;
            sig.Lecteurradiocassette = signlitique.Lecteurradiocassette;
            sig.Magnetoscope = signlitique.Magnetoscope;
            sig.Mobile = signlitique.Mobile;
            sig.Mois = signlitique.Mois;
            sig.NbPiece = signlitique.NbPiece;
            sig.NbVoiture = signlitique.NbPiece;
            sig.Niveau = sig.Niveau;
            sig.PCConnexion = sig.Pcsansconnexion;
            sig.Pcsansconnexion = sig.Pcsansconnexion;
            sig.Poid = signlitique.Poid;
            sig.Refrigirateur = signlitique.Refrigirateur;
            sig.RevenueTotalFoyer = signlitique.RevenueTotalFoyer;
            sig.SecheLinge = signlitique.SecheLinge;
            sig.Situationmatrimoniale = signlitique.Situationmatrimoniale;
            sig.Statutfamilial = signlitique.Statutfamilial;
            sig.TailleFoyer = signlitique.TailleFoyer;
            sig.Telephone = signlitique.Telephone;
            sig.Televisionencouleur = signlitique.Televisionencouleur;
            sig.TrancheAge = signlitique.TrancheAge;
            sig.TypeHabitat = signlitique.TypeHabitat;
            sig.Ville = signlitique.Ville;

            return sig;
        }

        public static  Donnees.Vague MapVague(Vague vague, UnitOfWork uow)
        {
            var vag = new Donnees.Vague(uow);
            vag.Annee = vague.Annee;
            vag.Libelle = vague.Libelle;
            vag.Mois = vague.Mois;
            vag.Numero = vague.Numero;
            vag.Rang = vague.Rang;
            foreach (var signalitique in vague.Signalitique)
            {
                var sig = MapSignalitique(signalitique, uow);
                foreach (var AudPresse in signalitique.AudienceJournals)
                {
                    var aud = MapAudJournal(AudPresse, uow);
                    sig.AudienceJournals.Add(aud);
                }
                vag.Signalitiques.Add(sig);
            }
            return vag;


        }

        public static Donnees.AudienceJournal MapAudJournal(AudienceJournal Adj, UnitOfWork uow)
        {
            var audience = new Donnees.AudienceJournal(uow);
            audience.NombreOccurence = Adj.NombreOccurence;
            audience.NumJournal = Adj.NumJournal;
            var support =uow.GetObjectByKey<XpoSupportPresse>(Adj.SupportPresse.id);

            audience.SupportPresse = support;
            return audience;
        }

        public static Donnees.AudienceTV MapAudTV(Zero.POCO.Audiences.AudienceTV Adj, UnitOfWork uow)
        {
            var audience = new Donnees.AudienceTV(uow);
            audience.Oid = Adj.id;
            audience.NumeroQuertdheure = Adj.NumeroQuertdheure;
            audience.NumeroJour = Adj.NumeroJour;

            var support = uow.GetObjectByKey<XpoSupportTV>(Adj.SupportTV.id);
            audience.SupportTV = support;
          
            return audience;
        }



        public static Donnees.AudienceRadio MapAudRD(Zero.POCO.Audiences.AudienceRadio Adj, UnitOfWork uow)
        {
            var audience = new Donnees.AudienceRadio(uow);
            audience.Oid = Adj.id;
            audience.QuartHeure = Adj.QuartHeure;
            audience.NumeroJour = Adj.NumeroJour;

            var support = uow.GetObjectByKey<XpoSupportRadio>(Adj.SupportRadio.id);
            audience.SupportRadio = support;

            return audience;
        }



        public static Donnees.Individu MapIndividu(Zero.POCO.Donnees.Individu indiv, UnitOfWork uow)
        {
            var individu = new Donnees.Individu(uow);
            individu.Oid = indiv.id;
            individu.Sexe = indiv.Sexe;
            individu.IdQuest = indiv.IdQuest;

            return individu;
        }

    }
}
