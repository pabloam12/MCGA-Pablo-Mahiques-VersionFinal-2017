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
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            //var cp = new CountryProcess();
            var lista = DataCache.Instance.CountryList();
            //return View(cp.SelectList());
            return View(lista);
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult Create(Country country)
        {
            try
            {
                var cp = new CountryProcess();
                cp.insertCountry(country);
                DataCache.Instance.CountryListRemove();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Details
        public ActionResult Details(int id)
        {
            var cp = new CountryProcess();

            return View(cp.findCountry(id));
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            var cp = new CountryProcess();

            return View(cp.findCountry(id));
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult Edit(Country country)
        {
            try
            {
                var cp = new CountryProcess();
                cp.editCountry(country);
                DataCache.Instance.CountryListRemove();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            var cp = new CountryProcess();

            return View(cp.findCountry(id));
        }

        // POST: Country/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Country country)
        {
            try
            {
                var cp = new CountryProcess();
                cp.deleteCountry(id);
                DataCache.Instance.CountryListRemove();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}