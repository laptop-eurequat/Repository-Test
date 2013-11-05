using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.POCO.Support;

namespace Zero.Repository
{
    public static class SupportFactory
    {
        static SupportTV CreateTV()
        {

            return new SupportTV();
        }
    }
}
