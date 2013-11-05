using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero.Contract;
using Zero.DataContract;

namespace Zero.ServiceProxy
{
    public class CreationVagueFacade
    {
        private readonly ICreationVagueService _creationVagueService;

        public CreationVagueFacade(ICreationVagueService creationVagueService)
        {
            _creationVagueService = creationVagueService;
        }

        public CreationVaguePresentation CreateVaguePresenter(string filePath, string VagueName)
        {
            var request =new VagueCreationRequest()
                {
                    FilePath = filePath,
                    VagueName = VagueName
                };
            var response=_creationVagueService.CreateVague(request);
            if (response.Success)
            {
                return new CreationVaguePresentation()
                    {
                        Vague = response.VagueName,
                        NbSignalitique = response.NbPopulation
                    };
            }
            return null;
        }
    }
}