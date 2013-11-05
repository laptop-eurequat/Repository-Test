using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;
using Zero.POCO.Donnees;

namespace Zero.POCO.Compagne
{
    public class PlanRadio : EntityBase<Guid>
    {
        public List<InsertionRadio> InsertionRadios { get; set; }
        public string Name { get; set; }
        public List<Signalitique> Signalitique { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
