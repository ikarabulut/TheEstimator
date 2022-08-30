FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app

COPY . ./

RUN dotnet restore

RUN dotnet publish -c Release -o published

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/published .
ENTRYPOINT ["dotnet", "TheEstimator.dll"]
