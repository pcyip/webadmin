using BARBARES_SistemaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BARBARES_SistemaWeb.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Promocion/

        public ActionResult Index()
        {
            ViewBag.Cerveza = 1;
            ViewBag.Vino = 2;
            ViewBag.Whisky = 3;
            ViewBag.Vodka = 4;
            ViewBag.Ron = 5;
            ViewBag.Tequila = 6;
            ViewBag.Pisco = 7;
            ViewBag.Licor = 8;
            ViewBag.Bebida = 9;
            ViewBag.Snack = 10;
            ViewBag.Cigarro = 11;
            return View();
        }

        public ActionResult List(int id)
        {
            /*
            ServiceReferenceProducto.Producto_ServicesClient s  = new ServiceReferenceProducto.Producto_ServicesClient();
            List<ServiceReferenceProducto.Producto> productos = s.selectAll_Producto().ToList();
            List<Producto> p = new List<Producto>();
             

            for (int i = 0; i < productos.Count; i++)
            {
                Producto prd = new Producto();
                prd.Nombre = productos[i].Nombre;
                p.Add(prd);
            }
            */

            if (id == 1)
                ViewBag.Title = "Cerveza";
            else if (id == 2)
                ViewBag.Title = "Vino";
            else if (id == 3)
                ViewBag.Title = "Whisky";
            else if (id == 4)
                ViewBag.Title = "Vodka";
            else if (id == 5)
                ViewBag.Title = "Ron";
            else if (id == 6)
                ViewBag.Title = "Tequila";
            else if (id == 7)
                ViewBag.Title = "Pisco";
            else if (id == 8)
                ViewBag.Title = "Licores";
            else if (id == 9)
                ViewBag.Title = "Bebidas";
            else if (id == 10)
                ViewBag.Title = "Snacks";
            else if (id == 11)
                ViewBag.Title = "Cigarros";

            ViewBag.Tipo = id;

            return View();
        }

        //
        // GET: /Promocion/Details/5

        public ActionResult Details(int id)
        {
            if (id == 1)
                ViewBag.Title = "Cerveza";
            else if (id == 2)
                ViewBag.Title = "Vino";
            else if (id == 3)
                ViewBag.Title = "Whisky";
            else if (id == 4)
                ViewBag.Title = "Vodka";
            else if (id == 5)
                ViewBag.Title = "Ron";
            else if (id == 6)
                ViewBag.Title = "Tequila";
            else if (id == 7)
                ViewBag.Title = "Pisco";
            else if (id == 8)
                ViewBag.Title = "Licores";
            else if (id == 9)
                ViewBag.Title = "Bebidas";
            else if (id == 10)
                ViewBag.Title = "Snacks";
            else if (id == 11)
                ViewBag.Title = "Cigarros";

            ViewBag.Tipo = id;

            return View();
        }

        //
        // GET: /Promocion/Create

        public ActionResult Create(int id)
        {
            if (id == 1)
                ViewBag.Title = "Cerveza";
            else if (id == 2)
                ViewBag.Title = "Vino";
            else if (id == 3)
                ViewBag.Title = "Whisky";
            else if (id == 4)
                ViewBag.Title = "Vodka";
            else if (id == 5)
                ViewBag.Title = "Ron";
            else if (id == 6)
                ViewBag.Title = "Tequila";
            else if (id == 7)
                ViewBag.Title = "Pisco";
            else if (id == 8)
                ViewBag.Title = "Licores";
            else if (id == 9)
                ViewBag.Title = "Bebidas";
            else if (id == 10)
                ViewBag.Title = "Snacks";
            else if (id == 11)
                ViewBag.Title = "Cigarros";

            ViewBag.Tipo = id;

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

        public ActionResult Edit(int id)
        {
            if (id == 1)
                ViewBag.Title = "Cerveza";
            else if (id == 2)
                ViewBag.Title = "Vino";
            else if (id == 3)
                ViewBag.Title = "Whisky";
            else if (id == 4)
                ViewBag.Title = "Vodka";
            else if (id == 5)
                ViewBag.Title = "Ron";
            else if (id == 6)
                ViewBag.Title = "Tequila";
            else if (id == 7)
                ViewBag.Title = "Pisco";
            else if (id == 8)
                ViewBag.Title = "Licores";
            else if (id == 9)
                ViewBag.Title = "Bebidas";
            else if (id == 10)
                ViewBag.Title = "Snacks";
            else if (id == 11)
                ViewBag.Title = "Cigarros";

            ViewBag.Tipo = id;

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
