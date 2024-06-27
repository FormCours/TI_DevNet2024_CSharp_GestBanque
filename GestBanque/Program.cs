using Models;

Personne p1 = new Personne();
p1.Prenom = "Balthazar";
p1.Nom = "Picsou";
p1.DateNaiss = new DateTime(1971, 2, 6);

Courant c1 = new Courant();
c1.Titulaire = p1;
c1.Numero = "BE34 0001 4567 8523";
c1.LigneDeCredit = 10_000;
c1.Depot(3_500_000_042);

