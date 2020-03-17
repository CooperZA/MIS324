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
        // create cart repo object
        MusicCartRepository cartRepo = new MusicCartRepository();

        // GET: Index
        public ActionResult Index()
        {
            ViewBag.Title = "MVC Music";
            return View(musicRepo.GetRandom());
        }

        // Header
        //public ActionResult _header()
        //{
        //    return View("_header", cartRepo.GetAllItemsInCart());
        //}

        // GET: PartialView
        public ActionResult _leftMenu()
        {
            List<MusicStyleModel> music = musicRepo.GetMusicCategories();
            return View(music);
        }

        // GET: Music Filtered by color
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

        //Cart
        public ActionResult Cart()
        {
            // display nothing if cart is empty
            return View("Cart", cartRepo.GetAllItemsInCart());
        }

        //Add to Cart
        public ActionResult AddToCart(string id)
        {
            cartRepo.AddToCart(id);
            return View("Cart", cartRepo.GetAllItemsInCart());
        }

        //Remove from Cart
        public ActionResult RemoveFromCart(string id)
        {
            cartRepo.RemoveFromCart(id);
            return View("Cart", cartRepo.GetAllItemsInCart());
        }

        //GET: Sign In
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        //POST: Signin
        [HttpPost]
        public ActionResult SignIn(SignInModel signInModel)
        {
            if (!ModelState.IsValid) return View(signInModel);

            return RedirectToAction("checkout", new { signInModel.Email });
        }

        //GET: Checkout
        [HttpGet]
        public ActionResult Checkout(string email)
        {
            if (email == null) return RedirectToAction("SignIn");

            CustomerModel customerModel = musicRepo.GetPersonByEmail(email);
            if (customerModel != null)
                ViewBag.message = "Returning Customer: Please review shipping information";
            else
            {
                ViewBag.message = "New Customer: Please enter shipping information";
                customerModel = new CustomerModel();
                customerModel.Email = email;
            }

            ViewBag.title = "Checkout";

            return View(customerModel);
        }

        //POST: Checkout
        [HttpPost]
        public ActionResult Checkout(CustomerModel customerModel)
        {
            // check model state
            if (!ModelState.IsValid) return View(customerModel);
            // new or returning customer
            if (customerModel.CustID > 0)
            {
                //returning customer
                musicRepo.UpdateCustomer(customerModel);
            }
            else
            {
                //new customer
                customerModel.CustID = musicRepo.InsertCustomer(customerModel); ////maybe else statement
            }

            Response.Write("CustID: " + customerModel.CustID);

            // Write order info
            int orderID = musicRepo.WriteOrder(customerModel.CustID);

            // populate checkout model 
            MusicCheckoutModel musicCheckoutModel = new MusicCheckoutModel();
            musicCheckoutModel.OrderID = orderID;
            musicCheckoutModel.OrderDate = DateTime.Now;
            musicCheckoutModel.CustModel = customerModel;

            // instatiate new music repo obj
            MusicCartRepository mCR = new MusicCartRepository();

            // populate order model with cart items
            musicCheckoutModel.OrderModel = mCR.GetAllItemsInCart();

            musicRepo.WriteOrderItems(orderID);

            // delete sessionID
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));


            ViewBag.title = "Order Confirmation";
            ViewBag.message = "Data written to db";

            // send email here 3c-3d
            // create method to generate header info
            string head = Utilities.SendEmail.GenerateHeader();

            //generate body
            string body = RenderRazorViewToString("OrderConfirmation", musicCheckoutModel);

            // other email vars
            string fromEmail = "cooperz@wwu.edu";
            string subject = "Your MVC Music Order";
            string fromName = "MVC Music";

            // send email
            Utilities.SendEmail.Send(customerModel.Email, customerModel.Fname + ' ' + customerModel.Lname, fromEmail, fromName, subject, body, true);

            return View("OrderConfirmation", musicCheckoutModel);
        }

        //History
        public ActionResult History(string id)
        {
            return View("History", musicRepo.GetHistory(id));
        }

        //About
        public ActionResult About()
        {
            return View();
        }

        // TODO: Where to put 3c and 3d
        //build html email string
        private string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new System.IO.StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        // Auto Close
        public string SetAutoClose()
        {
            string db = musicRepo.AutoClose();
            return "Sucess! Auto Close set to 'on' for database " + db;
        }
    }
}