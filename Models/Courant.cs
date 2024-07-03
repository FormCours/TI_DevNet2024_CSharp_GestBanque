using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        #region Surcharge d'opérateur
        // Surcharger l’opérateur « + » de la classe « Courant » afin qu’il retourne la somme, de type double, des soldes.
        // Cependant, les soldes négatifs ne doivent pas être pris en compte.
        public static double operator +(Courant c1, Courant c2)
        {
            double solde1 = Math.Max(c1.Solde, 0);
            double solde2 = Math.Max(c2.Solde, 0);

            return solde1 + solde2;
        }

        //public static double operator +(Courant c1, Courant c2)
        //{
        //    if (c1.Solde <= 0 && c2.Solde <= 0)
        //    {
        //        return 0;
        //    }
        //
        //    if (c1.Solde <= 0)
        //    {
        //        return c2.Solde;
        //    }
        //
        //    if (c2.Solde <= 0)
        //    {
        //        return c1.Solde;
        //    }
        //
        //    return c1.Solde + c2.Solde;
        //}
        #endregion       
    }
}
