# Corrected Dockerfile
 
# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
 
# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
 
# Copy only the .csproj first (for better build caching)
COPY ../Risk_Management_RiskEX_Backend/Risk_Management_RiskEX_Backend.csproj ./Risk_Management_RiskEX_Backend/
RUN dotnet restore "./Risk_Management_RiskEX_Backend/Risk_Management_RiskEX_Backend.csproj"
 
# Copy entire source code
COPY ../ ./
WORKDIR /src/Risk_Management_RiskEX_Backend
RUN dotnet build "./Risk_Management_RiskEX_Backend.csproj" -c $BUILD_CONFIGURATION -o /app/build
 
# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Risk_Management_RiskEX_Backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
 
# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Risk_Management_RiskEX_Backend.dll"]