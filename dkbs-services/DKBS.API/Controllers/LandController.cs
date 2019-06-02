using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DKBS.API.Controllers
{
    public class LandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}