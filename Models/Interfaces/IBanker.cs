using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IBanker : ICustomer
    {
       void AppliquerInteret();
       string Numero { get; }
       Personne Titulaire { get;}
    }
}
