# Acesse https://aka.ms/custo# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AgendamentoBanhoETosa/AgendamentoBanhoETosa.csproj", "./"]
RUN dotnet restore "AgendamentoBanhoETosa.csproj"

# Copia todos os arquivos para a pasta de build
COPY . .
RUN dotnet build "AgendamentoBanhoETosa.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "AgendamentoBanhoETosa.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgendamentoBanhoETosa.dll"]
