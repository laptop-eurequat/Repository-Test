using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;
using Zero.POCO.Donnees;
using Zero.POCO.Support;

namespace Zero.POCO.Audiences
{
    public class AudienceRadio : EntityBase<Guid>
    {
        public SupportRadio SupportRadio { get; set; }
        public int QuartHeure { get; set; }
        public int NumeroJour { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
