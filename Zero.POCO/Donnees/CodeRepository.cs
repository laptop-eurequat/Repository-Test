using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;
using Zero.Core.Domain.Query;
using Zero.POCO.Support;

namespace Zero.POCO.Donnees
{
    public class CodeRepository :  IRepository<CodeTv, Guid>
    {
        public static SupportTV GetTV(int numero)
        {

            return null;
        }

        public CodeTv FindBy(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CodeTv> FindAll()
        {
            //TODO: remplacer ce code
            return new List<CodeTv>()
                {
                    new CodeTv()
                        {
                            Numero = 1,
                            SupportTv = new SupportTV(){}
                        }
                }
        }

        public IEnumerable<CodeTv> FindBy(Query query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CodeTv> FindBy(Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

        public void Save(CodeTv entity)
        {
            throw new NotImplementedException();
        }

        public void Add(CodeTv entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(CodeTv entity)
        {
            throw new NotImplementedException();
        }
    }
}
