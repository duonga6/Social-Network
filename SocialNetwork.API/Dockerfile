#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 9999

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SocialNetwork.API/SocialNetwork.API.csproj", "SocialNetwork.API/"]
COPY ["SocialNetwork.Business/SocialNetwork.Business.csproj", "SocialNetwork.Business/"]
COPY ["SocialNetwork.DataAccess/SocialNetwork.DataAccess.csproj", "SocialNetwork.DataAccess/"]
RUN dotnet restore "./SocialNetwork.API/./SocialNetwork.API.csproj"
COPY . .
WORKDIR "/src/SocialNetwork.API"
RUN dotnet build "./SocialNetwork.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SocialNetwork.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "SocialNetwork.API.dll"]