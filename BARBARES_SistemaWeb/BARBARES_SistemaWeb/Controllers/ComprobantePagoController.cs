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
    public class ComprobantePagoController : Controller
    {
        //
        // GET: /ComprobantePago/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;
            
            //Selet Comprobante Pago
            List<Select.ComprobantePago> p = new List<Select.ComprobantePago>();

            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.List_Comprobante);
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
                p = (List<Select.ComprobantePago>)js.Deserialize(objText, typeof(List<Select.ComprobantePago>));
            }

            //Select Tipo Documento
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_TipoDocumento);
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
                ViewBag.TipoDocumento = (List<TipoDocumento>)js.Deserialize(objText, typeof(List<TipoDocumento>));
            }

            //Select Tipo Comprobante
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_TipoComprobante);
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
                ViewBag.TipoComprobante = (List<TipoComprobante>)js.Deserialize(objText, typeof(List<TipoComprobante>));
            }

            return View(p);
        }

        [HttpPost]
        public ActionResult List(string nombre, string appat, int tipoDoc, int tipo,
            string desde, string hasta, int nroDoc = 0, int nroCom = 0)
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            Search.ComprobantePago com = new Search.ComprobantePago()
            {
                Nombres = nombre,
                ApellidoPaterno = appat,
                IdTipoComprobante = tipo,
                IdTipoDocumento = tipoDoc,
                Numerocomprobante = nroCom,
                NumeroDocumento = nroDoc,
                Desde = DateTime.Parse(desde),
                Hasta = DateTime.Parse(hasta)
            };

            //Selet Comprobante Pago
            List<Select.ComprobantePago> p = new List<Select.ComprobantePago>();

            data = encoding.GetBytes(JsonSerializer.search_ComprobantePago(com));

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Search_Comprobante);
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
                p = (List<Select.ComprobantePago>)js.Deserialize(objText, typeof(List<Select.ComprobantePago>));
            }

            //Select Tipo Documento
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_TipoDocumento);
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
                ViewBag.TipoDocumento = (List<TipoDocumento>)js.Deserialize(objText, typeof(List<TipoDocumento>));
            }

            //Select Tipo Comprobante
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_TipoComprobante);
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
                ViewBag.TipoComprobante = (List<TipoComprobante>)js.Deserialize(objText, typeof(List<TipoComprobante>));
            }

            return View(p);
        }

        //
        // GET: /ComprobantePago/Details/5

        public ActionResult Details()
        {
            return View();
        }

        //
        // GET: /ComprobantePago/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ComprobantePago/Create

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
        // GET: /ComprobantePago/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ComprobantePago/Edit/5

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
        // GET: /ComprobantePago/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ComprobantePago/Delete/5

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
