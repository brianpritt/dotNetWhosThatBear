using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhosThatBear.Models;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WhosThatBear.Controllers
{
    public class SightingsController : Controller
    {
        private WhosThatBearContext db = new WhosThatBearContext();
        public IActionResult Index()
        {
            return View(db.Sightings.Include(sightings => sightings.Species).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisSighting = db.Sightings.FirstOrDefault(sightings => sightings.SightingId == id);
            return View(thisSighting);
        }
        public ActionResult Create()
        {
            ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Sighting sighting)
        {
            db.Sightings.Add(sighting);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Edit(int id)
        {
            var thisSighting = db.Sightings.FirstOrDefault(sightings => sightings.SightingId == id);
            ViewBag.SpeciesId = new SelectList(db.Species, "SpeciesId", "Name");
            return View(thisSighting);
        }
        [HttpPost]
        public ActionResult Edit(Sighting sighting)
        {
            db.Entry(sighting).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisSighting = db.Sightings.FirstOrDefault(sightings => sightings.SightingId == id);
            return View(thisSighting);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisSighting = db.Sightings.FirstOrDefault(sightings => sightings.SightingId == id);
            db.Sightings.Remove(thisSighting);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
