﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Banque
    {
        private Dictionary<string ,Compte> _Comptes = new Dictionary<string, Compte>();
        public string Nom { get; set; }

        public Compte? this[string numero]
        {
            get
            {
                foreach (KeyValuePair<string, Compte> kvp in _Comptes)
                {
                    if(kvp.Key == numero)
                    {
                        return kvp.Value;
                    }
                }
                return null;
            }
        }

        public void Ajouter(Compte c)
        {
            if ( this[c.Numero] != null )
            {
                Console.WriteLine($"Le compte numéro : {c.Numero} existe déjà!!!");
                return;
            }

            _Comptes.Add(c.Numero, c);
        }

        public void Supprimer(string numero)
        {
            if(!_Comptes.ContainsKey(numero))
            {
                Console.WriteLine($"Le compte numéro : {numero} n'existe pas!!!");
                return;
            }

            _Comptes.Remove(numero);
        }


        // Ajouter une méthode « AvoirDesComptes » à la classe « Banque » recevant en paramètre le titulaire (Personne) qui calculera les avoirs de tous ses comptes en utilisant l’opérateur « + ».
        public double AvoirDesComptes(Personne titulaire)
        {
            Compte temp = new Compte();
            double result = 0;

            foreach(KeyValuePair<string, Compte> kvp in _Comptes)
            {
                Compte compte = kvp.Value;

                if(compte.Titulaire == titulaire)
                {
                    double montant = temp + compte;

                    result += montant;
                }
            }

            return result;
        }
    }
}
