using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;
using Zero.POCO.Data;

namespace Zero.POCO.Support
{
    public class SupportPresse : EntityBase<Guid>, IAggregateRoot
    {
        private string Sujet { get; set; }
        private int Code { get; set; }
        private Langue Langue { get; set; }
        private string Type { get; set; }
        private string Libelle { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
