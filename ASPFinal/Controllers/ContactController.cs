using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPFinal.Models.EntityFramework;
using ASPFinal.Models;

namespace ASPFinal.Controllers
{
    public class ContactController : Controller
    {
        private HenryBookstoreASPDatabase dbo = new HenryBookstoreASPDatabase();
        // GET: Contact
        public ActionResult Index()
        {
            Contact model = new Contact();

            model.AllBranches = dbo.INVENTORies.OrderBy(c => c.BRANCH_NUM).ToList().Select(c => new SelectListItem
            {
                Text = c.BRANCH_NUM.ToString(),
                Value = c.BRANCH_NUM.ToString()
            });

            return View("~/Views/Home/Contact.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(Contact model)
        {

            model.AllBranches = dbo.INVENTORies.OrderBy(c => c.BRANCH_NUM).ToList().Select(c => new SelectListItem
            {
                Text = c.BRANCH_NUM.ToString(),
                Value = c.BRANCH_NUM.ToString()
            });

            if (string.IsNullOrEmpty(model.FirstName))
            {
                ModelState.AddModelError("", "Please Enter Your First Name");

            }
            else if (string.IsNullOrEmpty(model.LastName))
            {
                ModelState.AddModelError("", "Please Enter Your Last Name");
            }
            else if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("", "Please Enter Your Email");
            }
            else if (string.IsNullOrEmpty(model.EmailConfirm))
            {
                ModelState.AddModelError("", "Email and Confirmation Email Must be filled out and matching");
            }
            else if (string.IsNullOrEmpty(model.Message))
            {
                ModelState.AddModelError("", "Message Cannot Be Empty");
            }
            else
            {
                ModelState.AddModelError("", "Please Check Your Entries And Try Again");
            }

            return View("~/Views/Home/Contact.cshtml", model);
        }
    }
}