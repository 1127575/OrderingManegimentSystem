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
                var OrderingSearchResultViewModelList = new List<OrderingSearchResultViewModel>();


                var customerIdList = (from e in db.OrderDetails
                                      select new { e.DetailNo }).ToList(); ;
                if (customerId != null)
                {
                    customerIdList = (from e in db.OrderDetails
                                      where e.CustomerId.ToString().Contains(customerId.ToString())
                                      select new { e.DetailNo }).ToList();
                }

                var orderNoList = (from e in db.OrderDetails
                                   select new { e.DetailNo }).ToList();
                if (orderNo != null)
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
                if (statusList.Count == 0)//該当DetailNoゼロ
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
                                for (int l = 0; l < deliveryDateList.Count(); l++)
                                {
                                    for (int m = 0; m < orderDateList.Count(); m++)
                                    {
                                        if (statusList[i].DetailNo == customerIdList[j].DetailNo
                                        && statusList[i].DetailNo == orderNoList[k].DetailNo
                                        && statusList[i].DetailNo == deliveryDateList[l].DetailNo
                                        && statusList[i].DetailNo == orderDateList[m].DetailNo)
                                        {
                                            //各検索項目に該当するDetailNoのリストの中から、全てのリストに含まれるDetailNoを抽出ししてstring型でresultListに追加する。
                                            resultList.Add(statusList[i].DetailNo);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (resultList.Count() == 0)//該当DetailNoゼロ
                    {
                        ViewBag.element = 0;
                    }
                    else
                    {
                        for (int i = 0; i < resultList.Count(); i++)
                        {
                            //抽出したDetailNoに該当する列のデータをSearchResultListにリストとして格納。
                            int resultDetailNo = resultList[i];
                            var SearchResultList = (from e in db.OrderDetails
                                                    where e.DetailNo == resultDetailNo
                                                    select e).ToList();

                            for (int j = 0; j < SearchResultList.Count(); j++)
                            {
                                //SearchResultListの中身をモデルに格納。
                                var osrViewModel = new OrderingSearchResultViewModel(SearchResultList[j]);
                                OrderingSearchResultViewModelList.Add(osrViewModel);
                            }
                        }
                    }
                }
                return View(OrderingSearchResultViewModelList);
            }
        }
    }
}