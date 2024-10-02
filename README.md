# Api-.Net-NodeJs-Test
 Apis desarrolladas en .Net 8, NodeJs,
 
 Herramientas usadas en .Net 8 son: Entity Framework Core, Entity Framework SQL Server, XUnit para pruebas unitarias, herramienta de desarrollo visual studio 2022
 
 Herramientas usadas en NodeJs son : mssql para conectar con SQLServer y Jest para las pruebas unitarias, herramienta de desarrollo WebStorm
 
 Primero, realizar la parametrización de los archivos de configuración del proyecto .Net el cual es el AppSettings y para NodeJs db_context_ss.js.

 Con el host del SQLServer donde se creará la base de datos, su usuario, contraseña y el nombre de cómo se llamará la base de datos.
 
 Segundo, se debe realizar en la consulta del administrador de paquetes de visual studio 2022 ejecutar el siguiente comando para realizar la migración, donde se realizará la creación de la base de datos como los procesos almacenados:
 Update-DataBase -Project Prueba.DataAccess -StartupProject Prueba.Api
 
 Ejecución
 NodeJs se usa los comandos para iniciar el proyecto en el puerto 3000:
 npm init -y
 node index.js
 
 y con WebStorm se ejecuta el archivo index.js

 Método DELETE
 Eliminación de un producto cuando se hayan creado.
 http://localhost:3000/api/products?Id=IdDelProducto
 
 Método PUT
 Actualización de un producto
 http://localhost:3000/api/products
 Json Body:
 {
   "id": 1,
   "name": "Tenis",
   "description": "Muy comodos",
   "price": 150000,
   "stock": 120
 }
 
 Para la ejecución de las pruebas se usa el comando
 npx jest .\product.test.js
 
 y con WebStorm se ejecuta el archivo product.test.js
 
 .Net 8 se ejecuta el proyecto de la tradicional de visual studio 2022 y las pruebas usando la ventana de Text Explorer
 
 Para el manejo de los procesos almacenados en NodeJs primero los parametros reueridos para luego realizar un lanzamiento a la base de datos al procedimiento que se desea ejecutar usando la libreria mssql
 
 Para .Net se usa Entity Framework donde, usando los métodos de ExecuteSqlRawAsync para el tema de POST, PUT y DELETE, se coloca el procedimiento que se quiere usar con los parámetros que se requieren y para los Get FromSqlRaw según si requiere parámetros