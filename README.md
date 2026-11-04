# EV06 – Aplicación de la Sintaxis Básica de C# (Proyecto Consola)

## 📌 Descripción del Proyecto
Este proyecto es una aplicación interactiva por consola desarrollada en **C#** que simula un sistema de gestión para una biblioteca (Libros, Usuarios, Préstamos, Búsquedas/Reportes y Persistencia). 

El objetivo principal es aplicar conceptos fundamentales de programación estructurada y sintaxis básica en C#, incluyendo:
- Navegación interactiva entre menús y submenús.
- Métodos y funciones estáticas (`static`).
- Estructuras de control condicionales (`if-else`, `switch-case`) e iterativas (`while`, `do-while`).
- Lectura y validación básica de entradas por consola.
- Simulación de procesos de negocio mediante stub de funciones (sin POO, sin colecciones avanzadas ni persistencia real).

---

## 🛠️ Tecnologías y Requisitos
- **Lenguaje:** C# (.NET SDK 6.0 / 7.0 / 8.0 o superior)
- **Entorno de Ejecución:** Consola / Terminal
- **Control de Versiones:** Git & Git Flow

---

## 🚀 Instrucciones de Ejecución

1. **Clonar el repositorio:**
   ```bash
   git clone <URL_DE_TU_REPOSITORIO>
   cd <NOMBRE_DE_TU_PROYECTO>
   ```

2. **Compilar y Ejecutar:**
   ```bash
   dotnet run
   ```

---

## 📋 Estructura de Navegación del Menú

```text
=== MENÚ PRINCIPAL ===
1. Libros
   ├── 1.1 Registrar libro
   ├── 1.2 Listar libros (Todos / Disponibles / Prestados)
   ├── 1.3 Ver detalle de libro (por ID/ISBN)
   ├── 1.4 Actualizar libro (Título / Autor / Año y Categoría)
   └── 1.5 Eliminar libro (Validación: no si está prestado)
2. Usuarios
   ├── 2.1 Registrar usuario
   ├── 2.2 Listar usuarios
   ├── 2.3 Ver detalle de usuario (por ID/Documento)
   ├── 2.4 Actualizar usuario (Nombre / Contacto / Activar-Desactivar)
   └── 2.5 Eliminar usuario (Validación: no si tiene préstamos activos)
3. Préstamos
   ├── 3.1 Crear préstamo (Validaciones simuladas)
   ├── 3.2 Listar préstamos (Todos / Activos / Cerrados)
   ├── 3.3 Ver detalle de préstamo
   ├── 3.4 Registrar devolución (Cambia a devuelto / marca libro disponible)
   └── 3.5 Eliminar préstamo (Regla de devolución automática)
4. Búsquedas y Reportes
   ├── 4.1 Buscar libro (por título, autor, id, categoría)
   ├── 4.2 Buscar usuario (por nombre, id)
   └── 4.3 Reportes (por usuario, por libro, vencidos, resumen general)
5. Guardar / Cargar datos
   ├── 5.1 Guardar datos
   ├── 5.2 Cargar datos
   └── 5.3 Reiniciar datos (Confirmación S/N)
6. Salir
   └── Preguntar: ¿Guardar antes de salir? (S/N)
```

---

## 🌿 Estrategia de Ramas (Git Flow)

El desarrollo del proyecto se gestionó siguiendo el modelo **Git Flow**, dividiendo cada funcionalidad por ramas de tipo `feature/` desde `develop` y finalizando con el merge a `main`:

* `feature/project-bootstrap`: Inicialización del proyecto, menú principal y flujo de salida.
* `feature/books-menu`: Submenú y funciones del módulo de Libros.
* `feature/users-menu`: Submenú y funciones del módulo de Usuarios.
* `feature/loans-menu`: Submenú y funciones del módulo de Préstamos.
* `feature/search-reports-menu`: Submenú de Búsquedas y Reportes.
* `feature/persistence-menu`: Submenú de Persistencia y reseteo de datos.

### Integración Final:
- Integración continua de features en la rama `develop`.
- Fusión de `develop` → `main` para el incremento funcional.
- Tag de versión: `v0.1-menu`.

---

## 📝 Convención de Commits Utilizada
- `feat:` adición de nuevas características o menús.
- `fix:` corrección de errores de flujo o validación de entradas.
- `docs:` actualización de documentación (README).