using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;
using Zero.Core.Domain.Query;

namespace Zero.POCO.Support
{
    public class RepositoryRadio : IRepository<SupportRadio, Guid>
    {
        public SupportRadio FindBy(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupportRadio> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupportRadio> FindBy(Query query)
        {
            return new List<SupportRadio>() { new SupportRadio() { id = new Guid() } };
        }

        public IEnumerable<SupportRadio> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

        public void Save(SupportRadio entity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<SupportRadio> entities)
        {
            throw new NotImplementedException();
        }

        public List<SupportRadio> FindAll(List<Query> entities)
        {
            throw new NotImplementedException();
        }

        public List<SupportRadio> FindAll(List<SupportRadio> entities)
        {
            throw new NotImplementedException();
        }

        public void Add(SupportRadio entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(SupportRadio entity)
        {
            throw new NotImplementedException();
        }
    }
}
