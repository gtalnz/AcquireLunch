using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcquireLunch.Models;

namespace AcquireLunch.Controllers
{
    public class RestaurantLocationController : Controller
    {
        private AcquireLunchDb db = new AcquireLunchDb();

        //
        // GET: /RestaurantLocation/

        public ActionResult Index()
        {
            var restaurantlocations = db.RestaurantLocations.Include(r => r.Restaurant);
            return View(restaurantlocations.ToList());
        }

        //
        // GET: /RestaurantLocation/Details/5

        public ActionResult Details(int id = 0)
        {
            RestaurantLocation restaurantlocation = db.RestaurantLocations.Find(id);
            if (restaurantlocation == null)
            {
                return HttpNotFound();
            }
            return View(restaurantlocation);
        }

        //
        // GET: /RestaurantLocation/Create

        public ActionResult Create()
        {
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name");
            return View();
        }

        //
        // POST: /RestaurantLocation/Create

        [HttpPost]
        public ActionResult Create(RestaurantLocation restaurantlocation)
        {
            if (ModelState.IsValid)
            {
                db.RestaurantLocations.Add(restaurantlocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name", restaurantlocation.RestaurantId);
            return View(restaurantlocation);
        }

        //
        // GET: /RestaurantLocation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RestaurantLocation restaurantlocation = db.RestaurantLocations.Find(id);
            if (restaurantlocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name", restaurantlocation.RestaurantId);
            return View(restaurantlocation);
        }

        //
        // POST: /RestaurantLocation/Edit/5

        [HttpPost]
        public ActionResult Edit(RestaurantLocation restaurantlocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantlocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name", restaurantlocation.RestaurantId);
            return View(restaurantlocation);
        }

        //
        // GET: /RestaurantLocation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RestaurantLocation restaurantlocation = db.RestaurantLocations.Find(id);
            if (restaurantlocation == null)
            {
                return HttpNotFound();
            }
            return View(restaurantlocation);
        }

        //
        // POST: /RestaurantLocation/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RestaurantLocation restaurantlocation = db.RestaurantLocations.Find(id);
            db.RestaurantLocations.Remove(restaurantlocation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}