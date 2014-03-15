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
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            //Select Pedidos
            List<Select.Pedido> p = new List<Select.Pedido>();

            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.List_Pedido);
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
                p = (List<Select.Pedido>)js.Deserialize(objText, typeof(List<Select.Pedido>));
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

            //Select Medio Pago
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_MedioPago);
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
                ViewBag.MedioPago = (List<MedioPago>)js.Deserialize(objText, typeof(List<MedioPago>));
            }

            //Select Estado Pedido
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_EstadoPedido);
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
                ViewBag.EstadoPedido = (List<EstadoPedido>)js.Deserialize(objText, typeof(List<EstadoPedido>));
            }

            //Select Motivo Cancelación
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_MotivoCancelacion);
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
                ViewBag.MotivoCancelacion = (List<MotivoCancelacion>)js.Deserialize(objText, typeof(List<MotivoCancelacion>));
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

            return View(p);
        }

        [HttpPost]
        public ActionResult List(string nombre, string appat, int tipoDoc, int estado, int motivo,
            int medio, int tienda, string desde, string hasta, int nroDoc = 0)
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            Search.Pedido ped = new Search.Pedido()
            {
                Nombres = nombre,
                ApellidoPaterno = appat,
                IdMotivoCancelacion = motivo,
                IdTipoDocumento = tipoDoc,
                IdMedioPago = medio,
                NumeroDocumento = nroDoc,
                IdEstadoPedido = estado,
                IdTienda = tienda,
                Desde = DateTime.Parse(desde),
                Hasta = DateTime.Parse(hasta)
            };

            //Select Pedidos
            List<Select.Pedido> p = new List<Select.Pedido>();

            data = encoding.GetBytes(JsonSerializer.search_Pedido(ped));

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Search_Pedido);
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
                p = (List<Select.Pedido>)js.Deserialize(objText, typeof(List<Select.Pedido>));
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

            //Select Medio Pago
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_MedioPago);
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
                ViewBag.MedioPago = (List<MedioPago>)js.Deserialize(objText, typeof(List<MedioPago>));
            }

            //Select Estado Pedido
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_EstadoPedido);
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
                ViewBag.EstadoPedido = (List<EstadoPedido>)js.Deserialize(objText, typeof(List<EstadoPedido>));
            }

            //Select Motivo Cancelación
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_MotivoCancelacion);
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
                ViewBag.MotivoCancelacion = (List<MotivoCancelacion>)js.Deserialize(objText, typeof(List<MotivoCancelacion>));
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

            return View(p);
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
