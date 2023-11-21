# Utilisez l'image de base de l'environnement d'exécution .NET Core
FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

# Utilisez l'image de base de l'environnement de développement .NET Core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

# Copiez les fichiers de votre projet dans le conteneur
COPY ["./NBA_S5/NBA_S5.csproj", "NBA_S5/"]
RUN dotnet restore "./NBA_S5/NBA_S5.csproj"

# Copiez tout le contenu du répertoire actuel dans le conteneur
COPY ./NBA_S5 .

# Compilez l'application en mode de publication
RUN dotnet build "./NBA_S5/NBA_S5.csproj" -c Release -o /app/build

# Publiez l'application
FROM build AS publish
RUN dotnet publish "./NBA_S5/NBA_S5.csproj" -c Release -o /app/publish

# Utilisez l'image de base de l'environnement d'exécution .NET Core pour l'application publiée
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "./NBA_S5.dll"]
