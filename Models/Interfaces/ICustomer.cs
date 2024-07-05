using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface ICustomer
    {
        void Depot(double montant);
        void Retrait(double montant);
        double Solde { get; }
    }
}
