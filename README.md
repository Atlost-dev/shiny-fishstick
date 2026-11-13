# API de Eventos

API REST hecha con ASP.NET Core (.NET 10) y Entity Framework Core sobre SQL Server para registrar y administrar eventos: nombre, categoría, fecha, lugar, cupo máximo y si el evento está activo.

El proyecto está organizado en capas:

- **Controllers** (`EventosController`): recibe las peticiones HTTP y devuelve la respuesta adecuada.
- **Services** (`EventoService`): aplica las reglas de negocio.
- **Repositories** (`EventoSQLRepository`): lee y escribe en la base de datos.
- **Data** (`AppDbContext`): define la conexión de Entity Framework Core.
- **Models** (`Evento`): describe la entidad.

## Modelo `Evento`

| Campo | Tipo | Descripción |
|---|---|---|
| `id` | int | Identificador único, lo asigna la base de datos |
| `nombre` | string | Nombre del evento |
| `categoria` | string | Categoría del evento |
| `fecha` | string | Fecha del evento (recomendado `AAAA-MM-DD`) |
| `lugar` | string | Lugar de realización |
| `cupoMax` | int | Cupo máximo de asistentes |
| `activo` | bool | Indica si el evento está activo |

## Reglas de negocio

Se validan al crear (`POST`) y al actualizar (`PUT`). Si alguna no se cumple, la API responde `400 Bad Request` con un mensaje:

- El nombre es obligatorio.
- El cupo debe ser mayor que cero.
- La fecha debe ser válida.

```json
{ "mensaje": "El cupo debe ser mayor que cero." }
```

## Endpoints

| Método | Ruta | Descripción | Respuestas |
|---|---|---|---|
| GET | `/api/Eventos` | Obtiene todos los eventos | `200 OK` |
| GET | `/api/Eventos/{id}` | Obtiene un evento por su Id | `200 OK`, `404 Not Found` |
| POST | `/api/Eventos` | Registra un nuevo evento | `201 Created`, `400 Bad Request` |
| PUT | `/api/Eventos/{id}` | Actualiza un evento existente | `204 No Content`, `400 Bad Request`, `404 Not Found` |
| DELETE | `/api/Eventos/{id}` | Elimina un evento | `204 No Content`, `404 Not Found` |

### Ejemplo de cuerpo para `POST` / `PUT`

```json
{
  "nombre": "Feria de Ciencias",
  "categoria": "Académico",
  "fecha": "2026-12-05",
  "lugar": "Auditorio principal",
  "cupoMax": 150,
  "activo": true
}
```

## Cómo ejecutar

1. Agrega la cadena de conexión `DefaultConnection` en `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=EventosDB;User Id=sa;Password=<tu_password>;TrustServerCertificate=True"
   }
   ```

2. Crea la base de datos con las migraciones:

   ```bash
   dotnet ef migrations add Inicial
   dotnet ef database update
   ```

3. Ejecuta la API:

   ```bash
   dotnet run
   ```

4. En modo desarrollo, abre Swagger UI en `http://localhost:5260/swagger`.
