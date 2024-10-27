FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PlaceCheck.WebApi/PlaceCheck.WebApi.csproj", "PlaceCheck.WebApi/"]
COPY ["PlaceCheck.Application/PlaceCheck.Application.csproj", "PlaceCheck.Application/"]
COPY ["PlaceCheck.Domain/PlaceCheck.Domain.csproj", "PlaceCheck.Domain/"]
COPY ["PlaceCheck.Infrastructure/PlaceCheck.Infrastructure.csproj", "PlaceCheck.Infrastructure/"]
RUN dotnet restore "PlaceCheck.WebApi/PlaceCheck.WebApi.csproj"
COPY . .
WORKDIR "/src/PlaceCheck.WebApi"
RUN dotnet build "PlaceCheck.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PlaceCheck.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlaceCheck.WebApi.dll"]
