using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UserRegistryApp.DataAccess;
using UserRegistryApp.Models;

namespace UserRegistryApp;

public class AuthorizationService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public bool EsAdmin()
    {
        SessionUserInfo userInfo = ObtenerUsuarioDesdeSesion();
        return userInfo?.IdRolUsuario == 1;
    }

    public bool EsUsuarioNormal()
    {
        SessionUserInfo userInfo = ObtenerUsuarioDesdeSesion();
        return userInfo?.IdRolUsuario == 2;
    }

    private SessionUserInfo ObtenerUsuarioDesdeSesion()
    {
        var usuarioJson = _httpContextAccessor.HttpContext?.Session.GetString("usuario");
        return JsonConvert.DeserializeObject<SessionUserInfo>(usuarioJson);
    }
}
