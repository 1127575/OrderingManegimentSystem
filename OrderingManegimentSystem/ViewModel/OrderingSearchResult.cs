using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OrderingManegimentSystem.Models;
using Microsoft.Ajax.Utilities;

namespace OrderingManegimentSystem.ViewModel
{
    public class OrderingSearchResult:OrderDetail
    {
        [DisplayName("商品名")]
        public string ItemName { get; set; }
        [DisplayName("注文番号-明細")]
        public string OrderDetail { get; set; }
    }
}