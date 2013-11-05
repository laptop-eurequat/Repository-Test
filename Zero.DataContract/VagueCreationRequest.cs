using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Zero.POCO.Audiences;
using Zero.POCO.Donnees;

namespace Zero.DataContract
{
    [DataContract]
    public class VagueCreationRequest
    {

        [DataMember]
        public string FilePath{ get; set; }
        [DataMember]
        public String VagueName { get; set; }
       
    }
}
