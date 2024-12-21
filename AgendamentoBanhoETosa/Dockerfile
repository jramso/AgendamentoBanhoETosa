# Etapa base para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AgendamentoBanhoETosa/AgendamentoBanhoETosa.csproj", "./AgendamentoBanhoETosa/"]
WORKDIR "/src/AgendamentoBanhoETosa"
RUN dotnet restore "./AgendamentoBanhoETosa.csproj"
COPY . .
RUN dotnet build "./AgendamentoBanhoETosa.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "./AgendamentoBanhoETosa.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final para execução
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgendamentoBanhoETosa.dll"]
