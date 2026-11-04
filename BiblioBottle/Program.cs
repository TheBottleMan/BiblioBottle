using System;

class Program
{
    static void Main(string[] args)
    {
        ShowMainMenu();
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

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    // Se conectará con feature/books-menu
                    Console.WriteLine("\n[Módulo de Libros en desarrollo]");
                    Pausar();
                    break;
                case "2":
                    // Se conectará con feature/users-menu
                    Console.WriteLine("\n[Módulo de Usuarios en desarrollo]");
                    Pausar();
                    break;
                case "3":
                    // Se conectará con feature/loans-menu
                    Console.WriteLine("\n[Módulo de Préstamos en desarrollo]");
                    Pausar();
                    break;
                case "4":
                    // Se conectará con feature/search-reports-menu
                    Console.WriteLine("\n[Módulo de Búsquedas y Reportes en desarrollo]");
                    Pausar();
                    break;
                case "5":
                    // Se conectará con feature/persistence-menu
                    Console.WriteLine("\n[Módulo de Persistencia en desarrollo]");
                    Pausar();
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
        string respuesta = Console.ReadLine().Trim().ToUpper();

        if (respuesta == "S")
        {
            Console.WriteLine("Simulación: Guardando datos antes de salir...");
        }

        Console.WriteLine("\nSaliendo de la aplicación. ¡Hasta pronto!");
        return true;
    }

    // ==========================================
    // MÉTODO AUXILIAR
    // ==========================================
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

            string opcion = Console.ReadLine();

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

            string opcion = Console.ReadLine();
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
        Console.WriteLine("--> [Listar todos los libros]");
        Console.WriteLine("Simulación: Mostrando lista completa de libros...");
        Pausar();
    }

    static void ListBooksAvailable()
    {
        Console.Clear();
        Console.WriteLine("--> [Listar libros disponibles]");
        Console.WriteLine("Simulación: Mostrando libros disponibles...");
        Pausar();
    }

    static void ListBooksBorrowed()
    {
        Console.Clear();
        Console.WriteLine("--> [Listar libros prestados]");
        Console.WriteLine("Simulación: Mostrando libros actualmente prestados...");
        Pausar();
    }

    static void ViewBookDetail()
    {
        Console.Clear();
        Console.WriteLine("--> [Ver detalle de libro]");
        Console.Write("Ingrese el ID o ISBN del libro: ");
        Console.ReadLine();
        Console.WriteLine("Simulación: Mostrando detalles del libro...");
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

            string opcion = Console.ReadLine();
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

            string opcion = Console.ReadLine();

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
        Console.WriteLine("--> [Listar usuarios]");
        Console.WriteLine("Simulación: Mostrando todos los usuarios registrados...");
        Pausar();
    }

    static void ViewUserDetail()
    {
        Console.Clear();
        Console.WriteLine("--> [Ver detalle de usuario]");
        Console.Write("Ingrese el ID o documento del usuario: ");
        Console.ReadLine();
        Console.WriteLine("Simulación: Mostrando detalles del usuario...");
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

            string opcion = Console.ReadLine();
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

            string opcion = Console.ReadLine();

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

            string opcion = Console.ReadLine();
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
        Console.WriteLine("--> [Listar todos los préstamos]");
        Console.WriteLine("Simulación: Mostrando todos los préstamos...");
        Pausar();
    }

    static void ListLoansActive()
    {
        Console.Clear();
        Console.WriteLine("--> [Listar préstamos activos]");
        Console.WriteLine("Simulación: Mostrando préstamos activos...");
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
        Console.WriteLine("--> [Ver detalle de préstamo]");
        Console.Write("Ingrese el ID del préstamo: ");
        Console.ReadLine();
        Console.WriteLine("Simulación: Mostrando detalles del préstamo...");
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

            string opcion = Console.ReadLine();

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

            string opcion = Console.ReadLine();
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
        Console.WriteLine("Simulación: Listando préstamos con fecha límite superada...");
        Pausar();
    }

    static void ReportSummary()
    {
        Console.Clear();
        Console.WriteLine("--> [Reporte: Resumen general]");
        Console.WriteLine("Simulación: Total libros: 10 | Disponibles: 7 | Prestados: 3");
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

            string opcion = Console.ReadLine();

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
        string respuesta = Console.ReadLine().Trim().ToUpper();

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