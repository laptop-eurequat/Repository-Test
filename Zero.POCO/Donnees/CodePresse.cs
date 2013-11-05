using System;
using Zero.Core.Domain;
using Zero.POCO.Support;

namespace Zero.POCO.Donnees
{
    public class CodePresse : EntityBase<Guid>, IAggregateRoot
    {
        public SupportPresse SupportPresse { get; set; }
        public int Numero { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
