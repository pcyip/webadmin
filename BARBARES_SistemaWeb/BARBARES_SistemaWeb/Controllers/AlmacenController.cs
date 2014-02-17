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

        public ActionResult List_Parametros()
        {
            ViewBag.TipoProducto = 1;
            ViewBag.Unidad = 2;
            ViewBag.TipoMovimiento = 3;

            return View();
        }

        public ActionResult Details_Parametro(int id)
        {

            if (id == 1)
            {
                ViewBag.Header = "Tipo Producto";
                ViewBag.Nombre = "Cervezas";
                ViewBag.Desc = "Cervezas";
            }
            else if (id == 2)
            {
                ViewBag.Header = "Unidad Producto";
                ViewBag.Nombre = "lt";
                ViewBag.Desc = "Litros";
            }

            else if (id == 3)
            {
                ViewBag.Header = "Tipo Movimiento";
                ViewBag.Nombre = "Venta";
                ViewBag.Desc = "Salida por venta";
            }

            ViewBag.Tipo = id;

            return View();
        }

        public ActionResult Edit_Parametro(int id)
        {
            if (id == 1)
            {
                ViewBag.Header = "Tipo Producto";
                ViewBag.Nombre = "Cervezas";
                ViewBag.Desc = "Cervezas";
            }
            else if (id == 2)
            {
                ViewBag.Header = "Unidad Producto";
                ViewBag.Nombre = "lt";
                ViewBag.Desc = "Litros";
            }

            else if (id == 3)
            {
                ViewBag.Header = "Tipo Movimiento";
                ViewBag.Nombre = "Venta";
                ViewBag.Desc = "Salida por venta";
            }

            ViewBag.Tipo = id;

            return View();
        }

        public ActionResult Create_Parametro(int id)
        {
            if (id == 1)
                ViewBag.Header = "Tipo Producto";

            else if (id == 2)
                ViewBag.Header = "Unidad Producto";

            else if (id == 3)
                ViewBag.Header = "Unidad Producto";

            ViewBag.Tipo = id;

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

        public ActionResult Edit()
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
