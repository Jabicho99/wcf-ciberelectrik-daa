# Ciclo 6 — Versión corregida y completa

Versión corregida de [`../ciclo5-original`](../ciclo5-original), construida en una copia independiente para no modificar el trabajo entregado en el ciclo anterior. Cubre las 10 tablas pedidas por el enunciado del curso (Categoría, Marca, Sexo, Tipo de Documento, Rol, Distrito, Estado Civil, Producto, Empleado, Cliente) en los 3 laboratorios.

## Qué se corrigió respecto al ciclo 5

- **Estado Civil, construida desde cero** en los 3 laboratorios: entidad en el modelo de datos (EDM en lab03/lab04), `[OperationContract]`s en el servicio WCF (`estadocivilfindAll/add/update/delete/enable`), y formulario CRUD completo en la aplicación de consumo.
- **Empleado y Cliente completados**: se agregaron las columnas `fecha`, `nacionalidad` y la relación con Estado Civil, tanto en el modelo de datos como en los formularios de alta/edición.
- El resto de la arquitectura de cada laboratorio se mantuvo igual a la del ciclo 5 (que ya estaba correcta), solo extendida para cubrir lo que faltaba.

## Arquitectura por laboratorio

| Laboratorio | Patrón | Detalle |
|---|---|---|
| `laboratorio02` | ADO.NET + Stored Procedures | El servicio WCF invoca procedimientos almacenados directamente vía `SqlCommand`. |
| `laboratorio03` | Entity Framework + LINQ | El servicio WCF consulta el `DbContext` directamente con LINQ, sin procedimientos almacenados. |
| `laboratorio04` | Entity Framework + Stored Procedures | Los procedimientos almacenados se mapean en el EDM como *Function Imports*, expuestos como métodos tipados del `DbContext` (`ExecuteFunction`/`ExecuteFunction<T>`). |

## Verificación

Los 3 proyectos de servicio y sus 3 aplicaciones de consumo compilan sin errores (`MSBuild -t:Build`). El servicio de `laboratorio04` (el más complejo, por combinar EF con procedimientos almacenados) fue además probado en ejecución con llamadas SOAP reales — incluyendo una lectura con join multi-tabla y una operación de escritura — contra la base de datos del curso.
