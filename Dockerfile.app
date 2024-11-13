# Etapa de build: usa o SDK para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia o arquivo de projeto e restaura dependências
COPY *.csproj ./
RUN dotnet restore

# Copia todos os arquivos e realiza o build
COPY . ./
RUN dotnet publish -c Release -o /app/out

# Etapa de runtime: usa apenas o runtime do .NET (não precisa do SDK)
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

# Expõe a porta padrão do ASP.NET Core
EXPOSE 80

# Inicia a aplicação
ENTRYPOINT ["dotnet", "ListagemTarefasEstagio.dll"]
