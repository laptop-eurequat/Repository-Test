using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Moq;
using NUnit.Framework;
using Zero.Core.Domain;
using Zero.Core.Domain.Query;
using Zero.DataLayer;
using Zero.DataLayer.Helper;
using Zero.POCO;
using Zero.POCO.Compagne;
using Zero.POCO.Donnees;
using Zero.POCO.FiltreEnumeration;
using Zero.POCO.Interfaces;
using Zero.POCO.Support;
using System.Xml;

namespace Zero.Test
{
    public class FiltreTest : IFiltre
    {
        public string Nom
        {
            get { return "MonFiltre"; }
        }
        public int ageMin
        {
            get { return 20; }
        }
        public int ageMax
        {
            get { return 65; }
        }
        public List<CSE> CSEs
        {
            get 
            { 
                var list= new List<CSE> {CSE.A_ClasseAisee};
                return list;
            }
        }
        public List<CSP> CSPs
        {
            get
            {
                var list = new List<CSP> { CSP.Cadre };
                return list;
            }
        }
        public List<Equipement> Equipements
        {
            get
            {
                var list = new List<Equipement> { Equipement.Aspirateur, Equipement.Climatiseur };
                return list;
            }
        }
        public List<Genre> Genres
        {
            get
            {
                var list = new List<Genre> { Genre.Femme };
                return list;
            }
        }
        public List<Habitat> Habitats
        {
            get
            {
                var list = new List<Habitat> { Habitat.Proprietaire};
                return list;
            }
        }
        public List<NbChambre> NbChambres
        {
            get
            {
                var list = new List<NbChambre> { NbChambre.DeuxChambre };
                return list;
            }
        }
        public List<NbVoiture> NbVoitures
        {
            get
            {
                var list = new List<NbVoiture> { NbVoiture.DeuxVoiture };
                return list;
            }
        }
        public List<NiveauInstruction> NiveauxInstructions
        {
            get
            {
                var list = new List<NiveauInstruction> { NiveauInstruction.NiveauxMoyen };
                return list;
            }
        }
        public List<RevenuTotalFoyer> RevenueTotalFoyers
        {
            get
            {
                var list = new List<RevenuTotalFoyer> { RevenuTotalFoyer.deuximere};
                return list;
            }
        }
        public List<Salaire> Salaires
        {
            get
            {
                var list = new List<Salaire> { Salaire .Entre35000Et49000};
                return list;
            }
        }
        public List<SituationMatrimonial> SituationMatrimonials
        {
            get
            {
                var list = new List<SituationMatrimonial> { SituationMatrimonial.MarieAvecEnfantMineurMajeur };
                return list;
            }
        }
        public List<StatutFamiliale> StatutFamiliales
        {
            get
            {
                var list = new List<StatutFamiliale> { StatutFamiliale.ChefFamille };
                return list;
            }
        }
        public List<TailleFoyer> TailleFoyers
        {
            get
            {
                var list = new List<TailleFoyer> { TailleFoyer.gigantesque};
                return list;
            }
        }
        public List<TypeHabitation> TypeHabitations
        {
            get
            {
                var list = new List<TypeHabitation> { TypeHabitation.AppartementImmeubleStanding };
                return list;
            }
        }
    }



    [TestFixture]
    public class CompaignTest
    {
        private Mock<IRepository<Compaign, Guid>> mock;
        private Mock<IRepository<Signalitique, Guid>> mockSignalitique;
        [SetUp]
        public void Start()
        {
            mock = new Mock<IRepository<Compaign, Guid>>();
            mock.Setup(e => e.FindBy(It.IsAny<Guid>())).Returns(CompaignFactory.CreateCompaign(AnnonceurFactory.CreateAnnonceur("annonceur"), TypeCompaign.CourteDuree));

            mockSignalitique = new Mock<IRepository<Signalitique, Guid>>();
            mock.Setup(e => e.FindBy(It.IsAny<Guid>())).Returns(CompaignFactory.CreateCompaign(AnnonceurFactory.CreateAnnonceur("annonceur"), TypeCompaign.CourteDuree));
            
        }


        [Test]
        public void CanCreateACompaign()
        {
            
            var comp = CompaignFactory.CreateCompaign(AnnonceurFactory.CreateAnnonceur("annonceur"), TypeCompaign.CourteDuree);
            Assert.IsNotNull(comp);



            var comp2 = CompaignFactory.CreateCompaign(AnnonceurFactory.CreateAnnonceur("annonceur"), 
                                                       TypeCompaign.CourteDuree,
                                                       AnnonceurFactory.CreateMarque("marque", AnnonceurFactory.CreateAnnonceur("annonceur"),TypeMarque.Lessive));
            Assert.IsNotNull(comp2);
            Assert.AreEqual(comp2.Annonceur.Name,"annonceur");
            Assert.AreEqual(comp2.Marque.Name, "marque");
            Assert.AreEqual(comp2.TypeCompaign, TypeCompaign.CourteDuree);
            Assert.AreEqual(comp2.Marque.Type, TypeMarque.Lessive);



            var comp3 = CompaignFactory.CreateCompaign(AnnonceurFactory.CreateAnnonceur("annonceur"), 
                                                       TypeCompaign.CourteDuree);
            Assert.IsNotNull(comp3);
            Assert.AreEqual(comp3.TypeCompaign, TypeCompaign.CourteDuree);
            Assert.AreEqual(comp3.Annonceur.Name, "annonceur");

            

         

        }



        [Test]
        public void CanCreateAMarque()
        {
            var marque = AnnonceurFactory.CreateMarque("marque",AnnonceurFactory.CreateAnnonceur("annonceur"),TypeMarque.Lessive);
            Assert.IsNotNull(marque);
            Assert.AreEqual(marque.Name,"marque");
            Assert.AreEqual(marque.Annonceur.Name,"annonceur");
            Assert.AreEqual(marque.Type, TypeMarque.Lessive);
        }

        [Test]
        public void CanCreateAnAnnonceur()
        {
            var annonceur = AnnonceurFactory.CreateAnnonceur("annonceur");
            Assert.IsNotNull(annonceur);
            Assert.AreEqual(annonceur.Name, "annonceur");
        }

#region acces Db 
/* 
        [Test]
        public void CanRetreiveACompaign()
        {
            CompaignRepository.GetCompaign(new Marque());
            CompaignRepository.GetCompaign(new Annonceur());
            CompaignRepository.GetCompaign(new TypeCompaign());
            CompaignRepository.GetCompaign(new Marque(),new TypeCompaign());
            CompaignRepository.GetCompaign(new Marque(), new Annonceur());
            CompaignRepository.GetCompaign(new Annonceur(), new TypeCompaign());


            CompaignRepository.GetAllMarque();
            CompaignRepository.GetAllAnnonceur();

        }
        */



                /*
        [Ignore]
         [Test]
         public void CanArchieveACompaign()
         {
             CompaignRepository.Archieve(new Annonceur());
         }
        
         */
#endregion
        [Test]
        public void CanCreateFiltre()
        {
            var filtre = FiltreFactory.CreateFiltre(new FiltreTest());
            Assert.AreEqual(filtre.Nom, new FiltreTest().Nom);
        }






        [Test]
        public void CanCreatePlans()
        {
            var compagne=mock.Object.FindBy(new Guid());
            CompaignFactory.CreatePlanTv(name: "MonPlanTv", compaign: compagne);
            Assert.AreEqual(compagne.PlanTvs.Count,1);
            Assert.AreEqual(compagne.PlanTvs.First().Name, "MonPlanTv");

            CompaignFactory.CreatePlanRadio(name: "MonPlanRadio", compaign: compagne);
            Assert.AreEqual(compagne.PlanRadios.Count, 1);
            Assert.AreEqual(compagne.PlanRadios.First().Name, "MonPlanRadio");

            CompaignFactory.CreatePlanPresse(name: "MonPlanPresse", compaign: compagne);
            Assert.AreEqual(compagne.PlanPresses.Count, 1);
            Assert.AreEqual(compagne.PlanPresses.First().Name, "MonPlanPresse");

            CompaignFactory.CreatePlanPresse(name: "MonPlanPresse2", compaign: compagne);
            Assert.AreEqual(compagne.PlanPresses.Count, 2);

            const int numQuart = 2;
            var date = DateTime.Now;
            var supportTv=new SupportTV();
            CompaignFactory.CreateInsertionTv(compagne.PlanTvs.FirstOrDefault(), numQuart, supportTv,date);
            var firstOrDefault = compagne.PlanTvs.FirstOrDefault();
        
            /*Assert.AreEqual(firstOrDefault.InsertionTvs.First().NumeroQuartHeure, numQuart);


            const int numQuartR = 2;
            var dateR = DateTime.Now;
            var supportRadio = new SupportRadio();
            CompaignFactory.CreateInsertionRadio(compagne.PlanRadios.FirstOrDefault(), numQuartR, supportRadio, dateR);
            var firstOrDefaultR = compagne.PlanRadios.FirstOrDefault();

            Assert.AreEqual(firstOrDefaultR.InsertionRadios.First().NumeroQuartHeure, numQuart);


            const int numQuartP = 2;
            var datep = DateTime.Now;
            var supportPresse = new SupportPresse();
            CompaignFactory.CreateInsertionPresse(compagne.PlanPresses.FirstOrDefault(), numQuartP, supportPresse, datep);
            var firstOrDefaultP = compagne.PlanPresses.FirstOrDefault();

            Assert.AreEqual(firstOrDefaultP.InsertionPresses.First().Date, datep);*/
        }
        

         [Test]
         public void CanLoadExcel()
         {
             InitDAL.Init();
             const string nomVague = "LaMortQuiTue";

             const string filePath = @"C:\Users\Administrator\Desktop\upload.xlsx";
             //var vagueFacade = new CreationVagueFacade(new CreateVagueClientProxy());
             var resultat = DonneesFactory.CreateDonnees(filePath, "LaMortQuiTue", new IndividuRepository(),new VagueRepository());

         }
    }
}
