namespace BiblioBottle.Models;

public class Libro
{
    public int Id { get; set; }
    public string Isbn { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public int Anio { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public bool Disponible { get; set; }

    // Constructor vacío
    public Libro()
    {
        Disponible = true;
    }

    // Constructor completo
    public Libro(int id, string isbn, string titulo, string autor, int anio, string categoria, bool disponible = true)
    {
        Id = id;
        Isbn = isbn;
        Titulo = titulo;
        Autor = autor;
        Anio = anio;
        Categoria = categoria;
        Disponible = disponible;
    }

    public string ResumenCorto()
    {
        string estadoDisp = Disponible ? "Disponible" : "Prestado";
        return $"[{Id}] {Titulo} - {Autor} ({estadoDisp})";
    }

    public string DetalleCompleto()
    {
        string estadoDisp = Disponible ? "Sí (Disponible)" : "No (Prestado)";
        return $"=== DETALLE DEL LIBRO ===\n" +
               $"ID: {Id}\n" +
               $"ISBN: {Isbn}\n" +
               $"Título: {Titulo}\n" +
               $"Autor: {Autor}\n" +
               $"Año: {Anio}\n" +
               $"Categoría: {Categoria}\n" +
               $"Disponible: {estadoDisp}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}