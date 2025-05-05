# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY Livraria/API_Livraria.csproj Livraria/
RUN dotnet restore Livraria/API_Livraria.csproj
COPY . .
WORKDIR /src/Livraria
RUN dotnet publish -c Release -o /app/publish

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "API_Livraria.dll"]
