using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zero.Core.Domain;
using Zero.POCO.FiltreEnumeration;

namespace Zero.POCO
{
    public class Filter : EntityBase<Guid>
    {
         internal Filter()
        {
            
        }

         public string Nom { get; internal set; }


         public int ageMin { get;internal set; }
         public int age { get; internal set; }
         public List<CSE> CSEs { get; internal set; }
         public List<CSP> CSPs { get; internal set; }
         public List<Equipement> Equipements { get; internal set; }
         public List<Genre> Genres { get; internal set; }
         public List<Habitat> Habitats { get; internal set; }
         public List<NbChambre> NbChambres { get; internal set; }
         public List<NbVoiture> NbVoitures { get; internal set; }
         public List<NiveauInstruction> NiveauxInstructions { get; internal set; }
         public List<RevenuTotalFoyer> RevenueTotalFoyers { get; internal set; }
         public List<Salaire> Salaires { get; internal set; }
         public List<SituationMatrimonial> SituationMatrimonials { get; internal set; }
         public List<StatutFamiliale> StatutFamiliales { get; internal set; }
         public List<TailleFoyer> TailleFoyers { get; internal set; }
         public List<TypeHabitation> TypeHabitations { get; internal set; }


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
