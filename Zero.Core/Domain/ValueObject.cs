using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Core.Domain
{
    public abstract class ValueObject
    {
        private List<BusinessRule> _brokenRules = new List<BusinessRule>();

        protected ValueObject()
        {

        }

        protected abstract void Validate();
        public void ThrowExceptionIfInvalid()
        {
            _brokenRules.Clear();
            Validate();
            if (_brokenRules.Any())
            {
                var issues = new StringBuilder();
                foreach (BusinessRule businessRule in _brokenRules)
                    issues.AppendLine(businessRule.Rule);
                //throw new ValueObjectIsInvalidException(issues.ToString());
            }
        }


        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }
    }
}
