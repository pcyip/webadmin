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
    public class VehiculoController : Controller
    {
        //
        // GET: /Vehiculo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult selectAll_Marca()
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            byte[] data;
            Stream newStream;


            //Select Departamento
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Marca);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            HttpWebResponse webresponse;
            webresponse = (HttpWebResponse)webrequest.GetResponse();
            List<Select.Combo> p = new List<Select.Combo>();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                p = (List<Select.Combo>)js.Deserialize(objText, typeof(List<Select.Combo>));
            }

            return Json(p);
        }

        public ActionResult selectByMarca_Modelo(int id)
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            byte[] data;
            Stream newStream;


            //Select Departamento
            data = encoding.GetBytes(JsonSerializer.selectByMarca_Modelo(id));

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectByMarca_Modelo);
            webrequest.Method = Constantes.PostMethod;
            webrequest.ContentType = Constantes.ContentType;
            webrequest.ContentLength = data.Length;

            newStream = webrequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            HttpWebResponse webresponse;
            webresponse = (HttpWebResponse)webrequest.GetResponse();
            List<Select.Combo> p = new List<Select.Combo>();

            using (var reader = new StreamReader(webresponse.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var objText = reader.ReadToEnd();
                p = (List<Select.Combo>)js.Deserialize(objText, typeof(List<Select.Combo>));
            }

            return Json(p);
        }

        public ActionResult List()
        {
            List<Select.Vehiculo> v = new List<Select.Vehiculo>();

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes("");

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(Constantes.List_Vehiculo);
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
                v = (List<Select.Vehiculo>)js.Deserialize(objText, typeof(List<Select.Vehiculo>));
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


            return View(v);
        }

        [HttpPost]
        public ActionResult List(string placa, string desc, string desde, string hasta, int tienda,
            int marca = 0, int modelo = 0, bool estado = false)
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            Search.Vehiculo veh = new Search.Vehiculo()
            {
                Placa = placa,
                Descripcion = desc,                
                Marca = marca,
                Modelo = modelo,
                Activo = estado,
                IdTienda = tienda,
                Desde = DateTime.Parse(desde),
                Hasta = DateTime.Parse(hasta)
            };

            //Buscar Vehiculos
            List<Select.Vehiculo> v = new List<Select.Vehiculo>();

            data = encoding.GetBytes(JsonSerializer.search_Vehiculo(veh));

            Debug.WriteLine(JsonSerializer.search_Vehiculo(veh));

            Debug.WriteLine(DateTime.Parse(desde));
            Debug.WriteLine(DateTime.Parse(hasta));

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Search_Vehiculo);
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
                v = (List<Select.Vehiculo>)js.Deserialize(objText, typeof(List<Select.Vehiculo>));
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


            return View(v);
        }

        //
        // GET: /Vehiculo/Details/5

        public ActionResult Details()
        {
            return View();
        }

        //
        // GET: /Vehiculo/Create

        public ActionResult Create()
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

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
        // POST: /Vehiculo/Create

        [HttpPost]
        public ActionResult Create(string placa, string desc, int capacidad, int marca, int modelo,
            int tienda, bool estado = false)
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;
            ResponseBD u = new ResponseBD();

            Vehiculo p = new Vehiculo()
            {
                IdVehiculo = 0,
                Placa = placa,
                Descripcion = desc,
                Capacidad = capacidad,
                Marca = marca,
                Modelo = modelo,
                Activo = estado,
                IdTienda = tienda,
                FechaCreacion = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                UltimaModificacion = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture),
            };

            data = encoding.GetBytes(JsonSerializer.add_Vehiculo(p));

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Add_Vehiculo);
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
                return RedirectToAction("Index","Almacen");
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
        // GET: /Vehiculo/Edit/5

        public ActionResult Edit()
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

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
