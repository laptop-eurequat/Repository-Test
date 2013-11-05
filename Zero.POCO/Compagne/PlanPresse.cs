using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;
using Zero.POCO.Donnees;

namespace Zero.POCO.Compagne
{
    public class PlanPresse : EntityBase<Guid>
    {
        public List<InsertionPresse> InsertionPresses { get; set; }
        public string Name { get; set; }
        public List<Signalitique> Signalitique{get;set;}
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
