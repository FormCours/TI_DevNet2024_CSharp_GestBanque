using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Banque
    {
        private Dictionary<string ,Courant> _Courants = new Dictionary<string, Courant>();
        public string Nom { get; set; }

        public Courant? this[string numero]
        {
            get
            {
                foreach (KeyValuePair<string, Courant> kvp in _Courants)
                {
                    if(kvp.Key == numero)
                    {
                        return kvp.Value;
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

            _Courants.Add(c.Numero, c);
        }

        public void Supprimer(string numero)
        {
            if(!_Courants.ContainsKey(numero))
            {
                Console.WriteLine($"Le compte numéro : {numero} n'existe pas!!!");
                return;
            }

            _Courants.Remove(numero);
        }


        // Ajouter une méthode « AvoirDesComptes » à la classe « Banque » recevant en paramètre le titulaire (Personne) qui calculera les avoirs de tous ses comptes en utilisant l’opérateur « + ».
        public double AvoirDesComptes(Personne titulaire)
        {
            Courant temp = new Courant();
            double result = 0;

            foreach(KeyValuePair<string, Courant> kvp in _Courants)
            {
                Courant courant = kvp.Value;

                if(courant.Titulaire == titulaire)
                {
                    double montant = temp + courant;

                    result += montant;
                }
            }

            return result;
        }
    }
}
