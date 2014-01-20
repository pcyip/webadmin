using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BARBARES_SistemaWeb.Controllers
{
    public class VehiculoController : Controller
    {
        //
        // GET: /Vehiculo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        //
        // GET: /Vehiculo/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Vehiculo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Vehiculo/Create

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
        // GET: /Vehiculo/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Vehiculo/Edit/5

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
        // GET: /Vehiculo/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Vehiculo/Delete/5

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
