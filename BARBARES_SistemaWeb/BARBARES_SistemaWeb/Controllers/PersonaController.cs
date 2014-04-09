using BARBARES_SistemaWeb.Models;
using BARBARES_SistemaWeb.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BARBARES_SistemaWeb.Controllers
{
    public class PersonaController : Controller
    {
        //
        // GET: /Persona/

        public ActionResult Index()
        {
            ViewBag.Cliente = 1;
            ViewBag.Empleado = 2;
            return View();
        }

        public ActionResult List_Parametros()
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

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

            //Select Tipo Persona
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectAll_TipoPersona);
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
                ViewBag.TipoPersona = (List<TipoPersona>)js.Deserialize(objText, typeof(List<TipoPersona>));
            }

            ViewBag.Doc = 1;
            ViewBag.Tipo = 2;
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

            //Select Personas por tipo
            List<Select.Persona> p = new List<Select.Persona>();

            data = encoding.GetBytes(JsonSerializer.selectByTipo_Persona(idTipo));

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.SelectByTipo_Persona);
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
                p = (List<Select.Persona>)js.Deserialize(objText, typeof(List<Select.Persona>));
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

            Debug.WriteLine(p.Count, "cant");

            if (idTipo == 1)
                ViewBag.Title = "Clientes";
            else if (idTipo == 2)
                ViewBag.Title = "Empleados";

            ViewBag.Tipo = idTipo;

            return View(p);
        }

        [HttpPost]
        public ActionResult List(string nombre, string appat, string apmat, int tipoDoc,
            string desde, string hasta, int idTipo, int nroDoc = 0, bool estado = false)
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            //Select Personas por tipo
            List<Select.Persona> p = new List<Select.Persona>();

            Search.Persona per = new Search.Persona()
            {
                Nombres = nombre,
                ApellidoPaterno = appat,
                ApellidoMaterno = apmat,
                IdTipoDocumento = tipoDoc,
                IdTipoPersona = idTipo,
                NumeroDocumento = nroDoc,
                Activo = estado,
                Desde = DateTime.Parse(desde),
                Hasta = DateTime.Parse(hasta)
            };

            data = encoding.GetBytes(JsonSerializer.search_Persona(per));

            Debug.WriteLine(JsonSerializer.search_Persona(per));

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Search_Persona);
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
                p = (List<Select.Persona>)js.Deserialize(objText, typeof(List<Select.Persona>));
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

            if (idTipo == 1)
                ViewBag.Title = "Clientes";
            else if (idTipo == 2)
                ViewBag.Title = "Empleados";

            ViewBag.Tipo = idTipo;

            return View(p);
        }

        //
        // GET: /Persona/Details/5

        public ActionResult Details_Parametro(int id)
        {
            if (id == 1)
            {
                ViewBag.Header = "Tipo Documento";
                ViewBag.Nombre = "DNI";
                ViewBag.Desc = "Documento Nacional de Identidad";
            }
            else if (id == 2)
            {
                ViewBag.Header = "Tipo Persona";
                ViewBag.Nombre = "CLI";
                ViewBag.Desc = "Cliente";
            }

            ViewBag.Tipo = id;

            return View();
        }

        public ActionResult Details(int idTipo, int id)
        {
            Debug.WriteLine(id, "id");
            Debug.WriteLine(idTipo, "tipo");

            if (idTipo == 1)
                ViewBag.Title = "Clientes";
            else if (idTipo == 2)
                ViewBag.Title = "Empleados";

            ViewBag.Tipo = id;

            return View();
        }

        //
        // GET: /Persona/Create

        public ActionResult Create(int id)
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

            //Select Tipo Documento
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Combo_TipoDocumento);
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

            //Select Tipo Calle
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Combo_TipoCalle);
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

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Combo_TipoUrb);
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

            //Select Usuario
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Combo_Usuario);
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
                ViewBag.Usuario = (List<Usuario>)js.Deserialize(objText, typeof(List<Usuario>));
            }

            if (id == 1)
                return RedirectToAction("Index", "Persona");
            else if (id == 2)
                ViewBag.Title = "Empleados";

            ViewBag.Tipo = id;

            return View();
        }

        //
        // POST: /Persona/Create

        [HttpPost]
        public ActionResult Create(string nombre, string appat, string apmat, string email, int tipoDoc,
            int nroDoc, string fechanac, int tipoCalle, string calle, string interior, int tipoUrb, int idTipo,
            string urb, string mzlt, string referencia, char sexo, int usuario, int departamento = 0, int provincia = 0,
            int distrito = 0, int telefono = 0, int celular = 0, int numero = 0, bool estado = false)
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

                Persona p = new Persona()
                {
                    Nombres = nombre,
                    ApellidoPaterno = appat,
                    ApellidoMaterno = apmat,
                    Telefono = telefono,
                    Celular = celular,
                    Email = email,
                    IdTipoDocumento = tipoDoc,
                    NumeroDocumento = nroDoc,
                    FechaNacimiento = DateTime.Parse(fechanac),
                    Sexo = sexo,
                    IdTipoPersona = idTipo,
                    IdDireccion = idDireccion,
                    Activo = estado,
                    IdUsuario = usuario,
                    IdPersona = 0
                };

                data = encoding.GetBytes(JsonSerializer.add_Persona(p));

                webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Add_Persona);
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
                    return RedirectToAction("Index");
                }
            }

            //Select Tipo Documento
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Combo_TipoDocumento);
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

            //Select Tipo Calle
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Combo_TipoCalle);
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

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Combo_TipoUrb);
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

            //Select Usuario
            data = encoding.GetBytes("");

            webrequest = (HttpWebRequest)WebRequest.Create(Constantes.Combo_Usuario);
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
                ViewBag.Usuario = (List<Usuario>)js.Deserialize(objText, typeof(List<Usuario>));
            }

            ViewBag.Title = "Empleados";
            ViewBag.Tipo = 2;
            ViewBag.Mensaje = u.Mensaje;
            return View();
        }

        public ActionResult Create_Parametro(int id)
        {
            if (id == 1)
                ViewBag.Title = "Tipo Documento";
            else if (id == 2)
                return RedirectToAction("Index", "Persona");

            ViewBag.Tipo = id;

            return View();
        }


        //
        // GET: /Persona/Edit/5


        public ActionResult Edit(int id)
        {
            //Declaraciones Generales para los request

            ASCIIEncoding encoding = new ASCIIEncoding();
            HttpWebRequest webrequest;
            HttpWebResponse webresponse;
            byte[] data;
            Stream newStream;

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

            if (id == 1)
                return RedirectToAction("Index", "Persona");
            else if (id == 2)
                ViewBag.Title = "Empleados";

            return View();
        }



        public ActionResult Edit_Parametro(int id)
        {
            if (id == 1)
                ViewBag.Title = "Tipo Documento";
            else if (id == 2)
                return RedirectToAction("Index", "Persona");

            ViewBag.Tipo = id;

            return View();
        }

        //
        // POST: /Persona/Edit/5

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
        // GET: /Persona/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Persona/Delete/5

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
