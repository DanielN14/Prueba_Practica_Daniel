using System;
using System.Collections.Generic;

namespace UserRegistryApp.Models;

public partial class TestHabilidadesBlandasXusuario
{
    public int IdHabilidadBlanda { get; set; }

    public int IdUsuario { get; set; }

    public bool IsDeleted { get; set; }

    public virtual TestHabilidadesBlanda IdHabilidadBlandaNavigation { get; set; } = null!;

    public virtual TestUsuario IdUsuarioNavigation { get; set; } = null!;
}
