using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderingManegimentSystem.Controllers
{
    public class CustomerAddController : Controller
    {
        // GET: CustomerAdd
        public ActionResult CustomerLoginIndex()
        {
            return View();
        }
        public ActionResult CustomerMainMenu()
        {
            return View();
        }
    }
}