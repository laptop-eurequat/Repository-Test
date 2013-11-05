using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;
using Zero.Core.Domain.Query;

namespace Zero.POCO.Support
{
    public class RepositoryTV : IRepository<SupportTV, Guid>
    {
        public SupportTV FindBy(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupportTV> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupportTV> FindBy(Query query)
        {
            return new List<SupportTV>() { new SupportTV() { id = new Guid() } };
        }

        public IEnumerable<SupportTV> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

        public void Save(SupportTV entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<SupportTV> entities)
        {
            throw new NotImplementedException();
        }

        public List<SupportTV> FindAll(List<Query> entities)
        {
            throw new NotImplementedException();
        }

        public List<SupportTV> FindAll(List<SupportTV> entities)
        {
            throw new NotImplementedException();
        }

        public void Add(SupportTV entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(SupportTV entity)
        {
            throw new NotImplementedException();
        }
    }
}
