using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;

namespace Zero.POCO.Donnees
{
    public class Vague :EntityBase<Guid>,IAggregateRoot
    {
        public  int Rang{get;set;}
        public  List<ISignalitique> Signalitique { get; set; }
        public  int Annee { get; set; }
        public  int Mois { get; set; }
        public string Evenement { get; set; }
        public string Libelle { get; set; }
        public int Numero { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
