using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using Zero.Contract;
using Zero.DataContract;
using Zero.POCO;
using Zero.POCO.Donnees;

namespace Zero.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CreationVagueService : ICreationVagueService
    {
        private static MessageResponseHistory<VagueCreationReponse> _creationResponse =
            new MessageResponseHistory<VagueCreationReponse>();

        private IindividuRepository _individusRepository;

        void CreateVagueService(IindividuRepository individuRepository)
        {
            _individusRepository = individuRepository;
        }

        public VagueCreationReponse CreateVague(VagueCreationRequest vagueCreationRequest)
        {
            var vagueCreationReponse=new VagueCreationReponse();
            var listSignalitique=DonneesFactory.CreateDonnees(vagueCreationRequest.FilePath, vagueCreationRequest.VagueName, _individusRepository);
            if (listSignalitique.Count > 0)
            {
                vagueCreationReponse.Success = true;
                vagueCreationReponse.NbPopulation = listSignalitique.Count;
                vagueCreationReponse.VagueName = vagueCreationRequest.VagueName;
            }
            else
            {
                vagueCreationReponse.Success = false;
            }
            return vagueCreationReponse;
        }
    }
}
