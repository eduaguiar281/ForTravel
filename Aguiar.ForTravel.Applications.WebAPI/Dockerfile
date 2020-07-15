FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Aguiar.ForTravel.Applications.WebAPI/Aguiar.ForTravel.Applications.WebAPI.csproj", "Aguiar.ForTravel.Applications.WebAPI/"]
RUN dotnet restore "Aguiar.ForTravel.Applications.WebAPI/Aguiar.ForTravel.Applications.WebAPI.csproj"
COPY . .
WORKDIR "/src/Aguiar.ForTravel.Applications.WebAPI"
RUN dotnet build "Aguiar.ForTravel.Applications.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aguiar.ForTravel.Applications.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aguiar.ForTravel.Applications.WebAPI.dll"]