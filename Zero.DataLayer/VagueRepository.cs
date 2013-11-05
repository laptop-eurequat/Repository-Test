using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Zero.Core.Domain;
using Zero.Core.Domain.Query;
using Zero.POCO.Donnees;

namespace Zero.DataLayer
{
    public class VagueRepository : IRepository<Vague, Guid>
    {
        public Vague FindBy(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vague> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vague> FindBy(Query query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vague> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(IEnumerable<Vague> entities)
        {
            throw new NotImplementedException();
        }

        public List<Vague> FindAll(List<Query> entities)
        {
            throw new NotImplementedException();
        }

        public void Save(Vague entity)
        {
            using (
                  var uow = new UnitOfWork()
                  {
                      ConnectionString =
                          @"XpoProvider=MSAccess;Provider=Microsoft.Jet.OLEDB.4.0;Mode=Share Deny None;data source=C:\DataBase\audience.mdb;Jet OLEDB:Database Password=diesirae"
                  })
            {
                var vague = MAP.Map.MapVague(entity, uow);
                uow.CommitChanges();
            }
        }

        public void Add(Vague entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Vague entity)
        {
            throw new NotImplementedException();
        }
    }
}
