using BARBARES_SistemaWeb.Models;
using BARBARES_SistemaWeb.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            //Select Promoción de la semana
            List<Select.PromocionSemana> p = new List<Select.PromocionSemana>();

            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Semana_Promocion);
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
                p = (List<Select.PromocionSemana>)js.Deserialize(objText, typeof(List<Select.PromocionSemana>));
            }

            int count = 1;
            string productos = "";
            string descripcion = "";
            string precio = " S/. ";

            foreach (var i in p)
            {
                if (count > 1)
                    productos = productos + " + ";
                productos = productos + i.Cantidad.ToString() + ' ' + i.NombreProducto + ' ' + i.Presentacion.ToString() + ' '
                    + i.Unidad;

                if (count == 1)
                {
                    descripcion = i.Descripcion;
                    precio = precio + i.Precio.ToString();
                }
                
                count ++;
            }

            ViewBag.Productos = productos;
            ViewBag.Descripcion = descripcion;
            ViewBag.Precio = precio;

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
            List<Select.Producto> p = new List<Select.Producto>();

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
                p = (List<Select.Producto>)js.Deserialize(objText, typeof(List<Select.Producto>));
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
            List<Select.Producto> p = new List<Select.Producto>();

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
                p = (List<Select.Producto>)js.Deserialize(objText, typeof(List<Select.Producto>));
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

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Combo_UnidadProducto);
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

            //Select Moneda
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Combo_Moneda);
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
                ViewBag.Moneda = (List<Moneda>)js.Deserialize(objText, typeof(List<Moneda>));
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

        [HttpPost]
        public ActionResult Create(string nombre, string desc, int unidad, int moneda, int presentacion, double precio,
            int tipo, string obs, HttpPostedFileBase file, bool perecible = false, bool estado = false)
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;
            ResponseBD u = new ResponseBD();
            Producto p = new Producto();

            try
            {
                string imagen_url = "";
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/barabares_img"), fileName);
                    file.SaveAs(path);
                    //var request = ControllerContext.RequestContext.HttpContext.Request;
                    string base_url = string.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~"));
                    imagen_url = base_url + Constantes.URL_IMAGENES_BARABARES + fileName;
                }

                p = new Producto()
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
                    IdMoneda = moneda,
                    FechaCreacion = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Imagen = imagen_url
                };

                data = encoding.GetBytes(JsonSerializer.add_Producto(p));

                Debug.WriteLine(JsonSerializer.add_Producto(p));

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
            }
            catch (Exception ex)
            {
                LogBarabares b = new LogBarabares()
                {
                    Accion = Constantes.LOG_CREAR,
                    Servicio = Constantes.Add_Producto,
                    Input = JsonSerializer.add_Producto(p),
                    Descripcion = ex.ToString(),
                    Clase = (p == null) ? "null" : p.GetType().Name,
                    Aplicacion = Constantes.ENTORNO_SISTEMA,
                    Estado = Constantes.ERROR,
                    Ip = "",
                    IdUsuario = 1 //TODO: obtener usuario de la sesión

                };

                data = encoding.GetBytes(JsonSerializer.add_LogBarabares(b));

                webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Add_LogBarabares);
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

                return RedirectToAction("Index");
            }

            //Select Unidad Producto
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Combo_UnidadProducto);
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

            //Select Moneda
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Combo_Moneda);
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
                ViewBag.Moneda = (List<Moneda>)js.Deserialize(objText, typeof(List<Moneda>));
            }

            if (tipo == 1)
                ViewBag.Title = "Cerveza";
            else if (tipo == 2)
                ViewBag.Title = "Vino";
            else if (tipo == 3)
                ViewBag.Title = "Whisky";
            else if (tipo == 4)
                ViewBag.Title = "Vodka";
            else if (tipo == 5)
                ViewBag.Title = "Ron";
            else if (tipo == 6)
                ViewBag.Title = "Tequila";
            else if (tipo == 7)
                ViewBag.Title = "Pisco";
            else if (tipo == 8)
                ViewBag.Title = "Licores";
            else if (tipo == 9)
                ViewBag.Title = "Bebidas";
            else if (tipo == 10)
                ViewBag.Title = "Snacks";
            else if (tipo == 11)
                ViewBag.Title = "Cigarros";

            ViewBag.Tipo = tipo;

            ViewBag.Mensaje = u.Mensaje;
            return View();

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
