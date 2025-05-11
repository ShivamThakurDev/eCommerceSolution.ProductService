#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProductService.API/ProductService.API.csproj", "ProductService.API/"]
COPY ["ProductService.BLL/ProductService.BLL.csproj", "ProductService.BLL/"]
COPY ["ProductService.DAL/ProductService.DAL.csproj", "ProductService.DAL/"]

# Restore as distinct layers
RUN dotnet restore "ProductService.API/ProductService.API.csproj"

# Copy everything else
COPY . .
WORKDIR "/src/ProductService.API"

# Build and publish
RUN dotnet build "ProductService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ProductService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductService.API.dll"]

# Add healthcheck (install curl if needed)
HEALTHCHECK --interval=30s --timeout=3s --retries=3 CMD curl -f http://localhost:8080/health || exit 1
