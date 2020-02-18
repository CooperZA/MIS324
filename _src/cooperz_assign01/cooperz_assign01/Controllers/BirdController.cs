using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using cooperz_assign01.Models;
using cooperz_assign01.DataRepository;

namespace cooperz_assign01.Controllers
{
    public class BirdController : Controller
    {
        // create repo object
        BirdRepository birdRepo = new BirdRepository();

        // GET: Bird
        public ActionResult Index()
        {
            return View(birdRepo.GetAllBird());
        }

        // GET: Random Bird
        public ActionResult ViewRandom()
        {
            return View(birdRepo.GetRandom());
        }

        // GET: Bird/Details
        public ActionResult Details(int id)
        {
            return View(birdRepo.GetOneBird(id));
        }

        // GET: Bird/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bird/Create
        [HttpPost]
        public ActionResult Create(BirdModel birdModel)
        {
            if (!ModelState.IsValid) return View(birdModel);

            birdRepo.AddBird(birdModel);
            return RedirectToAction("Index");
        }

        // GET: Bird/Edit
        public ActionResult Edit(int id)
        {
            return View(birdRepo.GetOneBird(id));
        }

        // POST: Bird/Edit
        [HttpPost]
        public ActionResult Edit(BirdModel birdModel)
        {
            if (!ModelState.IsValid) return View(birdModel);

            birdRepo.UpdateBird(birdModel);
            return RedirectToAction("Index");
        }

        // GET: Bird/Delete
        //public ActionResult Delete(int id)
        //{
        //    birdRepo.DeleteBird(id);
        //    return RedirectToAction("Index");
        //}

        public string SetAutoClose()
        {
            string db = birdRepo.AutoClose();
            return "Sucess! Auto Close set to 'on' for database " + db;
        }
    }
}