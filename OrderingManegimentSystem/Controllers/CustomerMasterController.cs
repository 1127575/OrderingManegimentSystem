﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderingManegimentSystem.Models;
using OrderingManegimentSystem.ViewModel;

namespace OrderingManegimentSystem.Controllers
{
    public class CustomerMasterController : Controller
    {
        // GET: CustomerMaster
        public ActionResult CustomerList()
        {
            using (var db = new Database1Entities())
            {
                return View(db.Customers.ToList());

            }
        }


        public ActionResult CustomerUpdateInput(int id)
        {
            using (var db = new Database1Entities())
            {
                Customer ctm = db.Customers.Find(id);
                var civm = new CustomerInputViewModel(ctm);
                return View(civm);
            }
        }

        public ActionResult CustomerUpdateConfirm(CustomerInputViewModel civm)
        {
            using (var db = new Database1Entities())
            {
                Customer ctm = new Customer();
                ctm.CustomerId = civm.CustomerId;
                ctm.CompanyName = civm.CompanyName;
                ctm.Address = civm.Address;
                ctm.Telno = civm.Telno;
                ctm.CustomerName = civm.CustomerName;
                ctm.CustomerKana = civm.CustomerKana;
                ctm.Dept = civm.Dept;
                ctm.Email = civm.Email;
                ctm.Password = civm.Password;
                return View(ctm);
            }
        }

        public ActionResult CustomerUpdate(Customer ctm)
        {
            using (var db = new Database1Entities())
            {
                Customer c = db.Customers.Find(ctm.CustomerId);
                c.CompanyName = ctm.CompanyName;
                c.Address = ctm.Address;
                c.Telno = ctm.Telno;
                c.CustomerName = ctm.CustomerName;
                c.CustomerKana = ctm.CustomerKana;
                c.Dept = ctm.Dept;
                c.Email = ctm.Email;
                c.Password = ctm.Password;
                db.SaveChanges();
                return Redirect("CustomerList");
            }
        }

        public ActionResult CustomerDeleteConfirm(int id)
        {
            using (var db = new Database1Entities())
            {
                Customer ctm = db.Customers.Find(id);
                return View(ctm);
            }
        }

        public ActionResult CustomerDelete(int id)
        {
            using (var db = new Database1Entities())
            {
                Customer ctm = db.Customers.Find(id);
                db.Customers.Remove(ctm);
                db.SaveChanges();
                return Redirect("CustomerList");
            }
        }
    }
}