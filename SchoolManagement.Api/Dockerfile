# -------------------------------
# ---- Build stage (compila la app)
# -------------------------------
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar los archivos de proyecto primero (para aprovechar la caché)
COPY ["SchoolManagement.Api/SchoolManagement.Api.csproj", "SchoolManagement.Api/"]
COPY ["SchoolManagement.Application/SchoolManagement.Application.csproj", "SchoolManagement.Application/"]
COPY ["SchoolManagement.Domain/SchoolManagement.Domain.csproj", "SchoolManagement.Domain/"]
COPY ["SchoolManagement.Infraestructure/SchoolManagement.Infraestructure.csproj", "SchoolManagement.Infraestructure/"]

# Restaurar dependencias
RUN dotnet restore "SchoolManagement.Api/SchoolManagement.Api.csproj"

# Copiar todo el código fuente
COPY . .

# Publicar el proyecto
WORKDIR /src/SchoolManagement.Api
RUN dotnet publish "SchoolManagement.Api.csproj" -c Release -o /app/publish --no-restore


# -------------------------------
# ---- Runtime stage (ejecuta la app)
# -------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Variables de entorno recomendadas
ENV ASPNETCORE_URLS=http://+:80
ENV DOTNET_RUNNING_IN_CONTAINER=true

# Copiar la app publicada
COPY --from=build /app/publish .

# Exponer el puerto 80 para HTTP
EXPOSE 80

# Punto de entrada
ENTRYPOINT ["dotnet", "SchoolManagement.Api.dll"]
