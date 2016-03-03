using SampleMVCSite.Contracts.Repositories;
using SampleMVCSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVCSite.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        IRepositoryBase<Customer> customers;

        public CustomerController(IRepositoryBase<Customer> customers)
        {
            this.customers = customers;
        }//end constructor
        // GET: Customer
        public ActionResult Index()
        {
            var customerList = customers.GetAll();
            return View(customerList);
        }

        public ActionResult CustomerList()
        {
            var model = customers.GetAll();
            return View(model);
        }

        public ActionResult CreateCustomer()
        {
            var model = new Customer();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
            customers.Insert(customer);
            customers.Commit();
            return RedirectToAction("CustomerList");
        }

        public ActionResult EditCustomer(int id)
        {
            Customer customer = customers.GetById(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult EditCustomer(Customer customer)
        {
            customers.Update(customer);
            customers.Commit();

            return RedirectToAction("CustomerList");
        }

        public ActionResult Details(int id)
        {
             var customer = customers.GetById(id);
             return View(customer);
        }

        public ActionResult Delete(int id)
        {
            var customer = customers.GetById(id);
            return View(customer);
        }

        [HttpPost]
        [ActionName("Delete")]

        public ActionResult CustomerDelete(int id)
        {
            customers.Delete(id);
            customers.Commit();
            return RedirectToAction("CustomerList");
        }
    }
}