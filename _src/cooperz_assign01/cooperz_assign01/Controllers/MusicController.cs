using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using cooperz_assign01.Models;
using cooperz_assign01.DataRepository;

namespace cooperz_assign01.Controllers
{
    public class MusicController : Controller
    {
        // create repo object
        MusicRepository musicRepo = new MusicRepository();

        // GET: Bird
        public ActionResult Index()
        {
            ViewBag.Title = "MVC Music";
            return View(musicRepo.GetRandom());
        }

        // GET: PartialView
        public ActionResult _leftMenu()
        {
            List<MusicStyleModel> music = musicRepo.GetMusicCategories();
            return View(music);
        }

        // GET: Music Filtered by color /////////////// possible error with type conversion
        public ActionResult Browse(int id)
        {
            //if (id == null) return RedirectToAction("index");
            ViewBag.message = "Browse";
            return View("index", musicRepo.GetMusicByStyle(id));
        }

        // GET: Music/Details
        public ActionResult Details(string id)
        {
            if (id == null) return RedirectToAction("index");
            ViewBag.message = "Title Details";
            return View(musicRepo.GetOneTitle(id));
        }

        // GEt: Search Music
        public ActionResult Search(string query)
        {
            if (query == null) return RedirectToAction("index");
            ViewBag.message = "Search Results";
            return View("index", musicRepo.Search(query));
        }

        // Cart
        //public ActionResult Cart()
        //{

        //}

        ////Add to Cart
        //public ActionResult AddToCart(string id)
        //{

        //}

        ////Remove from Cart
        //public ActionResult RemoveFromCart(string id)
        //{

        //}

        ////GET: Sign In
        //[HttpGet]
        //public ActionResult SignIn()
        //{

        //}

        ////POST: Signin
        //[HttpPost]
        //public ActionResult SignIn(SignInModel signInModel)
        //{

        //}

        ////GET: Checkout
        //public ActionResult Checkout(SignInModel signInModel)
        //{

        //}

        ////POST: Checkout
        //[HttpPost]
        //public ActionResult Checkout(CustomerModel customerModel)
        //{

        //}

        ////History
        //public ActionResult History(string id)
        //{

        //}

        ////About
        //public ActionResult About()
        //{

        //}

        // Auto Close
        public string SetAutoClose()
        {
            string db = musicRepo.AutoClose();
            return "Sucess! Auto Close set to 'on' for database " + db;
        }
    }
}