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
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaiss { get; set; }
        #endregion

        
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
    }
}
