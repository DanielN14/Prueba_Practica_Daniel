using System;
using System.Collections.Generic;

namespace UserRegistryApp.Models;

public partial class TestTelefono
{
    public int IdTelefono { get; set; }

    public int IdUsuario { get; set; }

    public string NumeroTelefono { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual TestUsuario IdUsuarioNavigation { get; set; } = null!;
}
