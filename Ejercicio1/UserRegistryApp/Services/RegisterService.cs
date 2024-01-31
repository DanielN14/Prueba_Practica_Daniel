using UserRegistryApp.DataAccess;
using UserRegistryApp.Models;

namespace UserRegistryApp.Services;

public class RegisterService
{
    private readonly UserRegistryAppContext _dbContext;

    public RegisterService(UserRegistryAppContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<TestHabilidadesBlanda> GetAllHabilidadesBlandas()
    {
        return _dbContext.TestHabilidadesBlandas.ToList();
    }

    public List<TestRole> GetAllRoles()
    {
        return _dbContext.TestRoles.ToList();
    }

    public void InsertarUsuario(TestUsuario newUser)
    {
        _dbContext.TestUsuarios.Add(newUser);
        _dbContext.SaveChanges();
    }

}
