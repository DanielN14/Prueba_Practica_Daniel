using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserRegistryApp.Models;

namespace UserRegistryApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        if (String.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
        {
            return RedirectToAction("Index", "Login");
        }
        
        SessionUserInfo? usuario = JsonConvert.DeserializeObject<SessionUserInfo>(HttpContext.Session.GetString("usuario"));

        if (usuario?.IdRolUsuario != 2)
        {
            return RedirectToAction("AccessDenied", "Home");
        }

        return View();
    }

    public IActionResult AccessDenied()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
