using System;
using System.Collections.Generic;

namespace UserRegistryApp.Models;

public partial class TestRole
{
    public int IdRolUsuario { get; set; }

    public string NombreRol { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<TestUsuario> TestUsuarios { get; set; } = new List<TestUsuario>();
}
