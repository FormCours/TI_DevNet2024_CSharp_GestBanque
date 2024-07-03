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

        //public string GetPrenom()
        //{
        //    return Prenom;
        //}

        //public void SetPrenom(string value)
        //{
        //    value = "toto";
        //    Prenom = value;
        //}
    }
}
