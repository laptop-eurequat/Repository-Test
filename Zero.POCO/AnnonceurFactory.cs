using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.POCO
{
    public static class AnnonceurFactory
    {
        /// <summary>
        /// Factory method to create an annonceur
        /// </summary>
        /// <param name="name">the name of the annonceur</param>
        /// <returns>an annonceur</returns>
        public static Annonceur CreateAnnonceur(string name)
        {
            return new Annonceur(){Name = name,id=new Guid()};
        }

        /// <summary>
        /// Factory method to create a marque
        /// </summary>
        /// <param name="name">the name of the marque</param>
        /// <param name="annonceur">the owner of the marque </param>
        /// <param name="type"> the segement in wich operate the marque </param>
        /// <returns>a marque </returns>
        public static Marque CreateMarque(String  name,Annonceur annonceur, TypeMarque type)
        {
            return new Marque(){Name = name,Type = type,id = new Guid(),Annonceur = annonceur};
        }
    }
}
