using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Courant : Compte
    {
        #region Champs
        private double _LigneDeCredit;
        private const double TX_INTERET_POS = 3;
        private const double TX_INTERET_NEG = 9.75;
        #endregion

        #region Propriétés
        public double LigneDeCredit
        {
            // La ligne de credit est négative, car si la banque autorise un credit de 500€, cela signifie que le client peut retiré jusqu'a un solde de -500€.

            get { return _LigneDeCredit; }
            private set
            { 
                if(value < 0)
                {
                    throw new InvalidOperationException("Ligne de credit négative");
                }
                _LigneDeCredit = value; 
            }
        }

        protected override double SoldeDisponible
        {
            get { return  Solde + LigneDeCredit; }
        }

        #endregion

        #region Constructeurs

        public Courant(string numero, Personne titulaire) : base(numero, titulaire)
        {
            LigneDeCredit = 0;
        }

        public Courant(string numero, Personne titulaire, double ligneDeCredit) : base(numero, titulaire)
        {
            LigneDeCredit = ligneDeCredit;
        }

        public Courant(string numero, Personne titulaire, double solde, double ligneDeCredit) : base(numero, titulaire, solde)
        {
            LigneDeCredit = ligneDeCredit;
        }

        #endregion


        #region Méthodes
        protected override double CalculInteret()
        {
            double taux;
            if (Solde >= 0)
            {
                taux = TX_INTERET_POS;
            }
            else
            {
                taux = TX_INTERET_NEG;
            }
            //double taux = Solde >= 0 ? TX_INTERET_POS : TX_INTERET_NEG;

            return Solde * (taux / 100);
        }
        #endregion
    }
}
