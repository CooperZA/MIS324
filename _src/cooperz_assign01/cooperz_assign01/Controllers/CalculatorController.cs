using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cooperz_assign01.Models;

namespace cooperz_assign01.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CalculatorModel calculator, string myButton)
        {
            switch (myButton)
            {
                case "Add":
                    //add
                    ViewBag.result = calculator.ValueA + calculator.ValueB;
                    break;
                case "Subtract":
                    //sub
                    ViewBag.result = calculator.ValueA - calculator.ValueB;
                    break;
                case "Multiply":
                    //mult
                    ViewBag.result = calculator.ValueA * calculator.ValueB;
                    break;
                case "Divide":
                    //div
                    ViewBag.result = calculator.ValueA / calculator.ValueB;
                    break;
            }

            Response.Write("myButton:" + myButton + "<br>");
            return View(calculator);
        }
    }
}