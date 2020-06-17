using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderingManegimentSystem.Controllers
{
    public class StatusUpdateController : Controller
    {
        public ActionResult OrderStatusUpdate()
        {
            return View();
        }
        
        public ActionResult OrderStatusChange()
        {
            return View();
        }
    }
}