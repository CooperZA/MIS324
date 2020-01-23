using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cooperz_assign01.Models;

namespace cooperz_assign01.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PersonFormModel personFormModel)
        {
            ViewBag.Fname = personFormModel.Fname;
            return View(personFormModel);
        }
    }
}