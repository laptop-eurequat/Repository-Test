using System;
using System.Data;
using System.IO;
using System.Linq;
using Excel;
using Zero.Core.Domain.Query;
using Zero.POCO
using Zero.POCO.Donnees;

namespace Zero.Test
{
    public static class DonneesFactory
    {
        public static bool CreateDonnees(string filePath, string NomVague)
        {
            var extension = Path.GetExtension(filePath);
            var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            var excelReader = extension == ".xlsx" ? ExcelReaderFactory.CreateOpenXmlReader(stream) : ExcelReaderFactory.CreateBinaryReader(stream);
            excelReader.IsFirstRowAsColumnNames = true;
            var collectionBase = excelReader.AsDataSet().Tables[0].AsEnumerable();

            var Vide = collectionBase.Where(p => (string) p["annee"] == "2012");
            //Assert.AreEqual(extension, ".xlsx");

            var distincts = collectionBase.Select(p => p["Matricule"]).Distinct();

            foreach (var distinct in distincts)
            {
                var ind = new Individu();
                var convdistinct = int.Parse(distinct.ToString());
                
                

                var individuRepository = new IndividuRepository();
                var indivCriterion = new Criterion("IdQuest",convdistinct.ToString(),CriteriaOperator.Equal);
                var indivQuery = new Query();
                indivQuery.Add(indivCriterion);
                if (individuRepository.FindBy(indivQuery).Any())continue ;

                ind.IdQuest = int.Parse(distinct.ToString());

                ind.Sexe = (int)((collectionBase.First(d => d["Matricule"] == ind.IdQuest.ToString()))["Sexe"]);
                
            }


            return default(Boolean);
        }
    }
}