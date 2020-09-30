using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreSupportSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Controller]
    public class HomeController : Controller
    {

        [HttpGet]
        [Route("Admin/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
