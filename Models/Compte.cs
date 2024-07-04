using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Compte
    {
        public string Numero { get; set; }
        public Personne Titulaire { get; set; }
        public double Solde { get; private set; }

        protected virtual double SoldeDisponible {
            get
            {
                return Solde;
            }
        }

        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                throw new Exception("Montant négatif");
            }

            Solde += montant;
        }

        public virtual void Retrait(double montant)
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

        protected abstract double CalculInteret();

        public void AppliquerInteret()
        { 
            Solde = Solde + CalculInteret();
        }


        #region Surcharge d'opérateur
        // Surcharger l’opérateur « + » de la classe « Compte » afin qu’il retourne la somme, de type double, des soldes.
        // Cependant, les soldes négatifs ne doivent pas être pris en compte.
        public static double operator +(Compte c1, Compte c2)
        {
            double solde1 = Math.Max(c1.Solde, 0);
            double solde2 = Math.Max(c2.Solde, 0);

            return solde1 + solde2;
        }

        //public static double operator +(Compte c1, Compte c2)
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
