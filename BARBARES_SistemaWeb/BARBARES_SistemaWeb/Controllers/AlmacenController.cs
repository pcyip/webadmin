using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BARBARES_SistemaWeb.Controllers
{
    public class AlmacenController : Controller
    {
        //
        // GET: /Almacen/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        //
        // GET: /Almacen/Details/5

        public ActionResult Details()
        {
            return View();
        }

        //
        // GET: /Almacen/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Almacen/Create

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
        // GET: /Almacen/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Almacen/Edit/5

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
        // GET: /Almacen/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Almacen/Delete/5

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
