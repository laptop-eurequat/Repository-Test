using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.DataContract;
using Zero.POCO.Donnees;

namespace Zero.Service
{
    public static class CreteVagueExtension
    {
        public static VagueCreationReponse ConvertVagueToResponse(this Vague vague)
        {
            var response = new VagueCreationReponse {Vague = vague};
            return response;
        }
    }
}
