using MVC_ODEV1.DesignPatterns.SingletonPattern;
using MVC_ODEV1.Models.ContextClasses;
using MVC_ODEV1.Models.Entities;
using MVC_ODEV1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ODEV1.Controllers
{
    public class CustomerController : Controller
    {

        MyContext db;
        public CustomerController()
        {
            db = DBTool._DBInstance;
        }
        // GET: Customer
        public ActionResult Index()
        {
            List<CustomerVM> customers = db.Customers.Select(x => new CustomerVM
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).ToList();

            //List<CustomerVM> listCustomer = new List<CustomerVM>()
            //{
            //    new CustomerVM{ID=1,FirstName="Yasemin ",LastName="Cobanoğlu"},
            //    new CustomerVM{ID=2,FirstName="Erhan ",LastName="Zorlu"},
            //};

            return View(customers);
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(CustomerVM customerVM)
        {
            Customer customer = new Customer()
            {
                FirstName = customerVM.FirstName,
                LastName = customerVM.LastName,

            };
            db.Customers.Add(customer);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


       
        public ActionResult UpdateCustomer(int id)
        {
            CustomerVM customerVM = db.Customers.Where(x => x.ID == id).Select(x => new CustomerVM
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName

            }).FirstOrDefault();

            return View(customerVM);
        }


        [HttpPost]
        public ActionResult UpdateCustomer(CustomerVM vm)
        {
            Customer veri = db.Customers.Find(vm.ID);
            veri.FirstName = vm.FirstName;
            veri.LastName = vm.LastName;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteCustomer(int id)
        {
            db.Customers.Remove(db.Customers.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}