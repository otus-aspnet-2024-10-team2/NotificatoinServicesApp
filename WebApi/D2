FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApi/WebApi.csproj", "WebApi/"]
COPY ["Infrastructure.EF/Infrastructure.EF.csproj", "Infrastructure.EF/"]
COPY ["Core.Entity/Core.Entity.csproj", "Core.Entity/"]
COPY ["Infrastructure.Repositories.Implementations/Infrastructure.Repositories.Implementations.csproj", "Infrastructure.Repositories.Implementations/"]
COPY ["Services.Repositories/Services.Repositories.csproj", "Services.Repositories/"]
COPY ["Services.Contracts/Services.Contracts.csproj", "Services.Contracts/"]
COPY ["Services.Abstractions/Services.Abstractions.csproj", "Services.Abstractions/"]
COPY ["Services.Implementations/Services.Implementations.csproj", "Services.Implementations/"]
RUN dotnet restore "WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]
