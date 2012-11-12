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
    public class MenuItemController : Controller
    {
        private AcquireLunchDb db = new AcquireLunchDb();

        //
        // GET: /MenuItem/

        public ActionResult Index()
        {
            var menuitems = db.MenuItems.Include(m => m.Restaurant);
            return View(menuitems.ToList());
        }

        //
        // GET: /MenuItem/Details/5

        public ActionResult Details(int id = 0)
        {
            MenuItem menuitem = db.MenuItems.Find(id);
            if (menuitem == null)
            {
                return HttpNotFound();
            }
            return View(menuitem);
        }

        //
        // GET: /MenuItem/Create

        public ActionResult Create()
        {
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name");
            return View();
        }

        //
        // POST: /MenuItem/Create

        [HttpPost]
        public ActionResult Create(MenuItem menuitem)
        {
            if (ModelState.IsValid)
            {
                db.MenuItems.Add(menuitem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name", menuitem.RestaurantId);
            return View(menuitem);
        }

        //
        // GET: /MenuItem/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MenuItem menuitem = db.MenuItems.Find(id);
            if (menuitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name", menuitem.RestaurantId);
            return View(menuitem);
        }

        //
        // POST: /MenuItem/Edit/5

        [HttpPost]
        public ActionResult Edit(MenuItem menuitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantId = new SelectList(db.Restaurants, "RestaurantId", "Name", menuitem.RestaurantId);
            return View(menuitem);
        }

        //
        // GET: /MenuItem/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MenuItem menuitem = db.MenuItems.Find(id);
            if (menuitem == null)
            {
                return HttpNotFound();
            }
            return View(menuitem);
        }

        //
        // POST: /MenuItem/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuItem menuitem = db.MenuItems.Find(id);
            db.MenuItems.Remove(menuitem);
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