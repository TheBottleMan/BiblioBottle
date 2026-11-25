using System;
using BiblioBottle.Models;

class Program
{
    static void Main(string[] args)
    {
        ShowMainMenu();
    }

    // ==========================================
    // OBJETOS DE PRUEBA (EV07)
    // ==========================================
    static (Libro libro1, Libro libro2) CrearLibrosPrueba()
    {
        Libro libro1 = new Libro(
            1,
            "978-0321125217",
            "Domain-Driven Design",
            "Eric Evans",
            2003,
            "Arquitectura de Software"
        );

        Libro libro2 = new Libro();
        libro2.Id = 2;
        libro2.Isbn = "978-0132350884";
        libro2.Titulo = "Clean Code";
        libro2.Autor = "Robert C. Martin";
        libro2.Anio = 2008;
        libro2.Categoria = "Ingeniería de Software";
        libro2.Disponible = false; // Validación de libro no disponible / prestado

        return (libro1, libro2);
    }

    static (Usuario usuario1, Usuario usuario2) CrearUsuariosPrueba()
    {
        Usuario usuario1 = new Usuario(
            1,
            "1020304050",
            "Camila Restrepo",
            "camila.restrepo@correo.com"
        );

        Usuario usuario2 = new Usuario();
        usuario2.Id = 2;
        usuario2.Documento = "9876543210";
        usuario2.Nombre = "Andrés Morales";
        usuario2.Contacto = "3004567890";
        usuario2.Activo = false; // Validación de usuario inactivo

        return (usuario1, usuario2);
    }

    static Prestamo CrearPrestamoPrueba()
    {
        // Préstamo con fecha límite pasada para validar EstaVencido() y DiasTranscurridos()
        return new Prestamo(
            101,
            2,
            1,
            DateTime.Now.AddDays(-10),
            DateTime.Now.AddDays(-3),
            null,
            EstadoPrestamo.Activo
        );
    }

    static void MostrarValidacionesModelos(Libro l1, Libro l2, Usuario u1, Usuario u2, Prestamo p1)
    {
        Console.WriteLine("\n--- VALIDACIONES DE ESTADOS Y MÉTODOS ---");
        Console.WriteLine($"Libro 1 Disponible: {l1.Disponible}");
        Console.WriteLine($"Libro 2 Disponible: {l2.Disponible}");
        Console.WriteLine($"Usuario 1 Activo: {u1.Activo}");
        Console.WriteLine($"Usuario 2 Activo: {u2.Activo}");
        Console.WriteLine($"Préstamo Estado inicial: {p1.Estado} | FechaDevolucion: {(p1.FechaDevolucion.HasValue ? p1.FechaDevolucion.Value.ToString("yyyy-MM-dd") : "null")}");
        Console.WriteLine($"Préstamo EstaVencido(): {p1.EstaVencido()}");
        Console.WriteLine($"Préstamo DiasTranscurridos(): {p1.DiasTranscurridos()}");
    }

    // ==========================================
    // MENÚ PRINCIPAL Y NAVEGACIÓN
    // ==========================================
    static void ShowMainMenu()
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. Búsquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine() ?? string.Empty;

            switch (opcion)
            {
                case "1":
                    ShowBooksMenu();
                    break;
                case "2":
                    ShowUsersMenu();
                    break;
                case "3":
                    ShowLoansMenu();
                    break;
                case "4":
                    ShowSearchReportsMenu();
                    break;
                case "5":
                    ShowPersistenceMenu();
                    break;
                case "6":
                    salir = ConfirmExitAndSave();
                    break;
                default:
                    Console.WriteLine("\nOpción inválida. Intente de nuevo.");
                    Pausar();
                    break;
            }
        }
    }

    static bool ConfirmExitAndSave()
    {
        Console.Clear();
        Console.Write("¿Desea guardar los cambios antes de salir? (S/N): ");
        string respuesta = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();

        if (respuesta == "S")
        {
            Console.WriteLine("Simulación: Guardando datos antes de salir...");
        }

        Console.WriteLine("\nSaliendo de la aplicación. ¡Hasta pronto!");
        return true;
    }

    static void Pausar()
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    // ==========================================
    // 1. MÓDULO DE LIBROS
    // ==========================================
    static void ShowBooksMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- GESTIÓN DE LIBROS ---");
            Console.WriteLine("1.1 Registrar libro");
            Console.WriteLine("1.2 Listar libros");
            Console.WriteLine("1.3 Ver detalle de libro (por ID/ISBN)");
            Console.WriteLine("1.4 Actualizar libro");
            Console.WriteLine("1.5 Eliminar libro");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine() ?? string.Empty;

            switch (opcion)
            {
                case "1.1":
                case "1":
                    RegisterBook();
                    break;
                case "1.2":
                case "2":
                    ListBooksMenu();
                    break;
                case "1.3":
                case "3":
                    ViewBookDetail();
                    break;
                case "1.4":
                case "4":
                    UpdateBookMenu();
                    break;
                case "1.5":
                case "5":
                    DeleteBook();
                    break;
                case "0":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("\nOpción no válida.");
                    Pausar();
                    break;
            }
        }
    }

    static void RegisterBook()
    {
        Console.Clear();
        Console.WriteLine("--> [Registrar libro]");
        Console.WriteLine("Simulación: Libro registrado exitosamente en el diccionario/estructura.");
        Pausar();
    }

    static void ListBooksMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- LISTAR LIBROS ---");
            Console.WriteLine("1.2.1 Listar todos");
            Console.WriteLine("1.2.2 Listar disponibles");
            Console.WriteLine("1.2.3 Listar prestados");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine() ?? string.Empty;
            switch (opcion)
            {
                case "1.2.1":
                case "1":
                    ListBooksAll();
                    break;
                case "1.2.2":
                case "2":
                    ListBooksAvailable();
                    break;
                case "1.2.3":
                case "3":
                    ListBooksBorrowed();
                    break;
                case "0":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("\nOpción inválida.");
                    Pausar();
                    break;
            }
        }
    }

    static void ListBooksAll()
    {
        Console.Clear();
        Console.WriteLine("--> [Listar todos los libros - Objetos de prueba EV07]");
        var (l1, l2) = CrearLibrosPrueba();
        Console.WriteLine("Resumen 1 (ResumenCorto): " + l1.ResumenCorto());
        Console.WriteLine("Resumen 2 (ToString): " + l2.ToString());
        Console.WriteLine($"\nValidación Disponible -> Libro 1: {l1.Disponible} | Libro 2: {l2.Disponible}");
        Pausar();
    }

    static void ListBooksAvailable()
    {
        Console.Clear();
        Console.WriteLine("--> [Listar libros disponibles]");
        var (l1, l2) = CrearLibrosPrueba();
        if (l1.Disponible) Console.WriteLine(l1.ResumenCorto());
        if (l2.Disponible) Console.WriteLine(l2.ResumenCorto());
        Pausar();
    }

    static void ListBooksBorrowed()
    {
        Console.Clear();
        Console.WriteLine("--> [Listar libros prestados]");
        var (l1, l2) = CrearLibrosPrueba();
        if (!l1.Disponible) Console.WriteLine(l1.ResumenCorto());
        if (!l2.Disponible) Console.WriteLine(l2.ResumenCorto());
        Pausar();
    }

    static void ViewBookDetail()
    {
        Console.Clear();
        Console.WriteLine("--> [Ver detalle de libro - Objetos de prueba EV07]");
        Console.Write("Ingrese el ID o ISBN del libro (o Enter para ver ambos): ");
        Console.ReadLine();

        var (l1, l2) = CrearLibrosPrueba();
        Console.WriteLine();
        Console.WriteLine(l1.DetalleCompleto());
        Console.WriteLine();
        Console.WriteLine(l2.DetalleCompleto());
        Console.WriteLine($"\nValidación Disponible -> Libro 1: {l1.Disponible} | Libro 2: {l2.Disponible}");
        Pausar();
    }

    static void UpdateBookMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- ACTUALIZAR LIBRO ---");
            Console.WriteLine("1.4.1 Editar título");
            Console.WriteLine("1.4.2 Editar autor");
            Console.WriteLine("1.4.3 Editar año / categoría");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine() ?? string.Empty;
            switch (opcion)
            {
                case "1.4.1":
                case "1":
                    EditBookTitle();
                    break;
                case "1.4.2":
                case "2":
                    EditBookAuthor();
                    break;
                case "1.4.3":
                case "3":
                    EditBookYearCategory();
                    break;
                case "0":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("\nOpción inválida.");
                    Pausar();
                    break;
            }
        }
    }

    static void EditBookTitle()
    {
        Console.Clear();
        Console.WriteLine("--> [Editar título del libro]");
        Console.WriteLine("Simulación: Título actualizado correctamente.");
        Pausar();
    }

    static void EditBookAuthor()
    {
        Console.Clear();
        Console.WriteLine("--> [Editar autor del libro]");
        Console.WriteLine("Simulación: Autor actualizado correctamente.");
        Pausar();
    }

    static void EditBookYearCategory()
    {
        Console.Clear();
        Console.WriteLine("--> [Editar año / categoría del libro]");
        Console.WriteLine("Simulación: Año y categoría actualizados correctamente.");
        Pausar();
    }

    static void DeleteBook()
    {
        Console.Clear();
        Console.WriteLine("--> [Eliminar libro]");
        Console.WriteLine("Validación: Comprobando que el libro no esté prestado...");
        Console.WriteLine("Simulación: Libro eliminado correctamente.");
        Pausar();
    }

    // ==========================================
    // 2. MÓDULO DE USUARIOS
    // ==========================================
    static void ShowUsersMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- GESTIÓN DE USUARIOS ---");
            Console.WriteLine("2.1 Registrar usuario");
            Console.WriteLine("2.2 Listar usuarios");
            Console.WriteLine("2.3 Ver detalle de usuario");
            Console.WriteLine("2.4 Actualizar usuario");
            Console.WriteLine("2.5 Eliminar usuario");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine() ?? string.Empty;

            switch (opcion)
            {
                case "2.1":
                case "1":
                    RegisterUser();
                    break;
                case "2.2":
                case "2":
                    ListUsers();
                    break;
                case "2.3":
                case "3":
                    ViewUserDetail();
                    break;
                case "2.4":
                case "4":
                    UpdateUserMenu();
                    break;
                case "2.5":
                case "5":
                    DeleteUser();
                    break;
                case "0":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("\nOpción no válida.");
                    Pausar();
                    break;
            }
        }
    }

    static void RegisterUser()
    {
        Console.Clear();
        Console.WriteLine("--> [Registrar usuario]");
        Console.WriteLine("Simulación: Usuario registrado exitosamente.");
        Pausar();
    }

    static void ListUsers()
    {
        Console.Clear();
        Console.WriteLine("--> [Listar usuarios - Objetos de prueba EV07]");
        var (u1, u2) = CrearUsuariosPrueba();
        Console.WriteLine("Resumen 1 (ResumenCorto): " + u1.ResumenCorto());
        Console.WriteLine("Resumen 2 (ToString): " + u2.ToString());
        Console.WriteLine($"\nValidación Activo -> Usuario 1: {u1.Activo} | Usuario 2: {u2.Activo}");
        Pausar();
    }

    static void ViewUserDetail()
    {
        Console.Clear();
        Console.WriteLine("--> [Ver detalle de usuario - Objetos de prueba EV07]");
        Console.Write("Ingrese el ID o documento del usuario (o Enter para ver ambos): ");
        Console.ReadLine();

        var (u1, u2) = CrearUsuariosPrueba();
        Console.WriteLine();
        Console.WriteLine(u1.DetalleCompleto());
        Console.WriteLine();
        Console.WriteLine(u2.DetalleCompleto());
        Console.WriteLine($"\nValidación Activo -> Usuario 1: {u1.Activo} | Usuario 2: {u2.Activo}");
        Pausar();
    }

    static void UpdateUserMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- ACTUALIZAR USUARIO ---");
            Console.WriteLine("2.4.1 Editar nombre");
            Console.WriteLine("2.4.2 Editar contacto");
            Console.WriteLine("2.4.3 Activar / desactivar");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine() ?? string.Empty;
            switch (opcion)
            {
                case "2.4.1":
                case "1":
                    EditUserName();
                    break;
                case "2.4.2":
                case "2":
                    EditUserContact();
                    break;
                case "2.4.3":
                case "3":
                    ToggleUserActiveStatus();
                    break;
                case "0":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("\nOpción inválida.");
                    Pausar();
                    break;
            }
        }
    }

    static void EditUserName()
    {
        Console.Clear();
        Console.WriteLine("--> [Editar nombre de usuario]");
        Console.WriteLine("Simulación: Nombre actualizado correctamente.");
        Pausar();
    }

    static void EditUserContact()
    {
        Console.Clear();
        Console.WriteLine("--> [Editar contacto de usuario]");
        Console.WriteLine("Simulación: Contacto actualizado correctamente.");
        Pausar();
    }

    static void ToggleUserActiveStatus()
    {
        Console.Clear();
        Console.WriteLine("--> [Activar / Desactivar usuario]");
        Console.WriteLine("Simulación: Estado del usuario cambiado.");
        Pausar();
    }

    static void DeleteUser()
    {
        Console.Clear();
        Console.WriteLine("--> [Eliminar usuario]");
        Console.WriteLine("Validación: Verificando que no tenga préstamos activos...");
        Console.WriteLine("Simulación: Usuario eliminado correctamente.");
        Pausar();
    }

    // ==========================================
    // 3. MÓDULO DE PRÉSTAMOS
    // ==========================================
    static void ShowLoansMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- GESTIÓN DE PRÉSTAMOS ---");
            Console.WriteLine("3.1 Crear préstamo");
            Console.WriteLine("3.2 Listar préstamos");
            Console.WriteLine("3.3 Ver detalle de préstamo");
            Console.WriteLine("3.4 Registrar devolución");
            Console.WriteLine("3.5 Eliminar préstamo");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine() ?? string.Empty;

            switch (opcion)
            {
                case "3.1":
                case "1":
                    CreateLoan();
                    break;
                case "3.2":
                case "2":
                    ListLoansMenu();
                    break;
                case "3.3":
                case "3":
                    ViewLoanDetail();
                    break;
                case "3.4":
                case "4":
                    RegisterReturn();
                    break;
                case "3.5":
                case "5":
                    DeleteLoan();
                    break;
                case "0":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("\nOpción no válida.");
                    Pausar();
                    break;
            }
        }
    }

    static void CreateLoan()
    {
        Console.Clear();
        Console.WriteLine("--> [Crear préstamo]");
        Console.WriteLine("Validaciones en proceso:");
        Console.WriteLine("- Comprobando que el usuario existe y está activo...");
        Console.WriteLine("- Comprobando que el libro existe y está disponible...");
        Console.WriteLine("- Verificando límite de préstamos activos...");
        Console.WriteLine("Simulación: Préstamo creado exitosamente.");
        Pausar();
    }

    static void ListLoansMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- LISTAR PRÉSTAMOS ---");
            Console.WriteLine("3.2.1 Todos");
            Console.WriteLine("3.2.2 Activos");
            Console.WriteLine("3.2.3 Cerrados (devueltos)");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine() ?? string.Empty;
            switch (opcion)
            {
                case "3.2.1":
                case "1":
                    ListLoansAll();
                    break;
                case "3.2.2":
                case "2":
                    ListLoansActive();
                    break;
                case "3.2.3":
                case "3":
                    ListLoansClosed();
                    break;
                case "0":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("\nOpción inválida.");
                    Pausar();
                    break;
            }
        }
    }

    static void ListLoansAll()
    {
        Console.Clear();
        Console.WriteLine("--> [Listar todos los préstamos - Objeto de prueba EV07]");
        var prestamo = CrearPrestamoPrueba();
        Console.WriteLine("Resumen (ResumenCorto): " + prestamo.ResumenCorto());
        Console.WriteLine("Resumen (ToString): " + prestamo.ToString());
        Console.WriteLine($"Estado: {prestamo.Estado} | EstaVencido(): {prestamo.EstaVencido()} | DiasTranscurridos(): {prestamo.DiasTranscurridos()}");
        Pausar();
    }

    static void ListLoansActive()
    {
        Console.Clear();
        Console.WriteLine("--> [Listar préstamos activos]");
        var prestamo = CrearPrestamoPrueba();
        if (prestamo.Estado == EstadoPrestamo.Activo)
        {
            Console.WriteLine(prestamo.ResumenCorto());
        }
        Pausar();
    }

    static void ListLoansClosed()
    {
        Console.Clear();
        Console.WriteLine("--> [Listar préstamos cerrados]");
        Console.WriteLine("Simulación: Mostrando préstamos cerrados / devueltos...");
        Pausar();
    }

    static void ViewLoanDetail()
    {
        Console.Clear();
        Console.WriteLine("--> [Ver detalle de préstamo - Objeto de prueba EV07]");
        Console.Write("Ingrese el ID del préstamo (o Enter para ver el de prueba): ");
        Console.ReadLine();

        var (l1, l2) = CrearLibrosPrueba();
        var (u1, u2) = CrearUsuariosPrueba();
        var prestamo = CrearPrestamoPrueba();

        Console.WriteLine();
        Console.WriteLine(prestamo.DetalleCompleto());
        MostrarValidacionesModelos(l1, l2, u1, u2, prestamo);
        Pausar();
    }

    static void RegisterReturn()
    {
        Console.Clear();
        Console.WriteLine("--> [Registrar devolución]");
        Console.WriteLine("Simulación: Estado del préstamo cambiado a 'devuelto' y libro marcado como 'disponible'.");
        Pausar();
    }

    static void DeleteLoan()
    {
        Console.Clear();
        Console.WriteLine("--> [Eliminar préstamo]");
        Console.WriteLine("Regla: Si el préstamo estaba activo, se devuelve el libro automáticamente.");
        Console.WriteLine("Simulación: Préstamo eliminado.");
        Pausar();
    }

    // ==========================================
    // 4. MÓDULO DE BÚSQUEDAS Y REPORTES
    // ==========================================
    static void ShowSearchReportsMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- BÚSQUEDAS Y REPORTES ---");
            Console.WriteLine("4.1 Buscar libro (título, autor, id, categoría)");
            Console.WriteLine("4.2 Buscar usuario (nombre, id)");
            Console.WriteLine("4.3 Reportes (por usuario, por libro, vencidos, resumen)");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine() ?? string.Empty;

            switch (opcion)
            {
                case "4.1":
                case "1":
                    SearchBook();
                    break;
                case "4.2":
                case "2":
                    SearchUser();
                    break;
                case "4.3":
                case "3":
                    ReportsMenu();
                    break;
                case "0":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("\nOpción no válida.");
                    Pausar();
                    break;
            }
        }
    }

    static void SearchBook()
    {
        Console.Clear();
        Console.WriteLine("--> [Buscar libro]");
        Console.Write("Ingrese criterio de búsqueda (título / autor / ID / categoría): ");
        Console.ReadLine();
        Console.WriteLine("Simulación: Resultados de la búsqueda de libros...");
        Pausar();
    }

    static void SearchUser()
    {
        Console.Clear();
        Console.WriteLine("--> [Buscar usuario]");
        Console.Write("Ingrese criterio de búsqueda (nombre / ID / documento): ");
        Console.ReadLine();
        Console.WriteLine("Simulación: Resultados de la búsqueda de usuarios...");
        Pausar();
    }

    static void ReportsMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- REPORTES ---");
            Console.WriteLine("1. Préstamos por usuario");
            Console.WriteLine("2. Préstamos por libro");
            Console.WriteLine("3. Préstamos vencidos");
            Console.WriteLine("4. Resumen general (total, disponibles, prestados)");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine() ?? string.Empty;
            switch (opcion)
            {
                case "1":
                    ReportByUser();
                    break;
                case "2":
                    ReportByBook();
                    break;
                case "3":
                    ReportOverdue();
                    break;
                case "4":
                    ReportSummary();
                    break;
                case "0":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("\nOpción inválida.");
                    Pausar();
                    break;
            }
        }
    }

    static void ReportByUser()
    {
        Console.Clear();
        Console.WriteLine("--> [Reporte: Préstamos por usuario]");
        Console.WriteLine("Simulación: Generando reporte por usuario...");
        Pausar();
    }

    static void ReportByBook()
    {
        Console.Clear();
        Console.WriteLine("--> [Reporte: Préstamos por libro]");
        Console.WriteLine("Simulación: Generando reporte por libro...");
        Pausar();
    }

    static void ReportOverdue()
    {
        Console.Clear();
        Console.WriteLine("--> [Reporte: Préstamos vencidos]");
        var prestamo = CrearPrestamoPrueba();
        Console.WriteLine($"Préstamo #{prestamo.Id} | EstaVencido(): {prestamo.EstaVencido()} | Días transcurridos: {prestamo.DiasTranscurridos()}");
        Console.WriteLine(prestamo.DetalleCompleto());
        Pausar();
    }

    static void ReportSummary()
    {
        Console.Clear();
        Console.WriteLine("--> [Reporte: Resumen general]");
        var (l1, l2) = CrearLibrosPrueba();
        var (u1, u2) = CrearUsuariosPrueba();
        var p1 = CrearPrestamoPrueba();
        MostrarValidacionesModelos(l1, l2, u1, u2, p1);
        Pausar();
    }

    // ==========================================
    // 5. MÓDULO DE PERSISTENCIA
    // ==========================================
    static void ShowPersistenceMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- GUARDAR / CARGAR DATOS ---");
            Console.WriteLine("5.1 Guardar datos");
            Console.WriteLine("5.2 Cargar datos");
            Console.WriteLine("5.3 Reiniciar datos (vaciar todo)");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine() ?? string.Empty;

            switch (opcion)
            {
                case "5.1":
                case "1":
                    SaveData();
                    break;
                case "5.2":
                case "2":
                    LoadData();
                    break;
                case "5.3":
                case "3":
                    ConfirmResetData();
                    break;
                case "0":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("\nOpción no válida.");
                    Pausar();
                    break;
            }
        }
    }

    static void SaveData()
    {
        Console.Clear();
        Console.WriteLine("--> [Guardar datos]");
        Console.WriteLine("Simulación: Datos guardados correctamente en archivos simulados.");
        Pausar();
    }

    static void LoadData()
    {
        Console.Clear();
        Console.WriteLine("--> [Cargar datos]");
        Console.WriteLine("Simulación: Datos cargados correctamente.");
        Pausar();
    }

    static void ConfirmResetData()
    {
        Console.Clear();
        Console.WriteLine("--> [Reiniciar datos]");
        Console.Write("¿Está seguro de vaciar todos los datos? (S/N): ");
        string respuesta = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();

        if (respuesta == "S")
        {
            Console.WriteLine("Simulación: Todos los datos han sido reiniciados.");
        }
        else
        {
            Console.WriteLine("Operación cancelada.");
        }
        Pausar();
    }
}