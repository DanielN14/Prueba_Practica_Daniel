using System;
using System.Collections.Generic;

namespace UserRegistryApp.Models;

public partial class TestUsuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string PrimerApellido { get; set; } = null!;

    public string? SegundoApellido { get; set; }

    public string Identificacion { get; set; } = null!;

    public string TipoIdentificacion { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public int IdRolUsuario { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TestRole IdRolUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<TestHabilidadesBlandasXusuario> TestHabilidadesBlandasXusuarios { get; set; } = new List<TestHabilidadesBlandasXusuario>();

    public virtual ICollection<TestTelefono> TestTelefonos { get; set; } = new List<TestTelefono>();
}
