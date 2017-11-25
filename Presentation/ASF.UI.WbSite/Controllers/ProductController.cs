using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;
using ASF.UI.WbSite.Services.Cache;

namespace ASF.UI.WbSite.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            //var pp = new ProductProcess();
            var lista = DataCache.Instance.ProductList();
            //return View(pp.SelectList());
            return View(lista);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                var pp = new ProductProcess();
                pp.insertProduct(product);
                DataCache.Instance.ProductListRemove();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var pp = new ProductProcess();

            return View(pp.findProduct(id));
        }

        public ActionResult Edit(int id)
        {
            var pp = new ProductProcess();

            return View(pp.findProduct(id));
        }
        [HttpPost]
        public ActionResult Edit(Product Product)
        {
            try
            {
                var pp = new ProductProcess();
                pp.editProduct(Product);
                DataCache.Instance.ProductListRemove();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var pp = new ProductProcess();

            return View(pp.findProduct(id));
        }
        [HttpPost]
        public ActionResult Delete(int id, Product Product)
        {
            try
            {
                var pp = new ProductProcess();
                pp.deleteProduct(id);
                DataCache.Instance.ProductListRemove();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
