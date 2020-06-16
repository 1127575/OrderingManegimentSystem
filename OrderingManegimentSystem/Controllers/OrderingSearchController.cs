using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using OrderingManegimentSystem.Models;
using OrderingManegimentSystem.ViewModel;

namespace OrderingManegimentSystem.Controllers
{
    public class OrderingSearchController : Controller
    {
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult Searchresult(int? customerId, int? orderNo, DateTime? deliveryFrom, DateTime? deliveryTo, DateTime? orderFrom, DateTime? orderTo, string status)
        //public ActionResult Searchresult(int customerId, int orderNo, DateTime? deliveryFrom, DateTime? deliveryTo, DateTime? orderFrom, DateTime? orderTo, string status)
        {
            using (var db = new Database1Entities())
            {
                ViewBag.customerId = customerId;
                ViewBag.orderNo = orderNo;
                ViewBag.deliveryPeriod = deliveryFrom + "～" + deliveryTo;
                ViewBag.orderPeriod = orderFrom + "～" + orderTo;
                ViewBag.status = status;
                ViewBag.element = 1;
                //モデルのインスタンスを生成。
                var OrderingSearchResultViewModelList = new List<OrderingSearchResult>();


                var customerIdList = (from e in db.OrderDetails
                                      select new { e.DetailNo }).ToList(); ;
                if (customerId != 0)
                {
                    customerIdList = (from e in db.OrderDetails
                                          where e.CustomerId.ToString().Contains(customerId.ToString())
                                          select new { e.DetailNo }).ToList();
                }

                var orderNoList = (from e in db.OrderDetails
                                   select new { e.DetailNo }).ToList();
                if (orderNo != 0)
                {
                    orderNoList = (from e in db.OrderDetails
                                       where e.OrderNo.ToString().Contains(orderNo.ToString())
                                       select new { e.DetailNo }).ToList();
                }

                var deliveryDateList = (from e in db.OrderDetails
                                        select new { e.DetailNo }).ToList();
                if (deliveryFrom != null && deliveryTo != null)
                  {
                    deliveryDateList = (from e in db.OrderDetails
                                            where deliveryFrom <= e.DeliveryDate
                                            & e.DeliveryDate <= deliveryTo
                                            select new { e.DetailNo }).ToList();
                  }

                var orderDateList = (from e in db.OrderDetails
                                     select new { e.DetailNo }).ToList();
                if (orderFrom != null && orderTo != null)
                {
                    orderDateList = (from e in db.OrderDetails
                                         where orderFrom <= e.OrderDate
                                         & e.OrderDate <= orderTo
                                         select new { e.DetailNo }).ToList();
                }

                var statusList = (from e in db.OrderDetails
                                    where e.Status == status
                                    select new { e.DetailNo }).ToList();
                if(statusList == null)//該当DetailNoゼロ
                {
                    ViewBag.element = 0;
                }
                else
                {
                    List<int> resultList = new List<int>();
                    for (int i = 0; i < statusList.Count(); i++)
                    {
                        for (int j = 0; j < customerIdList.Count(); j++)
                        {
                            for (int k = 0; k < orderNoList.Count(); k++)
                            {
                                for (int l = 0; l < deliveryDateList.Count; l++)
                                {
                                    for (int m = 0; m < orderDateList.Count; m++)
                                    {
                                        if (statusList[i] == customerIdList[j] && statusList[i] == orderNoList[k] && statusList[i] == deliveryDateList[l] && statusList[i] == orderDateList[m] )
                                        {
                                            //各検索項目に該当するDetailNoのリストの中から、全てのリストに含まれるDetailNoを抽出ししてresultListに追加する。
                                            resultList.Add(int.Parse(statusList[i].ToString()));//型変換自信ない！
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if(resultList == null)//該当DetailNoゼロ

                    {
                        ViewBag.element = 0;
                    }
                    else
                    {
                        for (int i = 0; i < resultList.Count(); i++)
                        {
                            //抽出したDetailNoに該当する列のデータをSearchResultListにリストとして格納。
                            var SearchResultList = (from e in db.OrderDetails
                                                    where e.DetailNo == resultList[i]
                                                    select e).ToList();

                            for(int j = 0; j < SearchResultList.Count(); j++)
                            {
                                //SearchResultListの中身をモデルに格納。
                                var osrViewModel = new OrderingSearchResult(SearchResultList[j]);
                                OrderingSearchResultViewModelList.Add(osrViewModel);
                            }
                        }
                    }
                }
                /*
                var result = (db.OrderDetails.Where(
                o => o.CustomerId.ToString().Contains(customerId.ToString())
                & o.OrderNo.ToString().Contains(orderNo.ToString())
                & deliveryFrom <= o.DeliveryDate
                & o.DeliveryDate <= deliveryTo
                & orderFrom <= o.OrderDate
                & o.OrderDate <= orderTo
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
                )).ToList();
                */

                return View(OrderingSearchResultViewModelList);
            }                            
        }
    }
}