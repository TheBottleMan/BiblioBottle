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
    // 1. MÓDULO DE LIBROS (A integrar en Program.cs)
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
    // 2. MÓDULO DE USUARIOS (A integrar en Program.cs)
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
}