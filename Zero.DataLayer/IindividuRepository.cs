using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;
using Zero.Core.Domain;
using Zero.Core.Domain.Query;
using Zero.POCO.Donnees;

namespace Zero.DataLayer
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
            List<Individu> Modelindiv;
            using (
                    var xpoSession = new Session()
                    {
                        ConnectionString =
                            @"XpoProvider=MSAccess;Provider=Microsoft.Jet.OLEDB.4.0;Mode=Share Deny None;data source=C:\DataBase\audience.mdb;Jet OLEDB:Database Password=diesirae"
                    })
            {
                var individus = new XPCollection<Zero.DataLayer.Donnees.Individu>(xpoSession);
                Modelindiv = new List<Individu>();
                foreach (var individu in individus)
                {
                    Modelindiv.Add(MAP.MapInverse.MapIndividus(individu));
                }
            }

            return Modelindiv;
        }

        public IEnumerable<Individu> FindBy(Query query)
        {
            List<Individu> Modelindiv;
            if(query.Criteria.First().criteriaOperator==CriteriaOperator.Equal)
            {
               
                using (
                    var xpoSession = new Session()
                        {
                            ConnectionString =
                                @"XpoProvider=MSAccess;Provider=Microsoft.Jet.OLEDB.4.0;Mode=Share Deny None;data source=C:\DataBase\audience.mdb;Jet OLEDB:Database Password=diesirae"
                        })
                {
                    var individus = new XPCollection<Zero.DataLayer.Donnees.Individu>(xpoSession);
                    var Xpoindiv = individus.Where(p => p.IdQuest == query.Criteria.First().Value.ToString());
                    Modelindiv=new List<Individu>();
                    foreach (var individu in Xpoindiv)
                    {
                        Modelindiv.Add(MAP.MapInverse.MapIndividus(individu));
                    }
                }

                return Modelindiv;
            }
            return null;
        }

        public IEnumerable<Individu> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

        public void Save(Individu entity)
        {
            using (
                   var uow = new UnitOfWork()
                   {
                       ConnectionString =
                           @"XpoProvider=MSAccess;Provider=Microsoft.Jet.OLEDB.4.0;Mode=Share Deny None;data source=C:\DataBase\audience.mdb;Jet OLEDB:Database Password=diesirae"
                   })
            {
                var individu=MAP.Map.MapIndividu(entity, uow);
                uow.CommitChanges();
            }
        }


        public void SaveAll(IEnumerable<Individu> entities)
        {
            using (
                   var uow = new UnitOfWork()
                   {
                       ConnectionString =
                           @"XpoProvider=MSAccess;Provider=Microsoft.Jet.OLEDB.4.0;Mode=Share Deny None;data source=C:\DataBase\audience.mdb;Jet OLEDB:Database Password=diesirae"
                   })
            {
                Donnees.Individu individu;
                foreach (var entity in entities)
                {
                    individu = MAP.Map.MapIndividu(entity, uow);
                }
                
                uow.CommitChanges();
            }
        }

        public List<Individu> FindAll(List<Query> queries)
        {

            List<Individu> Modelindiv = new List<Individu>();
            using (
                var xpoSession = new Session()
                {
                    ConnectionString =
                        @"XpoProvider=MSAccess;Provider=Microsoft.Jet.OLEDB.4.0;Mode=Share Deny None;data source=C:\DataBase\audience.mdb;Jet OLEDB:Database Password=diesirae"
                })
            {
                foreach (var query in queries)
                {
                    var individus = new XPCollection<Zero.DataLayer.Donnees.Individu>(xpoSession);
                    var Xpoindiv = individus.Where(p => p.IdQuest == query.Criteria.First().Value.ToString());
                  
                    foreach (var individu in Xpoindiv)
                    {
                        Modelindiv.Add(MAP.MapInverse.MapIndividus(individu));
                    }
                }


                
            }
            return Modelindiv;

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
