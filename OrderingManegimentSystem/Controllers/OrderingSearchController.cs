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
                var dl = from a in db.OrderDetails
                         select a;
                //［顧客ID］欄が空でない場合、その値で部分一致検索
                if (!string.IsNullOrEmpty(customerId))
                {
                    dl = db.OrderDetails.Where(a => a.Contains(customerId));
                }

                //［公開済］チェックが付いている場合、公開済みの記事だけを絞り込み
                if (released.HasValue && released.Value)
                {
                    articles = articles.Where(a => a.Released);
                }
                /*var dl = from e in db.OrderDetails
                                          where e.CustomerId == customerId
                                          & e.OrderNo == orderNo
                                          //& deliveryfrom >= e.DeliveryDate >= deliveryTo
                                          //& orderFrom >= e.OrderDate >= orderTo
                                          & e.Status == status
                                          select e;

                    ViewBag.result = from o in db.OrderDetails//内部結合P231
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
                                            };*/
                return View(dl);
            }
        }
    }
}