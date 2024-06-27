using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Courant
    {
        #region Champs
        private double _LigneDeCredit;
        #endregion

        #region Propriétés
        public string Numero { get; set; }
        public Personne Titulaire { get; set; }
        public double Solde { get; private set; }

        public double LigneDeCredit
        {
            // La ligne de credit est négative, car si la banque autorise un credit de 500€, cela signifie que le client peut retiré jusqu'a un solde de -500€.

            get { return _LigneDeCredit; }
            set 
            { 
                if(value < 0)
                {
                    throw new Exception("Ligne de credit négative");
                }
                _LigneDeCredit = value; 
            }
        }

        private double SoldeDisponible
        {
            get { return  Solde + LigneDeCredit; }
        }
        #endregion


        #region Méthodes
        public void Depot(double montant)
        {
            if(montant <= 0)
            {
                throw new Exception("Montant négatif");
            }

            Solde += montant;
        }

        public void Retrait(double montant)
        {
            if (montant <= 0)
            {
                throw new Exception("Montant négatif");
            }

            if (montant > SoldeDisponible)
            {
                throw new Exception("Solde insufisant");
            }

            Solde -= montant;
        }
        #endregion


    }
}
