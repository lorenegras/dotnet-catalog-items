## Fonctionnel
Ce microservice gère des items avec un nom, une description et un prix. 

## Développement
Il est développé avec ASP.NET en C#.

## Base de données
La base de données est une base de données document avec MongoDB.
Elle est gérée avec l'ORM de .NET, Entity Framework. 

## Architecture de code
J'ai utilisé une architecture n-tiers :
- Les controllers pour gérer les routes et la sérialisation.
- Un repository d'items pour gérer l'utilisation de l'ORM (DAL)
- Une entité item pour pouvoir mettre en place une approche code-first
- Des DTOS pour faciliter la manipulation de données dans l'ensemble du CRUD
- Pour gérer la logique métier, il serait bon de rajouter une couche BLL

## Lancement du projet
Dans le dossier du projet Play.Catalog.Service, lancer la commande :
`dotnet run`
