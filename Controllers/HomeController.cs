using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Teams = _context.Teams.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Bowler bowler)
        {
            bowler.BowlerID = (_context.Bowlers.ToList().Capacity + 1);
            _context.Add(bowler);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Filter()
        {
            ViewBag.Teams = _context.Teams.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult filterview (int teamID)
        {
            IEnumerable<Bowler> blah = _context.Bowlers
                .Include(x => x.Team)
                .Where(x => x.Team.TeamID == teamID)
                .ToList();

            ViewBag.Teams = _context.Teams.ToList();
            

            return View(blah);
        }

    }
}
