# DBFirst-formularaceExample

# ClothingStore

## Comenzando 🚀
### Pre-requisitos 📋

- .NET 7.0
- MySQL
### Estrucutra de la base de datos utilizada
![image](https://github.com/yllensc/DBFirst-formularaceExample/assets/117176562/84e86f51-3758-4a55-b7e5-a84b32212d93)

### Instalación 🔧

Migración de la base de datos (db-first migration) y modelo de 3 capas:
Ejecuta los comandos una vez generada la estructura de la base de datos:
```
dotnet ef dbcontext scaffold "server=localhost;user=root;password=tucontraseña;database=formularace" Pomelo.EntityFrameworkCore.MySql -s API -p Infraestructure --context DbFirstContext --output-dir Entities
```
Luego, modifica las entidades, archivos de configuración y demás para poder hacer la migración:
```
dotnet ef migrations add InitialCreate -p Infraestructure -s API -o Data/Migrations
```

Ejecución de la WebApi (desde la ruta del proyecto):
Ejecuta los comandos:
```
1. cd API
2. dotnet run
```
## Ejecutando las pruebas ⚙️
### Ojito 👀:
El proyecto tiene una colección de postman con el CRUD para Team y Driver.
Aquí ➡️: [CollectionPostman](https://github.com/yllensc/DBFirst-formularaceExample/blob/main/campusDBFirst.postman_collection.json)

La estructura base de los Dto, a través del método GET, es la siguiente:
### Team
![image](https://github.com/yllensc/DBFirst-formularaceExample/assets/117176562/6b23bd70-930d-4e92-bfc5-611c1e857d1e)

### Driver
![image](https://github.com/yllensc/DBFirst-formularaceExample/assets/117176562/f870d56e-57b1-4cc4-a1c3-a787b142762a)

## Construido con 🛠️

* [ASP.NET Core]([http://www.dropwizard.io/1.0.2/docs/](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio)) - El framework web usado
* [MySql]([https://maven.apache.org/](https://dev.mysql.com/doc/workbench/en/wb-mysql-utilities.html)) - Base de datos


## Autor✒️

* **Yllen Santamaría** - [Yllensc](https://github.com/yllensc)
