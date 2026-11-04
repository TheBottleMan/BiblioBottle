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
}