using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Banque
    {
        #region Event
        // On souhaite utiliser le delegué suivant : void DelegateEvent(string message)
        // Pour cela, on peut utiliser un des delegué générique prévu par le framework
        public event Action<string>? BanqueNotifEvent = null;

        protected void RaiseBanqueNotifEvent(string message)
        {
            BanqueNotifEvent?.Invoke(message);
        }
        #endregion

        #region Champs
        private Dictionary<string, Compte> _Comptes = new Dictionary<string, Compte>();
        #endregion

        #region Propriétés
        public string Nom { get; set; }
        public Compte? this[string numero]
        {
            get
            {
                foreach (KeyValuePair<string, Compte> kvp in _Comptes)
                {
                    if (kvp.Key == numero)
                    {
                        return kvp.Value;
                    }
                }
                return null;
            }
        }
        #endregion

        #region Méthodes
        public void Ajouter(Compte c)
        {
            if (this[c.Numero] != null)
            {
                RaiseBanqueNotifEvent($"Le compte numéro : {c.Numero} existe déjà!!!");
                return;
            }

            // Ajout du compte dans la banque
            _Comptes.Add(c.Numero, c);

            // Abonnement a l'event des comptes
            c.PassageEnNegatifEvent += DetectionComptePasseEnNegatif;
        }

        private void DetectionComptePasseEnNegatif(Compte compte)
        {
            RaiseBanqueNotifEvent($"Le compte Numero {compte.Numero} vient de passer en négatif");
        }

        public void Supprimer(string numero)
        {
            if (!_Comptes.ContainsKey(numero))
            {
                RaiseBanqueNotifEvent($"Le compte numéro : {numero} n'existe pas!!!");
                return;
            }

            // Déabonnement de l'event des comptes
            _Comptes[numero].PassageEnNegatifEvent -= DetectionComptePasseEnNegatif;

            // Suppression du compte
            _Comptes.Remove(numero);
        }

        public double AvoirDesComptes(Personne titulaire)
        {
            // Ajouter une méthode « AvoirDesComptes » à la classe « Banque » recevant en paramètre le titulaire (Personne) qui calculera les avoirs de tous ses comptes en utilisant l’opérateur « + ».
            Compte temp = new Courant("test", titulaire);
            double result = 0;

            foreach (KeyValuePair<string, Compte> kvp in _Comptes)
            {
                Compte compte = kvp.Value;

                if (compte.Titulaire == titulaire)
                {
                    double montant = temp + compte;

                    result += montant;
                }
            }

            return result;
        }
        #endregion
    }
}
