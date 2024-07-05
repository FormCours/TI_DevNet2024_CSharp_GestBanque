﻿using Models;
using Models.Interfaces;

Personne p1 = new Personne();
p1.Nom = "Bya";
p1.Prenom = "Sébastien";
p1.DateNaiss = new DateTime(1991, 3, 27);

Personne p2 = new Personne();
p2.Nom = "Caffey";
p2.Prenom = "John";
p2.DateNaiss = new DateTime(1970, 3, 27);

Personne p3 = new Personne();
p3.Nom = "Della";
p3.Prenom = "Duck";
p3.DateNaiss = new DateTime(1989, 6, 7);

//p1.Prenom = p2.Prenom;
//p1.SetPrenom(p2.GetPrenom());

Courant c1 = new Courant();
c1.Numero = "123";
c1.Titulaire = p1;
c1.Depot(1000);
c1.Retrait(100);

Courant c2 = new Courant();
c2.Numero = "456";
c2.Titulaire = p1;
c2.Depot(1000);
c2.Retrait(500);

Courant c3 = new Courant();
c3.Numero = "789";
c3.Titulaire = p2;
c3.Depot(10000);
c3.Retrait(100);

Banque b1 = new Banque();
b1.Nom = "Les loustics";

b1.Ajouter(c1);
b1.Ajouter(c2);
b1.Ajouter(c3);

b1.Supprimer("5645");
b1["123"]?.Depot(1_000_000);




Personne pRechercher = new Personne();
pRechercher.Nom = "Bya";
pRechercher.Prenom = "Sébastien";
pRechercher.DateNaiss = new DateTime(1991, 3, 27);

double avoirSeb = b1.AvoirDesComptes(pRechercher);
Console.WriteLine($"Avoir des comptes de {pRechercher.Prenom} {pRechercher.Nom} est de {avoirSeb}.");

ICustomer customer = c3;
customer.Depot(25.00);
// On ne peut ni y accéder ni modifier le titulaire via l'interface ICustomer :)

// Cela est possible uniquement en repassant par un type permettant d'utiliser le "Set"
if(customer is Compte)
{
    ((Compte)customer).Titulaire = p3;
}