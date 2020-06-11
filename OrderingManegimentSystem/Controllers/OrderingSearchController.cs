using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderingManegimentSystem.Models;


namespace OrderingManegimentSystem.Controllers
{
    public class OrderingSearchController : Controller
    {
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult Searchresult(string customerId, string orderNo, string detailNo, DateTime? deliveryfrom, DateTime? deliveryTo, DateTime? orderFrom, DateTime? orderTo, string status)
        {
            using (var db = new Database1Entities())
            {

                var dl = from o in db.OrderDetails//外部結合P236
                         join p in db.Products on o.ItemNo equals p.ItemNo
                         into z
                         from subd in z.DefaultIfEmpty()
                         select new
                         {
                             orderdetail = o.OrderNo + "-" + o.DetailNo,
                             itemNo = o.ItemNo,
                             Product = new
                             {
                                 itemNo = o.ItemNo,
                                 itemName = (subd == null ?
                                                        String.Empty : subd.ItemName)
                             },
                             quantity = o.Quantity,
                             deliveryDate = o.DeliveryDate,
                             status = o.Status,
                         };
                return View(dl);
            }
        }
    }
}