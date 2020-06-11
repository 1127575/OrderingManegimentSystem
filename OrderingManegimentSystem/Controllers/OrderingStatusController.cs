using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderingManegimentSystem.Models;


namespace OrderingManegimentSystem.Controllers
{
    public class OrderingStatusController : Controller
    {
        Database1Entities db = new Database1Entities();
        // GET: OrderingStatus
        public ActionResult Orderstatus(int CustomerId = 1)
        {
            using (var db = new Database1Entities())
            {
                var ol = from e in db.OrderDetails where e.CustomerId == CustomerId select e;
                //return Content(string.Join("<br>", ol));
                return View(ol);
            }
        }
        public ActionResult Ordercancel(int OrderNo)
        {
            return View();
        }
    }
}