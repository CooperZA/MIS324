using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cooperz_assign01.Models;
using cooperz_assign01.ViewModels;
using cooperz_assign01.ViewModels.ListBoardsViewModel;
using cooperz_assign01.ViewModels.ListExperienceViewModel;

namespace cooperz_assign01.Controllers
{
    public class SnowboardController : Controller
    {
        // GET: Snowboard
        [HttpGet]
        public ActionResult Index()
        {
            Response.Write("Method: GET <br>");

            SnowboardModel sbModel = new SnowboardModel();

            return View(sbModel);
        }

        [HttpPost]
        public ActionResult Index(SnowboardModel sbModel)
        {
            Response.Write("Method: POST <br>");

            // new custOrder object
            CustomerOrderModel custOrder = new CustomerOrderModel();

            // board model id
            Boards boardModel = ListBoardsViewModel.BoardList.Find(m => m.ModelId == sbModel.ModelID);

            // assign model name from boardModel to CustOrder
            custOrder.ModelName = boardModel.ModelName;

            // assign model price from boardModel to CustOrder
            custOrder.ModelPrice = boardModel.Price;

            // get surcharge from experiences list model
            Experience expModel = ListExperienceViewModel.ExperienceLevel.Find(m => m.Level == sbModel.ExperienceLevel);

            // calculate the surcharge
            custOrder.ExperienceSurchargeDollars = custOrder.ModelPrice * (1 + expModel.Surcharge);

            if (sbModel.DiscountSenior && sbModel.DiscountStudent)
            {
                ModelState.AddModelError("Discounts", "You annot have both student and senior discounts.");
            }

            // return to view if any feilds are invalid
            if (!ModelState.IsValid) return View(sbModel);

            return View(sbModel);
        }
    }
}