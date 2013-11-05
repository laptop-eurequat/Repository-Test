using System;
using System.Collections.Generic;
using Zero.Core.Domain;

namespace Zero.POCO.Donnees
{
    public class Individu : EntityBase<Guid>, IAggregateRoot
    {
        public int Sexe{get;set;}
        public  String IdQuest{get;set;}
        public List<ISignalitique> Signalitiques { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}