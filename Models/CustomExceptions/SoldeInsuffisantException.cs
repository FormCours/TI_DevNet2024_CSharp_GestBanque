using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CustomExceptions
{
    public class SoldeInsuffisantException : Exception
    {
        public string Numero { get; private set; }
        public double Solde { get; private set; }
        public double Montant { get; private set; }

        public SoldeInsuffisantException(Compte compte, double montant, string message)
            : base(message)
        {
            Numero = compte.Numero;
            Solde = compte.Solde;
            Montant = montant;
        }

        public SoldeInsuffisantException(Compte compte, double montant)
            : this(compte, montant, "Le solde est insuffisant!")
        { }
    }
}
