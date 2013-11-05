using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.POCO.Helper
{
    public static class StringToBoolean
    {
        public static Boolean GetBoolean(this string str)
        {
            if (str == "1" || str == "True" || str == "true" || str == "Vrai" || str == "vrai") return true;
            if (str == "0" || str == "False" || str == "false" || str == "Faux" || str == "faux") return true;
            return false;
        }
    }
}
