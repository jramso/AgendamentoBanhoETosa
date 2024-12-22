# Base para o ambiente de produção
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia a solução e os projetos para o contêiner
COPY ["AgendamentoBanhoETosa.sln", "./"]
COPY ["AgendamentoBanhoETosa/AgendamentoBanhoETosa.csproj", "AgendamentoBanhoETosa/"]

# Restaura as dependências da solução
RUN dotnet restore "AgendamentoBanhoETosa.sln"

# Copia o restante do código para o contêiner
COPY . .

# Compila e publica o projeto
RUN dotnet publish "AgendamentoBanhoETosa/AgendamentoBanhoETosa.csproj" \
    -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final para produção
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AgendamentoBanhoETosa.dll"]
