using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Core.Domain
{
    public abstract class EntityBase<Tid>
    {
        private List<BusinessRule> _brokenRules=new List<BusinessRule>() ;
        public Tid id { get; set; }

         abstract protected void Validate();

         public IEnumerable<BusinessRule> GetBrokenRules()
         {
             _brokenRules.Clear();
             Validate();
             return _brokenRules;
         }

         protected void AddBrokenRule(BusinessRule businessRule)
         {
             _brokenRules.Add(businessRule);
         }

         public override bool Equals(object obj)
         {
             return obj != null && obj is EntityBase<Tid> && (EntityBase<Tid>) obj == this;
         }

         public static bool operator == (EntityBase<Tid> obj1,EntityBase<Tid> obj2  )
         {
             if (obj1 == null && obj2 == null) return true;
             if (obj1 == null || obj2 == null) return false;
             return obj1.id.ToString() == obj2.id.ToString();
         }

         public static bool operator !=(EntityBase<Tid> obj1, EntityBase<Tid> obj2)
         {
             return !(obj1 == obj2);
         }
    }
}
