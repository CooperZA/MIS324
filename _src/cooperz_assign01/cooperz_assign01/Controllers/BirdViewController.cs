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
        public ActionResult _leftMenu(ColorModel colorModel)
        {
            return PartialView(colorModel);
        }

        // GET: bird Filtered by color /////////////// possible error with type conversion
        public ActionResult Browse(string colorid)
        {
            return View("index", birdRepo.GetBirdsByColor(colorid));
        }

        // GET: Bird/Details
        public ActionResult Details(int id)
        {
            return View(birdRepo.GetOneBird(id));
        }

        // GEt: Search Birds
        public ActionResult Search(string id)
        {
            return View("index", birdRepo.Search(id));
        }

        // AJAX
        public ActionResult AjaxSearch(string id)
        {
            return View();
        }

        // handler for AJAX requests, returns JSON
        public ActionResult AjaxSearchHandler(string id)
        {
            return Json(birdRepo.Search(id), JsonRequestBehavior.AllowGet);
        }

        // Auto Close
        public string SetAutoClose()
        {
            string db = birdRepo.AutoClose();
            return "Sucess! Auto Close set to 'on' for database " + db;
        }
    }
}