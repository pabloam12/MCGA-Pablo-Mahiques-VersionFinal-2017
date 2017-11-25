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
    public class DealerController : Controller
    {
        // GET: Dealer
        public ActionResult Index()
        {
            //var cp = new DealerProcess();
            var lista = DataCache.Instance.DealerListDTO();
            //return View(cp.SelectList());
            return View(lista);
        }

        // GET: Dealer/Create
        public ActionResult Create ()
        {
            var category = new CategoryProcess().SelectList();
            var country = new CountryProcess().SelectList();

            ViewBag.Category = new SelectList(category, "Id", "Name");
            ViewBag.Country = new SelectList(country, "Id", "Name");

            return View();
        }

        // POST: Dealer/Create
        [HttpPost]
        public ActionResult Create(Dealer dealer)
        {
            try
            {
                var cp = new DealerProcess();
                cp.insertDealer(dealer);
                DataCache.Instance.DealerListRemoveDTO();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dealer/Details
        public ActionResult Details (int id)
        {
            var cp = new DealerProcess();
            return View(cp.findDealer(id));
        }

        // GET: Dealer/Edit/5
        public ActionResult Edit (int id)
        {

            var category = new CategoryProcess().SelectList();
            var country = new CountryProcess().SelectList();

            ViewBag.Category = new SelectList( category, "Id", "Name", id );
            ViewBag.Country = new SelectList( country, "Id", "Name", id );

            var cp = new DealerProcess();
            return View(cp.findDealer(id));
        }

        // POST: Dealer/Edit/5
        [HttpPost]
        public ActionResult Edit(Dealer dealer)
        {
            try
            {
                var cp = new DealerProcess();
                cp.editDealer( dealer );
                DataCache.Instance.DealerListRemoveDTO();
                return RedirectToAction( "Index" );
            }
            catch
            {
                return View();
            }
        }

        // GET: Dealer/Delete/5
        public ActionResult Delete ( int id )
        {
            var cp = new DealerProcess();

            return View( cp.findDealer( id ) );
        }

        // POST: Dealer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Dealer dealer)
        {
            try
            {
                var cp = new DealerProcess();
                cp.deleteDealer( id );
                DataCache.Instance.DealerListRemoveDTO();
                return RedirectToAction( "Index" );
            }
            catch
            {
                return View();
            }
        }
    }
}
