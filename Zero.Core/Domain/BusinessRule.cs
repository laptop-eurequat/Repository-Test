using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Core.Domain
{
    public class BusinessRule
    {
        public BusinessRule(string property, string rule)
        {
        Property = property;
        Rule = rule;
        }

        public string Property { get; set; }

        public string Rule { get; set; }
    }
}
