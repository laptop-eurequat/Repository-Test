using System;
using System.Collections.Generic;
using Zero.Core.Domain;

namespace Zero.POCO.Compagne
{
    public class Compaign : EntityBase<Guid>,IAggregateRoot
    {

        public Marque Marque { get; internal set; }
        public Annonceur Annonceur { get; internal set; }
        public TypeCompaign TypeCompaign{ get; internal set; }
        public List<PlanTV> PlanTvs { get; set; }
        public List<PlanRadio> PlanRadios { get; set; }
        public List<PlanPresse> PlanPresses { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
