using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CSSPWebTools2.Controllers
{
    public class RougeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rose()
        {
            return View();
        }
    }
}