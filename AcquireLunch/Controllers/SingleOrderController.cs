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
    public class SingleOrderController : Controller
    {
        private AcquireLunchDb db = new AcquireLunchDb();

        //
        // GET: /SingleOrder/

        public ActionResult Index()
        {
            var singleorders = db.SingleOrders.Include(s => s.Person);
            return View(singleorders.ToList());
        }

        //
        // GET: /SingleOrder/Details/5

        public ActionResult Details(int id = 0)
        {
            SingleOrder singleorder = db.SingleOrders.Find(id);
            if (singleorder == null)
            {
                return HttpNotFound();
            }
            return View(singleorder);
        }

        //
        // GET: /SingleOrder/Create

        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "FirstName");
            return View();
        }

        //
        // POST: /SingleOrder/Create

        [HttpPost]
        public ActionResult Create(SingleOrder singleorder)
        {
            if (ModelState.IsValid)
            {
                db.SingleOrders.Add(singleorder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(db.People, "PersonId", "FirstName", singleorder.PersonId);
            return View(singleorder);
        }

        //
        // GET: /SingleOrder/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SingleOrder singleorder = db.SingleOrders.Find(id);
            if (singleorder == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "FirstName", singleorder.PersonId);
            return View(singleorder);
        }

        //
        // POST: /SingleOrder/Edit/5

        [HttpPost]
        public ActionResult Edit(SingleOrder singleorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(singleorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "FirstName", singleorder.PersonId);
            return View(singleorder);
        }

        //
        // GET: /SingleOrder/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SingleOrder singleorder = db.SingleOrders.Find(id);
            if (singleorder == null)
            {
                return HttpNotFound();
            }
            return View(singleorder);
        }

        //
        // POST: /SingleOrder/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SingleOrder singleorder = db.SingleOrders.Find(id);
            db.SingleOrders.Remove(singleorder);
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