using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.POCO.Compagne;
using Zero.POCO.Support;

namespace Zero.POCO
{
    public static class CompaignFactory
    {



        public static Compaign CreateCompaign(Annonceur annonceur, TypeCompaign typeCompaign, Marque marque = null)
        {
            return new Compaign(){Annonceur = annonceur,Marque = marque,id = new Guid(),TypeCompaign = typeCompaign};
        }

        public static PlanTV CreatePlanTv(String name, Compaign compaign)
        {
            var planTv=new PlanTV() { Name = name, id = new Guid() };
            if (compaign.PlanTvs == null) compaign.PlanTvs=new List<PlanTV>();
            compaign.PlanTvs.Add(planTv);
            return planTv;
        }

        public static PlanRadio CreatePlanRadio(string name, Compaign compaign)
        {
            var planRadio = new PlanRadio() { Name = name, id = new Guid() };
            if (compaign.PlanRadios == null) compaign.PlanRadios = new List<PlanRadio>();
            compaign.PlanRadios.Add(planRadio);
            return planRadio;
        }

        public static PlanPresse  CreatePlanPresse(string name, Compaign compaign)
        {
            var planPresse = new PlanPresse() { Name = name, id = new Guid() };
            if (compaign.PlanPresses == null) compaign.PlanPresses = new List<PlanPresse>();
            compaign.PlanPresses.Add(planPresse);
            return planPresse;
        }

        public static InsertionTv CreateInsertionTv(PlanTV planTV, int numQuart, SupportTV supportTv,DateTime date)
        {
            var insertionTv = new InsertionTv() { Date = date,NumeroQuartHeure = numQuart,SupportTv = supportTv};
            if (planTV.InsertionTvs == null) planTV.InsertionTvs = new List<InsertionTv>();
            planTV.InsertionTvs.Add(insertionTv);
            return insertionTv;
        }

        public static InsertionRadio CreateInsertionRadio(PlanRadio planRadio, int numQuart, SupportRadio supportRadio, DateTime date)
        {
            var insertionRadio = new InsertionRadio() { Date = date, NumeroQuartHeure = numQuart, SupportRadio = supportRadio };
            if (planRadio.InsertionRadios == null) planRadio.InsertionRadios = new List<InsertionRadio>();
            planRadio.InsertionRadios.Add(insertionRadio);
            return insertionRadio;
        }

        public static InsertionPresse CreateInsertionPresse(PlanPresse planPresse, int nbFoisLus, SupportPresse supportPresse,DateTime date)
        {
            var insertionPresse = new InsertionPresse() { Date = date,NombreFoisLus = nbFoisLus, SupportPresse = supportPresse };
            if (planPresse.InsertionPresses == null) planPresse.InsertionPresses = new List<InsertionPresse>();
            planPresse.InsertionPresses.Add(insertionPresse);
            return insertionPresse;
        }
    }
}
