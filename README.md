# BalanceApp
Projet de fin d'études.

## Prérequis :
- Visual Studio 2022
- Docker

## Exécuter la base de données en local (ne marche pas avec un proxy) :
Lancer depuis la racine du projet : `docker compose up -d`
Arrêter la base de données : `docker compose stop`

## Créer les tables en base de données :

### Installer dotnet-ef sur la machine (risque de ne pas fonctionner avec un proxy) :
`dotnet tool install --global dotnet-ef`

### Se déplacer dans la couche d'infrastructure depuis la racine du projet :
`cd BalanceApp.Infrastructure`

### Créer les fichiers de migrations (seulement si les fichiers ne sont pas présent dans le dossier migrations :
`dotnet ef migrations add initalCreate --context Context --startup-project ../BalanceApp.API -o Migrations`

### Migrer vers la base de données :
`dotnet ef database update --context Context --startup-project ../BalanceApp.API`
