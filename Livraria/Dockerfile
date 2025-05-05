# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copia o arquivo .csproj e restaura as dependências
COPY Livraria/API_Livraria.csproj Livraria/
WORKDIR /src/Livraria
RUN dotnet restore "API_Livraria.csproj"

# Copia o restante dos arquivos e publica o aplicativo
COPY Livraria/. .
RUN dotnet publish "API_Livraria.csproj" -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "API_Livraria.dll"]
