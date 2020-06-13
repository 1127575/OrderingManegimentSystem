using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using OrderingManegimentSystem.Models;


namespace OrderingManegimentSystem.Controllers
{
    public class OrderingSearchController : Controller
    {
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult Searchresult(int? customerId, int? orderNo, DateTime? deliveryFrom, DateTime? deliveryTo, DateTime? orderFrom, DateTime? orderTo, string status)
        //public ActionResult Searchresult(string customerId, string orderNo, string deliveryFrom, string deliveryTo, string orderFrom, string orderTo, string status)
        {
            using (var db = new Database1Entities())
            {
                //if (customerId != 0)//検索条件の表示
                if (customerId != null)//検索条件の表示
                {
                    ViewBag.name1 = "顧客ID";
                    ViewBag.customerId = customerId;
                }
                //if(orderNo != 0)
                if (orderNo != null)
                {
                    ViewBag.name2 = "注文番号";
                    ViewBag.orderNo = orderNo;
                }
                if ((deliveryFrom != null) || (deliveryTo != null))
                {
                    ViewBag.name3 = "希望納期";
                    ViewBag.deliveryPeriod = deliveryFrom + "～" + deliveryTo;
                }
                if ((orderFrom != null) || (orderTo != null))
                {
                    ViewBag.name4 = "受注日時";
                    ViewBag.orderPeriod = orderFrom + "～" + orderTo;
                }
                ViewBag.status = status;

                 /*var dl = from e in db.OrderDetails//Searchで受け取った値で検索
                          where e.CustomerId == customerId
                          //& e.OrderNo == orderNo
                          //& deliveryfrom >= e.DeliveryDate >= deliveryTo
                          //& orderFrom >= e.OrderDate >= orderTo
                          //& e.Status == status
                          select e;*/

                var result = from o in db.OrderDetails //OrderDetail内でCuustomerIdが入力されたものと一致するものを探し、ItemNoをもとにProductと結合させる。
                             where o.CustomerId == customerId//内部結合P231
                             join p in db.Products on o.ItemNo equals p.ItemNo
                                 select new
                                 {
                                     orderdetail = o.OrderNo + "-" + o.DetailNo,
                                     itemNo = o.ItemNo,
                                     Product = new
                                     {
                                         itemName = p.ItemName
                                     },
                                     quantity = o.Quantity,
                                     deliveryDate = o.DeliveryDate,
                                     status = o.Status,
                                 };
            }
            return View();
        }
    }
}