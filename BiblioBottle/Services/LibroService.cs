using System;
using System.Collections.Generic;
using System.Linq;
using BiblioBottle.Models;

namespace BiblioBottle.Services;

public class LibroService
{
    private readonly List<Libro> _libros = new List<Libro>();

    public void AgregarLibro(Libro libro)
    {
        if (libro == null) return;
        _libros.Add(libro);
    }

    public bool EliminarLibro(int id)
    {
        Libro? libro = _libros.FirstOrDefault(l => l.Id == id);
        if (libro == null) return false;

        if (!libro.Disponible)
        {
            Console.WriteLine("Validación: No se puede eliminar el libro porque actualmente está prestado.");
            return false;
        }

        return _libros.Remove(libro);
    }

    public List<Libro> ObtenerTodos()
    {
        return new List<Libro>(_libros);
    }

    public List<Libro> BuscarPorIsbn(string isbn)
    {
        if (string.IsNullOrWhiteSpace(isbn)) return new List<Libro>();
        return _libros
            .Where(l => l.Isbn.Contains(isbn.Trim(), StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Libro> BuscarPorTitulo(string titulo)
    {
        if (string.IsNullOrWhiteSpace(titulo)) return new List<Libro>();
        return _libros
            .Where(l => l.Titulo.Contains(titulo.Trim(), StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Libro> BuscarPorAutor(string autor)
    {
        if (string.IsNullOrWhiteSpace(autor)) return new List<Libro>();
        return _libros
            .Where(l => l.Autor.Contains(autor.Trim(), StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Libro> OrdenarPorTitulo()
    {
        return _libros
            .OrderBy(l => l.Titulo, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    public List<Libro> OrdenarPorAnio()
    {
        return _libros
            .OrderBy(l => l.Anio)
            .ToList();
    }

    public int ObtenerTotalLibros()
    {
        return _libros.Count;
    }

    public int ObtenerLibrosDisponibles()
    {
        return _libros.Count(l => l.Disponible);
    }

    public int ObtenerLibrosPrestados()
    {
        return _libros.Count(l => !l.Disponible);
    }
}