using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.CustomExceptions;
using Models.Interfaces;

namespace Models
{
    public abstract class Compte : ICustomer, IBanker
    {
        #region Propriétés
        public string Numero { get; private set; }
        public Personne Titulaire { get; private set; }
        public double Solde { get; private set; }
        protected virtual double SoldeDisponible
        {
            get { return Solde; }
        }
        #endregion

        #region Constructeurs
        public Compte(string numero, Personne titulaire)
        {
            Titulaire = titulaire;
            Numero = numero;
            Solde = 0;
        }
        public Compte(string numero, Personne titulaire, double solde)
            : this(numero, titulaire)
        {
            Solde = solde;
        }
        #endregion

        #region Méthodes
        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), "Montant négatif");
            }

            Solde += montant;
        }

        public virtual void Retrait(double montant)
        {
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), "Montant négatif");
            }

            if (montant > SoldeDisponible)
            {
                throw new SoldeInsuffisantException(this, montant, "Ca va pété !");
            }

            Solde -= montant;
        }

        protected abstract double CalculInteret();

        public void AppliquerInteret()
        {
            Solde = Solde + CalculInteret();
        }
        #endregion

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
