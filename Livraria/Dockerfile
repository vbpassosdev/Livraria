# Etapa de construção

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Definindo o diretório de trabalho para /app
WORKDIR /app

# Copia o arquivo .csproj da pasta Livraria para dentro do container
COPY Livraria/*.csproj ./ 

# Restaura as dependências do projeto
RUN dotnet restore

# Copia o restante do código da pasta Livraria
COPY . .

# Publica a aplicação
RUN dotnet publish -c Release -o /out

# Etapa final: usa a imagem do ASP.NET Core para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:6.6.2

WORKDIR /app

# Copia a aplicação publicada da etapa de build
COPY --from=build /out .

# Define o comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "Livraria.dll"]
# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore "API_Livraria.csproj"
RUN dotnet publish "API_Livraria.csproj" -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "API_Livraria.dll"]
