using BARBARES_SistemaWeb.Models;
using BARBARES_SistemaWeb.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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

        public ActionResult List(int idTipo)
        {

            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            //Select Productos por tipo
            List<Producto> p = new List<Producto>();

            data = encoding.GetBytes(JsonSerializer.selectByTipo_Producto(idTipo));

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectByTipo_Producto);
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
                p = (List<Producto>)js.Deserialize(objText, typeof(List<Producto>));
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
            

            if (idTipo == 1)
                ViewBag.Title = "Cerveza";
            else if (idTipo == 2)
                ViewBag.Title = "Vino";
            else if (idTipo == 3)
                ViewBag.Title = "Whisky";
            else if (idTipo == 4)
                ViewBag.Title = "Vodka";
            else if (idTipo == 5)
                ViewBag.Title = "Ron";
            else if (idTipo == 6)
                ViewBag.Title = "Tequila";
            else if (idTipo == 7)
                ViewBag.Title = "Pisco";
            else if (idTipo == 8)
                ViewBag.Title = "Licores";
            else if (idTipo == 9)
                ViewBag.Title = "Bebidas";
            else if (idTipo == 10)
                ViewBag.Title = "Snacks";
            else if (idTipo == 11)
                ViewBag.Title = "Cigarros";

            ViewBag.Tipo = idTipo;

            return View(p);
        }

        [HttpPost]
        public ActionResult List(string nombre, int unidad, string desde, string hasta, int idTipo, int presentacion = 0,
            int min = 0, int max = 0, bool estado = false)
        {

            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            //Select Productos por tipo
            List<Producto> p = new List<Producto>();

            Search.Producto prd = new Search.Producto()
            {
                Nombre = nombre,
                IdTipoProducto = idTipo,
                IdUnidadProducto = unidad,
                Presentacion = presentacion,
                Minimo = min,
                Maximo = max,
                Activo = estado,
                Desde = DateTime.Parse(desde),
                Hasta = DateTime.Parse(hasta)
            };

            data = encoding.GetBytes(JsonSerializer.search_Producto(prd));

            Debug.WriteLine(JsonSerializer.search_Producto(prd));

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Search_Producto);
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
                p = (List<Producto>)js.Deserialize(objText, typeof(List<Producto>));
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


            if (idTipo == 1)
                ViewBag.Title = "Cerveza";
            else if (idTipo == 2)
                ViewBag.Title = "Vino";
            else if (idTipo == 3)
                ViewBag.Title = "Whisky";
            else if (idTipo == 4)
                ViewBag.Title = "Vodka";
            else if (idTipo == 5)
                ViewBag.Title = "Ron";
            else if (idTipo == 6)
                ViewBag.Title = "Tequila";
            else if (idTipo == 7)
                ViewBag.Title = "Pisco";
            else if (idTipo == 8)
                ViewBag.Title = "Licores";
            else if (idTipo == 9)
                ViewBag.Title = "Bebidas";
            else if (idTipo == 10)
                ViewBag.Title = "Snacks";
            else if (idTipo == 11)
                ViewBag.Title = "Cigarros";

            ViewBag.Tipo = idTipo;

            return View(p);
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
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

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
        public ActionResult Create(string nombre, string desc, int unidad, int presentacion, double precio, 
            int tipo, string obs, bool perecible = false, bool estado = false)
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;
            ResponseBD u = new ResponseBD();

            Producto p = new Producto()
            {
                IdProducto = 0,
                Nombre = nombre,
                Descripcion = desc,
                IdUnidadProducto = unidad,
                Presentacion = presentacion,
                PrecioUnitario = precio,
                Observaciones = obs,
                Perecible = perecible,
                Activo = estado,
                IdTipoProducto = tipo,
                FechaCreacion = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")),
                Imagen = "Imagen"
            };

            data = encoding.GetBytes(JsonSerializer.add_Producto(p));

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Add_Producto);
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
                u = (ResponseBD)js.Deserialize(objText, typeof(ResponseBD));
            }

            if (u.Flujo.Equals(Constantes.OK))
            {
                int id = Int32.Parse(u.Mensaje);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Mensaje = u.Mensaje;
                return View();
            }
           
        }

        //
        // GET: /Promocion/Edit/5

        public ActionResult Edit(int id)
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

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
