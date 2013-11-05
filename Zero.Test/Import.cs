using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Excel;
using NUnit.Framework;
using Zero.POCO.Compagne;
using Zero.POCO.Donnees;

namespace EventRegistration.UI
{
    public partial class ConstructionPlanMedia : System.Web.UI.Page
    {
       // private DevExpress.Xpo.Session XpoSession { get; set; }
        private static List<Signalitique> signalitiques;
        private static List<object> gridLookupChaineGridViewGetSelectedFieldValues;
        private static List<object> gridLookupRadioGridViewGetSelectedFieldValues;
        private static List<object> gridLookupPresseGridViewGetSelectedFieldValues;
        private static Guid Oid = default(Guid);
        private Compaign campagneActuelle = null;

        protected void Page_Init(object sender, EventArgs e)
        {
            #region mesg
            /*XpoSession = new DevExpress.Xpo.Session();
            DataSourceJournal.Session = XpoSession;
            DataSourceRadio.Session = XpoSession;
            DataSourceTele.Session = XpoSession;
            DataSourceVague.Session = XpoSession;


            DataSourceJournal.DefaultSorting = "Libelle ASC";
            DataSourceRadio.DefaultSorting = "Libelle ASC";
            DataSourceTele.DefaultSorting = "Libelle ASC";
            DataSourceVague.DefaultSorting = "Numero ASC";*/
            #endregion

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            #region msg1
            /* var s = new SupportMedia(XpoSession) { Libelle = "MBC Maser" };
             s.Save();

             s = new SupportMedia(XpoSession) { Libelle = "NUMIDIA NEWS" };
             s.Save();

             s = new SupportMedia(XpoSession) { Libelle = "Al JAZEERA SPORT" };
             s.Save();

             s = new SupportMedia(XpoSession) { Libelle = "Abu Dhabi" };
             s.Save();
     

          */
            //var vaguek = new Vague(XpoSession) { Annee = 2012, Mois = 12, Numero = 1, Libelle = "Decembre 2012" };
            //vaguek.Save();

            /*
            int ll = 0;
            var vaguec = XpoSession.GetObjectByKey<Vague>(Guid.Parse("5D952B23-0547-417C-AB51-01374B7FF481"));
            var signali = new XPCollection<Signalitique>(XpoSession, new BinaryOperator("Vague", vaguec));
            foreach (var sig in signali)
            {
                ll++;
                XpoSession.Delete(sig.AudienceJournals);
                XpoSession.Delete(sig.AudienceTVs);
                XpoSession.Delete(sig.AudienceRadios);

            }
            XpoSession.Delete(signali);
            */
            #endregion

            string date1 = "Annee = '2012'and Mois='6'";
            int anne = 2012;
            int mois = 6;


  #region com

            //var s = new SupportMedia(XpoSession) { Libelle = "Abu Dhabi" };
            //s.Save();

            /* var sig = new XPCollection<Signalitique>(XpoSession);
                  
             foreach (var signalitique in sig)
             {
                           
                 {
                     XpoSession.Delete(signalitique.AudienceJournals);
                     XpoSession.Delete(signalitique.AudienceTVs);
                     XpoSession.Delete(signalitique.AudienceRadios);
                    
                 }
                
             }*/


            /*
                       foreach (var signalitique in sig)
                       {
                           if (signalitique.Vague.Oid == Guid.Parse("89650168-615B-4914-8453-663FE3699B86"))

                           { signalitique.Vague = null; signalitique.Save(); }
                       }*/

            /*(
                        var co = new Code(XpoSession)
                        {
                            SupportMedia = s,
                            code5 = 48,
              

                        };
                        co.Save();
                        */






            /*
             * 
             * 
             * 
             * 
             * 
             * 
             * var vague= XpoSession.GetObjectByKey<Vague>(Guid.Parse("4C21DD32-D805-4B32-B32E-40C28AF75507"));
            var signali =new  XPCollection<Signalitique>(XpoSession,new BinaryOperator("Vague",vague));
            foreach (var sig in signali)
            {

                XpoSession.Delete(sig.AudienceJournals);
                XpoSession.Delete(sig.AudienceTVs);
                XpoSession.Delete(sig.AudienceRadios);
                
            }
             * 
             * 
             * 
             * 
            var r = new SupportRadio(XpoSession) { Libelle = "Chaine 1"};
            r.Save();

            r = new SupportRadio(XpoSession) { Libelle = "Chaine 2"};
            r.Save();


            r = new SupportRadio(XpoSession) { Libelle = "Chaine 3"};
            r.Save();


            r = new SupportRadio(XpoSession) { Libelle = "Jil FM"};
            r.Save();


            r = new SupportRadio(XpoSession) { Libelle = "Radio Algérie International"};
            r.Save();


            r = new SupportRadio(XpoSession) { Libelle = "Radio El Bahdja"};
            r.Save();

            r = new SupportRadio(XpoSession) { Libelle = "Radio Cirta"};
            r.Save();

            r = new SupportRadio(XpoSession) { Libelle = "Radio El Hidhab"};
            r.Save();

            r = new SupportRadio(XpoSession) { Libelle = "Radio El Bahia",};
            r.Save();

            r = new SupportRadio(XpoSession) { Libelle = "Autres Radio"};
            r.Save();







            var t = new SupportPresse(XpoSession) { Libelle = "Akher Saa"};
            t.Save();

            t = new SupportPresse(XpoSession) { Libelle = "Algerie News"};
            t.Save();



            t = new SupportPresse(XpoSession) { Libelle = "Competition"};
            t.Save();



            t = new SupportPresse(XpoSession) { Libelle = "Dajzair News (Ar)"};
            t.Save();





            t = new SupportPresse(XpoSession) { Libelle = "Echorouq"};
            t.Save();






            t = new SupportPresse(XpoSession) { Libelle = "El Haddef"};
            t.Save();


            t = new SupportPresse(XpoSession) { Libelle = "le Buteur"};
            t.Save();

            t = new SupportPresse(XpoSession) { Libelle = "El Khabar"};
            t.Save();

            t = new SupportPresse(XpoSession) { Libelle = "El Moudjahid"};
            t.Save();


            t = new SupportPresse(XpoSession) { Libelle = "El Watan"};
            t.Save();


            t = new SupportPresse(XpoSession) { Libelle = "El Yaoum"};
            t.Save();


            t = new SupportPresse(XpoSession) { Libelle = "Ennahar al-Jadid"};
            t.Save();


            t = new SupportPresse(XpoSession) { Libelle = "Horizons"};
            t.Save();



            t = new SupportPresse(XpoSession) { Libelle = "Info Soir"};
            t.Save();

            t = new SupportPresse(XpoSession) { Libelle = "la Nouvelle Réublique"};
            t.Save();



            t = new SupportPresse(XpoSession) { Libelle = "le Maghreb"};
            t.Save();



            t = new SupportPresse(XpoSession) { Libelle = "le Quotidien d'Oran"};
            t.Save();




            t = new SupportPresse(XpoSession) { Libelle = "le Soir d'Algérie"};
            t.Save();





            t = new SupportPresse(XpoSession) { Libelle = "le Temps"};
            t.Save();



            t = new SupportPresse(XpoSession) { Libelle = "l'Expression"};
            t.Save();



            t = new SupportPresse(XpoSession) { Libelle = "Liberté"};
            t.Save();




            t = new SupportPresse(XpoSession) { Libelle = "Midi Libre"};
            t.Save();



            t = new SupportPresse(XpoSession) { Libelle = "Transaction d'Algérie"};
            t.Save();




            t = new SupportPresse(XpoSession) { Libelle = "Waqt el-Djazair"};
            t.Save();



















            var s = new SupportMedia(XpoSession) { Libelle = "ENTV" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "Canal Algérie" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "A3C" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "Tamazight Algérie TV4" };
            s.Save();
            s = new SupportMedia(XpoSession) { Libelle = "TV Coran Algérie TV5" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "MBC 1" };
            s.Save();




            s = new SupportMedia(XpoSession) { Libelle = "MBC 2" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "MBC 3" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "MBC 4" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "MBC Action" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "MBC Max" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "MBC Drama" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "Nessma TV" };
            s.Save();





            s = new SupportMedia(XpoSession) { Libelle = "Al JAZEERA NEWS" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "Al JAZEERA SPORT ( Gratuit )" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "Al JAZEERA SPORT (Payante )" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "FOX Movies" };
            s.Save();


            s = new SupportMedia(XpoSession) { Libelle = "Medi 1 sat" };
            s.Save();





            s = new SupportMedia(XpoSession) { Libelle = "2M (Maroc)" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "TV7 (Tunisie)" };
            s.Save();



            s = new SupportMedia(XpoSession) { Libelle = "Echourouk TV" };
            s.Save();



            s = new SupportMedia(XpoSession) { Libelle = "AL MASRIA" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "Dubai TV" };
            s.Save();


            s = new SupportMedia(XpoSession) { Libelle = "Melody Aflam" };
            s.Save();



            s = new SupportMedia(XpoSession) { Libelle = "Rotana Cinéma" };
            s.Save();


            s = new SupportMedia(XpoSession) { Libelle = "Al ARABIYA" };
            s.Save();


            s = new SupportMedia(XpoSession) { Libelle = "Al ARASSIYA" };
            s.Save();


            s = new SupportMedia(XpoSession) { Libelle = "Al JAZAIRIA" };
            s.Save();


            s = new SupportMedia(XpoSession) { Libelle = "EN Nahar TV" };
            s.Save();



            s = new SupportMedia(XpoSession) { Libelle = "ARTE" };
            s.Save();




            s = new SupportMedia(XpoSession) { Libelle = "BEUR TV" };
            s.Save();




            s = new SupportMedia(XpoSession) { Libelle = "TF1" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = " FRANCE 2" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "FRANCE 3" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "M6" };
            s.Save();


            s = new SupportMedia(XpoSession) { Libelle = "CANAL+" };
            s.Save();





            s = new SupportMedia(XpoSession) { Libelle = "TV5" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "FRANCE 24" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "Autres Chaine Arabophones" };
            s.Save();

            s = new SupportMedia(XpoSession) { Libelle = "Autres Chaine Francophones" };
            s.Save();
                        var s = new SupportMedia(XpoSession) { Libelle = "LA 5e" };
            s.Save();

             * 
             * 
             * le Jeune Indépendant
             * 
             * 
             * 
             * 
             * l Echo d Oran
             * 
             * 
            var s = new SupportPresse(XpoSession) { Libelle = "le Jeune Indépendant" };
            s.Save();


            s = new SupportPresse(XpoSession) { Libelle = "l Echo d Oran" };
            s.Save();
             * 
             *             var s = new SupportMedia(XpoSession) { Libelle = "Vidéo / DVD" };
            s.Save();
             *             var s = new SupportMedia(XpoSession) { Libelle = "El Magharibia TV" };
            s.Save();
            */




            /*
            XPCollection<SupportMedia> suppTEL = new XPCollection<SupportMedia>(XpoSession);
            foreach (SupportMedia up in suppTEL)
            {
                codechanine cc = XpoSession.FindObject<codechanine>(BinaryOperator.Parse("Chaines = '" + up.Libelle + "'"));
            
                var co=new Code(XpoSession)
                {
                    SupportMedia=up,
                    code5=cc.code5,
                    Code2=cc.Code2,
                    Code3=cc.Code3,
                    Code4=cc.Code4,
                    Code5=cc.Code5,
                    Code6=cc.Code6,
                    Code7=cc.Code7,
                    Code8=cc.Code8,
                    Code9=cc.Code9,
                    code50=cc.code50,
                    code51=cc.code51,
                    code52=cc.code52,
                    code53=cc.code53,
                    code54=cc.code54

                };
                co.Save();
            }

            XPCollection<SupportRadio> supp = new XPCollection<SupportRadio>(XpoSession);
            foreach (SupportRadio up in supp)
            {
                codechanine cc = XpoSession.FindObject<codechanine>(BinaryOperator.Parse("Chaines = '" + up.Libelle + "'"));

                var co = new Code(XpoSession)
                {
                    SupportRadio = up,
                    code5 = cc.code5,
                    Code2 = cc.Code2,
                    Code3 = cc.Code3,
                    Code4 = cc.Code4,
                    Code5 = cc.Code5,
                    Code6 = cc.Code6,
                    Code7 = cc.Code7,
                    Code8 = cc.Code8,
                    Code9 = cc.Code9,
                    code50 = cc.code50,
                    code51 = cc.code51,
                    code52 = cc.code52,
                    code53 = cc.code53,
                    code54 = cc.code54

                };
                co.Save();
            }
          
            */
            /*
            XPCollection<SupportPresse> suppss = new XPCollection<SupportPresse>(XpoSession);
            foreach (SupportPresse up in suppss)
            {
                codechanine cc = XpoSession.FindObject<codechanine>(BinaryOperator.Parse("Chaines = '" + up.Libelle + "'"));

                var co = new CodePresse(XpoSession)
                {
                    SupportPresse = up,
                    code5 = cc.code5,
                    Code2 = cc.Code2,
                    Code3 = cc.Code3,
                    Code4 = cc.Code4,
                    Code5 = cc.Code5,
                    Code6 = cc.Code6,
                    Code7 = cc.Code7,
                    Code8 = cc.Code8,
                    Code9 = cc.Code9,
                    code50 = cc.code50,
                    code51 = cc.code51,
                    code52 = cc.code52,
                    code53 = cc.code53,
                    code54 = cc.code54

                };
                co.Save();
            }
            */


            #endregion

            string filePath = "";
            var extension = Path.GetExtension(filePath);
            var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            var excelReader = extension == ".xlsx" ? ExcelReaderFactory.CreateOpenXmlReader(stream) : ExcelReaderFactory.CreateBinaryReader(stream);
            excelReader.IsFirstRowAsColumnNames = true;
            var result = excelReader.AsDataSet();
            Assert.AreEqual(extension, ".xlsx");


          
            var distincts = result.Tables[0].Select(p => p.idquest).Distinct();
            foreach (var distinct in distincts)
            {
                var ind = new Individu(XpoSession);
                var convdistinct = int.Parse(distinct.ToString());
                if (XpoSession.FindObject<Individu>(new BinaryOperator("IdQuest", convdistinct.ToString())) != null) continue;

                ind.IdQuest = int.Parse(distinct.ToString());

                ind.Sexe = CollectionBase.Where(d => d.idquest == ind.IdQuest).First().SEXE;
                ind.Save();
            }


            #region comm



            /*     
             * 
             *    var vague = new Vague(XpoSession) { Annee = 2012, Mois = 8, Numero = 1, Libelle = "Aout 2012" };
            vague.Save();
                   var vague = new Vague(XpoSession) { Annee = 2011, Mois = 3, Numero = 1, Libelle = "Mars 2011" };
                   vague.Save();

                   vague = new Vague(XpoSession) { Annee = 2011, Mois = 4, Numero = 2, Libelle = "Avril 2011" };
                   vague.Save();

                   vague = new Vague(XpoSession) { Annee = 2011, Mois = 5, Numero = 3, Libelle = "Mai 2011" };
                   vague.Save();

                   vague = new Vague(XpoSession) { Annee = 2011, Mois = 6, Numero = 4, Libelle = "Juin 2011" };
                   vague.Save();


                   vague = new Vague(XpoSession) { Annee = 2011, Mois = 7, Numero = 5, Libelle = "Juillet 2011" };
                   vague.Save();

                   vague = new Vague(XpoSession) { Annee = 2011, Mois = 8, Numero = 6, Libelle = "Aout 2011" };
                   vague.Save();

                   vague = new Vague(XpoSession) { Annee = 2011, Mois = 9, Numero = 7, Libelle = "Septembre 2011" };
                   vague.Save();

                   vague = new Vague(XpoSession) { Annee = 2011, Mois = 10, Numero = 8, Libelle = "Octobre 2011" };
                   vague.Save();


                   vague = new Vague(XpoSession) { Annee = 2011, Mois = 11, Numero = 9, Libelle = "Novembre 2011" };
                   vague.Save();


                   vague = new Vague(XpoSession) { Annee = 2011, Mois = 12, Numero = 10, Libelle = "Decembre 2011" };
                   vague.Save();


                   vague = new Vague(XpoSession) { Annee = 2012, Mois = 1, Numero = 11, Libelle = "Janvier 2012" };
                   vague.Save();

                   vague = new Vague(XpoSession) { Annee = 2012, Mois = 2, Numero = 12, Libelle = "Fevrier 20012" };
                   vague.Save();


                   vague = new Vague(XpoSession) { Annee = 2012, Mois = 3, Numero = 13, Libelle = "Mars 2012" };
                   vague.Save();

                   vague = new Vague(XpoSession) { Annee = 2012, Mois = 4, Numero = 14, Libelle = "Avril 2012" };
                   vague.Save();

                   vague = new Vague(XpoSession) { Annee = 2012, Mois = 5, Numero = 15, Libelle = "Mai 2012" };
                   vague.Save();
             * 
             * 
             * 
             *     vague = new Vague(XpoSession) { Annee = 2012, Mois = 6, Numero = 16, Libelle = "Juin 2012" };
                   vague.Save();

                   vague = new Vague(XpoSession) { Annee = 2012, Mois = 7, Numero = 17, Libelle = "Juillet 2012" };
                   vague.Save();
             * 
             * 
            var vague = new Vague(XpoSession) { Annee = 2012, Mois = 8, Numero = 18, Libelle = " 2012" };
            vague.Save();

          */


            //var CollectionIndividu = new XPCollection<Individu>(XpoSession);
            //var a = CollectionIndividu.Count;

            //var collectionVague = new XPCollection<Vague>(XpoSession);

            //foreach (var individu in CollectionIndividu)
            //{
            //    var lignes = CollectionBase.Where(d => d.idquest == individu.IdQuest);
            //    foreach (var ligne in lignes)
            //    {
            //        var filtreVague = collectionVague.Where(p => (p.Mois == ligne.Mois && p.Annee == ligne.Annee));
            //        foreach (var vague1 in filtreVague)
            //        {
            //            individu.Vagues.Add(vague1); 
            //        }
            //    }
            //}




            // 



            #endregion

            //var Collectionindiidu2 = new XPCollection<Individu>(XpoSession);
            //var collectionVague = new XPCollection<Vague>(XpoSession);

            foreach (var individu in Collectionindiidu2)
            {

                var individu1 = individu;
                IEnumerable<test3> temp = CollectionBase.Where(p => p.idquest == individu1.IdQuest && p.Annee == anne && p.Mois == mois);

                foreach (var elem in temp)
                {
                    if (elem.Jour != 1) continue;
                    var tempSign = new Signalitique(XpoSession);
                    tempSign.Age = elem.AGE_CLAIR;
                    tempSign.CSE = elem.CSE;
                    tempSign.CSP = elem.OCCUPATION;
                    tempSign.Habitat = elem.Etat_Habitat;
                    tempSign.TypeHabitat = elem.TYP_HABI;
                    tempSign.NbVoiture = elem.NB_VOIT;
                    tempSign.NbPiece = elem.NB_PIECE;
                    tempSign.Niveau = elem.NIV;
                    tempSign.statut_familial = elem.STATUT;
                    tempSign.situation_matrimoniale = elem.SITUATION;
                    tempSign.Ville = elem.Ville;
                    tempSign.Tranche_Age = elem.AGE_TRANCH;
                    tempSign.RevenueTotalFoyer = elem.Revenu_Foyer;
                    tempSign.Poid = elem.poids;
                    tempSign.Mois = elem.Mois;
                    tempSign.Jour = elem.Jour;
                    tempSign.Refrigirateur = elem.P1;
                    tempSign.Television_en_couleur = elem.P2;
                    tempSign.Lecteur_radio_cassette = elem.P3;
                    tempSign.decodeur = elem.P4;
                    tempSign.Mobile = elem.P5;
                    tempSign.Cuisiniere = elem.P6;
                    tempSign.Telephone_Fixe = elem.P7;
                    tempSign.Four_micro_onde = elem.P8;
                    tempSign.Chaine_stereo = elem.P9;
                    tempSign.LaveLinge = elem.P10;
                    tempSign.Lecteur_DVD = elem.P11;
                    tempSign.Aspirateur = elem.P12;
                    tempSign.Pc_sans_connexion = elem.P13;
                    tempSign.Congelateur = elem.P14;
                    tempSign.appareil_Photo_Numerique = elem.P15;
                    tempSign.Magnetoscope = elem.P16;
                    tempSign.LecteurCD = elem.P17;
                    tempSign.Climatiseur = elem.P18;
                    tempSign.Camescope = elem.P19;
                    tempSign.Console = elem.P20;
                    tempSign.LaveVaissele = elem.P21;
                    tempSign.SecheLinge = elem.P22;
                    tempSign.PC_Connexion = elem.P23;
                    tempSign.genre = elem.SEXE;
                    tempSign.matricule = int.Parse(elem.idquest.ToString());

                    var ann = elem.Annee;
                    tempSign.Vague = collectionVague.Where(p => (p.Mois == tempSign.Mois && p.Annee == ann)).First();
                    individu.Signalitiques.Add(tempSign);
                }


                individu.Save();
            }

            #region com2
            /*
            var CollectionSiganlitique = new XPCollection<Signalitique>(XpoSession);
            collectionVague = new XPCollection<Vague>(XpoSession);

            foreach (var sig in CollectionSiganlitique)
            {
                IEnumerable<test3> collectionBaseWhere = CollectionBase.Where(p => p.idquest == sig.Individu.IdQuest);
                if (collectionBaseWhere.Count()==0) continue;
                var ann = collectionBaseWhere.First().Annee;
                sig.Vague = collectionVague.Where(p => (p.Mois == sig.Mois && p.Annee == ann)).First();
                sig.Save();
            }
            */

            #endregion

            var vague = collectionVague.Where(p => (p.Mois == mois && p.Annee == anne)).First();





            var signalitiques = new XPCollection<Signalitique>(XpoSession, new BinaryOperator("Vague", vague));
            foreach (var signalitique in signalitiques)
            {


                Signalitique signalitique1 = signalitique;
                var baseValueList = CollectionBase.Where(p => p.idquest == signalitique1.Individu.IdQuest);
                foreach (var baseValue in baseValueList)
                {





                    if (baseValue.titre_5 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 5,
                            NombreOccurence = baseValue.titre_5,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 5, BinaryOperatorType.Equal)).SupportPresse

                        });


                    if (baseValue.titre_17 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 17,
                            NombreOccurence = baseValue.titre_17,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 17, BinaryOperatorType.Equal)).SupportPresse

                        });





                    if (baseValue.titre_1 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 1,
                            NombreOccurence = baseValue.titre_1,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 1, BinaryOperatorType.Equal)).SupportPresse
                        });



                    if (baseValue.titre_2 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 2,
                            NombreOccurence = baseValue.titre_2,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 2, BinaryOperatorType.Equal)).SupportPresse
                        });



                    if (baseValue.titre_3 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 3,
                            NombreOccurence = baseValue.titre_3,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 3, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_4 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 4,
                            NombreOccurence = baseValue.titre_4,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 4, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_6 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 6,
                            NombreOccurence = baseValue.titre_6,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 6, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_7 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 7,
                            NombreOccurence = baseValue.titre_7,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 7, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_8 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 8,
                            NombreOccurence = baseValue.titre_8,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 8, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_9 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 9,
                            NombreOccurence = baseValue.titre_9,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 9, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_10 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 10,
                            NombreOccurence = baseValue.titre_10,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 10, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_11 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 11,
                            NombreOccurence = baseValue.titre_11,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 11, BinaryOperatorType.Equal)).SupportPresse
                        });



                    if (baseValue.titre_12 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 12,
                            NombreOccurence = baseValue.titre_12,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 12, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_13 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 13,
                            NombreOccurence = baseValue.titre_13,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 13, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_14 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 14,
                            NombreOccurence = baseValue.titre_14,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 14, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_15 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 15,
                            NombreOccurence = baseValue.titre_15,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 15, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_16 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 16,
                            NombreOccurence = baseValue.titre_16,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 16, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_18 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 18,
                            NombreOccurence = baseValue.titre_18,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 18, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_19 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 19,
                            NombreOccurence = baseValue.titre_19,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 19, BinaryOperatorType.Equal)).SupportPresse
                        });



                    if (baseValue.titre_20 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 20,
                            NombreOccurence = baseValue.titre_20,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 20, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_21 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 21,
                            NombreOccurence = baseValue.titre_21,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 21, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_22 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 22,
                            NombreOccurence = baseValue.titre_22,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 22, BinaryOperatorType.Equal)).SupportPresse
                        });



                    if (baseValue.titre_23 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 23,
                            NombreOccurence = baseValue.titre_23,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 23, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_24 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 24,
                            NombreOccurence = baseValue.titre_24,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 24, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_25 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 25,
                            NombreOccurence = baseValue.titre_25,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 25, BinaryOperatorType.Equal)).SupportPresse
                        });


                    if (baseValue.titre_26 != 0)
                        signalitique.AudienceJournals.Add(new AudienceJournal(XpoSession)
                        {
                            NumJournal = 26,
                            NombreOccurence = baseValue.titre_26,
                            Jour = baseValue.Jour,
                            SupportPresse = XpoSession.FindObject<CodePresse>(new BinaryOperator("Code14", 26, BinaryOperatorType.Equal)).SupportPresse
                        });

                }
                signalitique.Save();
            }


            signalitiques = new XPCollection<Signalitique>(XpoSession, new BinaryOperator("Vague", vague));



            int i = 0;

            foreach (var signalitique in signalitiques)
            {
                i++;

                Signalitique signalitique1 = signalitique;
                var baseValueList = CollectionBase.Where(p => p.idquest == signalitique1.Individu.IdQuest);
                foreach (var baseValue in baseValueList)
                {


                    if (baseValue.Q_1 != 0)

                        if (baseValue.Q_1 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_1,
                                NumeroQuertdheure = 1,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_1,
                                QuartHeure = 1,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_1, BinaryOperatorType.Equal)).SupportRadio
                            });



                    if (baseValue.Q_2 != 0)
                        if (baseValue.Q_2 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_2,
                                NumeroQuertdheure = 2,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_2, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_2,
                                QuartHeure = 2,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_2, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_3 != 0)
                        if (baseValue.Q_3 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_3,
                                NumeroQuertdheure = 3,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_3, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_3,
                                QuartHeure = 3,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_3, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_4 != 0)
                        if (baseValue.Q_4 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_4,
                                NumeroQuertdheure = 4,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_4, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_4,
                                QuartHeure = 4,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_4, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_5 != 0)
                        if (baseValue.Q_5 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_5,
                                NumeroQuertdheure = 5,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_5, BinaryOperatorType.Equal)).SupportMedia

                            });

                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_5,
                                QuartHeure = 5,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_5, BinaryOperatorType.Equal)).SupportRadio
                            });
                    if (baseValue.Q_6 != 0)
                        if (baseValue.Q_6 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_6,
                                NumeroQuertdheure = 6,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_6, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_6,
                                QuartHeure = 6,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_6, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_7 != 0)
                        if (baseValue.Q_7 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_7,
                                NumeroQuertdheure = 7,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_7, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_7,
                                QuartHeure = 7,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_7, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_8 != 0)
                        if (baseValue.Q_8 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_8,
                                NumeroQuertdheure = 8,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_8, BinaryOperatorType.Equal)).SupportMedia

                            });


                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_8,
                                QuartHeure = 8,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_8, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_9 != 0)
                        if (baseValue.Q_9 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_9,
                                NumeroQuertdheure = 9,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_9, BinaryOperatorType.Equal)).SupportMedia

                            });

                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_9,
                                QuartHeure = 9,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_9, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_10 != 0)
                        if (baseValue.Q_10 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_10,
                                NumeroQuertdheure = 10,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_10, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_10,
                                QuartHeure = 10,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_10, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_11 != 0)
                        if (baseValue.Q_11 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_11,
                                NumeroQuertdheure = 11,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_11, BinaryOperatorType.Equal)).SupportMedia

                            });

                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_11,
                                QuartHeure = 11,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_11, BinaryOperatorType.Equal)).SupportRadio
                            });




                    if (baseValue.Q_12 != 0)
                        if (baseValue.Q_12 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_12,
                                NumeroQuertdheure = 12,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_12, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_12,
                                QuartHeure = 12,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_12, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_13 != 0)
                        if (baseValue.Q_13 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_13,
                                NumeroQuertdheure = 13,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_13, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_13,
                                QuartHeure = 13,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_13, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_14 != 0)
                        if (baseValue.Q_14 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_14,
                                NumeroQuertdheure = 14,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_14, BinaryOperatorType.Equal)).SupportMedia

                            });


                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_14,
                                QuartHeure = 14,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_14, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_15 != 0)
                        if (baseValue.Q_15 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_15,
                                NumeroQuertdheure = 15,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_15, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_15,
                                QuartHeure = 15,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_15, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_16 != 0)
                        if (baseValue.Q_16 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_16,
                                NumeroQuertdheure = 16,
                                NumJour = baseValue.Jour
                                ,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_16, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_16,
                                QuartHeure = 16,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_16, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_17 != 0)
                        if (baseValue.Q_17 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_17,
                                NumeroQuertdheure = 17,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_17, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_17,
                                QuartHeure = 17,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_17, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_18 != 0)
                        if (baseValue.Q_18 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_18,
                                NumeroQuertdheure = 18,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_18, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_18,
                                QuartHeure = 18,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_18, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_19 != 0)
                        if (baseValue.Q_19 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_19,
                                NumeroQuertdheure = 19,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_19, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_19,
                                QuartHeure = 19,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_19, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_20 != 0)
                        if (baseValue.Q_20 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_20,
                                NumeroQuertdheure = 20,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_20, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_20,
                                QuartHeure = 20,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_20, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_21 != 0)
                        if (baseValue.Q_21 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_21,
                                NumeroQuertdheure = 21,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_21, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_21,
                                QuartHeure = 21,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_21, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_22 != 0)
                        if (baseValue.Q_22 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_22,
                                NumeroQuertdheure = 22,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_22, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_22,
                                QuartHeure = 22,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_22, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_23 != 0)
                        if (baseValue.Q_23 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_23,
                                NumeroQuertdheure = 23,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_23, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_23,
                                QuartHeure = 23,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_23, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_24 != 0)
                        if (baseValue.Q_24 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_24,
                                NumeroQuertdheure = 24,
                                NumJour = baseValue.Jour
                                ,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_24, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_24,
                                QuartHeure = 24,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_24, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_25 != 0)
                        if (baseValue.Q_25 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_25,
                                NumeroQuertdheure = 25,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_25, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_25,
                                QuartHeure = 25,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_25, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_26 != 0)
                        if (baseValue.Q_26 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_26,
                                NumeroQuertdheure = 26,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_26, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_26,
                                QuartHeure = 26,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_26, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_27 != 0)
                        if (baseValue.Q_27 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_27,
                                NumeroQuertdheure = 27,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_27, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_27,
                                QuartHeure = 27,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_27, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_28 != 0)
                        if (baseValue.Q_28 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_28,
                                NumeroQuertdheure = 28,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_28, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_28,
                                QuartHeure = 28,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_28, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_29 != 0)
                        if (baseValue.Q_29 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_29,
                                NumeroQuertdheure = 29,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_29, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_29,
                                QuartHeure = 29,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_29, BinaryOperatorType.Equal)).SupportRadio
                            });








                    if (baseValue.Q_30 != 0)
                        if (baseValue.Q_30 < 100)
                            signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                            {
                                NumeroChaine = baseValue.Q_30,
                                NumeroQuertdheure = 30,
                                NumJour = baseValue.Jour,
                                Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_30, BinaryOperatorType.Equal)).SupportMedia

                            });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_30,
                                QuartHeure = 30,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_30, BinaryOperatorType.Equal)).SupportRadio
                            });



                    if (baseValue.Q_31 != 0)
                        if (baseValue.Q_31 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_31,
                            NumeroQuertdheure = 31,
                            NumJour = baseValue.Jour
                            ,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_31, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_31,
                                QuartHeure = 31,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_31, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_32 != 0)
                        if (baseValue.Q_32 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_32,
                            NumeroQuertdheure = 32,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_32, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_32,
                                QuartHeure = 32,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_32, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_33 != 0)
                        if (baseValue.Q_33 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_33,
                            NumeroQuertdheure = 33,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_33, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_33,
                                QuartHeure = 33,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_33, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_34 != 0)
                        if (baseValue.Q_34 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_34,
                            NumeroQuertdheure = 34,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_34, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_34,
                                QuartHeure = 34,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_34, BinaryOperatorType.Equal)).SupportRadio
                            });








                    if (baseValue.Q_35 != 0)
                        if (baseValue.Q_35 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_35,
                            NumeroQuertdheure = 35,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_35, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_35,
                                QuartHeure = 35,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_35, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_36 != 0)
                        if (baseValue.Q_36 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_36,
                            NumeroQuertdheure = 36,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_36, BinaryOperatorType.Equal)).SupportMedia

                        });

                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_36,
                                QuartHeure = 36,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_36, BinaryOperatorType.Equal)).SupportRadio
                            });



                    if (baseValue.Q_37 != 0)
                        if (baseValue.Q_37 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_37,
                            NumeroQuertdheure = 37,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_37, BinaryOperatorType.Equal)).SupportMedia

                        });

                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_37,
                                QuartHeure = 37,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_37, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_38 != 0)
                        if (baseValue.Q_38 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_38,
                            NumeroQuertdheure = 38,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_38, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_38,
                                QuartHeure = 38,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_38, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_39 != 0)
                        if (baseValue.Q_39 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_39,
                            NumeroQuertdheure = 39,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_39, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_39,
                                QuartHeure = 39,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_39, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_40 != 0)
                        if (baseValue.Q_40 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_40,
                            NumeroQuertdheure = 40,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_40, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_40,
                                QuartHeure = 40,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_40, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_41 != 0)
                        if (baseValue.Q_41 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_41,
                            NumeroQuertdheure = 41,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_41, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_41,
                                QuartHeure = 41,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_41, BinaryOperatorType.Equal)).SupportRadio
                            });






                    if (baseValue.Q_42 != 0)
                        if (baseValue.Q_42 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_42,
                            NumeroQuertdheure = 42,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_42, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_42,
                                QuartHeure = 42,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_42, BinaryOperatorType.Equal)).SupportRadio
                            });





                    if (baseValue.Q_43 != 0)
                        if (baseValue.Q_43 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_43,
                            NumeroQuertdheure = 43,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_43, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_43,
                                QuartHeure = 43,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_43, BinaryOperatorType.Equal)).SupportRadio
                            });




                    if (baseValue.Q_44 != 0)
                        if (baseValue.Q_44 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_44,
                            NumeroQuertdheure = 44,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_44, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_44,
                                QuartHeure = 44,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_44, BinaryOperatorType.Equal)).SupportRadio
                            });





                    if (baseValue.Q_45 != 0)
                        if (baseValue.Q_45 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_45,
                            NumeroQuertdheure = 45,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_45, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_45,
                                QuartHeure = 45,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_45, BinaryOperatorType.Equal)).SupportRadio
                            });






                    if (baseValue.Q_46 != 0)
                        if (baseValue.Q_46 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_46,
                            NumeroQuertdheure = 46,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_46, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_46,
                                QuartHeure = 46,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_46, BinaryOperatorType.Equal)).SupportRadio
                            });





                    if (baseValue.Q_47 != 0)
                        if (baseValue.Q_47 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_47,
                            NumeroQuertdheure = 47,
                            NumJour = baseValue.Jour
                            ,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_47, BinaryOperatorType.Equal)).SupportMedia

                        });

                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_47,
                                QuartHeure = 47,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_47, BinaryOperatorType.Equal)).SupportRadio
                            });






                    if (baseValue.Q_48 != 0)
                        if (baseValue.Q_48 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_48,
                            NumeroQuertdheure = 48,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_48, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_48,
                                QuartHeure = 48,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_48, BinaryOperatorType.Equal)).SupportRadio
                            });




                    if (baseValue.Q_49 != 0)
                        if (baseValue.Q_49 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_49,
                            NumeroQuertdheure = 49,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_49, BinaryOperatorType.Equal)).SupportMedia

                        });

                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_49,
                                QuartHeure = 49,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_49, BinaryOperatorType.Equal)).SupportRadio
                            });




                    if (baseValue.Q_50 != 0)
                        if (baseValue.Q_50 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_50,
                            NumeroQuertdheure = 50,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_50, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_50,
                                QuartHeure = 50,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_50, BinaryOperatorType.Equal)).SupportRadio
                            });




                    if (baseValue.Q_51 != 0)
                        if (baseValue.Q_51 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_51,
                            NumeroQuertdheure = 51,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_51, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_51,
                                QuartHeure = 51,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_51, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_52 != 0)
                        if (baseValue.Q_52 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_52,
                            NumeroQuertdheure = 52,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_52, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_52,
                                QuartHeure = 52,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_52, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_53 != 0)
                        if (baseValue.Q_53 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_53,
                            NumeroQuertdheure = 53,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_53, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_53,
                                QuartHeure = 53,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_53, BinaryOperatorType.Equal)).SupportRadio
                            });




                    if (baseValue.Q_54 != 0)
                        if (baseValue.Q_54 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_54,
                            NumeroQuertdheure = 54,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_54, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_54,
                                QuartHeure = 54,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_54, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_55 != 0)
                        if (baseValue.Q_55 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_55,
                            NumeroQuertdheure = 55,
                            NumJour = baseValue.Jour
                            ,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_55, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_55,
                                QuartHeure = 55,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_55, BinaryOperatorType.Equal)).SupportRadio
                            });




                    if (baseValue.Q_56 != 0)
                        if (baseValue.Q_56 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_56,
                            NumeroQuertdheure = 56,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_56, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_56,
                                QuartHeure = 56,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_56, BinaryOperatorType.Equal)).SupportRadio
                            });




                    if (baseValue.Q_57 != 0)
                        if (baseValue.Q_57 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_57,
                            NumeroQuertdheure = 57,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_57, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_57,
                                QuartHeure = 57,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_57, BinaryOperatorType.Equal)).SupportRadio
                            });



                    if (baseValue.Q_58 != 0)
                        if (baseValue.Q_58 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_58,
                            NumeroQuertdheure = 58,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_58, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_58,
                                QuartHeure = 58,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_58, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_59 != 0)
                        if (baseValue.Q_59 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_59,
                            NumeroQuertdheure = 59,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_59, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_59,
                                QuartHeure = 59,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_59, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_60 != 0)
                        if (baseValue.Q_60 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_60,
                            NumeroQuertdheure = 60,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_60, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_60
,
                                QuartHeure = 60,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_60, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_61 != 0)
                        if (baseValue.Q_61 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_61,
                            NumeroQuertdheure = 61,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_61, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_61,
                                QuartHeure = 61,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_61, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_62 != 0)
                        if (baseValue.Q_62 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_62,
                            NumeroQuertdheure = 62,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_62, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_62,
                                QuartHeure = 62,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_62, BinaryOperatorType.Equal)).SupportRadio
                            });




                    if (baseValue.Q_63 != 0)
                        if (baseValue.Q_63 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_63,
                            NumeroQuertdheure = 63,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_63, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_63,
                                QuartHeure = 63,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_63, BinaryOperatorType.Equal)).SupportRadio
                            });






                    if (baseValue.Q_64 != 0)
                        if (baseValue.Q_64 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_64,
                            NumeroQuertdheure = 64,
                            NumJour = baseValue.Jour
                            ,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_64, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_64,
                                QuartHeure = 64,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_64, BinaryOperatorType.Equal)).SupportRadio
                            });





                    if (baseValue.Q_65 != 0)
                        if (baseValue.Q_65 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_65,
                            NumeroQuertdheure = 65,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_65, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_65,
                                QuartHeure = 65,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_65, BinaryOperatorType.Equal)).SupportRadio
                            });




                    if (baseValue.Q_66 != 0)
                        if (baseValue.Q_66 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_66,
                            NumeroQuertdheure = 66,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_66, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_66,
                                QuartHeure = 66,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_66, BinaryOperatorType.Equal)).SupportRadio
                            });






                    if (baseValue.Q_67 != 0)
                        if (baseValue.Q_67 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_67,
                            NumeroQuertdheure = 67,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_67, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_67,
                                QuartHeure = 67,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_67, BinaryOperatorType.Equal)).SupportRadio
                            });



                    if (baseValue.Q_68 != 0)
                        if (baseValue.Q_68 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_68,
                            NumeroQuertdheure = 68,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_68, BinaryOperatorType.Equal)).SupportMedia

                        });

                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_68,
                                QuartHeure = 68,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_68, BinaryOperatorType.Equal)).SupportRadio
                            });





                    if (baseValue.Q_69 != 0)
                        if (baseValue.Q_69 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_69,
                            NumeroQuertdheure = 69,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_69, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_69,
                                QuartHeure = 69,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_69, BinaryOperatorType.Equal)).SupportRadio
                            });







                    if (baseValue.Q_70 != 0)
                        if (baseValue.Q_70 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_70,
                            NumeroQuertdheure = 70,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_70, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_70,
                                QuartHeure = 70,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_70, BinaryOperatorType.Equal)).SupportRadio
                            });



                    if (baseValue.Q_71 != 0)
                        if (baseValue.Q_71 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_71,
                            NumeroQuertdheure = 71,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_71, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_71,
                                QuartHeure = 71,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_71, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_72 != 0)
                        if (baseValue.Q_72 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_72,
                            NumeroQuertdheure = 72,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_72, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_72,
                                QuartHeure = 72,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_72, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_73 != 0)
                        if (baseValue.Q_73 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_73,
                            NumeroQuertdheure = 73,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_73, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_73,
                                QuartHeure = 73,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_73, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_74 != 0)
                        if (baseValue.Q_74 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_74,
                            NumeroQuertdheure = 74,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_74, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_74,
                                QuartHeure = 74,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_74, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_75 != 0)
                        if (baseValue.Q_75 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_75,
                            NumeroQuertdheure = 75,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_75, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_75,
                                QuartHeure = 75,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_75, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_76 != 0)
                        if (baseValue.Q_76 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_76,
                            NumeroQuertdheure = 76,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_76, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_76,
                                QuartHeure = 76,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_76, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_77 != 0)
                        if (baseValue.Q_77 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_77,
                            NumeroQuertdheure = 77,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_77, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_77,
                                QuartHeure = 77,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_77, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_78 != 0)
                        if (baseValue.Q_78 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_78,
                            NumeroQuertdheure = 78,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_78, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_78,
                                QuartHeure = 78,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_78, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_79 != 0)
                        if (baseValue.Q_79 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_79,
                            NumeroQuertdheure = 79,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_79, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_79,
                                QuartHeure = 79,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_79, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_80 != 0)
                        if (baseValue.Q_80 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_80,
                            NumeroQuertdheure = 80,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_80, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_80,
                                QuartHeure = 80,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_80, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_81 != 0)
                        if (baseValue.Q_81 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_81,
                            NumeroQuertdheure = 81,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_81, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_81,
                                QuartHeure = 81,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_81, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_82 != 0)
                        if (baseValue.Q_82 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_82,
                            NumeroQuertdheure = 82,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_82, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_82,
                                QuartHeure = 82,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_82, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_83 != 0)
                        if (baseValue.Q_83 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_83,
                            NumeroQuertdheure = 83,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_83, BinaryOperatorType.Equal)).SupportMedia

                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_83,
                                QuartHeure = 83,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_83, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_84 != 0)
                        if (baseValue.Q_84 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_84,
                            NumeroQuertdheure = 84,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_84, BinaryOperatorType.Equal)).SupportMedia
                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_84,
                                QuartHeure = 84,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_84, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_85 != 0)
                        if (baseValue.Q_85 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_85,
                            NumeroQuertdheure = 85,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_85, BinaryOperatorType.Equal)).SupportMedia
                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_85,
                                QuartHeure = 85,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_85, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_86 != 0)
                        if (baseValue.Q_86 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_86,
                            NumeroQuertdheure = 86,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_86, BinaryOperatorType.Equal)).SupportMedia
                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_86,
                                QuartHeure = 86,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_86, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_87 != 0)
                        if (baseValue.Q_87 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_87,
                            NumeroQuertdheure = 87,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_87, BinaryOperatorType.Equal)).SupportMedia
                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_87,
                                QuartHeure = 87,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_87, BinaryOperatorType.Equal)).SupportRadio
                            });



                    if (baseValue.Q_88 != 0)
                        if (baseValue.Q_88 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_88,
                            NumeroQuertdheure = 88,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_88, BinaryOperatorType.Equal)).SupportMedia
                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_88,
                                QuartHeure = 88,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_88, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_89 != 0)
                        if (baseValue.Q_89 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_89,
                            NumeroQuertdheure = 89,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_89, BinaryOperatorType.Equal)).SupportMedia
                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_89,
                                QuartHeure = 89,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_89, BinaryOperatorType.Equal)).SupportRadio
                            });



                    if (baseValue.Q_90 != 0)
                        if (baseValue.Q_90 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_90,
                            NumeroQuertdheure = 90,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_90, BinaryOperatorType.Equal)).SupportMedia
                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_90,
                                QuartHeure = 90,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_90, BinaryOperatorType.Equal)).SupportRadio
                            });



                    if (baseValue.Q_91 != 0)
                        if (baseValue.Q_91 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_91,
                            NumeroQuertdheure = 91,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_91, BinaryOperatorType.Equal)).SupportMedia
                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_91,
                                QuartHeure = 91,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_91, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_92 != 0)
                        if (baseValue.Q_92 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_92,
                            NumeroQuertdheure = 92,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_92, BinaryOperatorType.Equal)).SupportMedia
                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_92,
                                QuartHeure = 92,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_92, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_93 != 0)
                        if (baseValue.Q_93 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_93,
                            NumeroQuertdheure = 93,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_93, BinaryOperatorType.Equal)).SupportMedia
                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_93,
                                QuartHeure = 93,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_93, BinaryOperatorType.Equal)).SupportRadio
                            });


                    if (baseValue.Q_94 != 0)
                        if (baseValue.Q_94 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_94,
                            NumeroQuertdheure = 94,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_94, BinaryOperatorType.Equal)).SupportMedia
                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_94,
                                QuartHeure = 94,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_94, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_95 != 0)
                        if (baseValue.Q_95 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_95,
                            NumeroQuertdheure = 95,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_95, BinaryOperatorType.Equal)).SupportMedia
                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_95,
                                QuartHeure = 95,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_95, BinaryOperatorType.Equal)).SupportRadio
                            });

                    if (baseValue.Q_96 != 0)
                        if (baseValue.Q_96 < 100) signalitique.AudienceTVs.Add(new AudienceTV(XpoSession)
                        {
                            NumeroChaine = baseValue.Q_96,
                            NumeroQuertdheure = 96,
                            NumJour = baseValue.Jour,
                            Support = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_96, BinaryOperatorType.Equal)).SupportMedia
                        });
                        else
                            signalitique.AudienceRadios.Add(new AudienceRadio(XpoSession)
                            {
                                NumeroRadio = baseValue.Q_96,
                                QuartHeure = 96,
                                Jour = baseValue.Jour,
                                SupportRadio = XpoSession.FindObject<Code>(new BinaryOperator("code1", baseValue.Q_96, BinaryOperatorType.Equal)).SupportRadio
                            });

                    signalitique.Save();

                }
            }




            #region support




            /*
              

                var AudiencesR = new XPCollection<AudienceRadio>(XpoSession, BinaryOperator.Parse("SupportRadio is null"));

                foreach (var audienceRad in AudiencesR)
                {
                    if (audienceRad.SupportRadio != null) continue;
                    //audienceRad.SupportRadio =
                      var temp= XpoSession.FindObject<Code>(new BinaryOperator("code1", audienceRad.NumeroRadio,BinaryOperatorType.Equal)).SupportRadio;
                      // var temp = XPCollection<codechanine>(XpoSession,new BinaryOperator("code1", audienceRad.NumeroRadio,BinaryOperatorType.Equal)).First();
                      audienceRad.SupportRadio = temp;
                       
                       
                       audienceRad.Save();

                }

            

          

                var Audiences = new XPCollection<AudienceTV>(XpoSession, BinaryOperator.Parse("Support is null"));

                            foreach (var audienceTv in Audiences)
                            {
                                if (audienceTv.Support != null) continue;
                                
                                var temp= XpoSession.FindObject<Code>(new BinaryOperator("code1", audienceTv.NumeroChaine,BinaryOperatorType.Equal)).SupportMedia;
                                
                                
                                audienceTv.Support =temp;
                                    //XpoSession.FindObject<SupportMedia>(new BinaryOperator("Code", audienceTv.NumeroChaine,
                                                                                           //BinaryOperatorType.Equal));
                                audienceTv.Save();

                            }
     
                    

               


        

         **/
            #endregion
            /*
                if (IsPostBack || IsCallback) return;
                if (Session["Campagne"] == null) return;
                Guid.TryParse(Session["Campagne"].ToString(), out Oid);
                campagneActuelle = XpoSession.GetObjectByKey<Campagne>(Oid);
             */

        }
        protected void ButtonAccepter_Click(object sender, EventArgs e)
        {
        }
        #region filtre
        private XPCollection<Signalitique> ConstructionDuFiltre(ConstructionPlanMedia constructionPlanMedia)
        {
            String c = null;



            if (constructionPlanMedia.CheckBoxListCSE.SelectedItems.Count <
                constructionPlanMedia.CheckBoxListCSE.Items.Count &&
                constructionPlanMedia.CheckBoxListCSE.SelectedItems.Count > 0)
            {
                var c1 = constructionPlanMedia.CheckBoxListCSE.Items[0].Selected ? 1 : 0;
                var c2 = constructionPlanMedia.CheckBoxListCSE.Items[1].Selected ? 2 : 0;
                var c3 = constructionPlanMedia.CheckBoxListCSE.Items[2].Selected ? 3 : 0;
                var c4 = constructionPlanMedia.CheckBoxListCSE.Items[3].Selected ? 4 : 0;


                c = String.Format("([CSE]={0} or [CSE]={1} or [CSE]={2} or  [CSE]={3}) ", c1, c2, c3, c4);

            }

            if (constructionPlanMedia.CheckBoxListCSP.SelectedItems.Count <
                constructionPlanMedia.CheckBoxListCSP.Items.Count &&
                constructionPlanMedia.CheckBoxListCSP.SelectedItems.Count > 0)
            {
                var c1 = constructionPlanMedia.CheckBoxListCSP.Items[0].Selected ? 1 : 0;
                var c2 = constructionPlanMedia.CheckBoxListCSP.Items[1].Selected ? 2 : 0;
                var c3 = constructionPlanMedia.CheckBoxListCSP.Items[2].Selected ? 3 : 0;
                var c4 = constructionPlanMedia.CheckBoxListCSP.Items[3].Selected ? 4 : 0;
                var c5 = constructionPlanMedia.CheckBoxListCSP.Items[4].Selected ? 5 : 0;
                var c6 = constructionPlanMedia.CheckBoxListCSP.Items[5].Selected ? 6 : 0;
                var c7 = constructionPlanMedia.CheckBoxListCSP.Items[6].Selected ? 7 : 0;
                var c8 = constructionPlanMedia.CheckBoxListCSP.Items[7].Selected ? 8 : 0;
                var c9 = constructionPlanMedia.CheckBoxListCSP.Items[8].Selected ? 9 : 0;
                var c10 = constructionPlanMedia.CheckBoxListCSP.Items[9].Selected ? 10 : 0;
                var c11 = constructionPlanMedia.CheckBoxListCSP.Items[10].Selected ? 11 : 0;
                var c12 = constructionPlanMedia.CheckBoxListCSP.Items[11].Selected ? 12 : 0;
                if (c != null)
                {
                    c += " and ";
                    c +=
                        string.Format(
                            "([CSP]={0} or [CSP]={1} or [CSP]={2} or  [CSP]={3} or [CSP]={4} or [CSP]={5} or  [CSP]={6} or [CSP]={7} or [CSP]={8} or  [CSP]={9} or [CSP]={9} or  [CSP]={10} or  [CSP]={11})",
                            c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12);

                }
                else
                    c =
                        string.Format(
                            "([CSP]={0} or [CSP]={1} or [CSP]={2} or  [CSP]={3} or [CSP]={4} or [CSP]={5} or  [CSP]={6} or [CSP]={7} or [CSP]={8} or  [CSP]={9} or [CSP]={9} or  [CSP]={10} or  [CSP]={11})",
                            c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12);

            }



            if (constructionPlanMedia.CheckBoxListEquipement.SelectedItems.Count <
                constructionPlanMedia.CheckBoxListEquipement.Items.Count &&
                constructionPlanMedia.CheckBoxListEquipement.SelectedItems.Count > 0)
            {
                if (c != null)
                {
                    c += " and ";
                    c +=
                        String.Format(
                            "([Refrigirateur]={0} and [Television_en_couleur]={1} and [decodeur]={2} and  [Lecteur_radio_cassette]={3} and [Mobile]={4} and [Cuisiniere]={5} and  [Telephone_Fixe]={6} and [Four_micro_onde]={7} and [Chaine_stereo]={8} and  [LaveLinge]={9} and [Lecteur_DVD]={10} and  [Aspirateur]={11} and  [Pc_sans_connexion]={12} and  [Congelateur]={13} and  [appareil_Photo_Numerique]={14} and  [Magnétoscope]={15} and  [LecteurCD]={16} and  [Climatiseur]={17} and [Camescope]={18} and  [Console]={19} and  [LaveVaissele]={20} and  [SecheLinge]={21} and  [PC_Connexion]={22})",
                            CheckBoxListEquipement.Items[0].Selected, CheckBoxListEquipement.Items[1].Selected,
                            CheckBoxListEquipement.Items[2].Selected, CheckBoxListEquipement.Items[3].Selected,
                            CheckBoxListEquipement.Items[4].Selected, CheckBoxListEquipement.Items[5].Selected,
                            CheckBoxListEquipement.Items[6].Selected, CheckBoxListEquipement.Items[7].Selected,
                            CheckBoxListEquipement.Items[8].Selected, CheckBoxListEquipement.Items[9].Selected,
                            CheckBoxListEquipement.Items[10].Selected, CheckBoxListEquipement.Items[11].Selected,
                            CheckBoxListEquipement.Items[12].Selected, CheckBoxListEquipement.Items[13].Selected,
                            CheckBoxListEquipement.Items[14].Selected, CheckBoxListEquipement.Items[15].Selected,
                            CheckBoxListEquipement.Items[16].Selected, CheckBoxListEquipement.Items[17].Selected,
                            CheckBoxListEquipement.Items[18].Selected, CheckBoxListEquipement.Items[19].Selected,
                            CheckBoxListEquipement.Items[20].Selected, CheckBoxListEquipement.Items[21].Selected,
                            CheckBoxListEquipement.Items[22].Selected);

                }
                else
                    c =
                        String.Format(
                            "([Refrigirateur]={0} and [Television_en_couleur]={1} and [decodeur]={2} and  [Lecteur_radio_cassette]={3} and [Mobile]={4} and [Cuisiniere]={5} and  [Telephone_Fixe]={6} and [Four_micro_onde]={7} and [Chaine_stereo]={8} and  [LaveLinge]={9} and [Lecteur_DVD]={10} and  [Aspirateur]={11} and  [Pc_sans_connexion]={12} and  [Congelateur]={13} and  [appareil_Photo_Numerique]={14} and  [Magnétoscope]={15} and  [LecteurCD]={16} and  [Climatiseur]={17} and [Camescope]={18} and  [Console]={19} and  [LaveVaissele]={20} and  [SecheLinge]={21} and  [PC_Connexion]={22})",
                            CheckBoxListEquipement.Items[0].Selected, CheckBoxListEquipement.Items[1].Selected,
                            CheckBoxListEquipement.Items[2].Selected, CheckBoxListEquipement.Items[3].Selected,
                            CheckBoxListEquipement.Items[4].Selected, CheckBoxListEquipement.Items[5].Selected,
                            CheckBoxListEquipement.Items[6].Selected, CheckBoxListEquipement.Items[7].Selected,
                            CheckBoxListEquipement.Items[8].Selected, CheckBoxListEquipement.Items[9].Selected,
                            CheckBoxListEquipement.Items[10].Selected, CheckBoxListEquipement.Items[11].Selected,
                            CheckBoxListEquipement.Items[12].Selected, CheckBoxListEquipement.Items[13].Selected,
                            CheckBoxListEquipement.Items[14].Selected, CheckBoxListEquipement.Items[15].Selected,
                            CheckBoxListEquipement.Items[16].Selected, CheckBoxListEquipement.Items[17].Selected,
                            CheckBoxListEquipement.Items[18].Selected, CheckBoxListEquipement.Items[19].Selected,
                            CheckBoxListEquipement.Items[20].Selected, CheckBoxListEquipement.Items[21].Selected,
                            CheckBoxListEquipement.Items[22].Selected);

            }


            if (constructionPlanMedia.CheckBoxListEtes.SelectedItems.Count <
                constructionPlanMedia.CheckBoxListEtes.Items.Count &&
                constructionPlanMedia.CheckBoxListEtes.SelectedItems.Count > 0)
            {
                var c1 = constructionPlanMedia.CheckBoxListEtes.Items[0].Selected ? 1 : 0;
                var c2 = constructionPlanMedia.CheckBoxListEtes.Items[1].Selected ? 2 : 0;

                if (c != null)
                {
                    c += " and ";
                    c += String.Format("([Habitat]={0} or [Habitat]={1}) ", c1, c2);
                }
                else
                    c = String.Format("([Habitat]={0} or [Habitat]={1}) ", c1, c2);

            }


            if (constructionPlanMedia.CheckBoxListFamiliale.SelectedItems.Count <
                constructionPlanMedia.CheckBoxListFamiliale.Items.Count &&
                constructionPlanMedia.CheckBoxListFamiliale.SelectedItems.Count > 0)
            {
                var c1 = constructionPlanMedia.CheckBoxListFamiliale.Items[0].Selected ? 1 : 0;
                var c2 = constructionPlanMedia.CheckBoxListFamiliale.Items[1].Selected ? 2 : 0;
                var c3 = constructionPlanMedia.CheckBoxListFamiliale.Items[2].Selected ? 3 : 0;
                var c4 = constructionPlanMedia.CheckBoxListFamiliale.Items[3].Selected ? 4 : 0;

                if (c != null)
                {
                    c += " and ";
                    c +=
                        String.Format(
                            "([Statut_familial]={0} or [Statut_familial]={1} or [Statut_familial]={2} or [Statut_familial]={3})",
                            c1, c2, c3, c4);

                }
                else
                    c =
                        String.Format(
                            "([Statut_familial]={0} or [Statut_familial]={1} or [Statut_familial]={2} or [Statut_familial]={3})",
                            c1, c2, c3, c4);

            }



            if (!String.IsNullOrEmpty(TextBoxMin.Text))
            {

                if (c != null)
                {
                    c += " and ";
                    c +=
                        String.Format(
                            "([Age]>={0} and [Age]<={1} )", TextBoxMin.Text, TextBoxMax.Text);

                }
                else
                    c +=
                         String.Format(
                             "([Age]>={0} and [Age]<={1} )", TextBoxMin.Text, TextBoxMax.Text);


            }



            if (constructionPlanMedia.CheckBoxListInstruction.SelectedItems.Count <
                constructionPlanMedia.CheckBoxListInstruction.Items.Count &&
                constructionPlanMedia.CheckBoxListInstruction.SelectedItems.Count > 0)
            {
                var c1 = constructionPlanMedia.CheckBoxListInstruction.Items[0].Selected ? 1 : 0;
                var c2 = constructionPlanMedia.CheckBoxListInstruction.Items[1].Selected ? 2 : 0;
                var c3 = constructionPlanMedia.CheckBoxListInstruction.Items[2].Selected ? 3 : 0;
                var c4 = constructionPlanMedia.CheckBoxListInstruction.Items[3].Selected ? 4 : 0;
                var c5 = constructionPlanMedia.CheckBoxListInstruction.Items[4].Selected ? 5 : 0;
                var c6 = constructionPlanMedia.CheckBoxListInstruction.Items[5].Selected ? 6 : 0;

                if (c != null)
                {
                    c += " and ";
                    c +=
                        String.Format(
                            "([Niveau]={0} or [Niveau]={1} or [Niveau]={2} or [Niveau]={3} or [Niveau]={4} or [Niveau])={5}",
                            c1, c2, c3, c4, c5, c6);

                }
                else
                    c =
                        String.Format(
                            "([Niveau]={0} or [Niveau]={1} or [Niveau]={2} or [Niveau]={3} or [Niveau]={4} or [Niveau])={5}",
                            c1, c2, c3, c4, c5, c6);

            }

            if (constructionPlanMedia.CheckBoxListMatrimoniale.SelectedItems.Count <
                constructionPlanMedia.CheckBoxListMatrimoniale.Items.Count &&
                constructionPlanMedia.CheckBoxListMatrimoniale.SelectedItems.Count > 0)
            {
                var c1 = constructionPlanMedia.CheckBoxListInstruction.Items[0].Selected ? 1 : 0;
                var c2 = constructionPlanMedia.CheckBoxListInstruction.Items[1].Selected ? 2 : 0;
                var c3 = constructionPlanMedia.CheckBoxListInstruction.Items[2].Selected ? 3 : 0;
                var c4 = constructionPlanMedia.CheckBoxListInstruction.Items[3].Selected ? 4 : 0;
                var c5 = constructionPlanMedia.CheckBoxListInstruction.Items[4].Selected ? 5 : 0;
                var c6 = constructionPlanMedia.CheckBoxListInstruction.Items[5].Selected ? 6 : 0;

                if (c != null)
                {
                    c += " and ";
                    c +=
                        String.Format(
                            "([situation_matrimoniale]={0} or [situation_matrimoniale]={1} or [situation_matrimoniale]={2} or [situation_matrimoniale]={3} or [situation_matrimoniale]={4} or [situation_matrimoniale]={5})",
                            c1, c2, c3, c4, c5, c6);

                }
                else
                    c =
                        String.Format(
                            "([situation_matrimoniale]={0} or [situation_matrimoniale]={1} or [situation_matrimoniale]={2} or [situation_matrimoniale]={3} or [situation_matrimoniale]={4} or [situation_matrimoniale]={5})",
                            c1, c2, c3, c4, c5, c6);

            }

            if (constructionPlanMedia.CheckBoxListNbChambre.SelectedItems.Count <
                constructionPlanMedia.CheckBoxListNbChambre.Items.Count &&
                constructionPlanMedia.CheckBoxListNbChambre.SelectedItems.Count > 0)
            {
                var c1 = constructionPlanMedia.CheckBoxListNbChambre.Items[0].Selected ? 1 : 0;
                var c2 = constructionPlanMedia.CheckBoxListNbChambre.Items[1].Selected ? 2 : 0;
                var c3 = constructionPlanMedia.CheckBoxListNbChambre.Items[2].Selected ? 3 : 0;
                var c4 = constructionPlanMedia.CheckBoxListNbChambre.Items[3].Selected ? 4 : 0;
                var c5 = constructionPlanMedia.CheckBoxListNbChambre.Items[4].Selected ? 5 : 0;

                if (c != null)
                {
                    c += " and ";

                    c +=
                        String.Format(
                            "([TailleFoyer]={0} or [TailleFoyer]={1} or [TailleFoyer]={2} or [TailleFoyer]={3} or [TailleFoyer]={4})",
                            c1, c2, c3, c4, c5);
                }
                else
                {
                    c =
                        String.Format(
                            "([TailleFoyer]={0} or [TailleFoyer]={1} or [TailleFoyer]={2} or [TailleFoyer]={3} or [TailleFoyer]={4})",
                            c1, c2, c3, c4, c5);
                }
            }



            if (constructionPlanMedia.CheckBoxListNbVoiture.SelectedItems.Count <
                constructionPlanMedia.CheckBoxListNbVoiture.Items.Count &&
                constructionPlanMedia.CheckBoxListNbVoiture.SelectedItems.Count > 0)
            {
                var c1 = constructionPlanMedia.CheckBoxListNbVoiture.Items[0].Selected ? 1 : 0;
                var c2 = constructionPlanMedia.CheckBoxListNbVoiture.Items[1].Selected ? 2 : 0;
                var c3 = constructionPlanMedia.CheckBoxListNbVoiture.Items[2].Selected ? 3 : 0;
                var c4 = constructionPlanMedia.CheckBoxListNbVoiture.Items[3].Selected ? 4 : 0;

                if (c != null)
                {
                    c += " and ";
                    c += String.Format("([NbVoiture]={0} or [NbVoiture]={1} or [NbVoiture]={2} or [NbVoiture]={3})", c1,
                                       c2, c3, c4);


                }
                else
                    c = String.Format("([NbVoiture]={0} or [NbVoiture]={1} or [NbVoiture]={2} or [NbVoiture]={3})", c1,
                                      c2, c3, c4);

            }



            if (constructionPlanMedia.CheckBoxListRevenueFoyer.SelectedItems.Count <
                constructionPlanMedia.CheckBoxListRevenueFoyer.Items.Count &&
                constructionPlanMedia.CheckBoxListRevenueFoyer.SelectedItems.Count > 0)
            {
                var c1 = constructionPlanMedia.CheckBoxListRevenueFoyer.Items[0].Selected ? 1 : 0;
                var c2 = constructionPlanMedia.CheckBoxListRevenueFoyer.Items[1].Selected ? 2 : 0;
                var c3 = constructionPlanMedia.CheckBoxListRevenueFoyer.Items[2].Selected ? 3 : 0;
                var c4 = constructionPlanMedia.CheckBoxListRevenueFoyer.Items[3].Selected ? 4 : 0;
                var c5 = constructionPlanMedia.CheckBoxListRevenueFoyer.Items[4].Selected ? 5 : 0;
                var c6 = constructionPlanMedia.CheckBoxListRevenueFoyer.Items[5].Selected ? 6 : 0;
                var c7 = constructionPlanMedia.CheckBoxListRevenueFoyer.Items[6].Selected ? 7 : 0;
                var c8 = constructionPlanMedia.CheckBoxListRevenueFoyer.Items[7].Selected ? 8 : 0;

                if (c != null)
                {
                    c += " and ";
                    c +=

                        String.Format(
                            "([RevenueTotalFoyer]={0} or [RevenueTotalFoyer]={1} or [RevenueTotalFoyer]={2} or [RevenueTotalFoyer]={3} or [RevenueTotalFoyer]={4} or [RevenueTotalFoyer]={5} or [RevenueTotalFoyer]={6} or [RevenueTotalFoyer]={7})",
                            c1, c2, c3, c4, c5, c6, c7, c8);
                }
                else
                {

                    c =
                        String.Format(
                            "([RevenueTotalFoyer]={0} or [RevenueTotalFoyer]={1} or [RevenueTotalFoyer]={2} or [RevenueTotalFoyer]={3} or [RevenueTotalFoyer]={4} or [RevenueTotalFoyer]={5} or [RevenueTotalFoyer]={6} or [RevenueTotalFoyer]={7})",
                            c1, c2, c3, c4, c5, c6, c7, c8);
                }
            }



            if (constructionPlanMedia.CheckBoxListTypeHabitat.SelectedItems.Count <
                constructionPlanMedia.CheckBoxListTypeHabitat.Items.Count &&
                constructionPlanMedia.CheckBoxListTypeHabitat.SelectedItems.Count > 0)
            {
                var c1 = constructionPlanMedia.CheckBoxListTypeHabitat.Items[0].Selected ? 1 : 0;
                var c2 = constructionPlanMedia.CheckBoxListTypeHabitat.Items[1].Selected ? 2 : 0;
                var c3 = constructionPlanMedia.CheckBoxListTypeHabitat.Items[2].Selected ? 3 : 0;
                var c4 = constructionPlanMedia.CheckBoxListTypeHabitat.Items[3].Selected ? 4 : 0;
                var c5 = constructionPlanMedia.CheckBoxListTypeHabitat.Items[4].Selected ? 5 : 0;
                var c6 = constructionPlanMedia.CheckBoxListTypeHabitat.Items[5].Selected ? 6 : 0;

                if (c != null)
                {
                    c += " and ";
                    c +=
                        String.Format(
                            "([TypeHabitat]={0} or [TypeHabitat]={1} or [TypeHabitat]={2} or [TypeHabitat]={3} or [TypeHabitat]={4} or [TypeHabitat]={5} )",
                            c1, c2, c3, c4, c5, c6);
                }
                else
                    c =
                        String.Format(
                            "([TypeHabitat]={0} or [TypeHabitat]={1} or [TypeHabitat]={2} or [TypeHabitat]={3} or [TypeHabitat]={4} or [TypeHabitat]={5} )",
                            c1, c2, c3, c4, c5, c6);
            }



            if (constructionPlanMedia.CheckBoxListGenre.SelectedItems.Count <
                constructionPlanMedia.CheckBoxListGenre.Items.Count &&
                constructionPlanMedia.CheckBoxListGenre.SelectedItems.Count > 0)
            {
                var c1 = CheckBoxListGenre.Items[0].Selected ? 1 : 0;
                var c2 = CheckBoxListGenre.Items[1].Selected ? 2 : 0;
                if (c != null)
                {




                    c = c + " and ";
                    c += String.Format("([Individu].Sexe={0} or [Individu].Sexe={1}) ",
                                       c1, c2);
                }
                else
                    c = String.Format("([Individu].Sexe={0} or [Individu].Sexe={1}) ",
                                      c1, c2);

            }

            signalitiques.Filter = CriteriaOperator.Parse(c);
            return null;
        }
        #endregion

        protected void ButtonAnnuler_Click(object sender, EventArgs e)
        {
            PopupControlCible.Visible = false;
        }

        protected void CheckBoxListCSE_Init(object sender, EventArgs e)
        {
            var list = (ASPxCheckBoxList)sender;
            list.Items.Add("A : Classe aisée");
            list.Items.Add("B : Classe Moyenne superieur");
            list.Items.Add("C : Classe Moyenne inferieur");
            list.Items.Add("D : Classe démunie");
        }





        protected void CheckBoxListEquipement_Init(object sender, EventArgs e)
        {
            var list = (ASPxCheckBoxList)sender;
            list.Items.Add("Réfrigirateur");
            list.Items.Add("Television en couleur");
            list.Items.Add("Lecteur radio cassette");
            list.Items.Add("Démodumateur");
            list.Items.Add("Télephone mobile");
            list.Items.Add("Cuisiniere");
            list.Items.Add("Telephone_Fixe");
            list.Items.Add("Four micro onde");
            list.Items.Add("Chaine stereo");
            list.Items.Add("Lavelinge");




            list.Items.Add("Lecteur DVD");
            list.Items.Add("Aspirateur");
            list.Items.Add("PC sans connexion");
            list.Items.Add("Congélateur");
            list.Items.Add("Appareil photo numérique");
            list.Items.Add("Magnétoscope");
            list.Items.Add("Lecteur CD");



            list.Items.Add("Climatiseur");
            list.Items.Add("Caméra video / Camescope");
            list.Items.Add("Console jeux video");
            list.Items.Add("Lave vaisselle");
            list.Items.Add("Séche linge");
            list.Items.Add("PC avec connexion internet");

        }











        /*
         
         
          <dx:ListEditItem Text="ListEditItem" />
        <dx:ListEditItem Text="Réfrigirateur" />
        <dx:ListEditItem Text="Television en couleur" />
        <dx:ListEditItem Text="Lecteur radio cassette" />
        <dx:ListEditItem Text="Démodumateur" />
        <dx:ListEditItem Text="Télephone mobile" />
        <dx:ListEditItem Text="Four micro onde" />
        <dx:ListEditItem Text="Chaine stereo" />
        <dx:ListEditItem Text="Lavelinge" />
        <dx:ListEditItem Text="Lecteur DVD" />
        <dx:ListEditItem Text="Aspirateur" />
        <dx:ListEditItem Text="PC sans connexion" />
        <dx:ListEditItem Text="Congélateur" />
        <dx:ListEditItem Text="Appareil photo numérique" />
        <dx:ListEditItem Text="Magnétoscope" />
        <dx:ListEditItem Text="Lecteur CD" />
        <dx:ListEditItem Text="Climatiseur" />
        <dx:ListEditItem Text="Caméra video / Camescope" />
        <dx:ListEditItem Text="Console jeux video" />
        <dx:ListEditItem Text="Lave vaisselle" />
        <dx:ListEditItem Text="Séche linge" />
        <dx:ListEditItem Text="PC avec connexion internet" />
         
         
         
         */





        protected void CheckBoxListTypeHabitat_Init(object sender, EventArgs e)
        {
            var list = (ASPxCheckBoxList)sender;
            list.Items.Add("Maison en toile");
            list.Items.Add("Maison Traditionnel");
            list.Items.Add("Appartement dans l'immeuble");
            list.Items.Add("Appartement dans l'immeuble de standing");
            list.Items.Add("Villa jumelé avec un petit terrain");
            list.Items.Add("Villa indépendante avec jardin");

        }





        /*
         
         
         
         
          <dx:ListEditItem Text="Maison en toile" />
            <dx:ListEditItem Text="Maison Traditionnel" />
            <dx:ListEditItem Text="Appartement dans l'immeuble" />
            <dx:ListEditItem Text="Appartement dans l'immeuble de standing" />
            <dx:ListEditItem Text="Villa jumelé avec un petit terrain" />
            <dx:ListEditItem Text="Villa indépendante avec jardin" />
                                              

         
         
         */

        protected void CheckBoxListInstruction_Init(object sender, EventArgs e)
        {
            var list = (ASPxCheckBoxList)sender;
            list.Items.Add("Sans Instruction analphabet");
            list.Items.Add("Sans instruction mais sait lire et écrire");
            list.Items.Add("Niveaux primaire");
            list.Items.Add("Niveaux moyen");
            list.Items.Add("Niveaux secondaire");
            list.Items.Add("Universitaire");

        }

        /* <dx:ListEditItem Text="Sans Instruction analphabet" />
            <dx:ListEditItem Text="Sans instruction mais sait lire et écrire" />
            <dx:ListEditItem Text="Niveaux primaire" />
            <dx:ListEditItem Text="Niveaux moyen" />
            <dx:ListEditItem Text="Niveaux secondaire" />
            <dx:ListEditItem Text="Universitaire" />
                                               */

        protected void CheckBoxListCSP_Init(object sender, EventArgs e)
        {
            var list = (ASPxCheckBoxList)sender;
            list.Items.Add("Haut fonctionnaire cadre supéireur de 'état");
            list.Items.Add("Profession libéral");
            list.Items.Add("Cadre");
            list.Items.Add("Cadre moyen / Cadre de maitrise");
            list.Items.Add("Employé");
            list.Items.Add("Petit patron,Commerçant, autre indépendant");



            list.Items.Add("Chômeur");
            list.Items.Add("Femme au foyer");
            list.Items.Add("Etudiant / Ecolier");
            list.Items.Add("Retraité");
            list.Items.Add("Retraité");
            list.Items.Add("Pensionné");
            list.Items.Add("Autre inactif");
        }


        /*
           <dx:ListEditItem Text="Haut fonctionnaire cadre supéireur de 'état" />
            <dx:ListEditItem Text="Profession libéral" />
            <dx:ListEditItem Text="Cadre" />
            <dx:ListEditItem Text="Cadre moyen / Cadre de maitrise" />
            <dx:ListEditItem Text="Employé" />
            <dx:ListEditItem Text="Petit patron,Commerçant, autre indépendant" />
            <dx:ListEditItem Text="Chômeur" />
            <dx:ListEditItem Text="Femme au foyer" />
            <dx:ListEditItem Text="Etudiant / Ecolier" />
            <dx:ListEditItem Text="Retraité" />
            <dx:ListEditItem Text="Pensionné" />
            <dx:ListEditItem Text="Autre inactif" />
                                                
         */


        protected void CheckBoxListRevenueFoyer_Init(object sender, EventArgs e)
        {
            var list = (ASPxCheckBoxList)sender;
            list.Items.Add("Moins de 12 000");
            list.Items.Add("Entre 12 000 et 19 999");
            list.Items.Add("Entre 20 000 et 34 999");
            list.Items.Add("Entre 35 000 et 49 999");
            list.Items.Add("Entre 50 000 et 89 000");
            list.Items.Add("Entre 90 000 et 120 000");
            list.Items.Add("Entre 120 000 et 150 000");
            list.Items.Add("plus de 150 000");
        }




        /*
         
              
            <dx:ListEditItem Text="Moins de 12 000" />
            <dx:ListEditItem Text="Entre 12 000 et 19 999" />
            <dx:ListEditItem Text="Entre 20 000 et 34 999" />
            <dx:ListEditItem Text="Entre 35 000 et 49 999" />
            <dx:ListEditItem Text="Entre 50 000 et 89 000" />
            <dx:ListEditItem Text="Entre 90 000 et 120 000" />
            <dx:ListEditItem Text="Entre 120 000 et 150 000" />
            <dx:ListEditItem Text="plus de 150 000" />
                                
         
         
         */

        protected void CheckBoxListNbVoiture_Init(object sender, EventArgs e)
        {
            var list = (ASPxCheckBoxList)sender;
            list.Items.Add("Aucune");
            list.Items.Add("une voiture");
            list.Items.Add("deux voitures");
            list.Items.Add("trois voitures ou plus");
        }




        protected void CheckBoxListNbChambre_Init(object sender, EventArgs e)
        {
            var list = (ASPxCheckBoxList)sender;
            list.Items.Add("1 Chambre");
            list.Items.Add("2 Chambre");
            list.Items.Add("3 Chambre");
            list.Items.Add("4 Chambre");

            list.Items.Add("5 Chambre ou plus");
        }


        /*
         
           <dx:ListEditItem Text="1 Chambre" />
        <dx:ListEditItem Text="2 Chambre" />
        <dx:ListEditItem Text="3 Chambre" />
        <dx:ListEditItem Text="4 Chambre" />
        <dx:ListEditItem Text="5 Chambre ou plus" />
                                                
         
         
         
         
         */


        protected void CheckBoxListMatrimoniale_Init(object sender, EventArgs e)
        {
            var list = (ASPxCheckBoxList)sender;
            list.Items.Add("Celibataire");
            list.Items.Add("Marié sans enfant");
            list.Items.Add("Marié avec enfant mineur");
            list.Items.Add("Marié avec enfant majeur");
            list.Items.Add("Marié avec enfant mineur et majeur");
            list.Items.Add("Divorcé");
        }

        /*
         
             <dx:ListEditItem Text="Celibataire" />
            <dx:ListEditItem Text="Marié sans enfant" />
            <dx:ListEditItem Text="Marié avec enfant mineur" />
            <dx:ListEditItem Text="Marié avec enfant majeur" />
            <dx:ListEditItem Text="Marié avec enfant mineur et majeur" />
            <dx:ListEditItem Text="Divorcé" />
                                                
         */

        protected void CheckBoxListGenre_Init(object sender, EventArgs e)
        {
            var list = (ASPxCheckBoxList)sender;
            list.Items.Add("Homme");
            list.Items.Add("Femme");
        }

        /*
               <dx:ListEditItem Text="Homme" />
                <dx:ListEditItem Text="Femme" />
                    */



        protected void CheckBoxListFamiliale_Init(object sender, EventArgs e)
        {
            var list = (ASPxCheckBoxList)sender;
            list.Items.Add("Chef de famille");
            list.Items.Add("Maitresse de maison");
            list.Items.Add("Enfant du chef de famille ou la maitresse de maison");
            list.Items.Add("Autre statut");
        }

        /*
               <dx:ListEditItem Text="Chef de famille" />
                <dx:ListEditItem Text="Maitresse de maison" />
                <dx:ListEditItem Text="Enfant du chef de famille ou la maitresse de maison" />
                <dx:ListEditItem Text="Autre statut" />
                                               
         
         
         */

        protected void CheckBoxListEtes_Init(object sender, EventArgs e)
        {
            var list = (ASPxCheckBoxList)sender;
            list.Items.Add("Proprietaire du domicile");
            list.Items.Add("Locataire du domicile");
        }


        protected void CallbackCible_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            signalitiques = new XPCollection<Signalitique>(XpoSession);
            ConstructionDuFiltre(this);

            double signalitiquesSum = Math.Round(signalitiques.Sum(p => p.Poid));
            CallbackCible.JSProperties["cpres"] = signalitiquesSum.ToString();

        }

        protected void ButtonPlan_Click(object sender, EventArgs e)
        {
            List<Signalitique> signalitiquesToList = signalitiques.ToList<Signalitique>();
            Session["Individu"] = signalitiquesToList;



            var listtemp = new List<Guid>();
            foreach (object user in gridLookupChaineGridViewGetSelectedFieldValues)
            {
                listtemp.Add(Guid.Parse(user.ToString()));
            }

            var listRadio = new List<Guid>();
            foreach (object radio in gridLookupRadioGridViewGetSelectedFieldValues)
            {
                listRadio.Add(Guid.Parse(radio.ToString()));
            }

            var listPresse = new List<Guid>();
            foreach (object Presse in gridLookupPresseGridViewGetSelectedFieldValues)
            {
                listPresse.Add(Guid.Parse(Presse.ToString()));
            }

            if (ComboBoxVague.SelectedItem != null)
                Session["Vague"] = ComboBoxVague.SelectedItem.GetValue("Oid");




            Session["Chaines"] = listtemp;
            Session["Radio"] = listRadio;
            Session["Presse"] = listPresse;

            Session["DateDebut"] = DateEditDebut.Date;
            Session["DateFin"] = DateEditFin.Date;
            Session["HeureDebut"] = HeureDebut.Text;
            Session["HeureFin"] = HeureFin.Text;

            //campagneActuelle.Debut= DateEditDebut.Date;
            //campagneActuelle.fin = DateEditFin.Date;
            //campagneActuelle.MoisReference = ComboBoxVague.SelectedIndex;
            //campagneActuelle.QuartDebut = HeureDebut.Text;
            //campagneActuelle.QuartFin = HeureFin.Text;
            //campagneActuelle.Signalitique = signalitiquesToList;

            //campagneActuelle.Save();

            Server.Transfer("PlanPub.aspx");
        }

        protected void CallbackChaine_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            var a = e.Result;
        }

        protected void CheckBoxListAge_Init(object sender, EventArgs e)
        {
            var list = (ASPxCheckBoxList)sender;
            list.Items.Add("12 à 14 ans");
            list.Items.Add("15 à 19 ans");
            list.Items.Add("20 à 24 ans");
            list.Items.Add("25 à 29 ans");
            list.Items.Add("30 à 34 ans");
            list.Items.Add("35 à 39 ans");
            list.Items.Add("40 à 44 ans");
            list.Items.Add("45 à 49 ans");
            list.Items.Add("50 à 54 ans");
            list.Items.Add("55 à 59 ans");
            list.Items.Add("60 à 64 ans");
            list.Items.Add("65 ans et plus");

        }

        protected void ComboBoxVague_PreRender(object sender, EventArgs e)
        {
            var list = (ASPxComboBox)sender;
            list.SelectedIndex = 3;
        }




        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);
            XpoSession.Dispose();
        }


        /*
                       1    12 à 14 ans
               2    15 à 19 ans
               3    20 à 24 ans
               4    25 à 29 ans
               5    30 à 34 ans
               6    35 à 39 ans
               7    40 à 44 ans
               8    45 à 49 ans
               9    50 à 54 ans
              10    55 à 59 ans
              11    60 à 64 ans
              12    65 ans et plus

        */

    }
}
