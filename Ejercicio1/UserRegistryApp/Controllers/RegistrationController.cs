using Microsoft.AspNetCore.Mvc;
using UserRegistryApp.Models;
using UserRegistryApp.Services;
using System.Diagnostics;
using Newtonsoft.Json;

namespace UserRegistryApp.Namespace
{
    public class RegistrationController : Controller
    {

        private readonly RegisterService _registerService;

        public RegistrationController(RegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpGet]
        public ActionResult RegisterUser()
        {

            if (String.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Index", "Login");
            }
            
            SessionUserInfo? usuario = JsonConvert.DeserializeObject<SessionUserInfo>(HttpContext.Session.GetString("usuario"));

            if (usuario?.IdRolUsuario != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            ViewBag.HabilidadesBlanda = _registerService.GetAllHabilidadesBlandas();
            ViewBag.Roles = _registerService.GetAllRoles();
            ViewBag.Usuario = JsonConvert.DeserializeObject<SessionUserInfo>(HttpContext.Session.GetString("usuario"));
            return View();

        }

        [HttpPost]
        public ActionResult RegisterUser(TestUsuario newUser)
        {

            if (String.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Index", "Login");
            }

            SessionUserInfo? usuario = JsonConvert.DeserializeObject<SessionUserInfo>(HttpContext.Session.GetString("usuario"));
            
            if (usuario?.IdRolUsuario != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            _registerService.InsertarUsuario(newUser);
            return RedirectToAction("RegisterUser", "Registration");;
        }

        public ActionResult UpdateUser()
        {

            if (String.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Index", "Login");
            }

            SessionUserInfo? usuario = JsonConvert.DeserializeObject<SessionUserInfo>(HttpContext.Session.GetString("usuario"));
            
            if (usuario?.IdRolUsuario != 1)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            return View();
        }
        public ActionResult DeleteUser()
        {

            if (String.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            SessionUserInfo? usuario = JsonConvert.DeserializeObject<SessionUserInfo>(HttpContext.Session.GetString("usuario"));
            
            if (usuario?.IdRolUsuario != 1)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
