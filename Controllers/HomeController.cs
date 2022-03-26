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

        [HttpGet]
        public IActionResult Edit(int bowlerID)
        {
            var application = _context.Bowlers.Single(x => x.BowlerID == bowlerID);

            return View("Form", application);
        }

        [HttpPost]
        public IActionResult Edit(Bowler blah)
        {
            _context.Update(blah);
            _context.SaveChanges();

            return View("Index");
        }

        public IActionResult Delete(Bowler blah)
        {
            _context.Remove(blah);
            _context.SaveChanges();

            return View("Index");
        }



    }
}
