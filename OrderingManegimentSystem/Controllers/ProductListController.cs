﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderingManegimentSystem.Controllers
{
    public class ProductListController : Controller
    {
        // GET: ProductList
        public ActionResult Index()
        {
            return View();
        }
    }
}