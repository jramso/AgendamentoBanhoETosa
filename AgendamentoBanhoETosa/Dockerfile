# Etapa de construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AgendamentoBanhoETosa/AgendamentoBanhoETosa.csproj", "./AgendamentoBanhoETosa/"]
RUN dotnet restore "./AgendamentoBanhoETosa/AgendamentoBanhoETosa.csproj"
COPY . .

# Criação da pasta de saída e ajuste de permissões
WORKDIR /app
RUN mkdir -p /app/build && chmod -R 777 /app/build

# Compilação
WORKDIR /src
RUN dotnet build "./AgendamentoBanhoETosa/AgendamentoBanhoETosa.csproj" -c Release -o /app/build

# Etapa de publicação
RUN dotnet publish "./AgendamentoBanhoETosa/AgendamentoBanhoETosa.csproj" -c Release -o /app/publish

# Etapa final: imagem para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expõe a porta usada pela aplicação
EXPOSE 8080
EXPOSE 8081

ENTRYPOINT ["dotnet", "AgendamentoBanhoETosa.dll"]