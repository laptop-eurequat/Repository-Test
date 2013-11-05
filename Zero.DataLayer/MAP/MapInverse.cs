using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.DataLayer.MAP
{
    public static class MapInverse
    {
        public static POCO.Donnees.Individu MapIndividus(Donnees.Individu individu)
        {
            return new POCO.Donnees.Individu()
                {
                    id = individu.Oid,
                    IdQuest = individu.IdQuest,
                    Sexe = individu.Sexe,
                    //TODO; convertir signalitique en données
                };
        }
    }
}
