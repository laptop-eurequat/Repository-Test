using System.Collections.Generic;
using Zero.POCO.FiltreEnumeration;
using Zero.POCO.Interfaces;

namespace Zero.POCO
{
    public static class FiltreFactory
    {
        public static Filter CreateFiltre(IFiltre filtre   )
        {
            var _filtre = new Filter
                {
                    Nom = filtre.Nom,
                    Habitats = filtre.Habitats,
                    CSEs = filtre.CSEs,
                    CSPs = filtre.CSPs,
                    Equipements = filtre.Equipements,
                    Genres = filtre.Genres,
                    NbChambres = filtre.NbChambres,
                    NbVoitures = filtre.NbVoitures,
                    NiveauxInstructions = filtre.NiveauxInstructions,
                    RevenueTotalFoyers = filtre.RevenueTotalFoyers,
                    Salaires = filtre.Salaires,
                    SituationMatrimonials = filtre.SituationMatrimonials,
                    StatutFamiliales = filtre.StatutFamiliales,
                    TailleFoyers = filtre.TailleFoyers
                };

            return _filtre;
        }
    }
}