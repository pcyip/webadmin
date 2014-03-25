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
    public class PromocionController : Controller
    {
        //
        // GET: /Promocion/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Promocion/Details/5

        public ActionResult Details()
        {
            return View();
        }

        //
        // GET: /Promocion/Create

        public ActionResult Create()
        {
            //Declaro Session para los seleccionados

            List<Producto> p = new List<Producto>();

            Session["selectedProducts"] = p;

            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            //Select Productos por tipo

            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Producto);
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
                ViewBag.Productos = (List<Producto>)js.Deserialize(objText, typeof(List<Producto>));
            }

            return View(p);
        }

        //
        // POST: /Promocion/Create

        [HttpPost]
        public ActionResult Create(string nombrePromocion, string desc, string inicio, string fin,
            string obs,int[] cantidad, int[] selectedProducts, int precio = 0, bool estadoPromocion = false, bool semana = false)
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;
            ResponseBD u = new ResponseBD();            

            //Select Producto
            List<Producto> sp = new List<Producto>();

            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_Producto);
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
                sp = (List<Producto>)js.Deserialize(objText, typeof(List<Producto>));
            }

            //Obtener productos seleccionados

            List<Producto> p = (List<Producto>)Session["selectedProducts"];

            if (selectedProducts == null)
            {
                //Guardar promoción

                Promocion promo = new Promocion()
                {
                    IdPromocion = 0,
                    Nombre = nombrePromocion,
                    Descripcion = desc,
                    PrecioUnitario = precio,
                    //Observaciones = obs,
                    Semana = semana,
                    //Activo = estado,
                    FechaInicio = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    FechaFin= DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Imagen = "Imagen"
                };

                data = encoding.GetBytes(JsonSerializer.add_Promocion(promo));

                webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Add_Promocion);
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

                    //Agregar Productos seleccionados

                    int i = 0;

                    foreach (var prod in p)
                    {
                        DetallePromocion det = new DetallePromocion()
                        {
                            IdPromocion = id,
                            IdDetallePromocion = i + 1,
                            Cantidad = cantidad[i], 
                            PrecioUnitario = prod.PrecioUnitario,
                            IdProducto = prod.IdProducto
                        };

                        data = encoding.GetBytes(JsonSerializer.add_DetallePromocion(det));

                        webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Add_DetallePromocion);
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

                        if (u.Flujo.Equals("ERROR"))
                        {
                            ViewBag.Mensaje = u.Mensaje;
                            ViewBag.Productos = sp;
                            return View(p);
                        }

                        i++;
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mensaje = u.Mensaje;
                    ViewBag.Productos = sp;
                    return View(p);
                }                
            }
                       
            foreach (var item in selectedProducts)
            {
                Producto prd = new Producto();

                data = encoding.GetBytes(JsonSerializer.selectById_Producto(item));

                webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectById_Producto);
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
                    prd = (Producto)js.Deserialize(objText, typeof(Producto));
                }

                p.Add(prd);

            }

            foreach (var i in p)
            {
                sp.RemoveAll(s => s.IdProducto == i.IdProducto);
            }

            ViewBag.Productos = sp;

            Session["selectedProducts"] = p;

            return View(p);
        }

        //
        // GET: /Promocion/Edit/5

        public ActionResult Edit()
        {
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
