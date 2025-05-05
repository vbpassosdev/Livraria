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
