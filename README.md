## Instrucciones de Instalación y Uso.

**Antes de ejecutar la API, asegurar que tenga instalados lo siguiente:**

.NET SDK 8.0

Visual Studio 2022 o superior

SQL Server

## -Instalación.

Clonar o descargar el repositorio

Abrir Proyecto-API.sln en Visual Studio.

Configurar la base de datos

**Editar el archivo appsettings.json para configurar la conexión a la base de datos:**

"ConnectionStrings": {
   "DefaultConnection": "Server=SU_SERVIDOR;Database=SU_BASE_DE_DATOS;Trusted_Connection=True;"

**Ejecute las migraciones de la base de datos:**

   dotnet ef database update

## -Ejecute la API
Desde Visual Studio, presionar Ctrl + F5 para iniciar el proyecto.

## -Endpoints Disponibles

**Productos**

GET /api/productos - Obtener todos los productos

GET /api/productos/{id} - Obtener un producto por ID

POST /api/productos - Crear un nuevo producto

PUT /api/productos/{id} - Actualizar un producto

DELETE /api/productos/{id} - Eliminar un producto

## -El tipo de Tecnológias que se usaron:

**C# / .NET 8.0**

**ASP.NET Core Web API**

**Entity Framework Core**

**SQL Server**
