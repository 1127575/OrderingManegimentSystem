using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderingManegimentSystem.Models;
using OrderingManegimentSystem.ViewModel;

namespace OrderingManegimentSystem.Controllers
{
    public class EmployeeMasterController : Controller
    {
        // GET: EmployeeMaster
        public ActionResult EmployeeList()
        {
            using (var db = new Database1Entities())
            {
                var empList = db.Employees.ToList();
                var elvmList = new List<EmployeeListViewModel>();
                foreach (var item in empList)
                {
                    var e = new EmployeeListViewModel(item);
                    elvmList.Add(e);
                }
                return View(elvmList);
            }
        }

        public ActionResult EmployeeAddInput()
        {
            using (var db = new Database1Entities())
            {
                return View();
            }
        }
        public ActionResult EmployeeAddConfirm(EmployeeInputViewModel evm)
        {
            using (var db = new Database1Entities())
            {
                if (!ModelState.IsValid)
                {
                    return View("EmployeeAddInput");
                }
                Employee e = new Employee();
                e.EmpNo = evm.EmpNo;
                e.EmpName = evm.EmpName;
                e.Password = evm.Password;
                return View(e);
            }
        }
        public ActionResult EmployeeAdd(Employee emp)
        {
            using (var db = new Database1Entities())
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return Redirect("EmployeeList");
            }
        }

        public ActionResult EmployeeUpdateInput(int id)
        {
            using (var db = new Database1Entities())
            {
                var emp = db.Employees.Find(id);
                var evm = new EmployeeInputViewModel();
                evm.EmpNo = emp.EmpNo;
                evm.EmpName = emp.EmpName;
                evm.Password = evm.Password;
                return View(evm);
            }
        }

        public ActionResult EmployeeUpdateConfirm(EmployeeInputViewModel evm)
        {
            using (var db = new Database1Entities())
            {
                if (!ModelState.IsValid)
                {
                    return View("EmployeeUpdateInput");
                }
                Employee e = new Employee();
                e.EmpNo = evm.EmpNo;
                e.EmpName = evm.EmpName;
                e.Password = evm.Password;
                return View(e);
            }
        }

        public ActionResult EmployeeUpdate(Employee emp)
        {
            using (var db = new Database1Entities())
            {
                Employee e = db.Employees.Find(emp.EmpNo);
                e.EmpNo = emp.EmpNo;
                e.EmpName = emp.EmpName;
                e.Password = emp.Password;
                db.SaveChanges();
                return Redirect("EmployeeList");
            }
        }

        public ActionResult EmployeeDeleteConfirm(List<EmployeeListViewModel> elvmList)
        {
            using (var db = new Database1Entities())
            {

                return View(elvmList);
            }
        }

        public ActionResult EmployeeDelete(List<EmployeeListViewModel> eivmList)
        {
            using (var db = new Database1Entities())
            {
                foreach (var item in eivmList)
                {
                    if (item.IsChecked == true)
                    {
                        var emp = db.Employees.Find(item.EmpNo);
                        db.Employees.Remove(emp);
                    }
                }
                db.SaveChanges();
                return Redirect("EmployeeList");
            }
        }
    }
}