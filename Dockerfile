# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY Livraria/Livraria-api.csproj Livraria/
RUN dotnet restore Livraria/Livraria-api.csproj
COPY . .
WORKDIR /src/Livraria
RUN dotnet publish -c Release -o /app/publish

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Livraria-api.dll"]
