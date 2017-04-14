using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models; // add to access models

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Products()
        {
            var products = new Product[]
            {
            // as part of exercise add a value for Count for each product
        new Product{ ProductId = 1, Name = "First One", Price = 1.11m, Count = 0},
        new Product{ ProductId = 2, Name="Second One", Price = 2.22m, Count = 3},
        new Product{ ProductId = 3, Name="Third One", Price = 3.33m, Count = 1},
        new Product{ ProductId = 4, Name="Fourth One", Price = 4.44m, Count = 10},
            };

            return View(products);
        }
        public ActionResult Product()
        {
            var myProduct = new Product
            {
                ProductId = 1,
                Name = "Kayak",
                Description = "A boat for one person",
                Category = "water-sports",
                Price = 200m,
            };

            return View(myProduct);
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