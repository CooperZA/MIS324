using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cooperz_assign01.Models;
using cooperz_assign01.ViewModels;

namespace cooperz_assign01.Controllers
{
    public class FontPickerController : Controller
    {
        // GET: FontPicker
        [HttpGet]
        public ActionResult Index()
        {
            FontPickerModel fontPicker = new FontPickerModel();
            ViewBag.imageTags = GenerateImageTags(fontPicker);
            return View();
        }

        [HttpPost]
        public ActionResult Index(FontPickerModel fontPicker)
        {
            Response.Write("Method Post <br>");
            Response.Write("FontID: " + fontPicker.FontID + "<br>");
            Response.Write("message: " + fontPicker.Message + "<br>");
        
            if (ModelState.IsValid)
            {
                ViewBag.imageTags = GenerateImageTags(fontPicker);
            }
            return View(fontPicker);
        }

        // Fonts View
        [HttpGet]
        public ActionResult Fonts()
        {
            FontPickerModel fontPicker = new FontPickerModel();

            ViewBag.imageTags = GenerateImageTags(fontPicker);

            return View();
        }

        [HttpPost]
        public ActionResult Fonts(FontPickerModel fontPicker)
        {
            Response.Write("Method Post <br>");
            Response.Write("FontID: " + fontPicker.FontID + "<br>");
            if (ModelState.IsValid)
            {
                ViewBag.imageTags = GenerateImageTags(fontPicker);
            }
            return View(fontPicker);
        }


        //generate tags method
        private string GenerateImageTags(FontPickerModel fontPicker)
        {
            // build string of image tags
            string imageTags = "";

            // loop through message
            for (int i = 0; i < fontPicker.Message.Length; i++)
            {
                string character = fontPicker.Message.Substring(i, 1);
                if (character != " ")
                {
                    // call method to get tag
                    imageTags += GetTag(fontPicker, character);
                } 
                else
                {
                    imageTags += "<br/>\n";
                }
            }

            return imageTags;
        }


        //get tag method
        private string GetTag(FontPickerModel fontPicker, string character)
        {
            //declare url
            string url = "";
            
            // select correct tag backed on fontID
            if (fontPicker.FontID == "ChunkRed")
            {
                url = "<img src='http://yorktown.cbe.wwu.edu/sandvig/images/alphabet/chunk/red/" + character + "9.jpg'/>\n";
            } else if (fontPicker.FontID == "DecoBlue"){
                url = "<img src='http://yorktown.cbe.wwu.edu/sandvig/images/alphabet/deco/blue/" + character + "1.gif'/>\n";
            } else if (fontPicker.FontID == "Animals")
            {
                url = "<img src='http://yorktown.cbe.wwu.edu/sandvig/images/alphabet/animals/" + character + "4.gif'/>\n";
            } else if (fontPicker.FontID == "ElegantRed")
            {
                url = "<img src='http://yorktown.cbe.wwu.edu/sandvig/images/alphabet/elegant/red/4" + character + ".gif'/>\n";
            } else if (fontPicker.FontID == "Funky")
            {
                url = "<img src='http://yorktown.cbe.wwu.edu/sandvig/images/alphabet/funky/" + character + "3.jpg'/>\n";
            } else if (fontPicker.FontID == "TapePunch")
            {
                url = "<img src='http://yorktown.cbe.wwu.edu/sandvig/images/alphabet/punch/black/" + character + "7.gif'/>\n";
            } else
            {
                //default value
                url = "<img src='http://yorktown.cbe.wwu.edu/sandvig/images/alphabet/chunk/red/" + character + "9.jpg'/>\n";
            }

            return url;
        }
    }
}