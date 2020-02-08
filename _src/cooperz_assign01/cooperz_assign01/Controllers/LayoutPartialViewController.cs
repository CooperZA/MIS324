using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cooperz_assign01.Controllers
{
    public class LayoutPartialViewController : Controller
    {
        // GET: LayoutPartialView
        public ActionResult Index()
        {
            return View();
        }

        // GET: PartialView
        public ActionResult _leftMenu()
        {
            ViewBag.menu = "<ul class='alphaList'>\n";
            for (int i = 65; i <= 90; i++)
            {
                char c = (char)i;
                string relativePath = Url.Content("~/LayoutPartialView/ShowImage/");
                ViewBag.menu += "<a href='" + relativePath + c + "'><div>" + c + "</div></a>\n ";
            }
            ViewBag.menu += "</ul>";
            return PartialView();
        }

        // get image
        public ActionResult ShowImage(string id)
        {
            ViewBag.displayChar = id;
            return View();
        }
    }
}