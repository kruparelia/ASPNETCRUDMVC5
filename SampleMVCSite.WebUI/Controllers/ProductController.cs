using SampleMVCSite.Contracts.Repositories;
using SampleMVCSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVCSite.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IRepositoryBase<Product> products;

        public ProductController(IRepositoryBase<Product> products)
        {
            this.products = products;
        }//end Constructor


        // GET: Product
        public ActionResult index()
        {
            var productList = products.GetAll();

            return View(productList);
        }

        public ActionResult ProductsList()
        {
            var model = products.GetAll();
            return View(model);
        }

        public ActionResult CreateProduct()
        {
            var model = new Product();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            products.Insert(product);
            products.Commit();
            return RedirectToAction("ProductsList");
        }

        public ActionResult EditProduct(int id)
        {
            Product product = products.GetById(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            products.Update(product);
            products.Commit();

            return RedirectToAction("ProductsList");
        }

        public ActionResult Details(int id)
        {
            var product = products.GetById(id);
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            var product = products.GetById(id);
            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]

        public ActionResult ProductDelete(int id)
        {
            products.Delete(id);
            products.Commit();
            return RedirectToAction("ProductsList");
        }


    }
}