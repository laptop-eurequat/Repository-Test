using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;

namespace Zero.POCO
{
    public class Annonceur : EntityBase<Guid>
    {
        internal Annonceur()
        {
            
        }
        //juste un test pour git 
        // un autre test


        // la brache iss53

        // une deuxieme modification 

        // we got a hotfix

        public string Name {get;internal set;}

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
