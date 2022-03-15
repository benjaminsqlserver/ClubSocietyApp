using System;
using Microsoft.AspNetCore.Mvc;

namespace SocietyApp.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
