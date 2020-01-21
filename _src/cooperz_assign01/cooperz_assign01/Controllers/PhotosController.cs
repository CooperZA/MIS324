using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cooperz_assign01.Controllers
{
    public class PhotosController : Controller
    {
        // GET: Photos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cosmos()
        {
            return View();
        }

        public ActionResult Dahlia()
        {
            return View();
        }

        public ActionResult Lotus()
        {
            return View();
        }

        //use parameter to pass in photo id
        public ActionResult photoView(string id)
        {
            ViewBag.photo = id;
            return View();
        }
    }
}