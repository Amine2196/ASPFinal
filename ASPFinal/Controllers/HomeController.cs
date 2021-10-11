using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFinal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BrowseByAuthor()
        {
            return View();
        }

        public ActionResult BrowseByLocation()
        {
            return View();
        }

        public ActionResult BrowseByPublisher()
        {
            return View();
        }

        public ActionResult BookDetails()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}