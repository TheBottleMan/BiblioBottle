using System;
using System.Collections.Generic;
using BiblioBottle.Models;
using BiblioBottle.Services;

class Program
{
    static void Main(string[] args)
    {
        ShowMainMenu();
    }

    // ==========================================
    // INICIALIZACIÓN DE SERVICIOS Y DATOS (EV08)
    // ==========================================
    static (LibroService libros, UsuarioService usuarios, PrestamoService prestamos) CrearServiciosConDatosPrueba()
    {
        LibroService libroService = new LibroService();
        libroService.AgregarLibro(new Libro(1, "978-0321125217", "Domain-Driven Design", "Eric Evans", 2003, "Arquitectura", true));
        libroService.AgregarLibro(new Libro(2, "978-0132350884", "Clean Code", "Robert C. Martin", 2008, "Ingeniería", false));
        libroService.AgregarLibro(new Libro(3, "978-0201616224", "The Pragmatic Programmer", "Andrew Hunt", 1999, "Desarrollo", true));

        UsuarioService usuarioService = new UsuarioService();
        usuarioService.AgregarUsuario(new Usuario(1, "1020304050", "Camila Restrepo", "camila@correo.com", true));
        usuarioService.AgregarUsuario(new Usuario(2, "9876543210", "Andrés Morales", "3004567890", false));
        usuarioService.AgregarUsuario(new Usuario(3, "1122334455", "Valentina Gómez", "valentina@correo.com", true));

        PrestamoService prestamoService = new PrestamoService();
        prestamoService.AgregarPrestamo(new Prestamo(101, 2, 1, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-3), null, EstadoPrestamo.Activo));
        prestamoService.AgregarPrestamo(new Prestamo(102, 1, 3, DateTime.Now.AddDays(-15), DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-6), EstadoPrestamo.Devuelto));

        return (libroService, usuarioService, prestamoService);
    }

    static void DemostrarArrayVsList()
    {
        Console.Clear();
        Console.WriteLine("=== COMPARACIÓN: ARRAY VS LIST<T> (EV08) ===\n");

        // Ejemplo con Array (tamaño fijo definido al crearlo)
        string[] titulosArray = new string[2];
        titulosArray[0] = "Domain-Driven Design";
        titulosArray[1] = "Clean Code";

        Console.WriteLine("1) Ejemplo con Array (tamaño fijo = 2):");
        foreach (string titulo in titulosArray)
        {
            Console.WriteLine($"   - {titulo}");
        }

        // Ejemplo con List<T> (colección dinámica que crece o se reduce en ejecución)
        List<string> titulosLista = new List<string> { "Domain-Driven Design", "Clean Code" };
        titulosLista.Add("The Pragmatic Programmer"); // Crece dinámicamente
        titulosLista.Remove("Clean Code");            // Se reduce dinámicamente

        Console.WriteLine("\n2) Ejemplo con List<T> (dinámica, tras Add y Remove):");
        foreach (string titulo in titulosLista)
        {
            Console.WriteLine($"   - {titulo}");
        }

        Console.WriteLine("\nDiferencias clave:");
        Console.WriteLine("- Array: tamaño fijo en memoria; rápido por índice, pero agregar/quitar elementos exige crear otro arreglo.");
        Console.WriteLine("- List<T>: tamaño dinámico (Count, Add, Remove, Find/Where, Sort/OrderBy); más flexible para servicios en memoria.");

        Pausar();
    }

    static void MostrarKpisGenerales(LibroService libros, UsuarioService usuarios, PrestamoService prestamos)
    {
        Console.WriteLine("\n=== KPIs Y ESTADÍSTICAS DEL SISTEMA ===");
        Console.WriteLine($"[Libros]   Total: {libros.ObtenerTotalLibros()} | Disponibles: {libros.ObtenerLibrosDisponibles()} | Prestados: {libros.ObtenerLibrosPrestados()}");
        Console.WriteLine($"[Usuarios] Total: {usuarios.ObtenerTotalUsuarios()} | Activos: {usuarios.ObtenerUsuariosActivos()} | Inactivos: {usuarios.ObtenerUsuariosInactivos()}");
        Console.WriteLine($"[Préstamos] Total: {prestamos.ObtenerTotalPrestamos()} | Activos: {prestamos.ObtenerPrestamosActivos()} | Vencidos: {prestamos.ObtenerPrestamosVencidos()} | Devueltos: {prestamos.ObtenerPrestamosDevueltos()}");
        Console.WriteLine($"[Préstamos] Promedio días transcurridos: {prestamos.ObtenerPromedioDiasPrestamo():F1}");
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
        Console.WriteLine("Simulación: Libro registrado exitosamente en el servicio.");
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
        var (libroService, _, _) = CrearServiciosConDatosPrueba();
        Console.WriteLine("--> [Todos los libros ordenados por título]");
        foreach (Libro l in libroService.OrdenarPorTitulo())
        {
            Console.WriteLine(l.ResumenCorto());
        }
        Pausar();
    }

    static void ListBooksAvailable()
    {
        Console.Clear();
        var (libroService, _, _) = CrearServiciosConDatosPrueba();
        Console.WriteLine("--> [Libros disponibles]");
        foreach (Libro l in libroService.ObtenerTodos())
        {
            if (l.Disponible) Console.WriteLine(l.ResumenCorto());
        }
        Pausar();
    }

    static void ListBooksBorrowed()
    {
        Console.Clear();
        var (libroService, _, _) = CrearServiciosConDatosPrueba();
        Console.WriteLine("--> [Libros prestados]");
        foreach (Libro l in libroService.ObtenerTodos())
        {
            if (!l.Disponible) Console.WriteLine(l.ResumenCorto());
        }
        Pausar();
    }

    static void ViewBookDetail()
    {
        Console.Clear();
        var (libroService, _, _) = CrearServiciosConDatosPrueba();
        Console.WriteLine("--> [Ver detalle de libro]");
        Console.Write("Ingrese ISBN o deje vacío para ver todos ordenados por año: ");
        string criterio = Console.ReadLine() ?? string.Empty;

        var lista = string.IsNullOrWhiteSpace(criterio)
            ? libroService.OrdenarPorAnio()
            : libroService.BuscarPorIsbn(criterio);

        foreach (Libro l in lista)
        {
            Console.WriteLine();
            Console.WriteLine(l.DetalleCompleto());
        }
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
        var (libroService, _, _) = CrearServiciosConDatosPrueba();
        Console.WriteLine("--> [Prueba de eliminación en LibroService]");
        Console.WriteLine("Intentando eliminar Libro ID 2 (prestado): " + libroService.EliminarLibro(2));
        Console.WriteLine("Intentando eliminar Libro ID 3 (disponible): " + libroService.EliminarLibro(3));
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
        var (_, usuarioService, _) = CrearServiciosConDatosPrueba();
        Console.WriteLine("--> [Usuarios ordenados por nombre]");
        foreach (Usuario u in usuarioService.OrdenarPorNombre())
        {
            Console.WriteLine(u.ResumenCorto());
        }
        Pausar();
    }

    static void ViewUserDetail()
    {
        Console.Clear();
        var (_, usuarioService, _) = CrearServiciosConDatosPrueba();
        Console.WriteLine("--> [Detalle de usuarios]");
        foreach (Usuario u in usuarioService.ObtenerTodos())
        {
            Console.WriteLine();
            Console.WriteLine(u.DetalleCompleto());
        }
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
        var (_, usuarioService, _) = CrearServiciosConDatosPrueba();
        Console.WriteLine("--> [Prueba de eliminación en UsuarioService]");
        Console.WriteLine("Intentando eliminar Usuario ID 1 (con préstamo activo): " + usuarioService.EliminarUsuario(1, true));
        Console.WriteLine("Intentando eliminar Usuario ID 2 (sin préstamos activos): " + usuarioService.EliminarUsuario(2, false));
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
        Console.WriteLine("Simulación: Préstamo registrado en PrestamoService.");
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
        var (_, _, prestamoService) = CrearServiciosConDatosPrueba();
        Console.WriteLine("--> [Préstamos ordenados por fecha límite]");
        foreach (Prestamo p in prestamoService.OrdenarPorFechaLimite())
        {
            Console.WriteLine(p.ResumenCorto());
        }
        Pausar();
    }

    static void ListLoansActive()
    {
        Console.Clear();
        var (_, _, prestamoService) = CrearServiciosConDatosPrueba();
        Console.WriteLine("--> [Préstamos activos]");
        foreach (Prestamo p in prestamoService.BuscarPorEstado(EstadoPrestamo.Activo))
        {
            Console.WriteLine(p.ResumenCorto());
        }
        Pausar();
    }

    static void ListLoansClosed()
    {
        Console.Clear();
        var (_, _, prestamoService) = CrearServiciosConDatosPrueba();
        Console.WriteLine("--> [Préstamos devueltos]");
        foreach (Prestamo p in prestamoService.BuscarPorEstado(EstadoPrestamo.Devuelto))
        {
            Console.WriteLine(p.ResumenCorto());
        }
        Pausar();
    }

    static void ViewLoanDetail()
    {
        Console.Clear();
        var (_, _, prestamoService) = CrearServiciosConDatosPrueba();
        Console.WriteLine("--> [Detalle de préstamos]");
        foreach (Prestamo p in prestamoService.ObtenerTodos())
        {
            Console.WriteLine();
            Console.WriteLine(p.DetalleCompleto());
        }
        Pausar();
    }

    static void RegisterReturn()
    {
        Console.Clear();
        Console.WriteLine("--> [Registrar devolución]");
        Console.WriteLine("Simulación: Préstamo marcado como devuelto.");
        Pausar();
    }

    static void DeleteLoan()
    {
        Console.Clear();
        Console.WriteLine("--> [Eliminar préstamo]");
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
            Console.WriteLine("4.1 Buscar libro (título / autor)");
            Console.WriteLine("4.2 Buscar usuario (nombre / documento)");
            Console.WriteLine("4.3 Reportes y KPIs");
            Console.WriteLine("4.4 Comparación Array vs List<T>");
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
                case "4.4":
                case "4":
                    DemostrarArrayVsList();
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
        var (libroService, _, _) = CrearServiciosConDatosPrueba();
        Console.Write("Ingrese título o autor a buscar: ");
        string texto = Console.ReadLine() ?? string.Empty;

        var porTitulo = libroService.BuscarPorTitulo(texto);
        var porAutor = libroService.BuscarPorAutor(texto);

        Console.WriteLine("\n--- Resultados por título ---");
        foreach (Libro l in porTitulo) Console.WriteLine(l.ResumenCorto());

        Console.WriteLine("\n--- Resultados por autor ---");
        foreach (Libro l in porAutor) Console.WriteLine(l.ResumenCorto());

        Pausar();
    }

    static void SearchUser()
    {
        Console.Clear();
        var (_, usuarioService, _) = CrearServiciosConDatosPrueba();
        Console.Write("Ingrese nombre o documento a buscar: ");
        string texto = Console.ReadLine() ?? string.Empty;

        var porNombre = usuarioService.BuscarPorNombre(texto);
        var porDocumento = usuarioService.BuscarPorDocumento(texto);

        Console.WriteLine("\n--- Resultados por nombre ---");
        foreach (Usuario u in porNombre) Console.WriteLine(u.ResumenCorto());

        Console.WriteLine("\n--- Resultados por documento ---");
        foreach (Usuario u in porDocumento) Console.WriteLine(u.ResumenCorto());

        Pausar();
    }

    static void ReportsMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("--- REPORTES Y KPIs ---");
            Console.WriteLine("1. Préstamos por usuario");
            Console.WriteLine("2. Préstamos por libro");
            Console.WriteLine("3. Préstamos vencidos");
            Console.WriteLine("4. Resumen general y KPIs");
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
        var (_, usuarioService, prestamoService) = CrearServiciosConDatosPrueba();
        foreach (Usuario u in usuarioService.ObtenerTodos())
        {
            int count = 0;
            foreach (Prestamo p in prestamoService.ObtenerTodos())
            {
                if (p.UsuarioId == u.Id) count++;
            }
            Console.WriteLine($"{u.ResumenCorto()} -> Préstamos asociados: {count}");
        }
        Pausar();
    }

    static void ReportByBook()
    {
        Console.Clear();
        var (libroService, _, prestamoService) = CrearServiciosConDatosPrueba();
        foreach (Libro l in libroService.ObtenerTodos())
        {
            int count = 0;
            foreach (Prestamo p in prestamoService.ObtenerTodos())
            {
                if (p.LibroId == l.Id) count++;
            }
            Console.WriteLine($"{l.ResumenCorto()} -> Préstamos asociados: {count}");
        }
        Pausar();
    }

    static void ReportOverdue()
    {
        Console.Clear();
        var (_, _, prestamoService) = CrearServiciosConDatosPrueba();
        Console.WriteLine("--> [Préstamos vencidos]");
        foreach (Prestamo p in prestamoService.ObtenerTodos())
        {
            if (p.EstaVencido() || p.Estado == EstadoPrestamo.Vencido)
            {
                Console.WriteLine(p.DetalleCompleto());
            }
        }
        Pausar();
    }

    static void ReportSummary()
    {
        Console.Clear();
        var (libroService, usuarioService, prestamoService) = CrearServiciosConDatosPrueba();
        MostrarKpisGenerales(libroService, usuarioService, prestamoService);
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
        Console.WriteLine("Simulación: Datos guardados correctamente.");
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