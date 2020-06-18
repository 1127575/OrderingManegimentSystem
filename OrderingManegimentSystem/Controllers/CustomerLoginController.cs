using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderingManegimentSystem.Models;

namespace OrderingManegimentSystem.Controllers
{
    public class CustomerLoginController : Controller
    {
        // GET: CustomerLogin
        public ActionResult CustomerLoginIndex()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CustomerMainMenu()
        {
            return View("CustomerLoginIndex");
        }
        [HttpPost]
        public ActionResult CustomerMainMenu(Customer customer)
        {
            using (var db = new Database1Entities())
            {
                var ul = db.Customers.Find(customer.CustomerId);
                int t = customer.CustomerId;
                string p = customer.Password;
                if (t == ul.CustomerId && customer.Password == ul.Password)
                {
                    //Session["顧客名"] = ul.CustomerName;
                    return View();
                }
                else
                {
                    ViewBag.IsAuth = false;
                    return View("CustomerLoginIndex");
                }
            }


        }
    }
}