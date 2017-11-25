using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;
using ASF.UI.WbSite.Services.Cache;

namespace ASF.UI.WbSite.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index ()
        {
            //var cp = new OrderProcess();
            var lista = DataCache.Instance.OrderList();
            //return View(cp.SelectList());
            return View( lista );
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            var client = new ClientProcess().SelectList();

            ViewBag.Client = new SelectList(client, "Id", "FirstName");
           
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create (Order Order)
        {
            try
            {
                var cp = new OrderProcess();

                cp.insertOrder(Order);

                DataCache.Instance.OrderListRemove();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Details
        public ActionResult Details (int id)
        {
            var cp = new OrderProcess();

            return View( cp.findOrder(id));
        }

        // GET: Order/Edit/5
        public ActionResult Edit (int id)
        {
            var cp = new OrderProcess();

            return View( cp.findOrder(id));
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(Order Order)
        {
            try
            {
                var cp = new OrderProcess();
                cp.editOrder(Order);
                DataCache.Instance.OrderListRemove();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete (int id)
        {
            var cp = new OrderProcess();

            return View( cp.findOrder(id));
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete (int id, Order Order)
        {
            try
            {
                var cp = new OrderProcess();
                cp.deleteOrder(id);
                DataCache.Instance.OrderListRemove();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
