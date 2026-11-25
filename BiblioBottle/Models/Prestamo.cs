namespace BiblioBottle.Models;

public class Prestamo
{
    public int Id { get; set; }
    public int LibroId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaLimite { get; set; }
    public DateTime? FechaDevolucion { get; set; }
    public EstadoPrestamo Estado { get; set; }

    // Constructor vacío
    public Prestamo()
    {
        FechaPrestamo = DateTime.Now;
        FechaLimite = DateTime.Now.AddDays(7);
        FechaDevolucion = null;
        Estado = EstadoPrestamo.Activo;
    }

    // Constructor completo
    public Prestamo(
        int id,
        int libroId,
        int usuarioId,
        DateTime fechaPrestamo,
        DateTime fechaLimite,
        DateTime? fechaDevolucion = null,
        EstadoPrestamo estado = EstadoPrestamo.Activo)
    {
        Id = id;
        LibroId = libroId;
        UsuarioId = usuarioId;
        FechaPrestamo = fechaPrestamo;
        FechaLimite = fechaLimite;
        FechaDevolucion = fechaDevolucion;
        Estado = estado;
    }

    public bool EstaVencido()
    {
        if (Estado == EstadoPrestamo.Devuelto)
        {
            return FechaDevolucion.HasValue && FechaDevolucion.Value > FechaLimite;
        }

        return DateTime.Now > FechaLimite;
    }

    public int DiasTranscurridos()
    {
        DateTime fechaReferencia = FechaDevolucion ?? DateTime.Now;
        int dias = (fechaReferencia.Date - FechaPrestamo.Date).Days;
        return dias < 0 ? 0 : dias;
    }

    public string ResumenCorto()
    {
        string vencidoTexto = EstaVencido() ? "Sí" : "No";
        return $"Préstamo #{Id} | Libro ID: {LibroId} | Usuario ID: {UsuarioId} | Estado: {Estado} | Vencido: {vencidoTexto}";
    }

    public string DetalleCompleto()
    {
        string devolucionTexto = FechaDevolucion.HasValue
            ? FechaDevolucion.Value.ToString("yyyy-MM-dd")
            : "No devuelto aún (null)";

        return $"=== DETALLE DEL PRÉSTAMO ===\n" +
               $"ID Préstamo: {Id}\n" +
               $"ID Libro: {LibroId}\n" +
               $"ID Usuario: {UsuarioId}\n" +
               $"Fecha de préstamo: {FechaPrestamo:yyyy-MM-dd}\n" +
               $"Fecha límite: {FechaLimite:yyyy-MM-dd}\n" +
               $"Fecha de devolución: {devolucionTexto}\n" +
               $"Estado: {Estado}\n" +
               $"¿Está vencido?: {(EstaVencido() ? "Sí" : "No")}\n" +
               $"Días transcurridos: {DiasTranscurridos()}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}