using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Zero.POCO.Donnees;

namespace Zero.DataContract
{
    [DataContract]
    public class VagueCreationReponse : Response
    {
        [DataMember]
        public int NbPopulation{ get; set; }

        [DataMember]
        public string VagueName { get; set; }
    }
}
