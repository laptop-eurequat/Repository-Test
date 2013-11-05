using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain.Query;

namespace Zero.Core.Domain
{
    public interface IRepository<T, TId> : IReadOnlyRepository<T, TId>, IRepositorySpec<T>
    where T : IAggregateRoot
    {
        void Save(T entity);
         
        void Add(T entity);
        void Remove(T entity);
    }
}
