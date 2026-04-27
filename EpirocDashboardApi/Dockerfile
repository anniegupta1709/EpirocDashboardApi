FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore EpirocDashboardApi/EpirocDashboardApi/EpirocDashboardApi.csproj
RUN dotnet publish EpirocDashboardApi/EpirocDashboardApi/EpirocDashboardApi.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "EpirocDashboardApi.dll"]