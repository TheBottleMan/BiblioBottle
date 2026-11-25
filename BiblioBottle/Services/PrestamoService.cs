using System;
using System.Collections.Generic;
using System.Linq;
using BiblioBottle.Models;

namespace BiblioBottle.Services;

public class PrestamoService
{
    private readonly List<Prestamo> _prestamos = new List<Prestamo>();

    public void AgregarPrestamo(Prestamo prestamo)
    {
        if (prestamo == null) return;
        _prestamos.Add(prestamo);
    }

    public bool EliminarPrestamo(int id)
    {
        Prestamo? prestamo = _prestamos.FirstOrDefault(p => p.Id == id);
        if (prestamo == null) return false;

        if (prestamo.Estado == EstadoPrestamo.Activo)
        {
            Console.WriteLine("Regla: El préstamo estaba activo; se marca como devuelto antes de eliminarlo.");
            prestamo.Estado = EstadoPrestamo.Devuelto;
            prestamo.FechaDevolucion ??= DateTime.Now;
        }

        return _prestamos.Remove(prestamo);
    }

    public List<Prestamo> ObtenerTodos()
    {
        return new List<Prestamo>(_prestamos);
    }

    public Prestamo? BuscarPorId(int id)
    {
        return _prestamos.FirstOrDefault(p => p.Id == id);
    }

    public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado)
    {
        return _prestamos
            .Where(p => p.Estado == estado)
            .ToList();
    }

    public List<Prestamo> OrdenarPorFechaLimite()
    {
        return _prestamos
            .OrderBy(p => p.FechaLimite)
            .ToList();
    }

    public int ObtenerTotalPrestamos()
    {
        return _prestamos.Count;
    }

    public int ObtenerPrestamosActivos()
    {
        return _prestamos.Count(p => p.Estado == EstadoPrestamo.Activo);
    }

    public int ObtenerPrestamosVencidos()
    {
        return _prestamos.Count(p => p.Estado == EstadoPrestamo.Vencido || p.EstaVencido());
    }

    public int ObtenerPrestamosDevueltos()
    {
        return _prestamos.Count(p => p.Estado == EstadoPrestamo.Devuelto);
    }

    public double ObtenerPromedioDiasPrestamo()
    {
        if (_prestamos.Count == 0) return 0.0;
        return _prestamos.Average(p => p.DiasTranscurridos());
    }
}