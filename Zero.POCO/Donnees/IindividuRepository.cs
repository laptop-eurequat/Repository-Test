using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;
using Zero.Core.Domain.Query;

namespace Zero.POCO.Donnees
{
    public class IndividuRepository:IRepository<Individu,Guid>
    {

        #region Implementation

        
        public Individu FindBy(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Individu> FindAll()
        {
            return IndividuFactory.Individus;
        }

        public IEnumerable<Individu> FindBy(Query query)
        {
            if(query.Criteria.First().criteriaOperator==CriteriaOperator.Equal)
            {
                return IndividuFactory.Individus.Where(p => p.IdQuest == query.Criteria.First().Value.ToString());
            }
            return null;
        }

        public IEnumerable<Individu> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

        public void Save(Individu entity)
        {
            throw new NotImplementedException();
        }

        public void Add(Individu entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Individu entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
