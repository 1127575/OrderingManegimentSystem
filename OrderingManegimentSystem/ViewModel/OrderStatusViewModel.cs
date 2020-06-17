using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrderingManegimentSystem.Models;

namespace OrderingManegimentSystem.ViewModel
{
    public class OrderStatusViewModel
    {
        public int OrderNo { get; set; }

        public int ItemNo { get; set; }

        public string ItemName { get; set; }

        public decimal Quantity { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string Status { get; set; }


        public OrderStatusViewModel() { }

        public OrderStatusViewModel(OrderDetail od)
        {
            this.OrderNo = od.OrderNo;
            this.ItemNo = od.ItemNo;
            this.ItemName = od.Product.ItemName;
            this.Quantity = od.Quantity;
            this.DeliveryDate = od.DeliveryDate;
            this.Status = od.Status;
        }
    }
}