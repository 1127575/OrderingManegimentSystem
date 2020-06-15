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
        //public ActionResult Searchresult(int? customerId, int? orderNo, DateTime? deliveryFrom, DateTime? deliveryTo, DateTime? orderFrom, DateTime? orderTo, string status)
        public ActionResult Searchresult(string customerId, string orderNo, DateTime? deliveryFrom, DateTime? deliveryTo, DateTime? orderFrom, DateTime? orderTo, string status)
        {
            using (var db = new Database1Entities())
            {
                ViewBag.customerId = customerId;
                ViewBag.orderNo = orderNo;
                ViewBag.deliveryPeriod = deliveryFrom + "～" + deliveryTo;
                ViewBag.orderPeriod = orderFrom + "～" + orderTo;
                ViewBag.status = status;

                //検索＆内部結合
                //OrderDetail内でCustomerIdが入力と一致するものを探し、ItemNoをもとにProductと結合させる。
                var result = db.OrderDetails.Where(
                    o => o.CustomerId.ToString().Contains(customerId)
                    & o.OrderNo.ToString().Contains(orderNo)//期間系入れる。
                    & deliveryFrom <= o.DeliveryDate
                    & o.DeliveryDate <= deliveryTo
                    & orderFrom <= o.OrderDate
                    &o.OrderDate <= orderTo
                    & o.Status == status
                    ).Join(
                    db.Products,
                    o => o.Product.ItemNo,
                    p => p.ItemNo,
                    (o, p) =>
                    new
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
                    }
                    );
                ViewBag.result = result;
                //return View();
                return Content(string.Join("<br>", result));
            }
        }
    }
}