using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderingManegimentSystem.Models;
using OrderingManegimentSystem.ViewModel;

namespace Test.Controllers
{
    public class CustomerAddController : Controller
    {
        // GET: CustomerAdd
        public ActionResult CustomerSignUp()
        {
            using (var db = new Database1Entities())
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult CustomerSignUpComfirmation()
        {
            return View("CustomerSignUp");
        }
        [HttpPost]
        public ActionResult CustomerSignUpComfirmation(CustomerSignUpViewModel csvm)
        {
            using (var db = new Database1Entities())
            {
                Customer e = new Customer();
                e.CompanyName = csvm.CompanyName;
                e.Address = csvm.Address;
                e.CustomerKana = csvm.CustomerKana;
                e.CustomerName = csvm.CustomerName;
                e.Dept = csvm.Dept;
                e.Email = csvm.Email;
                e.Telno = csvm.Telno;
                e.Password = csvm.Password;
                
                return View(e);
            }
        }
        [HttpGet]
        public ActionResult CustomerSignUpDone()
        {
            return View("CustomerSignUp");
        }
        [HttpPost]
        public ActionResult CustomerSignUpDone(Customer customer)
        {
            using (var db = new Database1Entities())
            {                

                db.Customers.Add(customer);
                //return Content(customer.Address);
                db.SaveChanges();
                ViewBag.Customer = customer;
                return View();
            }

            

        }
    }
}
