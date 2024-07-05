using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Personne
    {
        
        #region Propriétés
        public string Prenom { get; private set; }
        public string Nom { get; private set; }
        public DateTime DateNaiss { get; private set; }
        #endregion

        public Personne(string prenom, string nom, DateTime dateNaiss)
        {
            Prenom = prenom;
            Nom = nom;
            DateNaiss = dateNaiss;
        }


        #region Surchage d'opérateur
        public static bool operator ==(Personne? pLeft, Personne? pRight)
        {
            if (pLeft is null && pRight is null)
                return true;

            if (pLeft is null || pRight is null)
                return false;

            return pLeft.Prenom == pRight.Prenom
                && pLeft.Nom == pRight.Nom
                && pLeft.DateNaiss == pRight.DateNaiss;
        }

        public static bool operator != (Personne? pLeft, Personne? pRight)
        {
            return !(pLeft == pRight);
        }
        #endregion
    }
}
