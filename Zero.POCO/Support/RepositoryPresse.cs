using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;
using Zero.Core.Domain.Query;

namespace Zero.POCO.Support
{
    public class RepositoryPresse : IRepository<SupportPresse, Guid>
    {
        public SupportPresse FindBy(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupportPresse> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupportPresse> FindBy(Query query)
        {
            //TODO mettre une véritable fonction 
            return new List<SupportPresse>() {new SupportPresse() {id = new Guid()}};
        }

        public IEnumerable<SupportPresse> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

        public void Save(SupportPresse entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<SupportPresse> entities)
        {
            throw new NotImplementedException();
        }

        public List<SupportPresse> FindAll(List<Query> entities)
        {
            throw new NotImplementedException();
        }

        public List<SupportPresse> FindAll(List<SupportPresse> entities)
        {
            throw new NotImplementedException();
        }

        public void Add(SupportPresse entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(SupportPresse entity)
        {
            throw new NotImplementedException();
        }
    }
}
