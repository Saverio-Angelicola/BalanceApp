# BalanceApp

# create migrations :
`dotnet ef migrations add initalCreate --context Context --startup-project ../BalanceApp.API -o Migrations`

# Migrate :
`dotnet ef database update --context Context --startup-project ../BalanceApp.API`
