using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BARBARES_SistemaWeb.Controllers
{
    public class PedidoController : Controller
    {
        //
        // GET: /Pedido/

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
            ViewBag.Estado = 1;
            ViewBag.Motivo = 2;
            ViewBag.Medio = 3;
            ViewBag.TipoTarjeta = 4;
            ViewBag.Moneda = 5;
            ViewBag.TipoComprobante = 6;

            return View();
        }

        public ActionResult Details_Parametro(int id)
        {
            ViewBag.Label = "Nombre";

            if (id == 1)
            {
                ViewBag.Header = "Estado Pedido";
                ViewBag.Nombre = "Enviado";
                ViewBag.Desc = "Pedido enviado";
            }
            else if (id == 2)
            {
                ViewBag.Header = "Motivo Cancelación";
                ViewBag.Nombre = "Nunca llegó";
                ViewBag.Desc = "Unidad";
            }
            else if (id == 3)
            {
                ViewBag.Header = "Medio Pago";
                ViewBag.Nombre = "Débito";
                ViewBag.Desc = "Pago débito";
            }
            else if (id == 4)
            {
                ViewBag.Header = "Tipo Tarjeta";
                ViewBag.Nombre = "Visa";
                ViewBag.Desc = "Visa";
            }

            else if (id == 5)
            {
                ViewBag.Label = "Símbolo";
                ViewBag.Header = "Moneda";
                ViewBag.Nombre = "S/.";
                ViewBag.Desc = "Nuevos Soles";
            }
            else if (id == 6)
            {
                ViewBag.Header = "Tipo Comprobante";
                ViewBag.Nombre = "Boleta";
                ViewBag.Desc = "Boleta de Ventas";
            }

            ViewBag.Tipo = id;

            return View();
        }

        public ActionResult Edit_Parametro(int id)
        {
            ViewBag.Label = "Nombre";

            if (id == 1)
            {
                ViewBag.Header = "Estado Pedido";
                ViewBag.Nombre = "Enviado";
                ViewBag.Desc = "Pedido enviado";
            }
            else if (id == 2)
            {
                ViewBag.Header = "Motivo Cancelación";
                ViewBag.Nombre = "Nunca llegó";
                ViewBag.Desc = "Unidad";
            }
            else if (id == 3)
            {
                ViewBag.Header = "Medio Pago";
                ViewBag.Nombre = "Débito";
                ViewBag.Desc = "Pago débito";
            }
            else if (id == 4)
            {
                ViewBag.Header = "Tipo Tarjeta";
                ViewBag.Nombre = "Visa";
                ViewBag.Desc = "Visa";
            }

            else if (id == 5)
            {
                ViewBag.Label = "Símbolo";
                ViewBag.Header = "Moneda";
                ViewBag.Nombre = "S/.";
                ViewBag.Desc = "Nuevos Soles";
            }
            else if (id == 6)
            {
                ViewBag.Header = "Tipo Comprobante";
                ViewBag.Nombre = "Boleta";
                ViewBag.Desc = "Boleta de Ventas";
            }

            ViewBag.Tipo = id;

            return View();
        }

        public ActionResult Create_Parametro(int id)
        {
            ViewBag.Label = "Nombre";

            if (id == 1)
            {
                ViewBag.Header = "Estado Pedido";
            }
            else if (id == 2)
            {
                ViewBag.Header = "Motivo Cancelación";
            }
            else if (id == 3)
            {
                ViewBag.Header = "Medio Pago";
            }
            else if (id == 4)
            {
                ViewBag.Header = "Tipo Tarjeta";
            }

            else if (id == 5)
            {
                ViewBag.Label = "Símbolo";
                ViewBag.Header = "Moneda";
            }
            else if (id == 6)
            {
                ViewBag.Header = "Tipo Comprobante";
            }

            ViewBag.Tipo = id;

            return View();
        }


        //
        // GET: /Pedido/Details/5

        public ActionResult Details()
        {
            return View();
        }

        //
        // GET: /Pedido/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pedido/Create

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
        // GET: /Pedido/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Pedido/Edit/5

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
        // GET: /Pedido/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Pedido/Delete/5

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
