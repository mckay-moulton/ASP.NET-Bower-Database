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
            IEnumerable<Bowler> blah = _context.Bowlers.ToList();
            
            return View(blah);
        }

        [HttpGet]
        public IActionResult Edit(int bowlerID)
        {
            var application = _context.Bowlers.Single(x => x.BowlerID == bowlerID);

            return View("EditBowler", application);
        }

        [HttpPost]
        public IActionResult Edit(Bowler blah)
        {
            _context.Update(blah);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int bowlerID)
        {
            var bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerID);
            _context.Remove(bowler);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //[HttpPost]
        public IActionResult Add()
        {
            return View();
        }


    }
}
