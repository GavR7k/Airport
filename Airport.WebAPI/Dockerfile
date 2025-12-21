# Этап 1: SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY *.sln .
COPY Airport.WebAPI/*.csproj Airport.WebAPI/
COPY Airport.Infrastructure/*.csproj Airport.Infrastructure/
COPY Airport.Domain/*.csproj Airport.Domain/
COPY Airport.Application/*.csproj Airport.Application/
RUN dotnet restore

COPY . .
WORKDIR /src/Airport.WebAPI
RUN dotnet publish -c Release -o /app/publish

# Этап 2: Runtime для запуска
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Airport.WebAPI.dll"]
