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
            List<Select.Almacen> a = new List<Select.Almacen>();

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes("");

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(Constantes.List_Almacen);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            Stream newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                a = (List<Select.Almacen>)js.Deserialize(objText, typeof(List<Select.Almacen>));
            }

            //Select Tienda
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Tienda);
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
                ViewBag.Tienda = (List<Tienda>)js.Deserialize(objText, typeof(List<Tienda>));
            }

            return View(a);
        }

        [HttpPost]
        public ActionResult List(string desc, string desde, int tienda, string hasta,
            int departamento = 0, int provincia = 0, int distrito = 0, bool estado = false)
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            Search.Almacen alm = new Search.Almacen()
            {
                Descripcion = desc,
                IdDepartamento = departamento,
                IdProvincia = provincia,
                IdDistrito = distrito,
                Activo = estado,
                IdTienda = tienda,
                Desde = DateTime.Parse(desde),
                Hasta = DateTime.Parse(hasta)
            };

            //Busca almacenes
            List<Select.Almacen> a = new List<Select.Almacen>();

            data = encoding.GetBytes(JsonSerializer.search_Almacen(alm));

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Search_Almacen);
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
                a = (List<Select.Almacen>)js.Deserialize(objText, typeof(List<Select.Almacen>));
            }

            //Select Tienda
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Tienda);
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
                ViewBag.Tienda = (List<Tienda>)js.Deserialize(objText, typeof(List<Tienda>));
            }

            return View(a);
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
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            //Select Tipo Calle
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_TipoCalle);
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
                ViewBag.TipoCalle = (List<TipoCalle>)js.Deserialize(objText, typeof(List<TipoCalle>));
            }

            //Select Tipo Urbanización
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_TipoUrb);
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
                ViewBag.TipoUrb = (List<TipoUrb>)js.Deserialize(objText, typeof(List<TipoUrb>));
            }

            //Select Tienda
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Tienda);
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
                ViewBag.Tienda = (List<Tienda>)js.Deserialize(objText, typeof(List<Tienda>));
            }

            return View();
        }

        //
        // POST: /Almacen/Create

        [HttpPost]
        public ActionResult Create(string desc, int capacidad, int area, string email, int tipoCalle,
            string calle, string interior, int tipoUrb, string urb, string mzlt, string referencia, int tienda,
            int departamento = 0, int provincia = 0, int distrito = 0, int numero = 0, bool estado = false)
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;
            ResponseBD u = new ResponseBD();

            Direccion d = new Direccion()
            {
                IdTipoCalle = tipoCalle,
                Calle = calle,
                Interior = interior,
                Numero = numero,
                IdTipoUrb = tipoUrb,
                Urbanizacion = urb,
                Mzlt = mzlt,
                Referencia = referencia,
                IdDepartamento = departamento,
                IdProvincia = provincia,
                IdDistrito = distrito,
                IdDireccion = 0
            };

            data = encoding.GetBytes(JsonSerializer.add_Direccion(d));

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Add_Direccion);
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
                int idDireccion = Int32.Parse(u.Mensaje);

                Almacen p = new Almacen()
                {
                    IdAlmacen = 0,
                    Descripcion = desc,
                    Capacidad = capacidad,
                    Area = area,
                    IdDireccion = idDireccion,
                    Activo = estado,
                    IdTienda = tienda,
                    FechaCreacion = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")),
                    UltimaModificacion = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")),
                };

                data = encoding.GetBytes(JsonSerializer.add_Almacen(p));

                webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Add_Almacen);
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
                    Debug.WriteLine(Int32.Parse(u.Mensaje), "Almacen");
                    return RedirectToAction("Index");
                }

            }
            //Select Tipo Calle
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_TipoCalle);
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
                ViewBag.TipoCalle = (List<TipoCalle>)js.Deserialize(objText, typeof(List<TipoCalle>));
            }

            //Select Tipo Urbanización
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_TipoUrb);
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
                ViewBag.TipoUrb = (List<TipoUrb>)js.Deserialize(objText, typeof(List<TipoUrb>));
            }

            //Select Tienda
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Tienda);
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
                ViewBag.Tienda = (List<Tienda>)js.Deserialize(objText, typeof(List<Tienda>));
            }

            ViewBag.Mensaje = u.Mensaje;
            return View();

        }

        //
        // GET: /Almacen/Edit/5

        public ActionResult Edit()
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            //Select Tipo Calle
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_TipoCalle);
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
                ViewBag.TipoCalle = (List<TipoCalle>)js.Deserialize(objText, typeof(List<TipoCalle>));
            }

            //Select Tipo Urbanización
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_TipoUrb);
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
                ViewBag.TipoUrb = (List<TipoUrb>)js.Deserialize(objText, typeof(List<TipoUrb>));
            }

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
