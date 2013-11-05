using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;
using Zero.POCO.Support;

namespace Zero.POCO.Donnees
{
    public class CodeRadio : EntityBase<Guid>, IAggregateRoot
    {
        public SupportRadio SupportRadio{get; set; }
        public int Numero { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
