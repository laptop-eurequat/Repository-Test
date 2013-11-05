using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Core.Domain.Query
{
    public interface IRepositorySpec<T> where T : IAggregateRoot
    {
        void SaveAll(IEnumerable<T> entities);
        List<T> FindAll(List<Query> entities);
    }
}
