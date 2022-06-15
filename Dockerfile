#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_Environment=Production
ENV ASPNETCORE_URLS=http://*:$PORT

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BalanceApp.API/BalanceApp.API.csproj", "BalanceApp.API/"]
COPY ["BalanceApp.Application/BalanceApp.Application.csproj", "BalanceApp.Application/"]
COPY ["BalanceApp.Domain/BalanceApp.Domain.csproj", "BalanceApp.Domain/"]
COPY ["BalanceApp.Infrastructure/BalanceApp.Infrastructure.csproj", "BalanceApp.Infrastructure/"]
RUN dotnet restore "BalanceApp.API/BalanceApp.API.csproj"
COPY . .
WORKDIR "/src/BalanceApp.API"
RUN dotnet build "BalanceApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BalanceApp.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet BalanceApp.API.dll