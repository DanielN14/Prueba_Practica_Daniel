using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserRegistryApp.Models;
using UserRegistryApp.Services;

namespace UserRegistryApp.Namespace
{
    public class LoginController : Controller
    {
        private readonly AuthenticationService _authService;

        public LoginController(AuthenticationService authService)
        {
            _authService = authService;
        }

        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string username, string clave)
        {
            var result = await _authService.AuthenticateUserAsync(username, clave);

            if (result == 1)
            {
                // Autenticación exitosa, obtener información del usuario
                SessionUserInfo? usuario = await _authService.GetUserInfoAsync(username);

                // Guardar la información del usuario en la sesión
                HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuario));

                if (usuario?.IdRolUsuario == 1)
                {
                    return RedirectToAction("RegisterUser", "Registration");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            // Si la autenticación falla, puedes mostrar un mensaje de error o redirigir a una página de error
            ViewBag.ErrorMessage = "Nombre de usuario o clave incorrectos";
            return View();
        }

        public ActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }

}