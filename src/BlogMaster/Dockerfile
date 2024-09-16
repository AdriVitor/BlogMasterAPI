#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BlogMaster_API/BlogMaster_API.csproj", "BlogMaster_API/"]
COPY ["BlogMaster_Application/BlogMaster_Application.csproj", "BlogMaster_Application/"]
COPY ["BlogMaster_Domain/BlogMaster_Domain.csproj", "BlogMaster_Domain/"]
COPY ["BlogMaster_Infraestructure/BlogMaster_Infraestructure.csproj", "BlogMaster_Infraestructure/"]
RUN dotnet restore "./BlogMaster_API/BlogMaster_API.csproj"
COPY . .
WORKDIR "/src/BlogMaster_API"
RUN dotnet build "./BlogMaster_API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BlogMaster_API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlogMaster_API.dll"]