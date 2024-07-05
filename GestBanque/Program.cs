using Models;
using Models.Interfaces;

Personne p1 = new Personne("Sébastien", "Bya", new DateTime(1991, 3, 27));

Personne p2 = new Personne(nom: "Caffey", dateNaiss: new DateTime(1970, 3, 27), prenom: "John");

Personne p3 = new Personne("Duck", "Della", new DateTime(1989, 6, 7));

//p1.Prenom = p2.Prenom;
//p1.SetPrenom(p2.GetPrenom());

Courant c1 = new Courant("123", p1);
c1.Depot(1000);
c1.Retrait(100);

Courant c2 = new Courant("456", p1, 100);
c2.Depot(1000);
c2.Retrait(500);

Courant c3 = new Courant("789", p2);
c3.Depot(10000);
c3.Retrait(100);

Banque b1 = new Banque();
b1.Nom = "Les loustics";

b1.Ajouter(c1);
b1.Ajouter(c2);
b1.Ajouter(c3);

b1.Supprimer("5645");
b1["123"]?.Depot(1_000_000);




Personne pRechercher = new Personne("Sébastien", "Bya", new DateTime(1991, 3, 27));

double avoirSeb = b1.AvoirDesComptes(pRechercher);
Console.WriteLine($"Avoir des comptes de {pRechercher.Prenom} {pRechercher.Nom} est de {avoirSeb}.");

ICustomer customer = c3;
customer.Depot(25.00);
// On ne peut ni y accéder ni modifier le titulaire via l'interface ICustomer :)



if(customer is Courant customerCourant)
{
    Courant c4 = new Courant("42", p3, customerCourant.Solde, customerCourant.LigneDeCredit);
    customer.Retrait(customerCourant.Solde);
    b1.Ajouter(c4);
}