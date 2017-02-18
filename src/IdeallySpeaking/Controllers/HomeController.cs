using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IdeallySpeaking.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }        

        public IActionResult Contact()
        {
            ViewData["Message"] = "Ideally Speaking is owned and created by: Lori Overholtzer, a.k.a., PCPrincess.";

            return View();
        }

        public IActionResult Supporters()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
