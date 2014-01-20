using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BARBARES_SistemaWeb.Controllers
{
    public class ComprobantePagoController : Controller
    {
        //
        // GET: /ComprobantePago/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        //
        // GET: /ComprobantePago/Details/5

        public ActionResult Details()
        {
            return View();
        }

        //
        // GET: /ComprobantePago/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ComprobantePago/Create

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
        // GET: /ComprobantePago/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ComprobantePago/Edit/5

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
        // GET: /ComprobantePago/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ComprobantePago/Delete/5

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
