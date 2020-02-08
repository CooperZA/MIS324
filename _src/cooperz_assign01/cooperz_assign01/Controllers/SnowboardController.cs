using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cooperz_assign01.Models;
using cooperz_assign01.ViewModels;
using cooperz_assign01.ViewModels.ListBoardsViewModel;
using cooperz_assign01.ViewModels.ListExperienceViewModel;
using cooperz_assign01.ViewModels.ListStatesViewModel;

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

            if (sbModel.DiscountSenior && sbModel.DiscountStudent)
            {
                ModelState.AddModelError("Discounts", "You annot have both student and senior discounts.");
            }

            // return to view if any feilds are invalid
            if (!ModelState.IsValid) return View(sbModel);

            // new custOrder object
            CustomerOrderModel custOrder = new CustomerOrderModel();

            // find board model
            Boards boardModel = ListBoardsViewModel.BoardList.Find(m => m.ModelId == sbModel.ModelID);

            // assign model name from boardModel to CustOrder
            custOrder.ModelName = boardModel.ModelName;

            // assign model price from boardModel to CustOrder
            custOrder.ModelPrice = boardModel.Price;

            // get surcharge from experiences list model
            Experience expModel = ListExperienceViewModel.ExperienceLevel.Find(m => m.Level == sbModel.ExperienceLevel);

            // get experieince surcharge percentage
            custOrder.ExperienceSurchargePercent = expModel.Surcharge;

            // calculate the surcharge
            custOrder.ExperienceSurchargeDollars = custOrder.ModelPrice * (1 + expModel.Surcharge);

            // check  for discounts
            if (sbModel.DiscountStudent)
            {
                custOrder.DiscountsTaken += "student, ";
                custOrder.DiscountsPercent += 0.1;
            }
            if (sbModel.DiscountSenior)
            {
                custOrder.DiscountsTaken += "senior, ";
                custOrder.DiscountsPercent += 0.05;
            }
            if (sbModel.DiscountGoldClub)
            {
                custOrder.DiscountsTaken += "gold club, ";
                custOrder.DiscountsPercent += 0.08;
            }

            // trim list of discounts
            if ( custOrder.DiscountsTaken != null) custOrder.DiscountsTaken = custOrder.DiscountsTaken.TrimEnd(',', ' ');

            // get discount dollar amount
            custOrder.DiscountDollars = custOrder.ModelPrice * custOrder.DiscountsPercent; 
            
            // calculate subtotal
            custOrder.Subtotal = custOrder.ExperienceSurchargeDollars * (1 + custOrder.DiscountsPercent);
            
            // get tax rate
            State stateTax = ListStatesViewModel.StateList.Find(m => m.StateAbbr == sbModel.State);

            // get tax rate
            custOrder.TaxPercent = stateTax.TaxRate;

            // get the tax dollar amount
            custOrder.TaxDollars = custOrder.Subtotal * custOrder.TaxPercent;

            // calculate total price
            custOrder.TotalPrice = custOrder.Subtotal * (1 + stateTax.TaxRate);

            return View("OrderConfirmation", custOrder);
        }


        public ActionResult OrderConfirmation(CustomerOrderModel custOrder)
        {
            return View(custOrder);
        }
    }
}