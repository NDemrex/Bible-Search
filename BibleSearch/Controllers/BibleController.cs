using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleSearch.Controllers
{
    public class BibleController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
    }
}
