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

        [HttpPost]
        public ActionResult BrowseByAuthor(int id)
        {
            AUTHOR author = dbo.AUTHORs.Find(id);
            if (author == null)
            {
                HttpNotFound();
            }

            var allauthors = dbo.AUTHORs.ToList();
            List<AUTHOR> result = new List<AUTHOR>();

            foreach (var auth in allauthors)
            {
                var model = new AUTHOR();
                model.AUTHOR_NUM = auth.AUTHOR_NUM;
                model.AUTHOR_LAST = auth.AUTHOR_LAST;
                model.WROTEs = dbo.WROTEs.Where(c => c.AUTHOR_NUM == auth.AUTHOR_NUM).ToList();
                var filterBy = from f in dbo.AUTHORs
                               where f.AUTHOR_NUM == id
                               //where f.AUTHOR_NUM.Equals(id)
                               orderby f.AUTHOR_FIRST
                               select f;

                //model.WROTEs = filterBy.ToList();

                result.Add(model);
            }

            //data needed in the view
            return View("~/Views/Home/BrowseByAuthor.cshtml", result);
        }

        public ActionResult BrowseByLocation()
        {
            var allauthors = dbo.BRANCHes.ToList();
            List<BRANCH> result = new List<BRANCH>();

            foreach (var auth in allauthors)
            {
                var model = new BRANCH();
                model.BRANCH_NUM = auth.BRANCH_NUM;
                model.BRANCH_NAME = auth.BRANCH_NAME;
                model.INVENTORies = dbo.INVENTORies.Where(c => c.BRANCH_NUM == auth.BRANCH_NUM).ToList();
                result.Add(model);
            }

            //data needed in the view
            return View(result);
        }

        [HttpPost]
        public ActionResult BrowseByLocation(int id)
        {
            var allauthors = dbo.BRANCHes.ToList();
            List<BRANCH> result = new List<BRANCH>();

            foreach (var auth in allauthors)
            {
                var model = new BRANCH();
                model.BRANCH_NUM = auth.BRANCH_NUM;
                model.BRANCH_NAME = auth.BRANCH_NAME;
                model.INVENTORies = dbo.INVENTORies.Where(c => c.BRANCH_NUM == auth.BRANCH_NUM).ToList();
                result.Add(model);
            }

            //data needed in the view
            return View(result);
        }


        public ActionResult BrowseByPublisher()
        {
            var allauthors = dbo.PUBLISHERs.ToList();
            List<PUBLISHER> result = new List<PUBLISHER>();

            foreach (var auth in allauthors)
            {
                var model = new PUBLISHER();
                model.PUBLISHER_CODE = auth.PUBLISHER_CODE;
                model.PUBLISHER_NAME = auth.PUBLISHER_NAME;
                model.BOOKs = dbo.BOOKs.Where(c => c.PUBLISHER_CODE == auth.PUBLISHER_CODE).ToList();
                result.Add(model);
            }

            //data needed in the view
            return View(result);
        }

        [HttpPost]
        public ActionResult BrowseByPublisher(int id)
        {
            var allauthors = dbo.PUBLISHERs.ToList();
            List<PUBLISHER> result = new List<PUBLISHER>();

            foreach (var auth in allauthors)
            {
                var model = new PUBLISHER();
                model.PUBLISHER_CODE = auth.PUBLISHER_CODE;
                model.PUBLISHER_NAME = auth.PUBLISHER_NAME;
                model.BOOKs = dbo.BOOKs.Where(c => c.PUBLISHER_CODE == auth.PUBLISHER_CODE).ToList();
                result.Add(model);
            }

            //data needed in the view
            return View(result);
        }


        public ActionResult BookDetails(string id)
        {
            BOOK book = dbo.BOOKs.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            //var auth = dbo.AUTHORs.Find(dbo.BOOKs.Find(id));
            ViewBag.Name = book.TITLE.ToUpper();
            ViewBag.Price = String.Format("{0:C}", book.PRICE);
            ViewBag.Author = book.WROTEs.First().AUTHOR.AUTHOR_LAST;
            ViewBag.Publisher = book.PUBLISHER.PUBLISHER_NAME;
            ViewBag.PubId = book.PUBLISHER.PUBLISHER_CODE;
            //ViewBag.AuthId = auth.AUTHOR_NUM;

            return View(book);
        }

        public ActionResult Contact()
        {
            //Contact bra = new Contact();
            //var allb = dbo.BRANCHes.ToList();

            //foreach (var auth in allb)
            //{
            //    var model = new BRANCH();
            //    model.BRANCH_NUM = auth.BRANCH_NUM;
            //    model.BRANCH_NAME = auth.BRANCH_NAME;
            //    bra.Add(model);
            //}

            return View();
        }

        [HttpPost]
        public JsonResult Contact(Contact contactData)
        {
            return Json(contactData);
        }

        public ActionResult BrowseByInventory()
        {
            var allauthors = dbo.INVENTORies.ToList();
            List<INVENTORY> result = new List<INVENTORY>();

            foreach (var auth in allauthors)
            {
                var model = new INVENTORY();
                model.ON_HAND = auth.ON_HAND;
                model.BOOK_CODE = auth.BOOK_CODE;
                result.Add(model);
            }

            return View(result);
        }

        [HttpPost]
        public ActionResult BrowseByInventory(string id)
        {
            var allauthors = dbo.INVENTORies.ToList();
            List<INVENTORY> result = new List<INVENTORY>();

            BOOK book = dbo.BOOKs.Find(id);

            if (book == null)
            {
                return HttpNotFound();
            }

            //foreach (var auth in allauthors)
            //{
            //    var model = new INVENTORY();
            //    model.ON_HAND = auth.ON_HAND;
            //    model.BOOK_CODE = auth.BOOK_CODE;
            //    model.BOOK = auth.BOOK;
            //    model.BRANCH = auth.BRANCH;
            //    model.BRANCH_NUM = auth.BRANCH_NUM;
            //    model.ON_HAND = auth.ON_HAND;

            //    result.Add(model);
            //}

            //data needed in the view
            return View("~/Views/Home/BrowseByInventory.cshtml", book);
        }
    }
}