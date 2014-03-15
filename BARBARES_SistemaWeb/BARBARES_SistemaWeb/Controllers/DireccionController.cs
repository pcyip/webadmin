using BARBARES_SistemaWeb.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BARBARES_SistemaWeb.Controllers
{
    public class DireccionController : Controller
    {
        //
        // GET: /Direccion/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult selectAll_Departamento() 
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            byte[] data;
            Stream newStream;
            

            //Select Departamento
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Departamento);
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

        public ActionResult selectByDepartamento_Provincia(int id)
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            byte[] data;
            Stream newStream;

            //Select Departamento
            data = encoding.GetBytes(JsonSerializer.selectByDepartamento_Provincia(id));

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectByDepartamento_Provincia);
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

        public ActionResult selectByProvincia_Distrito(int id)
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            byte[] data;
            Stream newStream;

            //Select Departamento
            data = encoding.GetBytes(JsonSerializer.selectByProvincia_Distrito(id));

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectByProvincia_Distrito);
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

        //
        // GET: /Direccion/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Direccion/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Direccion/Create

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
        // GET: /Direccion/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Direccion/Edit/5

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
        // GET: /Direccion/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Direccion/Delete/5

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
