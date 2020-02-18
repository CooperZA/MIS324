using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using cooperz_assign01.Models;
using cooperz_assign01.DataRepository;

namespace cooperz_assign01.Controllers
{
    public class BirdViewController : Controller
    {
        // create repo object
        BirdViewRepository birdRepo = new BirdViewRepository();

        // GET: Bird
        public ActionResult Index()
        {
            return View(birdRepo.GetRandom());
        }

        // GET: PartialView
        [ChildActionOnly]
        public ActionResult _leftMenu()
        {
            ViewBag.menu = "<ul class='alphaList'>\n";
            for (int i = 65; i <= 90; i++)
            {
                char c = (char)i;
                string relativePath = Url.Content("~/BirdView/ShowImage/");
                ViewBag.menu += "<a href='" + relativePath + c + "'><div>" + c + "</div></a>\n ";
            }
            ViewBag.menu += "</ul>";
            return PartialView();
        }

        // GET: Bird/Details
        public ActionResult Details(int id)
        {
            return View(birdRepo.GetOneBird(id));
        }

        public string SetAutoClose()
        {
            string db = birdRepo.AutoClose();
            return "Sucess! Auto Close set to 'on' for database " + db;
        }
    }
}