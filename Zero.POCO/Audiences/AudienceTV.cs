using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;
using Zero.POCO.Support;

namespace Zero.POCO.Audiences
{
    public class AudienceTV : EntityBase<Guid>
    {
        public int NumeroQuertdheure { get; set; }
        public SupportTV SupportTV { get; set; }
        public int NumeroJour { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
