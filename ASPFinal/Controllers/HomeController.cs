using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPFinal.Models;
using ASPFinal.Models.EntityFramework;

namespace ASPFinal.Controllers
{
    public class HomeController : Controller
    {
        private HenryBookstoreASPDatabase dbo = new HenryBookstoreASPDatabase();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BrowseByAuthor()
        {
            var allauthors = dbo.AUTHORs.ToList();
            List<AUTHOR> result = new List<AUTHOR>();

            foreach (var auth in allauthors)
            {
                var model = new AUTHOR();
                model.AUTHOR_NUM = auth.AUTHOR_NUM;
                model.AUTHOR_FIRST = auth.AUTHOR_FIRST;
                model.WROTEs = dbo.WROTEs.Where(c => c.AUTHOR_NUM == auth.AUTHOR_NUM).ToList();
                result.Add(model);
            }

            //data needed in the view
            return View(result);
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
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact contactData)
        {
            return View();
        }
    }
}