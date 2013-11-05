using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using Excel;
using Zero.Core.Domain;
using Zero.Core.Domain.Query;
using Zero.POCO.Audiences;
using Zero.POCO.Donnees;
using Zero.POCO.Helper;
using Zero.POCO.Support;

namespace Zero.POCO
{

    internal class SignalitiqueInstance : ISignalitique
    {
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

    public static class DonneesFactory
    {
        private static IRepository<Individu, Guid> _individuRepository;
        //TODO : au niveau du service dans le request c'est le fichier qui doit etre transmis
        public static List<ISignalitique> CreateDonnees(string filePath, string NomVague, IRepository<Individu, Guid> individuRepositorys, IRepository<Vague, Guid> vagueRepository )
        {
            _individuRepository = individuRepositorys;
            var extension = Path.GetExtension(filePath);
            var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            var excelReader = extension == ".xlsx"
                                  ? ExcelReaderFactory.CreateOpenXmlReader(stream)
                                  : ExcelReaderFactory.CreateBinaryReader(stream);
            excelReader.IsFirstRowAsColumnNames = true;
            var collectionBase = excelReader.AsDataSet().Tables[0].AsEnumerable();

            //var Vide = collectionBase.Where(p => (string) p["année"] == "2012");
            //Assert.AreEqual(extension, ".xlsx");

            var distincts = collectionBase.Select(p => p["Matricule"]).Distinct();
            var individuRepository = _individuRepository;
            List<Individu> individusSave = new List<Individu>();

            List<Query> queries = new List<Query>();
            foreach (var distinct in distincts)
            {
                var convdistinct = int.Parse(distinct.ToString());

                var indivCriterion = new Criterion("IdQuest", convdistinct.ToString(), CriteriaOperator.Equal);
                var indivQuery = new Query();
                indivQuery.Add(indivCriterion);
                queries.Add(indivQuery);

            }
            var IndividuExistant = individuRepository.FindAll(queries);


            foreach (var distinct in distincts)
            {
                if (IndividuExistant.Where(e => e.IdQuest == (string)distinct).Any()) continue;
                var Tempgenre = ((collectionBase.First(d => d["Matricule"] == distinct.ToString()))["Sexe"]);
                var genre = 0;
                int.TryParse(Tempgenre.ToString(), out genre);
                var individu=IndividuFactory.Create(distinct.ToString(), genre
                    );
                //individuRepository.Save(individu);
                individusSave.Add(individu);
            }
            individuRepository.SaveAll(individusSave);

            // on commence la sauvegarde de la vague et des signlatiques
            var vague = IndividuFactory.CreateVague(NomVague);

            var collectionIndidu = individuRepository.FindAll();
            var listSignalitique = new List<ISignalitique>();
            foreach (var individu in collectionIndidu)
            {

                var individuCopy = individu;
                var individuParticulier = collectionBase.First(p => (string) p["Matricule"] == individuCopy.IdQuest);
                //TODO:vérifier que individuParticulier n'est pas nul
                #region Creation instance signalitique

                System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                var signalitique = new SignalitiqueInstance();

                signalitique.Age = int.Parse(individuParticulier["AGE_CLAIR"].ToString());
                signalitique.CSE = int.Parse(individuParticulier["CSE"].ToString());
                signalitique.CSP = int.Parse(individuParticulier["OCCUPATION"].ToString());
                signalitique.Habitat = int.Parse(individuParticulier["Habitat"].ToString());
                signalitique.TypeHabitat = int.Parse(individuParticulier["TYP_HABI"].ToString());
                signalitique.NbVoiture = int.Parse(individuParticulier["NB_VOIT"].ToString());
                signalitique.NbPiece = int.Parse(individuParticulier["NB_PIECE"].ToString());
                signalitique.Niveau = int.Parse(individuParticulier["NIV"].ToString());
                signalitique.Statutfamilial = int.Parse(individuParticulier["STATUT"].ToString());
                signalitique.Situationmatrimoniale = int.Parse(individuParticulier["SITUATION"].ToString());
                signalitique.Ville = int.Parse(individuParticulier["Ville"].ToString());
                signalitique.TrancheAge = int.Parse(individuParticulier["AGE_TRANCH"].ToString());
                signalitique.RevenueTotalFoyer = int.Parse(individuParticulier["Revenu_Foyer"].ToString());
                signalitique.Poid = float.Parse(individuParticulier["poids"].ToString());
                signalitique.Mois = int.Parse(individuParticulier["Mois"].ToString());
                signalitique.Jour = int.Parse(individuParticulier["Jour"].ToString());
                signalitique.Refrigirateur = individuParticulier["P1"].ToString().GetBoolean();
                signalitique.Televisionencouleur = individuParticulier["P2"].ToString().GetBoolean();
                signalitique.Lecteurradiocassette = individuParticulier["P3"].ToString().GetBoolean();
                signalitique.Decodeur = individuParticulier["P4"].ToString().GetBoolean();
                signalitique.Mobile = individuParticulier["P5"].ToString().GetBoolean();
                signalitique.Cuisiniere = individuParticulier["P6"].ToString().GetBoolean();
                signalitique.Telephone = individuParticulier["P7"].ToString().GetBoolean();
                signalitique.Fourmicroonde = individuParticulier["P8"].ToString().GetBoolean();
                signalitique.Chainestereo = individuParticulier["P9"].ToString().GetBoolean();
                signalitique.LaveLinge = individuParticulier["P10"].ToString().GetBoolean();
                signalitique.LecteurDVD = individuParticulier["P11"].ToString().GetBoolean();
                signalitique.Aspirateur = individuParticulier["P12"].ToString().GetBoolean();
                signalitique.Pcsansconnexion = individuParticulier["P13"].ToString().GetBoolean();
                signalitique.Congelateur = individuParticulier["P14"].ToString().GetBoolean();
                signalitique.AppareilPhotoNumerique = individuParticulier["P15"].ToString().GetBoolean();
                signalitique.Magnetoscope = individuParticulier["P16"].ToString().GetBoolean();
                signalitique.LecteurCD = individuParticulier["P17"].ToString().GetBoolean();
                signalitique.Climatiseur = individuParticulier["P18"].ToString().GetBoolean();
                signalitique.Camescope = individuParticulier["P19"].ToString().GetBoolean();
                signalitique.Console = individuParticulier["P20"].ToString().GetBoolean();
                signalitique.LaveVaissele = individuParticulier["P21"].ToString().GetBoolean();
                signalitique.SecheLinge = individuParticulier["P22"].ToString().GetBoolean();
                signalitique.PCConnexion = individuParticulier["P23"].ToString().GetBoolean();
                signalitique.Genre = int.Parse(individuParticulier["SEXE"].ToString());
                if (vague.Signalitique == null) vague.Signalitique=new List<ISignalitique>(); 
                vague.Signalitique.Add(signalitique);
                //TODO: vérifier que la vague est unique

                #endregion

                //signalitique.matricule = int.Parse(individuParticulier.idquest.ToString());

                //var Ann = individuParticulier.Annee;
                if (individu.Signalitiques == null) individu.Signalitiques = new List<ISignalitique>();
                individu.Signalitiques.Add(signalitique);
                signalitique.Individu = individu;
                signalitique.AudienceJournals=new List<AudienceJournal>();
                signalitique.AudienceRadios = new List<AudienceRadio>();
                signalitique.AudienceTVs = new List<AudienceTV>();
                listSignalitique.Add(signalitique);

            }
            vagueRepository.Save(vague);

            var repositoryPresse = new RepositoryPresse();
            foreach (var signalitique in listSignalitique)
            {


                ISignalitique signalitique1 = signalitique;
                var baseValueList = collectionBase.Where(p => (string) p["Matricule"] == signalitique1.Individu.IdQuest);
                foreach (var baseValue in baseValueList)
                {

                    if (int.Parse(baseValue["S5"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                            {
                            NumJournal = 5,
                            NombreOccurence = int.Parse(baseValue["S5"].ToString()) ,
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse =repositoryPresse.FindBy(new Query().Add(new Criterion("Code",5,CriteriaOperator.Equal))).First() 

                        });


                    if (int.Parse(baseValue["S17"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                            {
                            NumJournal = 17,
                            NombreOccurence = int.Parse(baseValue["S17"].ToString()) ,
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse =repositoryPresse.FindBy(new Query().Add(new Criterion("Code",17,CriteriaOperator.Equal))).First() 

                        });





                    if (int.Parse(baseValue["S1"].ToString())  != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 1,
                            NombreOccurence = int.Parse(baseValue["S1"].ToString()),
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse =repositoryPresse.FindBy(new Query().Add(new Criterion("Code",1,CriteriaOperator.Equal))).First() 

                        });



                    if (int.Parse(baseValue["S2"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 2,
                            NombreOccurence = int.Parse(baseValue["S2"].ToString()) ,
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse =repositoryPresse.FindBy(new Query().Add(new Criterion("Code",2,CriteriaOperator.Equal))).First() 

                        });



                    if (int.Parse(baseValue["S3"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 3,
                            NombreOccurence = int.Parse(baseValue["S3"].ToString()) ,
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                           SupportPresse =repositoryPresse.FindBy(new Query().Add(new Criterion("Code",3,CriteriaOperator.Equal))).First() 

                        });


                    if (int.Parse(baseValue["S4"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 4,
                            NombreOccurence = int.Parse(baseValue["S4"].ToString()) ,
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse =repositoryPresse.FindBy(new Query().Add(new Criterion("Code",4,CriteriaOperator.Equal))).First() 

                        });


                    if (int.Parse(baseValue["S6"].ToString())  != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 6,
                            NombreOccurence = int.Parse(baseValue["S6"].ToString()) ,
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse =repositoryPresse.FindBy(new Query().Add(new Criterion("Code",6,CriteriaOperator.Equal))).First() 

                        });


                    if (int.Parse(baseValue["S7"].ToString())  != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 7,
                            NombreOccurence = int.Parse(baseValue["S7"].ToString()) ,
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse =repositoryPresse.FindBy(new Query().Add(new Criterion("Code",7,CriteriaOperator.Equal))).First() 

                        });


                    if (int.Parse(baseValue["S8"].ToString())  != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 8,
                            NombreOccurence = int.Parse(baseValue["S8"] .ToString()),
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                           SupportPresse =repositoryPresse.FindBy(new Query().Add(new Criterion("Code",8,CriteriaOperator.Equal))).First() 

                        });


                    if (int.Parse(baseValue["S9"].ToString())  != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 9,
                            NombreOccurence = int.Parse(baseValue["S9"].ToString()) ,
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse =repositoryPresse.FindBy(new Query().Add(new Criterion("Code",9,CriteriaOperator.Equal))).First() 

                        });


                    if (int.Parse(baseValue["S10"].ToString())  != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 10,
                            NombreOccurence = int.Parse(baseValue["S10"].ToString()) ,
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse =repositoryPresse.FindBy(new Query().Add(new Criterion("Code",10,CriteriaOperator.Equal))).First() 

                        });


                    if (int.Parse(baseValue["S11"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 11,
                            NombreOccurence = int.Parse(baseValue["S11"].ToString()) ,
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse =repositoryPresse.FindBy(new Query().Add(new Criterion("Code",11,CriteriaOperator.Equal))).First() 

                        });



                    if (int.Parse(baseValue["S12"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 12,
                            NombreOccurence = int.Parse(baseValue["S12"].ToString()),
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse = repositoryPresse.FindBy(new Query().Add(new Criterion("Code",12,CriteriaOperator.Equal))).First() 
                        });


                    if (int.Parse(baseValue["S13"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 13,
                            NombreOccurence = int.Parse(baseValue["S13"].ToString()),
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse = repositoryPresse.FindBy(new Query().Add(new Criterion("Code",13,CriteriaOperator.Equal))).First() 
                        });


                    if (int.Parse(baseValue["S14"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 14,
                            NombreOccurence = int.Parse(baseValue["S14"].ToString()),
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse = repositoryPresse.FindBy(new Query().Add(new Criterion("Code",14,CriteriaOperator.Equal))).First() 
                        });


                    if (int.Parse(baseValue["S15"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 15,
                            NombreOccurence = int.Parse(baseValue["S15"].ToString()),
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse = repositoryPresse.FindBy(new Query().Add(new Criterion("Code",15,CriteriaOperator.Equal))).First() 
                        });


                    if (int.Parse(baseValue["S16"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 16,
                            NombreOccurence = int.Parse(baseValue["S16"].ToString()),
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse = repositoryPresse.FindBy(new Query().Add(new Criterion("Code",16,CriteriaOperator.Equal))).First() 
                        });


                    if (int.Parse(baseValue["S18"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 18,
                            NombreOccurence = int.Parse(baseValue["S18"].ToString()),
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse = repositoryPresse.FindBy(new Query().Add(new Criterion("Code",18,CriteriaOperator.Equal))).First() 
                        });


                    if (int.Parse(baseValue["S19"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 19,
                            NombreOccurence = int.Parse(baseValue["S19"].ToString()),
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse = repositoryPresse.FindBy(new Query().Add(new Criterion("Code",19,CriteriaOperator.Equal))).First() 
                        });



                    if (int.Parse(baseValue["S20"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 20,
                            NombreOccurence =int.Parse( baseValue["S20"].ToString()),
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse = repositoryPresse.FindBy(new Query().Add(new Criterion("Code",20,CriteriaOperator.Equal))).First() 
                        });


                    if (int.Parse(baseValue["S21"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 21,
                            NombreOccurence = int.Parse(baseValue["S21"].ToString()),
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse = repositoryPresse.FindBy(new Query().Add(new Criterion("Code",21,CriteriaOperator.Equal))).First() 
                        });


                    if (int.Parse(baseValue["S22"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 22,
                            NombreOccurence = int.Parse(baseValue["S22"].ToString()),
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse = repositoryPresse.FindBy(new Query().Add(new Criterion("Code",22,CriteriaOperator.Equal))).First() 
                        });



                    if (int.Parse(baseValue["S23"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 23,
                            NombreOccurence = int.Parse(baseValue["S23"].ToString()),
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse = repositoryPresse.FindBy(new Query().Add(new Criterion("Code",23,CriteriaOperator.Equal))).First() 
                        });


                    if (int.Parse(baseValue["S24"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 24,
                            NombreOccurence = int.Parse(baseValue["S24"].ToString()),
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse = repositoryPresse.FindBy(new Query().Add(new Criterion("Code",24,CriteriaOperator.Equal))).First() 
                        });


                    if (int.Parse(baseValue["S25"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 25,
                            NombreOccurence = int.Parse(baseValue["S25"].ToString()),
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse = repositoryPresse.FindBy(new Query().Add(new Criterion("Code",25,CriteriaOperator.Equal))).First() 
                        });


                    if (int.Parse(baseValue["S26"].ToString()) != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal
                        {
                            NumJournal = 26,
                            NombreOccurence = int.Parse(baseValue["S26"].ToString()),
                            Jour = int.Parse(baseValue["Jour"].ToString()),
                            SupportPresse = repositoryPresse.FindBy(new Query().Add(new Criterion("Code",26,CriteriaOperator.Equal))).First() 
                        });

                }
            }
            vagueRepository.Save(vague);
            var repositoryTV = new RepositoryTV();
            var repositoryRadio = new RepositoryRadio();
            int i = 0;
            foreach (var signalitique in listSignalitique)
            {
                i++;

                var signalitique1 = signalitique;
                var baseValueList = collectionBase.Where(p => p["Matricule"] == signalitique1.Individu.IdQuest);
                foreach (var baseValue in baseValueList)
                {


                    if (int.Parse(baseValue["Q1"].ToString()) != 0)

                        if (int.Parse(baseValue["Q1"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                                {

                                    NumeroQuertdheure = 1,
                                    NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                    SupportTV =
                                        repositoryTV.FindBy(
                                            new Query().Add(new Criterion("Code", int.Parse(baseValue["Q1"].ToString()),
                                                                          CriteriaOperator.Equal))).First()
                                    //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                                });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                                {
                                    QuartHeure = 1,
                                    NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                    SupportRadio =
                                        repositoryRadio.FindBy(
                                            new Query().Add(new Criterion("Code", int.Parse(baseValue["Q1"].ToString()),
                                                                          CriteriaOperator.Equal))).First()
                                    //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                    //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                                });



                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q2"].ToString()) != 0)

                        if (int.Parse(baseValue["Q2"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 2,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q2"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 2,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q2"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });





                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q3"].ToString()) != 0)

                        if (int.Parse(baseValue["Q3"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 3,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q3"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 3,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q3"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });






                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q4"].ToString()) != 0)

                        if (int.Parse(baseValue["Q4"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 4,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q4"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 4,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q4"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });






                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q5"].ToString()) != 0)

                        if (int.Parse(baseValue["Q5"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 5,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q5"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 5,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q5"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });







                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q6"].ToString()) != 0)

                        if (int.Parse(baseValue["Q6"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 6,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q6"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 6,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q6"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });





                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q7"].ToString()) != 0)

                        if (int.Parse(baseValue["Q7"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 7,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q7"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 7,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q7"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });




                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q8"].ToString()) != 0)

                        if (int.Parse(baseValue["Q8"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 8,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q8"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 8,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q8"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });





                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q9"].ToString()) != 0)

                        if (int.Parse(baseValue["Q9"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 9,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q9"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 9,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q9"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });





                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q10"].ToString()) != 0)

                        if (int.Parse(baseValue["Q10"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 10,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q10"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 10,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q10"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });







                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q11"].ToString()) != 0)

                        if (int.Parse(baseValue["Q11"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 11,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q11"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 11,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q11"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });








                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q12"].ToString()) != 0)

                        if (int.Parse(baseValue["Q12"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 12,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q12"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 12,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q12"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });








                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q13"].ToString()) != 0)

                        if (int.Parse(baseValue["Q13"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 13,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q13"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 13,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q13"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });






                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q14"].ToString()) != 0)

                        if (int.Parse(baseValue["Q14"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 14,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q14"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 14,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q14"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });








                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q15"].ToString()) != 0)

                        if (int.Parse(baseValue["Q15"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 15,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q15"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 15,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q15"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });








                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q16"].ToString()) != 0)

                        if (int.Parse(baseValue["Q16"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 16,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q16"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 16,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q16"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });












                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q17"].ToString()) != 0)

                        if (int.Parse(baseValue["Q17"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 17,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q17"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 17,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q17"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });












                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q18"].ToString()) != 0)

                        if (int.Parse(baseValue["Q18"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 18,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q18"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 18,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q18"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });








                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q19"].ToString()) != 0)

                        if (int.Parse(baseValue["Q19"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 19,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q19"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 19,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q19"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });





                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q20"].ToString()) != 0)

                        if (int.Parse(baseValue["Q20"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 20,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q20"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 20,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q20"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });









                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q21"].ToString()) != 0)

                        if (int.Parse(baseValue["Q21"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 21,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q21"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 21,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q21"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });






                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q22"].ToString()) != 0)

                        if (int.Parse(baseValue["Q22"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 22,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q22"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 22,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q22"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            }); 
                    
                    
                    
                    
                    
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q23"].ToString()) != 0)

                        if (int.Parse(baseValue["Q23"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 23,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q23"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 23,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q23"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });






                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q24"].ToString()) != 0)

                        if (int.Parse(baseValue["Q24"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 24,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q24"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 24,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q24"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });


                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q25"].ToString()) != 0)

                        if (int.Parse(baseValue["Q25"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 25,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q25"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 25,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q25"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });



                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q26"].ToString()) != 0)

                        if (int.Parse(baseValue["Q26"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 26,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q26"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 26,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q26"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });

                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q27"].ToString()) != 0)

                        if (int.Parse(baseValue["Q27"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 27,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q27"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 27,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q27"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q28"].ToString()) != 0)

                        if (int.Parse(baseValue["Q28"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 28,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q28"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 28,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q28"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });

                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q29"].ToString()) != 0)

                        if (int.Parse(baseValue["Q29"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 29,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q29"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 29,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q29"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q30"].ToString()) != 0)

                        if (int.Parse(baseValue["Q30"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 30,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q30"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 30,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q30"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });

                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q31"].ToString()) != 0)

                        if (int.Parse(baseValue["Q31"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 31,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q31"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 31,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q31"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                   
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q32"].ToString()) != 0)

                        if (int.Parse(baseValue["Q32"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 32,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q32"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 32,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q32"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q33"].ToString()) != 0)

                        if (int.Parse(baseValue["Q33"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 33,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q33"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 33,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q33"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q34"].ToString()) != 0)

                        if (int.Parse(baseValue["Q34"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 34,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q34"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 34,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q34"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q35"].ToString()) != 0)

                        if (int.Parse(baseValue["Q35"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 35,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q35"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 35,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q35"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q36"].ToString()) != 0)

                        if (int.Parse(baseValue["Q36"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 36,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q36"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 36,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q36"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q37"].ToString()) != 0)

                        if (int.Parse(baseValue["Q37"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 37,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q37"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 37,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q37"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q38"].ToString()) != 0)

                        if (int.Parse(baseValue["Q38"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 38,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q38"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 38,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q38"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q39"].ToString()) != 0)

                        if (int.Parse(baseValue["Q39"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 39,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q39"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 39,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q39"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q40"].ToString()) != 0)

                        if (int.Parse(baseValue["Q40"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 40,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q40"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 40,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q40"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q41"].ToString()) != 0)

                        if (int.Parse(baseValue["Q41"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 41,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q41"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 41,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q41"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q42"].ToString()) != 0)

                        if (int.Parse(baseValue["Q42"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 42,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q42"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 42,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q42"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q43"].ToString()) != 0)

                        if (int.Parse(baseValue["Q43"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 43,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q43"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 43,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q43"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q44"].ToString()) != 0)

                        if (int.Parse(baseValue["Q44"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 44,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q44"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 44,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q44"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q45"].ToString()) != 0)

                        if (int.Parse(baseValue["Q45"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 45,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q45"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 45,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q45"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q46"].ToString()) != 0)

                        if (int.Parse(baseValue["Q46"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 46,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q46"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 46,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q46"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q47"].ToString()) != 0)

                        if (int.Parse(baseValue["Q47"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 47,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q47"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 47,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q47"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q48"].ToString()) != 0)

                        if (int.Parse(baseValue["Q48"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 48,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q48"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 48,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q48"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q49"].ToString()) != 0)

                        if (int.Parse(baseValue["Q49"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 49,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q49"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 49,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q49"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q50"].ToString()) != 0)

                        if (int.Parse(baseValue["Q50"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 50,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q50"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 50,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q50"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q51"].ToString()) != 0)

                        if (int.Parse(baseValue["Q51"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 51,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q51"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 51,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q51"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q52"].ToString()) != 0)

                        if (int.Parse(baseValue["Q52"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 52,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q52"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 52,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q52"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q53"].ToString()) != 0)

                        if (int.Parse(baseValue["Q53"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 53,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q53"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 53,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q53"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q54"].ToString()) != 0)

                        if (int.Parse(baseValue["Q54"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 54,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q54"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 54,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q54"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q55"].ToString()) != 0)

                        if (int.Parse(baseValue["Q55"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 55,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q55"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 55,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q55"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q56"].ToString()) != 0)

                        if (int.Parse(baseValue["Q56"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 56,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q56"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 56,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q56"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q57"].ToString()) != 0)

                        if (int.Parse(baseValue["Q57"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 57,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q57"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 57,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q57"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q58"].ToString()) != 0)

                        if (int.Parse(baseValue["Q58"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 58,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q58"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 58,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q58"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q59"].ToString()) != 0)

                        if (int.Parse(baseValue["Q59"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 59,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q59"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 59,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q59"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q60"].ToString()) != 0)

                        if (int.Parse(baseValue["Q60"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 60,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q60"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 60,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q60"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q61"].ToString()) != 0)

                        if (int.Parse(baseValue["Q61"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 61,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q61"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 61,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q61"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q62"].ToString()) != 0)

                        if (int.Parse(baseValue["Q62"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 62,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q62"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 62,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q62"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q63"].ToString()) != 0)

                        if (int.Parse(baseValue["Q63"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 63,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q63"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 63,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q63"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q64"].ToString()) != 0)

                        if (int.Parse(baseValue["Q64"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 64,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q64"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 64,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q64"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q65"].ToString()) != 0)

                        if (int.Parse(baseValue["Q65"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 65,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q65"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 65,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q65"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q66"].ToString()) != 0)

                        if (int.Parse(baseValue["Q66"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 66,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q66"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 66,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q66"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q67"].ToString()) != 0)

                        if (int.Parse(baseValue["Q67"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 67,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q67"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 67,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q67"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q68"].ToString()) != 0)

                        if (int.Parse(baseValue["Q68"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 68,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q68"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 68,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q68"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q69"].ToString()) != 0)

                        if (int.Parse(baseValue["Q69"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 69,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q69"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 69,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q69"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q70"].ToString()) != 0)

                        if (int.Parse(baseValue["Q70"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 70,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q70"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 70,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q70"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q71"].ToString()) != 0)

                        if (int.Parse(baseValue["Q71"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 71,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q71"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 71,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q71"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q72"].ToString()) != 0)

                        if (int.Parse(baseValue["Q72"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 72,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q72"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 72,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q72"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q73"].ToString()) != 0)

                        if (int.Parse(baseValue["Q73"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 73,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q73"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 73,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q73"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q74"].ToString()) != 0)

                        if (int.Parse(baseValue["Q74"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 74,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q74"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 74,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q74"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q75"].ToString()) != 0)

                        if (int.Parse(baseValue["Q75"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 75,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q75"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 75,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q75"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q76"].ToString()) != 0)

                        if (int.Parse(baseValue["Q76"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 76,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q76"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 76,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q76"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q77"].ToString()) != 0)

                        if (int.Parse(baseValue["Q77"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 77,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q77"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 77,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q77"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q78"].ToString()) != 0)

                        if (int.Parse(baseValue["Q78"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 78,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q78"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 78,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q78"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q79"].ToString()) != 0)

                        if (int.Parse(baseValue["Q79"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 79,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q79"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 79,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q79"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q80"].ToString()) != 0)

                        if (int.Parse(baseValue["Q80"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 80,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q80"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 80,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q80"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q81"].ToString()) != 0)

                        if (int.Parse(baseValue["Q81"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 81,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q81"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 81,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q81"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q82"].ToString()) != 0)

                        if (int.Parse(baseValue["Q82"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 82,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q82"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 82,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q82"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q83"].ToString()) != 0)

                        if (int.Parse(baseValue["Q83"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 83,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q83"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 83,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q83"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q84"].ToString()) != 0)

                        if (int.Parse(baseValue["Q84"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 84,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q84"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 84,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q84"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q85"].ToString()) != 0)

                        if (int.Parse(baseValue["Q85"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 85,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q85"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 85,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q85"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q86"].ToString()) != 0)

                        if (int.Parse(baseValue["Q86"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 86,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q86"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 86,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q86"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q87"].ToString()) != 0)

                        if (int.Parse(baseValue["Q87"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 87,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q87"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 87,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q87"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q88"].ToString()) != 0)

                        if (int.Parse(baseValue["Q88"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 88,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q88"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 88,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q88"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q89"].ToString()) != 0)

                        if (int.Parse(baseValue["Q89"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure =89,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q89"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 89,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q89"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q90"].ToString()) != 0)

                        if (int.Parse(baseValue["Q90"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 90,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q90"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 90,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q90"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q91"].ToString()) != 0)

                        if (int.Parse(baseValue["Q91"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 91,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q91"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 91,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q91"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q92"].ToString()) != 0)

                        if (int.Parse(baseValue["Q92"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 92,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q92"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 92,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q92"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q93"].ToString()) != 0)

                        if (int.Parse(baseValue["Q93"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 93,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q93"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 93,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q93"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q94"].ToString()) != 0)

                        if (int.Parse(baseValue["Q94"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 94,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q94"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 94,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q94"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q95"].ToString()) != 0)

                        if (int.Parse(baseValue["Q95"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 95,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q95"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 95,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q95"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                    /***********************************************************************************************/
                    if (int.Parse(baseValue["Q96"].ToString()) != 0)

                        if (int.Parse(baseValue["Q96"].ToString()) < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV()
                            {

                                NumeroQuertdheure = 96,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportTV =
                                    repositoryTV.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q96"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio()
                            {
                                QuartHeure = 96,
                                NumeroJour = int.Parse(baseValue["Jour"].ToString()),
                                SupportRadio =
                                    repositoryRadio.FindBy(
                                        new Query().Add(new Criterion("Code", int.Parse(baseValue["Q96"].ToString()),
                                                                      CriteriaOperator.Equal))).First()
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportMedia
                                //XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1,BinaryOperatorType.Equal)).SupportRadio
                            });
                   
                }

            }



                      return listSignalitique;
        }
    }
}