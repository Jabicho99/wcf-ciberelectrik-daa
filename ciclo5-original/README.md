# Ciclo 5 — Versión original (incompleta)

Esta es la versión entregada originalmente en el ciclo 5 del curso, reutilizada como punto de partida para el ciclo 6. Se conserva tal cual para dejar constancia de qué parte del trabajo estaba incompleta antes de la corrección (ver [`../ciclo6-corregido`](../ciclo6-corregido)).

## Qué falló aquí

- **Falta por completo la entidad Estado Civil.** No existe ni en el modelo de datos (EDM en lab03/lab04, ni tabla referenciada en lab02), ni como `[OperationContract]` en el servicio WCF, ni como formulario en la aplicación de consumo. De las 10 tablas pedidas por el enunciado, esta versión solo cubre 9.
- **Empleado y Cliente están incompletos.** Les faltan las columnas `fecha` (nacimiento), `nacionalidad` y la relación con Estado Civil (`codestc`/FK), aunque esas columnas sí existen en la base de datos real del curso.
- El resto de tablas (Categoría, Marca, Sexo, Tipo de Documento, Rol, Distrito, Producto) y el patrón arquitectónico de cada laboratorio (ADO.NET+SP / EF+LINQ / EF+SP) sí estaban correctamente implementados — el problema es puntual a Estado Civil y a esos campos de Empleado/Cliente, no al resto del proyecto.

## Laboratorios incluidos

- `laboratorio02` — WCF + ADO.NET + procedimientos almacenados.
- `laboratorio03` — WCF + Entity Framework (LINQ).
- `laboratorio04` — WCF + Entity Framework + procedimientos almacenados (Function Imports).
