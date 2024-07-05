﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Models
{
    public class Epargne : Compte
    {
        #region Champs
        private const double TX_INTERET = 4.5;
        #endregion

        #region Propriétés
        public DateTime DateDernierRetrait { get; private set; }
        #endregion

        #region Méthodes
        public override void Retrait(double montant)
        {
            base.Retrait(montant);
            DateDernierRetrait = DateTime.Now;
        }

        protected override double CalculInteret()
        {
            return this.Solde * (TX_INTERET / 100);
        }
        #endregion
    }
}
