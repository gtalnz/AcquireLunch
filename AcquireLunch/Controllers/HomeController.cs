using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcquireLunch.Models;
using AcquireLunch.ViewModels;

namespace AcquireLunch.Controllers
{
    public class HomeController : Controller
    {
        private AcquireLunchDb db = new AcquireLunchDb();

        public ActionResult Index()
        {
            ViewBag.Message = "Let's eat!";
            var viewModel = new IndexViewModel();
            viewModel.People = db.People;
            viewModel.Restaurants = db.Restaurants;
            viewModel.MenuItems = db.MenuItems;

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
