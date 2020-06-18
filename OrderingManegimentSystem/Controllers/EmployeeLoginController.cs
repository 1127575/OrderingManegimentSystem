using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderingManegimentSystem.Models;

namespace OrderingManegimentSystem.Controllers
{
    public class EmployeeLoginController : Controller
    {
        // GET: EmployeeLogin
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult EmployeeMain(Employee employee)
        {
            using (var db = new Database1Entities())
            {
                var ul = db.Customers.Find(employee.EmpNo);
                int t = employee.EmpNo;
                string p = employee.Password;
                if (t == ul.CustomerId && p == ul.Password)
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