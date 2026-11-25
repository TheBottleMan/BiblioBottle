using System;
using System.Collections.Generic;
using System.Linq;
using BiblioBottle.Models;

namespace BiblioBottle.Services;

public class UsuarioService
{
    private readonly List<Usuario> _usuarios = new List<Usuario>();

    public void AgregarUsuario(Usuario usuario)
    {
        if (usuario == null) return;
        _usuarios.Add(usuario);
    }

    public bool EliminarUsuario(int id, bool tienePrestamosActivos = false)
    {
        Usuario? usuario = _usuarios.FirstOrDefault(u => u.Id == id);
        if (usuario == null) return false;

        if (tienePrestamosActivos)
        {
            Console.WriteLine("Validación: No se puede eliminar el usuario porque tiene préstamos activos.");
            return false;
        }

        return _usuarios.Remove(usuario);
    }

    public List<Usuario> ObtenerTodos()
    {
        return new List<Usuario>(_usuarios);
    }

    public List<Usuario> BuscarPorDocumento(string documento)
    {
        if (string.IsNullOrWhiteSpace(documento)) return new List<Usuario>();
        return _usuarios
            .Where(u => u.Documento.Contains(documento.Trim(), StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Usuario> BuscarPorNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre)) return new List<Usuario>();
        return _usuarios
            .Where(u => u.Nombre.Contains(nombre.Trim(), StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Usuario> OrdenarPorNombre()
    {
        return _usuarios
            .OrderBy(u => u.Nombre, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    public int ObtenerTotalUsuarios()
    {
        return _usuarios.Count;
    }

    public int ObtenerUsuariosActivos()
    {
        return _usuarios.Count(u => u.Activo);
    }

    public int ObtenerUsuariosInactivos()
    {
        return _usuarios.Count(u => !u.Activo);
    }
}