using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;

namespace Zero.POCO
{
    public class Marque : EntityBase<Guid>
    {
        internal Marque()
        {
            
        }
        public String Name { get; internal set; }
        public TypeMarque Type { get; internal set; }
        public Annonceur Annonceur { get; internal set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }

    
        
    }
}
