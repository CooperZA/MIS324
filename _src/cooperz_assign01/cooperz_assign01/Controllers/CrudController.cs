using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using cooperz_assign01.Models;
using cooperz_assign01.DataRepository;

namespace cooperz_assign01.Controllers
{
    public class CrudController : Controller
    {
        // create repo object
        CrudRepository crudRepo = new CrudRepository();

        // GET: Crud
        public ActionResult Index()
        {
            return View(crudRepo.GetAllPeople());
        }

        // GET: People/Details
        public ActionResult Details(int id)
        {
            return View(crudRepo.GetOnePerson(id));
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        public ActionResult Create(CrudModel crudModel)
        {
            if (!ModelState.IsValid) return View(crudModel);

            crudRepo.AddPerson(crudModel);
            return RedirectToAction("Index");
        }

        // GET: People/Edit
        public ActionResult Edit(int id)
        {
            return View(crudRepo.GetOnePerson(id));
        }

        // POST: People/Edit
        [HttpPost]
        public ActionResult Edit(CrudModel crudModel)
        {
            if (!ModelState.IsValid) return View(crudModel);

            crudRepo.UpdatePerson(crudModel);
            return RedirectToAction("Index");
        }

        // GET: People/Delete
        public ActionResult Delete(int id)
        {
            crudRepo.DeletePerson(id);
            return RedirectToAction("Index");
        }

        public string SetAutoClose()
        {
            string db = crudRepo.AutoClose();
            return "Sucess! Auto Close set to 'on' for database " + db;
        }
        //update and delete
    }
}