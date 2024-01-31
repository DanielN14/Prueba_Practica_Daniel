namespace UserRegistryApp;

public class SessionUserInfo
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string PrimerApellido { get; set; } = null!;

    public string? SegundoApellido { get; set; }

    public string Identificacion { get; set; } = null!;

    public string TipoIdentificacion { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public int IdRolUsuario { get; set; }
}
