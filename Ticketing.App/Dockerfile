#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ticketing.App/Ticketing.App.csproj", "Ticketing.App/"]
COPY ["Ticketing.Application/Ticketing.Application.csproj", "Ticketing.Application/"]
COPY ["Shared.Abstractions/Shared.Abstractions.csproj", "Shared.Abstractions/"]
COPY ["Shared.Constants/Shared.Constants.csproj", "Shared.Constants/"]
COPY ["Ticketing.Domain/Ticketing.Domain.csproj", "Ticketing.Domain/"]
COPY ["Ticketing.Infrastructure/Ticketing.Infrastructure.csproj", "Ticketing.Infrastructure/"]
RUN dotnet restore "./Ticketing.App/Ticketing.App.csproj"
COPY . .
WORKDIR "/src/Ticketing.App"
RUN dotnet build "./Ticketing.App.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Ticketing.App.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ticketing.App.dll"]