FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Garante que a pasta /app existe e tem permissão total para leitura/escrita
RUN mkdir -p /app && chmod 777 /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "CafeteriaApi/CafeteriaApi.csproj"
RUN dotnet publish "CafeteriaApi/CafeteriaApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CafeteriaApi.dll"]
