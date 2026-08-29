# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# --- SOLUCIONES PARA RENDER FREE ---
# 1. Evitar que crashee por límite de vigilantes de archivos (inotify)
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
# 2. Desactivar diagnósticos pesados
ENV DOTNET_EnableDiagnostics=0
# 3. Dar permisos de administrador (root) para que SQLite pueda crear su base de datos
USER root
# -----------------------------------

# Exponer puerto para Render
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "evaluacion20262.dll"]