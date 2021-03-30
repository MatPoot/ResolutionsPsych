using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResolutionsPsych.Controllers
{
    public class CounsellorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
