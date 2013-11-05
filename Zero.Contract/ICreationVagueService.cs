using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Zero.DataContract;

namespace Zero.Contract
{
    [ServiceContract]
    public interface ICreationVagueService
    {
        [OperationContract()]
        VagueCreationReponse CreateVague(VagueCreationRequest vagueCreationRequest);

    }
}
