using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Banque
    {
        private List<Courant> _Courants = new List<Courant>();
        public string Nom { get; set; }

        public Courant? this[string numero]
        {
            get
            {
                foreach ( Courant c in _Courants)
                {
                    if(c.Numero == numero)
                    {
                        return c;
                    }
                }
                return null;
            }
        }

        public void Ajouter(Courant c)
        {
            if ( this[c.Numero] != null )
            {
                Console.WriteLine($"Le compte numéro : {c.Numero} existe déjà!!!");
                return;
            }
            _Courants.Add(c);
        }

        public void Supprimer(string numero)
        {
            Courant? c = this[numero];
            if( c == null)
            {
                Console.WriteLine($"Le compte numéro : {numero} n'existe pas!!!");
                return;
            }
            _Courants.Remove(c);
        }
    }
}
