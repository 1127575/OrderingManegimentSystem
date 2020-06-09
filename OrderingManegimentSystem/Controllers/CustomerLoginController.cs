using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderingManegimentSystem.Controllers
{
    public class CustomerLoginController : Controller
    {
        // GET: CustomerLogin
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