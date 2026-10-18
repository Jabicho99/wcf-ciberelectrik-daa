# WCF CiberElectrik — Desarrollo de Aplicaciones Avanzado (ISIL)

Laboratorios de servicios WCF para el curso **Desarrollo de Aplicaciones Avanzado (DAA)**, sobre un sistema de gestión para una tienda ficticia ("CiberElectrik"). Cada laboratorio expone las mismas 10 tablas del dominio (Categoría, Marca, Sexo, Tipo de Documento, Rol, Distrito, Estado Civil, Producto, Empleado, Cliente) mediante un patrón de arquitectura distinto, junto con una aplicación ASP.NET Web Forms que las consume.

Este repositorio conserva **dos versiones** del mismo trabajo para poder compararlas:

| Carpeta | Ciclo | Estado |
|---|---|---|
| [`ciclo5-original/`](ciclo5-original) | Ciclo 5 | Versión original entregada — **incompleta**: falta la entidad Estado Civil y algunos campos de Empleado/Cliente |
| [`ciclo6-corregido/`](ciclo6-corregido) | Ciclo 6 | Versión corregida y completada — 10/10 tablas, verificada en ejecución |

## Laboratorios

- **laboratorio02** — WCF + ADO.NET puro, con procedimientos almacenados invocados directamente.
- **laboratorio03** — WCF + Entity Framework, consultas vía LINQ sobre el `DbContext`.
- **laboratorio04** — WCF + Entity Framework + Procedimientos Almacenados, mapeados como *Function Imports* del modelo EDM.

Cada laboratorio incluye el proyecto de servicio (`CiberElectrikWCF*`) y su aplicación de consumo (`ConsumoWCF*`), con sus respectivos archivos `.slnx` para abrirlos en Visual Studio.

## Nota sobre configuración local

Las cadenas de conexión a SQL Server fueron reemplazadas por marcadores genéricos (`YOUR_SERVER`, `YOUR_USER`, `YOUR_PASSWORD`) antes de publicar este repositorio. Para ejecutar cualquiera de los laboratorios, ajusta `ConexionDAL.cs` y el `Web.config` del proyecto de servicio con los datos de tu propia instancia de SQL Server y restaura la base de datos `bdciberelectrik*`.
