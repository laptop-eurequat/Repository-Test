using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Zero.Contract;
using Zero.DataContract;

namespace Zero.ServiceProxy
{
    public class CreateVagueClientProxy : ClientBase<ICreationVagueService>, ICreationVagueService
    {
        public VagueCreationReponse CreateVague(VagueCreationRequest vagueCreationRequest)
        {
            return base.Channel.CreateVague(vagueCreationRequest);
        }
    }
}