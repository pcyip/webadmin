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
    public class TiendaController : Controller
    {
        //
        // GET: /Tienda/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<Select.Tienda> t = new List<Select.Tienda>();

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes("");

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(Constantes.List_Tienda);
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
                t = (List<Select.Tienda>)js.Deserialize(objText, typeof(List<Select.Tienda>));
            }

            return View(t);
        }

        [HttpPost]
        public ActionResult List(string nombre, string desde, string hasta,
            int departamento = 0, int provincia = 0, int distrito = 0, bool estado = false)
        {
            List<Select.Tienda> t = new List<Select.Tienda>();

            Search.Tienda ti = new Search.Tienda()
            {
                Nombre = nombre,
                IdDepartamento = departamento,
                IdProvincia = provincia,
                IdDistrito = distrito,
                Activo = estado,
                Desde = DateTime.Parse(desde),
                Hasta = DateTime.Parse(hasta)
            };

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(JsonSerializer.search_Tienda(ti));

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Search_Tienda);
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
                t = (List<Select.Tienda>)js.Deserialize(objText, typeof(List<Select.Tienda>));
            }

            return View(t);
        }

        //
        // GET: /Tienda/Details/5

        public ActionResult Details()
        {
            return View();
        }

        //
        // GET: /Tienda/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tienda/Create

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
        // GET: /Tienda/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Tienda/Edit/5

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
        // GET: /Tienda/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Tienda/Delete/5

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
