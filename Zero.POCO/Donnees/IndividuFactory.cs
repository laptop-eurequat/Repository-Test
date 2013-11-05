using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.POCO.Donnees
{
    public static class IndividuFactory
    {

        public static Individu Create(String idQuest,int sexe )
        {
            return new Individu() {id = new Guid(), IdQuest = idQuest, Sexe = sexe};
     
        }


        public static Boolean CreateSignalitique(String idQuest, int sexe)
        {
            //Individus.Add(new Individu() { id = new Guid(), IdQuest = idQuest, Sexe = sexe });
            return true;
        }

        public static Vague CreateVague(String vagueName)
        {
            var vague = new Vague() {id = new Guid(),Libelle = vagueName};
            return vague;
        }
    }
}
