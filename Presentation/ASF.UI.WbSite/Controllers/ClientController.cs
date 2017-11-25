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
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            //var cp = new ClientProcess();
            var lista = DataCache.Instance.ClientList();
            //return View(cp.SelectList());
            return View(lista);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            var country = new CountryProcess().SelectList();

            ViewBag.Country = new SelectList(country, "Id", "Name");

            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client Client)
        {
            try
            {
                var cp = new ClientProcess();

                cp.insertClient(Client);

                DataCache.Instance.ClientListRemove();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Details
        public ActionResult Details(int id)
        {
            var cp = new ClientProcess();

            return View( cp.findClient(id));
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            var country = new CountryProcess().SelectList();

            ViewBag.Country = new SelectList(country, "Id", "Name", id);

            var cp = new ClientProcess();

            return View( cp.findClient(id));
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(Client Client)
        {
            try
            {
                var cp = new ClientProcess();
                cp.editClient( Client );
                DataCache.Instance.ClientListRemove();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            var cp = new ClientProcess();

            return View( cp.findClient(id));
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Client Client)
        {
            try
            {
                var cp = new ClientProcess();
                cp.deleteClient(id);
                DataCache.Instance.ClientListRemove();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
