using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;
using Zero.POCO.Support;

namespace Zero.POCO.Compagne
{
    public class InsertionTv:ValueObject
    {
        public SupportTV SupportTv { get; set; }
        public int NumeroQuartHeure { get; set; }
        public DateTime Date { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
