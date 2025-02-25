# Antivirus Backend

Antivirus Backend es un conjunto de APIs desarrolladas en .NET 9 que proporciona funcionalidad para el desafío Antivirus. Utiliza Entity Framework para la conexión con una base de datos PostgreSQL e implementa autenticación mediante JWT. Además, incorpora Swagger para la documentación de los endpoints.

## Tecnologías utilizadas
- .NET 9
- Entity Framework Core
- PostgreSQL
- JWT para autenticación
- Swagger para documentación

## Requisitos previos
Antes de ejecutar el proyecto, asegúrate de tener instalado:
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)

## Instalación y configuración
1. Clonar el repositorio:
   ```sh
   git clone https://github.com/tu-usuario/antivirus-backend.git
   cd antivirus-backend
   ```

2. Configurar la cadena de conexión en `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Database=antivirus_db;Username=usuario;Password=contraseña"
   }
   ```

3. Aplicar las migraciones a la base de datos:
   ```sh
   dotnet ef database update
   ```

4. Ejecutar el proyecto:
   ```sh
   dotnet run
   ```

## Uso
Una vez en ejecución, la API estará disponible en:
- `http://localhost:5000`
- `https://localhost:5001`

La documentación de Swagger se encuentra en:
- `http://localhost:5000/swagger`

## Autenticación
El proyecto utiliza JWT para la autenticación. Para obtener un token, realiza una solicitud POST a `/api/login` con credenciales válidas.

## Despliegue con GitHub Actions en Azure
1. Configurar el archivo `azure-pipelines.yml` o `.github/workflows/deploy.yml`.
2. Definir los secretos necesarios en GitHub (`AZURE_WEBAPP_NAME`, `AZURE_CREDENTIALS`).
3. Automatizar el despliegue con GitHub Actions.

## Contribución
Si deseas contribuir, por favor sigue estos pasos:
1. Haz un fork del repositorio.
2. Crea una rama (`git checkout -b feature-nueva`).
3. Realiza los cambios y confirma (`git commit -m 'Descripción del cambio'`).
4. Envía los cambios (`git push origin feature-nueva`).
5. Crea un Pull Request.

## Licencia
Este proyecto está bajo la licencia MIT.
