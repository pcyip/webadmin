﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BARBARES_SistemaWeb.Controllers
{
    public class PerfilController : Controller
    {
        //
        // GET: /Perfil/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        //
        // GET: /Perfil/Details/5

        public ActionResult Details()
        {
            return View();
        }

        //
        // GET: /Perfil/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Perfil/Create

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
        // GET: /Perfil/Edit/5

        public ActionResult Edit()
        {
            return View();
        }

        //
        // POST: /Perfil/Edit/5

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
        // GET: /Perfil/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Perfil/Delete/5

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
