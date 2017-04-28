using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models; // add to access models
using System.Linq;
using System.Web.UI;

namespace HelloWorld.Controllers
{
    //[AuthorizeIPAddress] //add the ip address filter attribute
    //[Logging] // add the action filter attribute on the controller
    public class HomeController : Controller
    {
        //Security
        [Authorize]
        public ActionResult Notes()
        {
            return View();
        }

        // Create a cookie
        public ActionResult SetCookie()
        {
            // Name the cookie as MyCookie for later retrieval
            var cookie = new HttpCookie("MyCookie");

            // This cookie will expire about one minute, depends on the browser
            cookie.Expires = DateTime.Now.AddMinutes(1);

            // This cookie will have a simple string value of myUserName
            // but it can be any kind of object.
            cookie.Value = "myUserName";

            // Add the cookie to the response to send it to the browser
            HttpContext.Response.Cookies.Add(cookie);

            return View(cookie);
        }

        // to read or get cookie
        public ActionResult GetCookie()
        {
            return View(HttpContext.Request.Cookies["MyCookie"]);
        }


        //session exercise: create login action
        public ActionResult Login()
        {
            return View();     
        }

        [HttpPost] // session exercise: post back the username
        // on the index page when logged in
        public ActionResult Login(LoginModel loginModel)
        {
            Session["UserName"] = loginModel.UserName;
            return RedirectToAction("Index");
        }

        //session exercise: add Logoff method
        public ActionResult Logoff()
        {
            Session["UserName"] = null;
            return RedirectToAction("Index");
        }

        //Display Login Name: show the Partial View Result
        public PartialViewResult DisplayLoginName()
        {
            return new PartialViewResult();
        }

        public PartialViewResult IncrementCount()
        {
            int count = 0;

            // Check if MyCount exists
            if (Session["MyCount"] != null)
            {
                count = (int)Session["MyCount"];
                count++;
            }

            // Create the MyCount session variable
            Session["MyCount"] = count;

            return new PartialViewResult();
        }

        //public ActionResult Products()
        //{
        //    var products = new Product[]
        //    {
        //    // as part of exercise add a value for Count for each product
        //new Product{ ProductId = 1, Name = "First One", Price = 1.11m, Count = 0},
        //new Product{ ProductId = 2, Name="Second One", Price = 2.22m, Count = 3},
        //new Product{ ProductId = 3, Name="Third One", Price = 3.33m, Count = 1},
        //new Product{ ProductId = 4, Name="Fourth One", Price = 4.44m, Count = 10},
        //    };

        //    return View(products);
        //}

        //public ActionResult Product()
        //{
        //    var myProduct = new Product
        //    {
        //        ProductId = 1,
        //        Name = "Kayak",
        //        Description = "A boat for one person",
        //        Category = "water-sports",
        //        Price = 200m,
        //    };

        //    return View(myProduct);
        //}

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    base.OnException(filterContext);
        //}

        // introduce dependency injections to access our products

        private IProductRepository productRepository;

        // constructor
        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        //show first Product
        public ActionResult Product()
        {
            return View(productRepository.Products.First());
        }

        //Show entire Products
        //[OutputCache(Duration = 15, Location = OutputCacheLocation.Any, VaryByParam = "none")]
        public ActionResult Products()
        {
            return View(productRepository.Products);
        }

        // GET: Home
        public ActionResult Index()
        {
           
                //int x = 1;  // add me
                //x = x / (x - 1); // add me  
             
            return View();
        }

        //public ActionResult Error()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RsvpForm(Models.GuestResponse guestResponse)
        {
            if (ModelState.IsValid) // check on validation
            {
                return View("Thanks", guestResponse);
            }
            else //if false stay on the same page
            {
                return View();
            }
        }
    }
}