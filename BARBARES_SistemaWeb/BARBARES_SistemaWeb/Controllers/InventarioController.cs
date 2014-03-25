using BARBARES_SistemaWeb.Models;
using BARBARES_SistemaWeb.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BARBARES_SistemaWeb.Controllers
{
    public class InventarioController : Controller
    {
        //
        // GET: /Inventario/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List_Vehiculo()
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            List<Select.InventarioVehiculo> p = new List<Select.InventarioVehiculo>();

            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.List_InventarioVehiculo);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                p = (List<Select.InventarioVehiculo>)js.Deserialize(objText, typeof(List<Select.InventarioVehiculo>));
            }

            //Select Unidad Producto
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_UnidadProducto);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                ViewBag.UnidadProducto = (List<UnidadProducto>)js.Deserialize(objText, typeof(List<UnidadProducto>));
            }

            //Select Vehiculos
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Vehiculo);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                ViewBag.Vehiculo = (List<Vehiculo>)js.Deserialize(objText, typeof(List<Vehiculo>));
            }


            return View(p);
        }

        public ActionResult List_Almacen()
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            List<Select.InventarioAlmacen> p = new List<Select.InventarioAlmacen>();

            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.List_InventarioAlmacen);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                p = (List<Select.InventarioAlmacen>)js.Deserialize(objText, typeof(List<Select.InventarioAlmacen>));
            }

            //Select Unidad Producto
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_UnidadProducto);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                ViewBag.UnidadProducto = (List<UnidadProducto>)js.Deserialize(objText, typeof(List<UnidadProducto>));
            }

            //almacenes

            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Almacen);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                ViewBag.Almacen = (List<Almacen>)js.Deserialize(objText, typeof(List<Almacen>));
            }

            return View(p);
        }

        //
        // GET: /Inventario/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Inventario/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Inventario/Create

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
        // GET: /Inventario/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Inventario/Edit/5

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
        // GET: /Inventario/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Inventario/Delete/5

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
