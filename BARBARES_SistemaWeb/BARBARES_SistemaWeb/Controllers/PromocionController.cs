using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BARBARES_SistemaWeb.Controllers
{
    public class PromocionController : Controller
    {
        //
        // GET: /Promocion/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Promocion/Details/5

        public ActionResult Details()
        {
            return View();
        }

        //
        // GET: /Promocion/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Promocion/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Promocion/Edit/5

        public ActionResult Edit()
        {
            return View();
        }

        //
        // POST: /Promocion/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Promocion/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Promocion/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
