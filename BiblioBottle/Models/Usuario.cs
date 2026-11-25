namespace BiblioBottle.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Documento { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Contacto { get; set; } = string.Empty;
    public bool Activo { get; set; }

    // Constructor vacío
    public Usuario()
    {
        Activo = true;
    }

    // Constructor completo
    public Usuario(int id, string documento, string nombre, string contacto, bool activo = true)
    {
        Id = id;
        Documento = documento;
        Nombre = nombre;
        Contacto = contacto;
        Activo = activo;
    }

    public string ResumenCorto()
    {
        string estadoActivo = Activo ? "Activo" : "Inactivo";
        return $"[{Id}] {Nombre} - Doc: {Documento} ({estadoActivo})";
    }

    public string DetalleCompleto()
    {
        string estadoActivo = Activo ? "Sí (Activo)" : "No (Inactivo)";
        return $"=== DETALLE DEL USUARIO ===\n" +
               $"ID: {Id}\n" +
               $"Documento: {Documento}\n" +
               $"Nombre: {Nombre}\n" +
               $"Contacto: {Contacto}\n" +
               $"Activo: {estadoActivo}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}