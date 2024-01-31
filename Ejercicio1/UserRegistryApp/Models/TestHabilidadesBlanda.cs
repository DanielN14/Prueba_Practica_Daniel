using System;
using System.Collections.Generic;

namespace UserRegistryApp.Models;

public partial class TestHabilidadesBlanda
{
    public int IdHabilidadBlanda { get; set; }

    public string NombreHabilidadBlanda { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<TestHabilidadesBlandasXusuario> TestHabilidadesBlandasXusuarios { get; set; } = new List<TestHabilidadesBlandasXusuario>();
}
