using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.POCO.FiltreEnumeration;

namespace Zero.POCO.Interfaces
{
    public interface IFiltre
    {
        string Nom { get;}
        int ageMin { get; }
        int ageMax { get;  }
        List<CSE> CSEs { get; }
        List<CSP> CSPs { get;  }
        List<Equipement> Equipements { get; }
        List<Genre> Genres { get;  }
        List<Habitat> Habitats { get;  }
        List<NbChambre> NbChambres { get; }
        List<NbVoiture> NbVoitures { get; }
        List<NiveauInstruction> NiveauxInstructions { get;  }
        List<RevenuTotalFoyer> RevenueTotalFoyers { get;  }
        List<Salaire> Salaires { get;  }
        List<SituationMatrimonial> SituationMatrimonials { get; }
        List<StatutFamiliale> StatutFamiliales { get; }
        List<TailleFoyer> TailleFoyers { get;  }
        List<TypeHabitation> TypeHabitations { get;  }
    }
}
