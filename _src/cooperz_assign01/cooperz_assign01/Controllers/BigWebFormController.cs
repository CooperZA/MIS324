using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cooperz_assign01.Models;

namespace cooperz_assign01.Controllers
{
    public class BigWebFormController : Controller
    {
        // GET: BigWebForm
        [HttpGet]
        public ActionResult Index()
        {
            Response.Write("Method Get <br>");
            // set a couple of form values
            BigWebFormModel bigWebForm = new BigWebFormModel();
            bigWebForm.PersonId = 6;
            bigWebForm.IsSeaHawkFan = true;
            return View(bigWebForm);
        }

        [HttpPost]
        public ActionResult Index(BigWebFormModel bigWebForm)
        {
            Response.Write("Method Post <br>");
            ViewBag.message = bigWebForm.FName + " is a " + bigWebForm.Gender + " who lives in " + bigWebForm.StateAbbr + " and was born " + bigWebForm.BirthDate.ToShortDateString() + ". PersonId: " + bigWebForm.PersonId + " IsSeaHawkFan: " + bigWebForm.IsSeaHawkFan;
            return View(bigWebForm);
        }
    }
}