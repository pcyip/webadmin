using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BARBARES_SistemaWeb.Controllers
{
    public class PersonaController : Controller
    {
        //
        // GET: /Persona/

        public ActionResult Index()
        {
            ViewBag.Cliente = 1;
            ViewBag.Empleado = 2;
            return View();
        }

        public ActionResult List_Parametros()
        {
            ViewBag.Doc = 1;
            ViewBag.Tipo = 2;
            return View();
        }

        public ActionResult List(int id)
        {
            if (id == 1)
                ViewBag.Title = "Clientes";
            else if (id == 2)
                ViewBag.Title = "Empleados";

            ViewBag.Tipo = id;

            return View();
        }

        //
        // GET: /Persona/Details/5

        public ActionResult Details_Parametro(int id)
        {
            if (id == 1)
            {
                ViewBag.Header = "Tipo Documento";
                ViewBag.Nombre = "DNI";
                ViewBag.Desc = "Documento Nacional de Identidad";
            }
            else if (id == 2)
            {
                ViewBag.Header = "Tipo Persona";
                ViewBag.Nombre = "CLI";
                ViewBag.Desc = "Cliente";
            }

            ViewBag.Tipo = id;
        
            return View();
        }

        public ActionResult Details(int id)
        {
            if (id == 1)
                ViewBag.Title = "Clientes";
            else if (id == 2)
                ViewBag.Title = "Empleados";

            ViewBag.Tipo = id;

            return View();
        }

        //
        // GET: /Persona/Create

        public ActionResult Create(int id)
        {
            if (id == 1)
                return RedirectToAction("Index", "Persona");
            else if (id == 2)
                ViewBag.Title = "Empleados";

            ViewBag.Tipo = id;

            return View();
        }

        //
        // POST: /Persona/Create

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

        public ActionResult Create_Parametro(int id)
        {
            if (id == 1)
                ViewBag.Title = "Tipo Documento";
            else if (id == 2)
                return RedirectToAction("Index", "Persona");

            ViewBag.Tipo = id;

            return View();
        }


        //
        // GET: /Persona/Edit/5


        public ActionResult Edit(int id)
        {
            if (id == 1)
                return RedirectToAction("Index", "Persona");
            else if (id == 2)
                ViewBag.Title = "Empleados";
            
            return View();
        }



        public ActionResult Edit_Parametro(int id)
        {
            if (id == 1)
                ViewBag.Title = "Tipo Documento";                
            else if (id == 2)            
                return RedirectToAction("Index", "Persona");

            ViewBag.Tipo = id;

            return View();
        }

        //
        // POST: /Persona/Edit/5

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
        // GET: /Persona/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Persona/Delete/5

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
