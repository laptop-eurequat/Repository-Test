using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;
using Zero.POCO.Support;

namespace Zero.POCO.Audiences
{
    public class AudienceJournal : EntityBase<Guid>
    {
        public int Jour { get; set; }
        public SupportPresse SupportPresse { get; set; }
        public int NombreOccurence { get; set; }
        public int NumJournal { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
