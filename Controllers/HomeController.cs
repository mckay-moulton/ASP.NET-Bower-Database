using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private BowlingDbContext _context { get; set; }
        //Contructor
        public HomeController(BowlingDbContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            var blah = _context.Bowlers.ToList();
            return View(blah);
        }
    }
}
