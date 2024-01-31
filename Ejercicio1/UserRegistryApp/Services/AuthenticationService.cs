using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UserRegistryApp.DataAccess;
using UserRegistryApp.Models;

namespace UserRegistryApp;

public class AuthenticationService
{
    private readonly UserRegistryAppContext _dbContext;

    public AuthenticationService(UserRegistryAppContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int?> AuthenticateUserAsync(string username, string password)
    {
        var usernameParam = new SqlParameter("@Username", username);
        var passwordParam = new SqlParameter("@Password", password);

        var resultParam = new SqlParameter
        {
            ParameterName = "@AuthenticationResult",
            SqlDbType = SqlDbType.Int,
            Direction = ParameterDirection.Output
        };

        await _dbContext.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC test_AuthUser @Username={usernameParam}, @Password={passwordParam}, @AuthenticationResult={resultParam} OUTPUT"
        );

        if (resultParam.Value != DBNull.Value)
        {
            int authenticationResult = Convert.ToInt32(resultParam.Value);

            if (authenticationResult == 1)
            {
                return 1;
            }
        }

        return 0;
    }

    public async Task<SessionUserInfo?> GetUserInfoAsync(string username)
    {
        var usernameParam = new SqlParameter("@Username", username);

        var userInfo = await _dbContext.TestUsuarios
                .Where(u => u.NombreUsuario == username)
                .Select(u => new SessionUserInfo
                {
                    IdUsuario = u.IdUsuario,
                    Nombre = u.Nombre,
                    PrimerApellido = u.PrimerApellido,
                    SegundoApellido = u.SegundoApellido,
                    Identificacion = u.Identificacion,
                    TipoIdentificacion = u.TipoIdentificacion,
                    Email = u.Email,
                    NombreUsuario = u.NombreUsuario,
                    IdRolUsuario = u.IdRolUsuario
                })
                .FirstOrDefaultAsync();

        return userInfo;
    }
}
