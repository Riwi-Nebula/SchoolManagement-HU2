FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SchoolManagement.Api/SchoolManagement.Api.csproj", "SchoolManagement.Api/"]
COPY ["SchoolManagement.Domain/SchoolManagement.Domain.csproj", "SchoolManagement.Domain/"]
COPY ["SchoolManagement.Application/SchoolManagement.Application.csproj", "SchoolManagement.Application/"]
COPY ["SchoolManagement.Infraestructure/SchoolManagement.Infraestructure.csproj", "SchoolManagement.Infraestructure/"]
RUN dotnet restore "SchoolManagement.Api/SchoolManagement.Api.csproj"
COPY . .
WORKDIR "/src/SchoolManagement.Api"
RUN dotnet build "./SchoolManagement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SchoolManagement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolManagement.Api.dll"]
