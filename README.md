## Fonctionnel
Ce microservice gère des items avec un nom, une description et un prix. 

## Développement
Il est développé avec ASP.NET en C#.

## Base de données
La base de données est une base de données document avec MongoDB.
Il est géré avec l'ORM de .NET, Entity Framework. 

## Architecture de code
Plusieurs composantes ont été créées : 
- Les DTOS pour gérer les formats transmits
- Le controller pour gèrer le CRUD d'items
- Un repository d'items pour gérer la base de données
- Une entité pour gérer le model d'un item dans la base de données
