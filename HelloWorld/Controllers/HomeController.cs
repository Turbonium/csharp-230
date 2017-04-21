using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;
using Swashbuckle.Application;

// add to access models

namespace HelloWorld.Controllers
{
    [Logging]
    [AuthorizeIPAddress]
    public class HomeController : Controller
    {
        //Introduce Dependency injection
        private IProductRepository productRepository;

        //Constructor
        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ActionResult Product()
        {
            return View(productRepository.Products.First());
        }

        public ActionResult Products()
        {
            return View(productRepository.Products);
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

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